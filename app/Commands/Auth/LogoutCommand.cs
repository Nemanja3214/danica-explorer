using System;
using app.Model;
using app.Services.Interfaces;
using app.Stores;
using app.ViewModels;
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
        _navigation.CurrentUser = null;
        _navigation.CurrentViewModel = new LandingViewModel();
    }
}