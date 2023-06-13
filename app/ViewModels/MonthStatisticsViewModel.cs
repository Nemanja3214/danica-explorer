using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using app.Model;
using app.Services.Interfaces;
using Splat;
using TripService = app.Services.TripService;

namespace app.ViewModels;

public class MonthStatisticsViewModel : BaseViewModel
{
    private ObservableCollection<MonthStatisticsItemViewModel> _trips;

    public ObservableCollection<MonthStatisticsItemViewModel> Trips
    {
        get => _trips;
        set => _trips = value;
    }
    
    private DateTime _selectedDate;
    public DateTime SelectedDate
    {
        get => _selectedDate;
        set
        {
            _selectedDate = value;
            OnPropertyChanged(nameof(SelectedDate));
        }
    }

    public MonthStatisticsViewModel()
    {
        _selectedDate = DateTime.Now;
        _trips = new ObservableCollection<MonthStatisticsItemViewModel>();
        GetTrips();

    }

    private async void GetTrips()
    {
        DateTime d = DateTime.Now.AddMonths(-1);
        IEnumerable<Trip> trips = await Locator.Current.GetService<ITripService>().GetAllForMonth(d);

        foreach (var trip in trips)
        {
            _trips.Add(new MonthStatisticsItemViewModel(trip));
        }
    }
}