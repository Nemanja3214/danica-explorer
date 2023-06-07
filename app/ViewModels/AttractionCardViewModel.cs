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

    public ICommand LearnMoreCommand { get; }

    public AttractionCardViewModel()
    {
        LearnMoreCommand = new AttractionDetailsCommand();
        _imageSource = "../Assets/tripimage.jpeg";
    }

    
    
}