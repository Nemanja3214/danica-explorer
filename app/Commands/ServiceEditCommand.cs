using app.Stores;
using app.ViewModels;

namespace app.Commands;

public class ServiceEditCommand : BaseCommand
{

    private readonly AppCore _core;
    private readonly NavigationStore _navigation;
    private readonly ServiceCardViewModel _viewModel;

    public ServiceEditCommand(ServiceCardViewModel tripCardViewModel)
    {
        _core = AppCore.Instance();
        _viewModel = tripCardViewModel;
        _navigation = NavigationStore.Instance();
    }

    public override void Execute(object parameter)
    {
        if (_viewModel.Service.Ishotel.Value)
        {
            NavigationStore.Instance().CurrentViewModel = new AccomodationCreateViewModel(_viewModel.Service);

        }
        else
        {
            NavigationStore.Instance().CurrentViewModel = new RestaurantCreateViewModel(_viewModel.Service);
        }
    }
}