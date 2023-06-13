using System;
using System.Reactive;
using app.Model;
using app.Stores;
using app.ViewModels;
using app.Views;
using Avalonia.Controls;
using Avalonia.Markup.Parsers.Nodes;
using ReactiveUI;


public class MainWindowViewModel : BaseViewModel
{
    private static Window _parent;

    private readonly NavigationStore _navigationStore;
    public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel ;

    public MainWindowViewModel(Window parent)
    {
         _parent = parent;
        _navigationStore = NavigationStore.Instance();
        _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

    }

    public static Window GetMainWindow()
    {
        return _parent;
    }

    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
    
    
    
}
