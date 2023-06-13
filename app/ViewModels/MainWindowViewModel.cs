using System;
using System.Reactive;
using app.Commands;
using app.Commands.Auth;
using app.Commands.Navigation;
using app.Model;
using app.Stores;
using app.ViewModels;
using app.Views;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Parsers.Nodes;
using ReactiveUI;


public class MainWindowViewModel : BaseViewModel
{
    private static Window _parent;

    private readonly NavigationStore _navigationStore;
    public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel ;
    public BaseCommand LogoutCommand { get; }
    public KeyGesture LogoutGesture { get; } = new KeyGesture(Key.Escape, KeyModifiers.Control);

    public MainWindowViewModel(Window parent)
    {
         _parent = parent;
        _navigationStore = NavigationStore.Instance();
        _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        LogoutCommand = new LogoutCommand();
        HelpCommand = new HelpCommand();
        LandingCommand = new HomeCommand();

    }

    public static Window GetMainWindow()
    {
        return _parent;
    }

    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
    
    public BaseCommand HelpCommand { get;  }
    public BaseCommand LandingCommand { get;  }
    public KeyGesture HelpGesture { get; } = new KeyGesture(Key.F1);
    public KeyGesture LandingGesture { get; } = new KeyGesture(Key.Escape);
    
}
