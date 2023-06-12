using System.Collections.Generic;
using System.Collections.ObjectModel;
using app.Model;
using app.Services.Interfaces;
using app.Views;
using Avalonia;
using Splat;

namespace app.ViewModels;

public class AllAttractionsViewModel : BaseViewModel
{
    private IAttractionService _service;
    //public ViewModelBase TripCardViewModel { get; set; }
    //private TripCard _card;

    //public TripCard Card { get => _card; }

    private ObservableCollection<AttractionCard> _allAttractions;
    public ObservableCollection<AttractionCard> AllAttractions
    {
        get => _allAttractions;
        set
        {
            _allAttractions = value;
            OnPropertyChanged(nameof(AllAttractions));
        }
    }
    public AllAttractionsViewModel()
    {
        AllAttractions = new ObservableCollection<AttractionCard>();
        _service = Locator.Current.GetService<IAttractionService>();
        GetAttractions();
    }

    private async void GetAttractions()
    {
        IEnumerable<Attraction> attractions = await _service.GetAll();
        foreach (var attraction in attractions)
        {
            AttractionCardViewModel attractionCardViewModel = new AttractionCardViewModel(attraction);
            AttractionCard card = new AttractionCard();
            card.DataContext = attractionCardViewModel;
            AllAttractions.Add(card);
        }
        OnPropertyChanged(nameof(AllAttractions));
    }
}