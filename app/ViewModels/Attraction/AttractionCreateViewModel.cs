using System;
using System.ComponentModel;
using app.Utils;
using app.Views;
using Avalonia.Controls;
using Mapsui;
using Mapsui.Extensions;
using Mapsui.Projections;
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
}