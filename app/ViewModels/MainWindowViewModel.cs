using System;
using System.Reactive;
using app.Views;
using Avalonia.Controls;
using ReactiveUI;

namespace app.ViewModels;
using app.Stores;

namespace app.ViewModels;

public class MainWindowViewModel : BaseViewModel
{
    private readonly Window _parent;

    public RestaurantCreateViewModel AcmVm { get; set; }
    private readonly NavigationStore _navigationStore;
    public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel ;

    public MainWindowViewModel(Window parent)
    {
         _parent = parent;
        _navigationStore = NavigationStore.Instance();
        _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
    }
    
    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}
