using System.Windows.Input;
using app.Commands;
using app.Model;

namespace app.ViewModels;

public class AttractionCardViewModel : BaseViewModel
{

    private string _imageSource;

    public string ImageSource
    {
        get => _imageSource;
    }

    private string _attractionName;
    public string AttractionName
    {
        get => _attractionName;
        set => _attractionName = value;
    }

    public Attraction Attraction { get; set; }

    public ICommand LearnMoreCommand { get; }

    public AttractionCardViewModel()
    {
        LearnMoreCommand = new AttractionDetailsCommand(this);
        _imageSource = "../Assets/tripimage.jpeg";
        _attractionName = "Sagrada familija";
    }

    public AttractionCardViewModel(Attraction attraction)
    {
        LearnMoreCommand = new AttractionDetailsCommand(this);
        Attraction = attraction;
        _imageSource = "../Assets/tripimage.jpeg";
        _attractionName = attraction.Title;
    }
}