using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using app.Model;
using app.Services.Interfaces;
using Splat;

namespace app.ViewModels;

public class TripStatisticsViewModel : BaseViewModel
{
    private ObservableCollection<TripStatisticsItemViewModel> _reservations;

    public ObservableCollection<TripStatisticsItemViewModel> Reservations
    {
        get => _reservations;
        set => _reservations = value;
    }

    public ObservableCollection<Trip> Options { get; }

    private Trip _selectedOption;
    public Trip SelectedOption
    {
        get => _selectedOption;
        set
        {
            if (_selectedOption != value)
            {
                _selectedOption = value;
                GetAllReservations();
                OnPropertyChanged(nameof(SelectedOption));
            }
        }
    }

    private async void GetAllReservations()
    {
        if (_reservations == null)
        {
            _reservations = new();
        }
        _reservations.Clear();
        IEnumerable<Reservation> reservations = await Locator.Current.GetService<IReservationService>().GetAllForTrip(_selectedOption);
        foreach (Reservation reservation in reservations)
        {
            _reservations.Add(new TripStatisticsItemViewModel(reservation));
        }
    }

    public TripStatisticsViewModel()
    {
        Options = new ObservableCollection<Trip>();
        GetAllTrips();
        //Options.Add("Option 1");
        //Options.Add("Option 2");
        //Options.Add("Option 3");
        

        _reservations = new ObservableCollection<TripStatisticsItemViewModel>();
        //for (int i = 0; i < 20; i++)
        //{
        //    _reservations.Add(Locator.Current.GetService<TripStatisticsItemViewModel>());
        //}
    }

    private async void GetAllTrips()
    {
        IEnumerable<Trip> trips = await Locator.Current.GetService<ITripService>().GetAll();
        foreach (Trip trip in trips)
        {
            Options.Add(trip);
        }
        SelectedOption = Options.FirstOrDefault();
        OnPropertyChanged(nameof(Options));
    }
}