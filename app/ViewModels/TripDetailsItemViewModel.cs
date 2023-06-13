using app.Model;

namespace app.ViewModels;

public class TripDetailsItemViewModel : BaseViewModel
{
    public TripDetailsItemViewModel(Service service)
    {
        Title = service.Title;
    }

    public TripDetailsItemViewModel(Attraction attraction)
    {
        Title = attraction.Title;
    }

    public string Title { get; set; }
    
}