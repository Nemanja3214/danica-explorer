using System;
using app.Stores;
using app.ViewModels;
using Splat;

namespace app.Commands;

public class AttractionDetailsCommand : BaseCommand
{

    private readonly AppCore _core;
    private readonly NavigationStore _navigation;
    private readonly AttractionCardViewModel _viewModel;

    public AttractionDetailsCommand(AttractionCardViewModel attractionCardViewModel)
    {
        _core = AppCore.Instance();
        _viewModel = attractionCardViewModel;
        _navigation = NavigationStore.Instance();
    }
    public override void Execute(object parameter)
    {
        _navigation.CurrentViewModel = new AttractionDetailsViewModel(_viewModel.Attraction);
    }
}