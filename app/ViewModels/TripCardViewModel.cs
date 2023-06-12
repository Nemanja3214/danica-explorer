using System.Windows.Input;
using app.Commands;

namespace app.ViewModels;

public class TripCardViewModel : BaseViewModel
{
    private string _imageSource;
    public string ImageSource { get => _imageSource; set => _imageSource = value; }

    private string _tripName;
    public string TripName
    {
        get => _tripName;
        set => _tripName = value;
    }

    private string _tripDate;
    public string TripDate
    {
        get => _tripDate;
        set => _tripDate = value;
    }

    private string _tripPrice;
    public string TripPrice
    {
        get => _tripPrice;
        set => _tripPrice = value;
    }

    public BaseCommand BookCommand { get; }
    public BaseCommand LearnMoreCommand { get; }

    public TripCardViewModel()
    {
        BookCommand = new BookCommand();
        LearnMoreCommand = new TripDetailsCommand();
        _imageSource = "Assets/banner.png";
        _tripName = "Beogradska magija";
        _tripDate = "Datum: " + "01.01.2020.";
        _tripPrice = "Cena: " + "4500" + " din";
    }
}