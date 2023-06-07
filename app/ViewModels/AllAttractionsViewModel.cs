using System.Collections.ObjectModel;
using app.Views;
using Avalonia;

namespace app.ViewModels;

public class AllAttractionsViewModel : ViewModelBase
{
    //public ViewModelBase AttractionCardViewModel { get; set; }
    //private AttractionCard _card;

    //public AttractionCard Card { get => _card; }

    public ObservableCollection<AttractionCard> AllAttractions { get; set; }
    public AllAttractionsViewModel()
    {
        AllAttractions = new ObservableCollection<AttractionCard>();

        for (int i = 0; i < 20; i++)
        {
            AttractionCardViewModel attractionCardViewModel = new AttractionCardViewModel();
            AttractionCard card = new AttractionCard();
            card.DataContext = attractionCardViewModel;
            card.Margin = Thickness.Parse("10");
            AllAttractions.Add(card);
        }
    }
}