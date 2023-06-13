using app.Stores;
using app.ViewModels;

namespace app.Commands;

public class HelpCommand : BaseCommand
{
    private readonly AppCore _core;
    private readonly NavigationStore _navigation;

    public HelpCommand()
    {
        _core = AppCore.Instance();
        _navigation = NavigationStore.Instance();
    }
    public override void Execute(object parameter)
    {
        _navigation.CurrentViewModel = new HelpViewModel();
    }
}