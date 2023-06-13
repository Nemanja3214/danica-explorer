using System.Collections.Generic;
using System.Collections.ObjectModel;
using app.Model;
using app.Services;
using app.Services.Interfaces;
using app.Views;
using Avalonia;
using Splat;

namespace app.ViewModels;

public class AllTripsViewModel : BaseViewModel
{
    private ITripService _service;
    //public ViewModelBase TripCardViewModel { get; set; }
    //private TripCard _card;

    //public TripCard Card { get => _card; }

    private ObservableCollection<TripCard> _allTrips;
    public ObservableCollection<TripCard> AllTrips
    {
        get => _allTrips;
        set
        {
            _allTrips = value;
            OnPropertyChanged(nameof(AllTrips));
        }
    }

    public AllTripsViewModel()
    {
        _service = Locator.Current.GetService<ITripService>();
        _allTrips = new ObservableCollection<TripCard>();
        GetTrips();
    }

    private async void GetTrips()
    {
        AllTrips = new();
        OnPropertyChanged(nameof(AllTrips));
        IEnumerable<Trip> trips = await _service.GetAll();
        foreach (var trip in trips)
        {
            TripCardViewModel viewModel = new TripCardViewModel(trip);
            TripCard card = new TripCard();
            card.DataContext = viewModel;
            AllTrips.Add(card);
        }
        OnPropertyChanged(nameof(AllTrips));
    }
}