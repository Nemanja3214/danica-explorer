using System;
using app.Model;
using app.Services.Interfaces;
using app.Stores;
using app.ViewModels;
using MessageBox.Avalonia;
using MessageBox.Avalonia.Enums;
using Splat;

namespace app.Commands.Auth;

public class LogoutCommand: BaseCommand
{
    private readonly AppCore _core;
    private readonly NavigationStore _navigation;
    private readonly IUserService _userService;

    public LogoutCommand()
    {
        _userService = Locator.Current.GetService<IUserService>();
        _core = AppCore.Instance();
        _navigation = NavigationStore.Instance();
    }

    public async override void Execute(object parameter)
    {
        if (_navigation.CurrentUser != null)
        {
            _navigation.CurrentUser = null;
            _navigation.CurrentViewModel = new LandingViewModel();
            var result = await MessageBoxManager.GetMessageBoxStandardWindow(
                    "Obaveštenje",
                    "Uspešno ste se izlogovali",
                    ButtonEnum.Ok,
                    Icon.None)
                .ShowDialog(MainWindowViewModel.GetMainWindow());
        }
    }
}