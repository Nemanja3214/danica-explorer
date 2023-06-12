using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using System.Windows.Input;
using app.Model;
using app.Models;
using Avalonia.Input;
using ExCSS;
using Mapsui;
using Mapsui.Extensions;
using Mapsui.Projections;
using NetTopologySuite.Geometries;
using ReactiveUI;
using Attraction = app.Models.Attraction;
using Splat;
using Point = NetTopologySuite.Geometries.Point;

namespace app.ViewModels;

public class TripCreateViewModel
{

    public TripCreateViewModel()
    {
        HotelVm = new DragNDropViewModel("Hotels", GetHotelItems);
        RestaurantVm = new DragNDropViewModel("Restaurants", GetRestaurantItems);
        AttractionVm = new DragNDropViewModel("Attractions", GetAttractionItems);
        MapVm = new MapViewModel();

        AttractionVm.AddedItems.CollectionChanged += CollectionChangedMethod;
        AttractionVm.SelectionChanged += SelectionChangedMethod;
        
        RestaurantVm.AddedItems.CollectionChanged += CollectionChangedMethod;
        RestaurantVm.SelectionChanged += SelectionChangedMethod;
        
        HotelVm.AddedItems.CollectionChanged += CollectionChangedMethod;
        HotelVm.SelectionChanged += SelectionChangedMethod;
        
        _undoCommand = ReactiveCommand.Create<Unit>(e =>
        {
            if (PreviousTrip == null)
            {
                var messageBoxStandardWindow = MessageBox.Avalonia.MessageBoxManager
                    .GetMessageBoxStandardWindow("Povratak prethodne verzije", "Niste sačuvali putovanje kako biste mogli da ga vratite");
                messageBoxStandardWindow.Show();
                return;
            }
            // TODO delete current
            CurrentTrip = PreviousTrip;
            PreviousTrip = null;
        });
        
        _saveCommand = ReactiveCommand.Create<Unit>(e =>
        {
            Trip t = FormTrip();
            
            // TODO persist
        });

    }

    private Trip FormTrip()
    {
        Trip t = new Trip();


        return t;
    }

    public MapViewModel MapVm { get; set; }

    public DragNDropViewModel AttractionVm { get; set; }

    public DragNDropViewModel RestaurantVm { get; set; }

    public DragNDropViewModel HotelVm { get; set; }

    private void CollectionChangedMethod(object sender, NotifyCollectionChangedEventArgs e)
    {
        MapVm.Points.Clear();
        foreach (var item in AttractionVm.AddedItems)
        {
            MapVm.Points.Add(SphericalMercator.FromLonLat(item.Location.X, item.Location.Y).ToMPoint());
        }
        foreach (var item in RestaurantVm.AddedItems)
        {
            MapVm.Points.Add(SphericalMercator.FromLonLat(item.Location.X, item.Location.Y).ToMPoint());
        }
        foreach (var item in HotelVm.AddedItems)
        {
            MapVm.Points.Add(SphericalMercator.FromLonLat(item.Location.X, item.Location.Y).ToMPoint());
        }
    }
    
    private void SelectionChangedMethod(object sender, EventArgs e)
    {
        if(sender == null)
            return;
        Sightseeing item = (Sightseeing)sender;
        MapVm.SelectedSphericalMercatorCoordinate =
            SphericalMercator.FromLonLat(item.Location.X, item.Location.Y).ToMPoint();
        MapVm.RefreshPins();
    }
    
    private Trip _previousTrip;
    private Trip _currentTrip;

    private ReactiveCommand<Unit, Unit> _undoCommand;
    private ReactiveCommand<Unit, Unit> _saveCommand;
    
    public KeyGesture SaveGesture { get; } = new KeyGesture(Key.S, KeyModifiers.Control);
    public KeyGesture UndoGesture { get; } = new KeyGesture(Key.Z, KeyModifiers.Control);

    public Trip PreviousTrip
    {
        get => _previousTrip;
        set => _previousTrip = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Trip CurrentTrip
    {
        get => _currentTrip;
        set => _currentTrip = value ?? throw new ArgumentNullException(nameof(value));
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

    // TODO simulation function delete
    public async static Task<List<Sightseeing>> GetHotelItems(string query)
    {
        return new List<Sightseeing>()
        {
            new Hotel()
            {
                Name = "dqwd",
                Location = new Point(21.005859, 44.016521)
            },
            new Hotel()
            {
                Name = "azxcaw",
                Location = new Point(22.005859, 44.016521)
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
                Location = new Point(23.005859, 44.016521)
            },
            new Restaurant()
            {
                Name = "werw",
                Location = new Point(24.005859, 44.016521)
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
                Location = new Point(25.005859, 44.016521)
            },
            new Attraction()
            {
                Name = "werw",
                Location = new Point(26.005859, 44.016521)
            }
        };
    }


}