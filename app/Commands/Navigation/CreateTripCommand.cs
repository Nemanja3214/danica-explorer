using app.Stores;
using app.ViewModels;
using Splat;

namespace app.Commands.Navigation;

public class CreateTripCommand : BaseCommand
{
    private readonly AppCore _core;
    private readonly NavigationStore _navigation;

    public CreateTripCommand()
    {
        _core = AppCore.Instance();
        _navigation = NavigationStore.Instance();
    }
    public override void Execute(object parameter)
    {
        _navigation.CurrentViewModel = Locator.Current.GetService<TripCreateViewModel>();
    }
}