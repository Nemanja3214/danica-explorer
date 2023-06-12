using app.Services.Interfaces;
using app.Views;
using Splat;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using app.Model;

namespace app.ViewModels;

public class AllHotelsViewModel : BaseViewModel
{
    private IServiceService _service;
    //public ViewModelBase TripCardViewModel { get; set; }
    //private TripCard _card;

    //public TripCard Card { get => _card; }

    private ObservableCollection<ServiceCard> _allHotels;
    public ObservableCollection<ServiceCard> AllHotels
    {
        get => _allHotels;
        set
        {
            _allHotels = value;
            OnPropertyChanged(nameof(AllHotels));
        }
    }
    public AllHotelsViewModel()
    {
        AllHotels = new ObservableCollection<ServiceCard>();
        _service = Locator.Current.GetService<IServiceService>();
        GetRestaurants();
    }

    private async void GetRestaurants()
    {
        IEnumerable<Service> services = await _service.GetAllHotels();
        foreach (var service in services)
        {
            ServiceCardViewModel serviceCardViewModel = new ServiceCardViewModel(service);
            ServiceCard card = new ServiceCard();
            card.DataContext = serviceCardViewModel;
            AllHotels.Add(card);
        }
        OnPropertyChanged(nameof(AllHotels));
    }
}