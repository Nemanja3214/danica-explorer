using System;
using System.ComponentModel;
using System.Reactive;
using app.Model;
using app.Services.Interfaces;
using app.Utils;
using app.Views;
using Avalonia.Controls;
using Avalonia.Input;
using Mapsui;
using Mapsui.Extensions;
using Mapsui.Projections;
using ReactiveUI;
using ReactiveValidation;
using ReactiveValidation.Extensions;
using Splat;
using Location = app.Model.Location;

namespace app.ViewModels;

public class RestaurantCreateViewModel : BaseViewModel
{
    private readonly Window _parent;
    private ReactiveCommand<Unit, Unit> _undoCommand;
    private ReactiveCommand<Unit, Unit> _saveCommand;

    public RestaurantCreateViewModel()
    {
        _parent = MainWindowViewModel.GetMainWindow();
        Form = Locator.Current.GetService<RestaurantCreateFormViewModel>();
        MapVM = Locator.Current.GetService<MapViewModel>();
        Form.LocationChanged += LocationChanged;
        Uvm = new UploadViewModel();

        _undoCommand = ReactiveCommand.Create<Unit>(e =>
        {
            if (PreviousService == null)
            {
                var messageBoxStandardWindow = MessageBox.Avalonia.MessageBoxManager
                    .GetMessageBoxStandardWindow("Povratak prethodne verzije", "Niste sačuvali restoran kako biste mogli da je vratite");
                messageBoxStandardWindow.Show();
                return;
            }
            Locator.Current.GetService<IServiceService>().Delete(CurrentService);
            CurrentService = PreviousService;
            PreviousService = null;
            Locator.Current.GetService<IServiceService>().Update(CurrentService);
        });
        
        _saveCommand = ReactiveCommand.Create<Unit>(e =>
        {
            Service s = FormRestaurant();

            if (_toUpdate == null)
            {
                s = Locator.Current.GetService<IServiceService>().Create(s);
            }
            else
            {
                s = Locator.Current.GetService<IServiceService>().Update(s);
            }

            PreviousService = CurrentService;
            CurrentService = s;
        });
    }
    
    private void LocationChanged(object sender, EventArgs e)
    {
        LocationDTO current = Form.SelectedLocation;
        MapVM.CurrentSphericalMercatorCoordinate = current == null ? null : SphericalMercator.FromLonLat(Double.Parse(current.lon), Double.Parse(current.lat)).ToMPoint();
        MapVM.RefreshPin();
    }
    
    private Service _previousService;

    public Service PreviousService
    {
        get => _previousService;
        set => _previousService = value ;
    }

    public Service CurrentService
    {
        get => _currentService;
        set => _currentService = value;
    }

    private Service _currentService;
    private Service _toUpdate;

    public ReactiveCommand<Unit, Unit> UndoCommand
    {
        get => _undoCommand;
        set => _undoCommand = value;
    }

    public ReactiveCommand<Unit, Unit> SaveCommand
    {
        get => _saveCommand;
        set => _saveCommand = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public KeyGesture SaveGesture { get; } = new KeyGesture(Key.S, KeyModifiers.Control);
    public KeyGesture UndoGesture { get; } = new KeyGesture(Key.Z, KeyModifiers.Control);

    public MapViewModel MapVM { get; set; }

    public RestaurantCreateFormViewModel Form { get; set; }

    public UploadViewModel Uvm { get; set; }
    
    private Service FormRestaurant()
    {
        Service s = _toUpdate != null ? _toUpdate : new Service();
        s.Ishotel = true;
        s.Description = Form.Description;
        
        if (Form.SelectedLocation == null)
            return null;
        Location location = new Location(Double.Parse(Form.SelectedLocation.lat), Double.Parse(Form.SelectedLocation.lon));
        s.Location = location;

        if (Uvm.ImageToView != null)
        {
            s.Image = UploadViewModel.ImageToByte(Uvm.ImageToView);
        }
        s.Title = Form.RestaurantName;
        s.Ishotel = false;
        
        return s;
    }


}