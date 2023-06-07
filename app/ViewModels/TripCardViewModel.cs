using System.Windows.Input;
using app.Commands;

namespace app.ViewModels;

public class TripCardViewModel : ViewModelBase
{
    private string _imageSource;
    public string ImageSource { get => _imageSource; set => _imageSource = value; }

    public ICommand BookCommand { get; }
    public ICommand LearnMoreCommand { get; }

    public TripCardViewModel()
    {
        BookCommand = new BookCommand();
        LearnMoreCommand = new TripDetailsCommand();
        _imageSource = "../Assets/tripimage.jpeg";
    }
}