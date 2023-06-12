using System.Collections.ObjectModel;
using app.Views;
using Avalonia;

namespace app.ViewModels;

public class AllAttractionsViewModel : BaseViewModel
{
    public ObservableCollection<AttractionCard> AllAttractions { get; set; }
    public AllAttractionsViewModel()
    {
        AllAttractions = new ObservableCollection<AttractionCard>();

        for (int i = 0; i < 20; i++)
        {
            AttractionCardViewModel attractionCardViewModel = new AttractionCardViewModel();
            AttractionCard card = new AttractionCard();
            card.DataContext = attractionCardViewModel;
            AllAttractions.Add(card);
        }
    }
}