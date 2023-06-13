using System;
using System.ComponentModel;
using System.Reactive;
using app.Model;
using app.Services;
using app.Services.Interfaces;
using app.Utils;
using app.Views;
using Avalonia.Controls;
using Avalonia.Input;
using Mapsui;
using Mapsui.Extensions;
using Mapsui.Projections;
using ReactiveUI;
using Location = app.Model.Location;
using Splat;

namespace app.ViewModels;

public class AccomodationCreateViewModel : BaseViewModel
{
    private readonly Window _parent;

    public AccomodationCreateViewModel()
    {
        _parent = MainWindowViewModel.GetMainWindow();
        Form = Locator.Current.GetService<AccomodationCreateFormViewModel>();
        MapVM = Locator.Current.GetService<MapViewModel>();
        Uvm = new UploadViewModel();
        Form.LocationChanged += LocationChanged;

        _undoCommand = ReactiveCommand.Create<Unit>(e =>
        {
            if (PreviousAccomodation == null)
            {
                var messageBoxStandardWindow = MessageBox.Avalonia.MessageBoxManager
                    .GetMessageBoxStandardWindow("Povratak prethodne verzije", "Niste sačuvali servis kako biste mogli da ga vratite");
                messageBoxStandardWindow.Show();
                return;
            }
            Locator.Current.GetService<IServiceService>().Delete(CurrentAccomodation);
            CurrentAccomodation = PreviousAccomodation;
            PreviousAccomodation = null;
        });
        
        _saveCommand = ReactiveCommand.Create<Unit>(e =>
        {
           Service s = FormAccomodation();
           s = Locator.Current.GetService<IServiceService>().Create(s);
           PreviousAccomodation = CurrentAccomodation;
           CurrentAccomodation = s;
        });
    }

    private Service FormAccomodation()
    {
        Service s = new Service();
        s.Ishotel = true;
        s.Description = Form.Description;
        
        if (Form.SelectedLocation == null)
            return null;
        Location location = new Location(Double.Parse(Form.SelectedLocation.lat), Double.Parse(Form.SelectedLocation.lon));
        s.Location = location;

        s.Image = UploadViewModel.ImageToByte(Uvm.ImageToView);
        s.Title = Form.Title;
        
        return s;
    }

    private void LocationChanged(object sender, EventArgs e)
    {
        LocationDTO current = Form.SelectedLocation;
        MapVM.CurrentSphericalMercatorCoordinate = current == null ? null : SphericalMercator.FromLonLat(Double.Parse(current.lon), Double.Parse(current.lat)).ToMPoint();
        MapVM.RefreshPin();
    }

    public MapViewModel MapVM { get; set; }

    public AccomodationCreateFormViewModel Form { get; set; }

    public UploadViewModel Uvm { get; set; }
    
    
    
    private Service _previousAccomodation;
    private Service _currentAccomodation;

    private ReactiveCommand<Unit, Unit> _undoCommand;
    private ReactiveCommand<Unit, Unit> _saveCommand;
    
    public KeyGesture SaveGesture { get; } = new KeyGesture(Key.S, KeyModifiers.Control);
    public KeyGesture UndoGesture { get; } = new KeyGesture(Key.Z, KeyModifiers.Control);


    public Service PreviousAccomodation
    {
        get => _previousAccomodation;
        set => _previousAccomodation = value;
    }

    public Service CurrentAccomodation
    {
        get => _currentAccomodation;
        set => _currentAccomodation = value;
    }

    public ReactiveCommand<Unit, Unit> UndoCommand
    {
        get => _undoCommand;
        set => _undoCommand = value ?? throw new ArgumentNullException(nameof(value));
    }

    public ReactiveCommand<Unit, Unit> SaveCommand
    {
        get => _saveCommand;
        set => _saveCommand = value ?? throw new ArgumentNullException(nameof(value));
    }
}