using app.Model;
using app.Services.Interfaces;
using Microsoft.Extensions.Options;
using Splat;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace app.ViewModels;

public class MyReservationsViewModel : BaseViewModel
{
    private ObservableCollection<MyReservationItemViewModel> _reservations;

    public ObservableCollection<MyReservationItemViewModel> Reservations
    {
        get => _reservations;
        set => _reservations = value;
    }

    private async void GetAllReservations()
    {
        //implement real user
        User u = await Locator.Current.GetService<IUserService>().GetById(1);
        _reservations.Clear();
        IEnumerable<Reservation> reservations = await Locator.Current.GetService<IReservationService>().GetAllForUser(u);
        foreach (Reservation reservation in reservations)
        {
            _reservations.Add(new MyReservationItemViewModel(reservation));
        }
    }

    public MyReservationsViewModel()
    {
        _reservations = new ObservableCollection<MyReservationItemViewModel>();
        GetAllReservations();
    }
}