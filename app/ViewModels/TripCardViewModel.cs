namespace app.ViewModels;

public class TripCardViewModel : ViewModelBase
{
    private string _imageSource;
    public string ImageSource { get => _imageSource; set => _imageSource = value; }



    public TripCardViewModel()
    {
        _imageSource = "../Assets/tripimage.jpeg";
    }
}