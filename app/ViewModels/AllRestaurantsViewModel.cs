using app.Services.Interfaces;
using app.Views;
using Splat;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using app.Model;

namespace app.ViewModels;

public class AllRestaurantsViewModel : BaseViewModel
{
    private IServiceService _service;
    //public ViewModelBase TripCardViewModel { get; set; }
    //private TripCard _card;

    //public TripCard Card { get => _card; }

    private ObservableCollection<ServiceCard> _allRestaurants;
    public ObservableCollection<ServiceCard> AllRestaurants
    {
        get => _allRestaurants;
        set
        {
            _allRestaurants = value;
            OnPropertyChanged(nameof(AllRestaurants));
        }
    }
    public AllRestaurantsViewModel()
    {
        AllRestaurants = new ObservableCollection<ServiceCard>();
        _service = Locator.Current.GetService<IServiceService>();
        GetRestaurants();
    }

    private async void GetRestaurants()
    {
        IEnumerable<Service> services = await _service.GetAllRestaurants();
        foreach (var service in services)
        {
            ServiceCardViewModel serviceCardViewModel = new ServiceCardViewModel(service);
            ServiceCard card = new ServiceCard();
            card.DataContext = serviceCardViewModel;
            AllRestaurants.Add(card);
        }
        OnPropertyChanged(nameof(AllRestaurants));
    }

}