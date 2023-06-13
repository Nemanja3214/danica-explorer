using app.Model;

namespace app.ViewModels;

public class MyReservationItemViewModel : BaseViewModel
{
    private string _name;
    public string Name { get => _name; set => _name = value; }

    private string _date;
    public string Date { get => _date; set => _date = value; }

    private string _price;
    public string Price { get => _price; set => _price = value; }

    private string _dateOfBooking;
    public string DateOfBooking { get => _dateOfBooking; set => _dateOfBooking = value; }

    public MyReservationItemViewModel(Reservation reservation)
    {
        _name = reservation.Trip.Title;
        _date = reservation.Trip.Startdate.ToString("dd.MM.yyyy.");
        _price = reservation.Trip.Price.ToString();
        _dateOfBooking = reservation.Date.Value.ToString("dd.MM.yyyy.");
    }
}