using System;
using System.Linq;
using System.Windows.Input;
using app.Commands;
using app.Model;

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
        BookCommand = new BookCommand(this);
        LearnMoreCommand = new TripDetailsCommand(this);
        _imageSource = "Assets/banner.png";
        _tripName = "Beogradska magija";
        _tripDate = "Datum: " + "01.01.2020.";
        _tripPrice = "Cena: " + "4500" + " din";
    }

    public TripCardViewModel(Trip trip)
    {
        BookCommand = new BookCommand(this);
        LearnMoreCommand = new TripDetailsCommand(this);
        SelectedTrip = trip;
        _imageSource = "../Assets/tripimage.jpeg";
        _tripName = trip.Title;
        if (_tripName.Length > 30)
        {
            _tripName = _tripName.Substring(0, 27) + "...";
        }
        if (_tripName.Length <= 30)
        {
            _tripName += String.Concat(Enumerable.Repeat(" ", 30 - _tripName.Length));
        }
        _tripDate = "Datum: " + trip.Startdate.ToString("dd.MM.yyyy.");
        _tripPrice = "Cena: " + trip.Price + " din";
    }

    public Trip SelectedTrip { get; set; }
}