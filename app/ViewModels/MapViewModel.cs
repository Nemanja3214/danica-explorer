using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using Avalonia;
using Avalonia.Platform;
using Mapsui;
using Mapsui.Extensions;
using Mapsui.Layers;
using Mapsui.Projections;
using Mapsui.Styles;
using Mapsui.Tiling;
using Mapsui.UI.Avalonia;

namespace app.ViewModels;


// MAPSUI USES SPHERICAL COORDINATES PAY ATTENTION
public class MapViewModel : BaseViewModel
{
    public MPoint CurrentSphericalMercatorCoordinate { get; set; } = SphericalMercator.FromLonLat(21.005859, 44.016521).ToMPoint();
    public MPoint SelectedSphericalMercatorCoordinate { get; set; }

    private ObservableCollection<MPoint> _points;

    public ObservableCollection<MPoint> Points
    {
        get => _points;
        set => _points = value ?? throw new ArgumentNullException(nameof(value));
    }

    private bool _init = true;

    private MapControl _mapControlUI;

    public MapControl MapControlUI
    {
        get => _mapControlUI;
        set => _mapControlUI = value ?? throw new ArgumentNullException(nameof(value));
    }

    public MapViewModel()
    {
        Points = new ObservableCollection<MPoint>();
        Points.CollectionChanged += CollectionChangedMethod;
        
        MapControlUI = new MapControl();
        MapControlUI.Map.Layers.Add(OpenStreetMap.CreateTileLayer());
        MapControlUI.Map.Layers.Add(CreatePinLayer());
        MapControlUI.Map.Layers.Add(CreatePinsLayer());

        MapControlUI.Map.Home = n => n.CenterOnAndZoomTo(CurrentSphericalMercatorCoordinate, n.Resolutions[7]);
    }

    public void RefreshPin()
    {
        MapControlUI.Map.Layers.Remove(MapControlUI.Map.Layers.FindLayer("Points").First());
        MapControlUI.Map.Layers.Add(CreatePinLayer());
        MapControlUI.RefreshGraphics();
    }
    
    public void RefreshPins()
    {
        MapControlUI.Map.Layers.Remove(MapControlUI.Map.Layers.FindLayer("Multiple points").First());
        MapControlUI.Map.Layers.Add(CreatePinsLayer());
        MapControlUI.RefreshGraphics();
    }
    
    private void CollectionChangedMethod(object sender, NotifyCollectionChangedEventArgs e)
    {
        RefreshPins();
    }

    private ILayer CreatePinLayer()
    {
        return new MemoryLayer
        {
            Style = null,
            Name = "Points",
            IsMapInfoLayer=true,
            Features = GetListOfPoints(),
            
        };
    }
    
    private ILayer CreatePinsLayer()
    {
        return new MemoryLayer
        {
            Style = null,
            Name = "Multiple points",
            IsMapInfoLayer=true,
            Features = GetListOfPoints(_points),
            
        };
    }
    
    private IEnumerable<IFeature> GetListOfPoints()
    {
        List<IFeature> list = new List<IFeature>();
        if (_init)
        {
            _init = false;
            return list;
        }
        if (CurrentSphericalMercatorCoordinate == null)
        {
            return list;
        }
        var feature = new PointFeature(CurrentSphericalMercatorCoordinate);
        feature["name"] = "MyPoint";
        feature.Styles.Add(Pin());
        list.Add(feature);

        return list;
    }
    
    private IEnumerable<IFeature> GetListOfPoints(ObservableCollection<MPoint> points)
    {
        List<IFeature> list = new List<IFeature>();
        if (points == null)
        {
            points = new ObservableCollection<MPoint>();
        }

        foreach (var point in points)
        {
            var feature = new PointFeature(point);
            feature["name"] = "MyPoint";
            
            if(point.Equals(SelectedSphericalMercatorCoordinate))
                feature.Styles.Add(SelectedPin());
            else
                feature.Styles.Add(Pin());
            
            list.Add(feature);
        }

        return list;
    }

    private static IStyle Pin()
    {
        var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
        var stream = assets.Open(new Uri($"avares://{Assembly.GetExecutingAssembly().GetName().Name}/Assets/pin.png"));
        var ID = BitmapRegistry.Instance.Register(stream);
        return new SymbolStyle
        {
            BitmapId = ID,
            SymbolScale = 0.1,
            
        };
    }
    
    private static IStyle SelectedPin()
    {
        var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
        var stream = assets.Open(new Uri($"avares://{Assembly.GetExecutingAssembly().GetName().Name}/Assets/selectedPin.png"));
        var ID = BitmapRegistry.Instance.Register(stream);
        return new SymbolStyle
        {
            BitmapId = ID,
            SymbolScale = 0.1,
            
        };
    }
}