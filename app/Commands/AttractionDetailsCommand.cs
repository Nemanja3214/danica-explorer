using System;
using app.Stores;
using app.ViewModels;
using Splat;

namespace app.Commands;

public class AttractionDetailsCommand : BaseCommand
{

    private readonly AppCore _core;
    private readonly NavigationStore _navigation;

    public AttractionDetailsCommand()
    {
        _core = AppCore.Instance();
        _navigation = NavigationStore.Instance();
    }
    public override void Execute(object parameter)
    {
        _navigation.CurrentViewModel = Locator.Current.GetService<AttractionDetailsViewModel>();
    }
}