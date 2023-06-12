using System;
using app.Services.Interfaces;
using app.Stores;
using app.ViewModels;
using app.Views;
using Avalonia;
using MessageBox.Avalonia;
using MessageBox.Avalonia.Enums;

namespace app.Commands.Auth;

public class LoginCommand : BaseCommand
{
    private readonly AppCore _core;
    private readonly NavigationStore _navigation;
    private readonly AuthViewModel _authViewModel;
    private readonly IUserService _userService;

    public LoginCommand(AuthViewModel authViewModel)
    {
        _core = AppCore.Instance();
        _navigation = NavigationStore.Instance();
        _authViewModel = authViewModel;
    }
    public async override void Execute(object parameter)
    {
        try
        {
            // await _userService.Login(this._authViewModel.Email, this._authViewModel.Password);
            // _navigation.CurrentViewModel = new LandingViewModel();
        }
        catch (InvalidOperationException)
        {
            // ...
        }
    }
}