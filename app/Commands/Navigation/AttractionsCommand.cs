using app.Stores;
using app.ViewModels;

namespace app.Commands.Navigation;

public class AttractionsCommand : BaseCommand
{
    private readonly AppCore _core;
    private readonly NavigationStore _navigation;

    public AttractionsCommand()
    {
        _core = AppCore.Instance();
        _navigation = NavigationStore.Instance();
    }
    public override void Execute(object parameter)
    {
        _navigation.CurrentViewModel = new AuthViewModel();
    }
}