using app.Stores;
using app.ViewModels;

namespace app.Commands.Auth;

public class LoginCommand : BaseCommand
{
    private readonly AppCore _core;
    private readonly NavigationStore _navigation;

    public LoginCommand()
    {
        _core = AppCore.Instance();
        _navigation = NavigationStore.Instance();
    }
    public override void Execute(object parameter)
    {
        _navigation.CurrentViewModel = new LandingViewModel();
    }
}