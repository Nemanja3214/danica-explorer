using app.Model;

namespace app.ViewModels;

public class MonthStatisticsItemViewModel : BaseViewModel
{
    private string _title;
    public string Title { get => _title; set => _title = value; }

    private string _date;
    public string Date { get => _date; set => _date = value; }

    private string _price;
    public string Price { get => _price; set => _price = value; }

    private string _noOfBookings;
    public string NoOfBookings { get => _noOfBookings; set => _noOfBookings = value; }

    public MonthStatisticsItemViewModel()
    {
        _title = "Barselona";
        _date = "01.01.2020";
        _price = "4500";
        _noOfBookings = "45";
    }

    public MonthStatisticsItemViewModel(Trip t)
    {
        _title = t.Title;
        _date = t.Startdate.ToString("dd.MM.yyyy.");
        _price = "" + t.Price;
        _noOfBookings = "" + t.Reservations.Count;
    }
}