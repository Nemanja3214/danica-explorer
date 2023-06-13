using System;
using app.Stores;
using app.ViewModels;
using Splat;

namespace app.Commands;

public class TripDetailsCommand : BaseCommand
{
    private readonly AppCore _core;
    private readonly NavigationStore _navigation;
    private readonly TripCardViewModel _viewModel;

    public TripDetailsCommand(TripCardViewModel tripCardViewModel)
    {
        _core = AppCore.Instance();
        _viewModel = tripCardViewModel;
        _navigation = NavigationStore.Instance();
    }
    public override void Execute(object parameter)
    {
        _navigation.CurrentViewModel = new TripDetailsViewModel(_viewModel.SelectedTrip);
    }
}