using System;
using app.Model;
using app.Services.Interfaces;
using app.Stores;
using app.ViewModels;
using Splat;

namespace app.Commands;

public class BookCommand : BaseCommand
{
    private readonly AppCore _core;
    private readonly NavigationStore _navigation;
    private readonly TripCardViewModel _tripCardViewModel;
    private readonly IReservationService _reservationService;

    public BookCommand(TripCardViewModel tripCardViewModel)
    {
        _core = AppCore.Instance();
        _navigation = NavigationStore.Instance();
        _tripCardViewModel = tripCardViewModel;
        _reservationService = Locator.Current.GetService<IReservationService>();
    }
    public async override void Execute(object parameter)
    {
        Reservation newReservation = new Reservation
        {
            Date = DateOnly.FromDateTime(DateTime.Now),
            UserId = _navigation.CurrentUser.Id,
            TripId = _tripCardViewModel.SelectedTrip.Id,
        };
        var result = await MessageBox.Avalonia.MessageBoxManager
            .GetMessageBoxStandardWindow(new MessageBox.Avalonia.DTO.MessageBoxStandardParams
            {
                ContentTitle = "Potvrda reyervacije",
                ContentMessage = "Rezerviši " + _tripCardViewModel.SelectedTrip.Title + " ?",
                Icon = MessageBox.Avalonia.Enums.Icon.None,
                ButtonDefinitions = MessageBox.Avalonia.Enums.ButtonEnum.YesNo
            })
            .ShowDialog(MainWindowViewModel.GetMainWindow());
        if (result == MessageBox.Avalonia.Enums.ButtonResult.Yes)
        {
            
            result = await MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow(new MessageBox.Avalonia.DTO.MessageBoxStandardParams
                {
                    ContentTitle = "Poruka",
                    ContentMessage = "Rezervacija uspješna",
                    Icon = MessageBox.Avalonia.Enums.Icon.None,
                    ButtonDefinitions = MessageBox.Avalonia.Enums.ButtonEnum.Ok
                })
                .ShowDialog(MainWindowViewModel.GetMainWindow());
        }
        _navigation.CurrentViewModel = Locator.Current.GetService<LandingViewModel>();
    }
}