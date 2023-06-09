using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Mapsui;
using Mapsui.Extensions;
using Mapsui.Layers;
using Mapsui.Projections;
using Mapsui.Providers;
using Mapsui.Styles;
using Mapsui.Tiling;
using Mapsui.UI.Avalonia.Extensions;
using Mapsui.Tiling.Layers;
using Mapsui.UI.Forms;
using Mapsui.Extensions;
using Mapsui.Layers;
using Mapsui.Styles;
using Mapsui.Tiling;
using Mapsui.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BruTile;
using Position = Mapsui.UI.Forms.Position;

namespace app.Views;

public partial class MapComponent : UserControl
{
    public MapComponent()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
        var mapControl = new Mapsui.UI.Avalonia.MapControl();
        mapControl.Map.Layers.Add(OpenStreetMap.CreateTileLayer());
        mapControl.Map.Layers.Add(CreatePinLayer(mapControl.Map.Extent));

        // var serbiaCoords = new MPoint(21.005859, 44.016521);
        var serbiaCoords = new MPoint(0, 0);
        // OSM uses spherical mercator coordinates. So transform the lon lat coordinates to spherical mercator
        var sphericalMercatorCoordinate = SphericalMercator.FromLonLat(serbiaCoords.X, serbiaCoords.Y).ToMPoint();
        // Set the center of the viewport to the coordinate. The UI will refresh automatically
        // Additionally you might want to set the resolution, this could depend on your specific purpose
        mapControl.Map.Home = n => n.CenterOnAndZoomTo(sphericalMercatorCoordinate, n.Resolutions[7]);
        
        
        Content = mapControl;
    }

    private static ILayer CreatePinLayer(MRect? envelope)
    {
        return new MemoryLayer
        {
            
            Name = "Points",
            IsMapInfoLayer=true,
            Features = GetListOfPoints(),
            
        };
    }
    private static IEnumerable<IFeature> GetListOfPoints()
    {
        List<IFeature> list = new List<IFeature>();
        var feature = new PointFeature(0, 0);
        feature["name"] = "MyPoint";
        feature.Extent(new Extent(10, 10, 60, 60));
        feature.Styles.Add(SmalleDot());
        list.Add(feature);

        IEnumerable<IFeature> points = list as IEnumerable<IFeature>;
        return points;
    }
    
    private static IStyle SmalleDot()
    {
        return new SymbolStyle { SymbolScale = 0.03, Fill = new Brush(new Color(40, 40, 40)) };
    }

}