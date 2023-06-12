using System;
using System.ComponentModel;
using System.Reactive;
using app.Model;
using app.Utils;
using app.Views;
using Avalonia.Controls;
using Avalonia.Controls.Platform;
using Avalonia.Input;
using Mapsui;
using Mapsui.Extensions;
using Mapsui.Projections;
using ReactiveUI;
using Location = app.Model.Location;
using Splat;

namespace app.ViewModels;

public class AttractionCreateViewModel
{
    private readonly Window _parent;

    public AttractionCreateViewModel(Window parent)
    {
        _parent = parent;
        Uvm = new UploadViewModel(_parent);
        Form = Locator.Current.GetService<AttractionCreateFormViewModel>();
        MapVM = Locator.Current.GetService<MapViewModel>();
        Form.LocationChanged += LocationChanged;
        _undoCommand = ReactiveCommand.Create<Unit>(e =>
        {
            if (PreviousAttraction == null)
            {
                var messageBoxStandardWindow = MessageBox.Avalonia.MessageBoxManager
                    .GetMessageBoxStandardWindow("Povratak prethodne verzije", "Niste sačuvali atrakciju kako biste mogli da je vratite");
                messageBoxStandardWindow.Show();
                return;
            }
            // TODO delete current
            CurrentAttraction = PreviousAttraction;
            PreviousAttraction = null;
        });
        
        _saveCommand = ReactiveCommand.Create<Unit>(e =>
        {
            Attraction a = FormAttraction();
            
            // TODO persist
        });
    }
    
    private void LocationChanged(object sender, EventArgs e)
    {
        LocationDTO current = Form.SelectedLocation;
        MapVM.CurrentSphericalMercatorCoordinate = current == null ? null : SphericalMercator.FromLonLat(Double.Parse(current.lon), Double.Parse(current.lat)).ToMPoint();
        MapVM.RefreshPin();
    }

    public MapViewModel MapVM { get; set; }

    public AttractionCreateFormViewModel Form { get; set; }

    public UploadViewModel Uvm { get; set; }
    private Attraction _previousAttraction;
    private Attraction _currentAttraction;

    private ReactiveCommand<Unit, Unit> _undoCommand;
    private ReactiveCommand<Unit, Unit> _saveCommand;


    public Attraction PreviousAttraction
    {
        get => _previousAttraction;
        set => _previousAttraction = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Attraction CurrentAttraction
    {
        get => _currentAttraction;
        set => _currentAttraction = value ?? throw new ArgumentNullException(nameof(value));
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
    
    public KeyGesture SaveGesture { get; } = new KeyGesture(Key.S, KeyModifiers.Control);
    public KeyGesture UndoGesture { get; } = new KeyGesture(Key.Z, KeyModifiers.Control);

    public Attraction FormAttraction()
    {
        Attraction a = new Attraction();
        a.Image = UploadViewModel.ImageToByte(Uvm.ImageToView);
        a.Description = Form.Description;
        a.Title = Form.AttractionName;

        Location location = new Location();
        if (Form.SelectedLocation == null)
            return null;
        location.Latitude = Double.Parse(Form.SelectedLocation.lat);
        location.Longitude= Double.Parse(Form.SelectedLocation.lon);
        a.Location = location;

        return a;
    }
}