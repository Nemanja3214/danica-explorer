using System;
using System.Reactive;
using app.Stores;
using app.ViewModels;
using app.Views;
using Avalonia.Controls;
using ReactiveUI;


public class MainWindowViewModel : BaseViewModel
{
    private readonly Window _parent;

    public TripCreateViewModel TcmVm { get; set; }
    private readonly NavigationStore _navigationStore;
    public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel ;

    public MainWindowViewModel(Window parent)
    {
         _parent = parent;
         TcmVm = new TripCreateViewModel();

        _navigationStore = NavigationStore.Instance();
        _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
    }
    
    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}
