using System;
using app.Model;
using app.Services.Interfaces;
using app.Stores;
using app.ViewModels;
using Splat;

namespace app.Commands.Auth;

public class RegisterCommand : BaseCommand
{
    private readonly AppCore _core;
    private readonly NavigationStore _navigation;
    private readonly AuthViewModel _authViewModel;
    private readonly IUserService _userService;

    public RegisterCommand(AuthViewModel authViewModel)
    {
        _userService = Locator.Current.GetService<IUserService>();
        _core = AppCore.Instance();
        _navigation = NavigationStore.Instance();
        _authViewModel = authViewModel;
    }
    public async override void Execute(object parameter)
    {
        if (_authViewModel.IsRegisterButtonEnabled)
        {
            User user = new User
            {
                Name = this._authViewModel.Name,
                Phone = this._authViewModel.Phone,
                Email = this._authViewModel.Email,
                Password = this._authViewModel.Password,
            };
            try
            {
                User res = await _userService.Register(user);
                _navigation.CurrentViewModel = new LandingViewModel();
            }
            catch (InvalidOperationException)
            {
                // ...
            }
        }
    }
}