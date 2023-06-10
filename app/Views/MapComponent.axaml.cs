using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Mapsui;
using Mapsui.Extensions;
using Mapsui.Layers;
using Mapsui.Projections;
using Mapsui.Providers;
using Mapsui.Styles;
using Mapsui.Tiling;
using Mapsui.Utilities;


namespace app.Views;

public partial class MapComponent : UserControl
{
    public MapComponent()
    {
        InitializeComponent();
    }
    private static MPoint serbiaCoords = new MPoint(21.005859, 44.016521);
    private static MPoint serbiaSphericalMercatorCoordinate = SphericalMercator.FromLonLat(serbiaCoords.X, serbiaCoords.Y).ToMPoint();

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
        var mapControl = new Mapsui.UI.Avalonia.MapControl();
        mapControl.Map.Layers.Add(OpenStreetMap.CreateTileLayer());
        mapControl.Map.Layers.Add(CreatePinLayer(mapControl.Map.Extent));

       
        // var serbiaCoords = new MPoint(0, 0);
        // OSM uses spherical mercator coordinates. So transform the lon lat coordinates to spherical mercator

        // Set the center of the viewport to the coordinate. The UI will refresh automatically
        // Additionally you might want to set the resolution, this could depend on your specific purpose
        mapControl.Map.Home = n => n.CenterOnAndZoomTo(serbiaSphericalMercatorCoordinate, n.Resolutions[7]);
        
        Content = mapControl;
    }

    private static ILayer CreatePinLayer(MRect? envelope)
    {
        return new MemoryLayer
        {
            Style = null,
            Name = "Points",
            IsMapInfoLayer=true,
            Features = GetListOfPoints(),
            
        };
    }
    private static IEnumerable<IFeature> GetListOfPoints()
    {
        List<IFeature> list = new List<IFeature>();
        var feature = new PointFeature(serbiaSphericalMercatorCoordinate.X, serbiaSphericalMercatorCoordinate.Y);
        feature["name"] = "MyPoint";
        feature.Styles.Add(Pin());
        list.Add(feature);

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
            // SymbolOffset = new Offset { Y = 64 },
            SymbolScale = 0.1
        };
    }

}