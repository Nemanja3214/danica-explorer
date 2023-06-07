using System.Collections.ObjectModel;
using app.Views;

namespace app.ViewModels;

public class AllTripsViewModel : ViewModelBase
{
    public ViewModelBase TripCardViewModel { get; set; }
    private TripCard _card;

    public TripCard Card { get => _card; }

    public ObservableCollection<TripCard> AllTrips { get; set; }
    public AllTripsViewModel()
    {
        AllTrips = new ObservableCollection<TripCard>();
        TripCardViewModel = new TripCardViewModel();
        _card = new TripCard();
        _card.DataContext = TripCardViewModel;
    }
}