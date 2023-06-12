using System.Collections.ObjectModel;
using System;
using System.Linq;
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

    public ObservableCollection<string> Options { get; }

    private string _selectedOption;
    public string SelectedOption
    {
        get => _selectedOption;
        set
        {
            if (_selectedOption != value)
            {
                _selectedOption = value;
                OnPropertyChanged(nameof(SelectedOption));
            }
        }
    }
    
    public TripStatisticsViewModel()
    {
        Options = new ObservableCollection<string>();
        Options.Add("Option 1");
        Options.Add("Option 2");
        Options.Add("Option 3");
        _selectedOption = Options.FirstOrDefault();

        _reservations = new ObservableCollection<TripStatisticsItemViewModel>();
        for (int i = 0; i < 20; i++)
        {
            _reservations.Add(Locator.Current.GetService<TripStatisticsItemViewModel>());
        }
    }
}