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
using app.Stores;
using Avalonia.Input;
using ExCSS;
using Mapsui;
using Mapsui.Extensions;
using Mapsui.Projections;
using NetTopologySuite.Geometries;
using NetTopologySuite.Triangulate.Tri;
using ReactiveUI;
using Splat;
using Location = app.Model.Location;

namespace app.ViewModels;

public class TripCreateViewModel : BaseViewModel
{
    
    private Trip _toUpdate;

    public Trip ToUpdate
    {
        get => _toUpdate;
        set => _toUpdate = value ?? throw new ArgumentNullException(nameof(value));
    }

    public TripCreateViewModel()
    {
        HotelVm = new DragNDropViewModel("Hotels", GetHotelItems);
        HotelVm.IsHotel = true;
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
            Locator.Current.GetService<ITripService>().Update(CurrentTrip);
        });
        
        _saveCommand = ReactiveCommand.Create<Unit>(e =>
        {
            Trip t = FormTrip();
         

            if (_toUpdate == null)
            {
                t = Locator.Current.GetService<ITripService>().Create(t);
                IEnumerable<Attraction> attractions = AttractionVm.AddedItems.Select(sightseeing => (Attraction) sightseeing);
                t.TripAttractions = attractions.Select(attraction => new TripAttraction(attraction.Id, t.Id)).ToList();
                t.TripAttractions.Select(ta => Locator.Current.GetService<ITripAttractionService>().Create(ta));
        
                IEnumerable<Service> services = RestaurantVm.AddedItems.Concat(HotelVm.AddedItems)
                    .Select(sightseeing => (Service) sightseeing);
                t.TripServices = services.Select(service => new TripService(service.Id, t.Id)).ToList();
                t.TripServices.Select(ts => Locator.Current.GetService<ITripServiceService>().Create(ts));
            }
            else
            {
                t = Locator.Current.GetService<ITripService>().Update(t);
                IEnumerable<Attraction> attractions = AttractionVm.AddedItems
                    .Where(a => !t.TripAttractions.Select(ta => ta.Attraction).Contains(a)) 
                    .Select(sightseeing => (Attraction) sightseeing);

                attractions = (AttractionVm.AddedItems.Except(t.TripAttractions.Select(ta => ta.Attraction))).Select(a => a as Attraction);
                t.TripAttractions = attractions.Select(attraction => new TripAttraction(attraction.Id, t.Id)).ToList();
                t.TripAttractions.Select(ta => Locator.Current.GetService<ITripAttractionService>().Create(ta));
        
                IEnumerable<Service> services = RestaurantVm.AddedItems.Concat(HotelVm.AddedItems)
                    .Select(sightseeing => (Service) sightseeing);
                services = (RestaurantVm.AddedItems.Concat(HotelVm.AddedItems).Except(t.TripServices.Select(ts => ts.Service))).Select(a => a as Service);
                t.TripServices = services.Select(service => new TripService(service.Id, t.Id)).ToList();
                t.TripServices.Select(ts => Locator.Current.GetService<ITripServiceService>().Create(ts));
            }
          
            
            PreviousTrip = CurrentTrip;
            CurrentTrip = t;
            NavigationStore.Instance().CurrentViewModel = Locator.Current.GetService<LandingViewModel>();
        });

    }

    public UploadViewModel Uvm { get; set; }

    public TripCreateFormViewModel Tvm { get; set; }

    private Trip FormTrip()
    {
        Trip t = _toUpdate != null ? _toUpdate : new Trip();
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
        set => _previousTrip = value;
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

    public async static Task<List<ISigthSeeing>> GetHotelItems(string query, bool dummy)
    {
        IEnumerable<Service> list = await Locator.Current.GetService<ISearchService<Service>>().Search(query, true);
        return new List<ISigthSeeing>(list);
    }
    
       
    public async static Task<List<ISigthSeeing>> GetRestaurantItems(string query, bool dummy)
    {
        IEnumerable<Service> list = await Locator.Current.GetService<ISearchService<Service>>().Search(query, false);
        return new List<ISigthSeeing>(list);
    }
    
    public async static Task<List<ISigthSeeing>> GetAttractionItems(string query, bool dummy)
    {
        IEnumerable<Attraction> list = await Locator.Current.GetService<ISearchService<Attraction>>().Search(query, false);
        return new List<ISigthSeeing>(list);
    }


}