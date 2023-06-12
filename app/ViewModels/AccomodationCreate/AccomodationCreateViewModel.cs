using System;
using System.ComponentModel;
using app.Utils;
using app.Views;
using Avalonia.Controls;
using Mapsui;
using Mapsui.Extensions;
using Mapsui.Projections;

namespace app.ViewModels;

public class AccomodationCreateViewModel
{
    private readonly Window _parent;

    public AccomodationCreateViewModel(Window parent)
    {
        _parent = parent;
        Uvm = new UploadViewModel(_parent);
        Form = new AccomodationCreateFormViewModel();
        MapVM = new MapViewModel();
        Form.LocationChanged += LocationChanged;
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
}