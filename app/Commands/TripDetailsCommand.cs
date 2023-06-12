using System;
using app.Stores;
using app.ViewModels;
using Splat;

namespace app.Commands;

public class TripDetailsCommand : BaseCommand
{
    private readonly AppCore _core;
    private readonly NavigationStore _navigation;

    public TripDetailsCommand()
    {
        _core = AppCore.Instance();
        _navigation = NavigationStore.Instance();
    }
    public override void Execute(object parameter)
    {
        _navigation.CurrentViewModel = Locator.Current.GetService<TripDetailsViewModel>();
    }
}