using System;
using app.Stores;

namespace app.ViewModels;

public class MainWindowViewModel : BaseViewModel
{
    private readonly NavigationStore _navigationStore;
    public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel ;

    public MainWindowViewModel()
    {
        _navigationStore = NavigationStore.Instance();
        _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
    }
    
    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}
