﻿namespace app.ViewModels;

public class TripStatisticsItemViewModel : ViewModelBase
{
    private string _firstName;
    public string FirstName { get => _firstName; set => _firstName = value; }

    private string _lastName;
    public string LastName { get => _lastName; set => _lastName = value; }

    private string _phoneNumber;
    public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }

    private string _dateOfBooking;
    public string DateOfBooking { get => _dateOfBooking; set => _dateOfBooking = value; }

    public TripStatisticsItemViewModel()
    {
        _firstName = "Marko";
        _lastName = "Markovic";
        _phoneNumber = "06254112542";
        _dateOfBooking = "01.01.2020.";
    }
}