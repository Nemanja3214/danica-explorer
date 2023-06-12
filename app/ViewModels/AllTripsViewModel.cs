using System.Collections.ObjectModel;
using app.Views;
using Avalonia;
using Splat;

namespace app.ViewModels;

public class AllTripsViewModel : BaseViewModel
{
    //public ViewModelBase TripCardViewModel { get; set; }
    //private TripCard _card;

    //public TripCard Card { get => _card; }

    public ObservableCollection<TripCard> AllTrips { get; set; }
    public AllTripsViewModel()
    {
        AllTrips = new ObservableCollection<TripCard>();
        for (int i = 0; i < 20; i++)
        {
            TripCardViewModel viewModel = Locator.Current.GetService<TripCardViewModel>();
            TripCard card = new TripCard();
            card.DataContext = viewModel;
            AllTrips.Add(card);
        }
    }
}