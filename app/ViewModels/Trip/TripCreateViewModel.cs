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
using app.Services.Interfaces;
using Avalonia.Input;
using ExCSS;
using Mapsui;
using Mapsui.Extensions;
using Mapsui.Projections;
using NetTopologySuite.Geometries;
using ReactiveUI;
using Splat;
using Location = app.Model.Location;

namespace app.ViewModels;

public class TripCreateViewModel
{

    public TripCreateViewModel()
    {
        HotelVm = new DragNDropViewModel("Hotels", GetHotelItems);
        RestaurantVm = new DragNDropViewModel("Restaurants", GetRestaurantItems);
        AttractionVm = new DragNDropViewModel("Attractions", GetAttractionItems);
        Tvm = new TripCreateFormViewModel();
        Uvm = new UploadViewModel();
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
            Locator.Current.GetService<ITripService>().Delete(CurrentTrip);
            CurrentTrip = PreviousTrip;
            PreviousTrip = null;
        });
        
        _saveCommand = ReactiveCommand.Create<Unit>(e =>
        {
            Trip t = FormTrip();
            t = Locator.Current.GetService<ITripService>().Create(t);
            
            IEnumerable<Attraction> attractions = AttractionVm.AddedItems.Select(sightseeing => (Attraction) sightseeing);
            t.TripAttractions = attractions.Select(attraction => new TripAttraction(attraction.Id, t.Id)).ToList();
            attractions.Select(a => Locator.Current.GetService<IAttractionService>().Create(a));
        
            IEnumerable<Service> services = RestaurantVm.AddedItems.Concat(HotelVm.AddedItems)
                .Select(sightseeing => (Service) sightseeing);
            t.TripServices = services.Select(service => new TripService(service.Id, t.Id)).ToList();
            services.Select(s => Locator.Current.GetService<IServiceService>().Create(s));
            
            PreviousTrip = CurrentTrip;
            CurrentTrip = t;
        });

    }

    public UploadViewModel Uvm { get; set; }

    public TripCreateFormViewModel Tvm { get; set; }

    private Trip FormTrip()
    {
        Trip t = new Trip();
        t.Title = Tvm.Title;
        t.Description = Tvm.Description;
        t.Durationindays = Tvm.Lasting;
        t.Price = Tvm.Price;
        t.Image = UploadViewModel.ImageToByte(Uvm.ImageToView);
      
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
            MapVm.Points.Add(SphericalMercator.FromLonLat(item.Location.Longitude, item.Location.Latitude).ToMPoint());
        }
        foreach (var item in RestaurantVm.AddedItems)
        {
            MapVm.Points.Add(SphericalMercator.FromLonLat(item.Location.Longitude, item.Location.Latitude).ToMPoint());
        }
        foreach (var item in HotelVm.AddedItems)
        {
            MapVm.Points.Add(SphericalMercator.FromLonLat(item.Location.Longitude, item.Location.Latitude).ToMPoint());
        }
    }
    
    private void SelectionChangedMethod(object sender, EventArgs e)
    {
        if(sender == null)
            return;
        ISigthSeeing item = (ISigthSeeing)sender;
        MapVm.SelectedSphericalMercatorCoordinate =
            SphericalMercator.FromLonLat(item.Location.Longitude, item.Location.Latitude).ToMPoint();
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
    public async static Task<List<ISigthSeeing>> GetHotelItems(string query)
    {
        return new List<ISigthSeeing>()
        {
            new Service()
            {
                Title = "dqwd",
                Id = 0,
                Location = new Location(21.005859, 44.016521)
            },
            new Service()
            {
                Title = "azxcaw",
                Id = 1,
                Location = new Location(22.005859, 44.016521)
            }
        };
    }
    
       
    // TODO simulation function delete
    public async static Task<List<ISigthSeeing>> GetRestaurantItems(string query)
    {
        return new List<ISigthSeeing>()
        {
            new Service()
            {
                Title = "yutyu",
                Id = 0,
                Location = new Location(23.005859, 44.016521)
            },
            new Service()
            {
                Title = "werw",
                Id = 1,
                Location = new Location(24.005859, 44.016521)
            }
        };
    }
    
    // TODO simulation function delete
    public async static Task<List<ISigthSeeing>> GetAttractionItems(string query)
    {
        return new List<ISigthSeeing>()
        {
            new Attraction()
            {
                Title = "yutyu",
                Id = 0,
                Location = new Location(25.005859, 44.016521)
            },
            new Attraction()
            {
                Title = "werw",
                Id = 1,
                Location = new Location(26.005859, 44.016521)
            }
        };
    }


}