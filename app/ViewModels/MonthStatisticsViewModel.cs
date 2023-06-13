using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
    
        Initialize();
    }

    private async void Initialize()
    {
        await GetTripsAsync();
    }

    private async Task GetTripsAsync()
    {
        DateTime d = DateTime.Now;
        using (var dbContext = new DanicaExplorerContext()) // Replace YourDbContext with your actual DbContext class
        {
            List<Trip> trips = await Locator.Current.GetService<ITripService>().GetAllForMonth(d, dbContext);

            foreach (var trip in trips)
            {
                _trips.Add(new MonthStatisticsItemViewModel(trip));
            }
        }
    }


}