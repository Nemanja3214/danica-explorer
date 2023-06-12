using System;
using System.Collections.ObjectModel;

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
        for (int i = 0; i < 20; i++)
        {
            _trips.Add(new MonthStatisticsItemViewModel());
        }
    }
}