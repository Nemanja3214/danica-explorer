using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using app.Models;
using ExCSS;
using Mapsui;
using Mapsui.Extensions;
using Mapsui.Projections;
using NetTopologySuite.Geometries;
using Point = NetTopologySuite.Geometries.Point;

namespace app.ViewModels;

public class TripCreateViewModel
{
    private DragNDropViewModel _hotelVm;
    private DragNDropViewModel _restaurantVm;
    private DragNDropViewModel _attractionVm;
    private readonly MapViewModel _mapVm;

    public DragNDropViewModel AttractionVm
    {
        get => _attractionVm;
        set => _attractionVm = value ?? throw new ArgumentNullException(nameof(value));
    }

    public DragNDropViewModel HotelVm
    {
        get => _hotelVm;
        set => _hotelVm = value ?? throw new ArgumentNullException(nameof(value));
    }

    public DragNDropViewModel RestaurantVm
    {
        get => _restaurantVm;
        set => _restaurantVm = value ?? throw new ArgumentNullException(nameof(value));
    }

    public MapViewModel MapVm => _mapVm;

    public TripCreateViewModel()
    {
        _hotelVm = new DragNDropViewModel("Hotels", GetHotelItems);
        _restaurantVm = new DragNDropViewModel("Restaurants", GetRestaurantItems);
        _attractionVm = new DragNDropViewModel("Attractions", GetAttractionItems);
        _mapVm = new MapViewModel();

        AttractionVm.AddedItems.CollectionChanged += CollectionChangedMethod;

    }
    
    private void CollectionChangedMethod(object sender, NotifyCollectionChangedEventArgs e)
    {
        MapVm.Points.Clear();
        foreach (var item in AttractionVm.AddedItems)
        {
            MapVm.Points.Add(SphericalMercator.FromLonLat(item.Location.X, item.Location.Y).ToMPoint());
        }
    }
    
    // TODO simulation function delete
    public async static Task<List<Sightseeing>> GetHotelItems(string query)
    {
        return new List<Sightseeing>()
        {
            new Hotel()
            {
                Name = "dqwd",
            },
            new Hotel()
            {
                Name = "azxcaw",
            }
        };
    }
    
       
    // TODO simulation function delete
    public async static Task<List<Sightseeing>> GetRestaurantItems(string query)
    {
        return new List<Sightseeing>()
        {
            new Restaurant()
            {
                Name = "yutyu",
            },
            new Restaurant()
            {
                Name = "werw",
            }
        };
    }
    
    // TODO simulation function delete
    public async static Task<List<Sightseeing>> GetAttractionItems(string query)
    {
        return new List<Sightseeing>()
        {
            new Attraction()
            {
                Name = "yutyu",
                Date = DateTime.Now,
                Location = new Point(22.005859, 44.016521)
            },
            new Attraction()
            {
                Name = "werw",
                Date = DateTime.Now,
                Location = new Point(21.005859, 44.016521)
            }
        };
    }


}