using System.Windows.Input;
using app.Commands;

namespace app.ViewModels;

public class AttractionCardViewModel : ViewModelBase
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

    public ICommand LearnMoreCommand { get; }

    public AttractionCardViewModel()
    {
        LearnMoreCommand = new AttractionDetailsCommand();
        _imageSource = "../Assets/tripimage.jpeg";
        _attractionName = "Sagrada familija";
    }

    
    
}