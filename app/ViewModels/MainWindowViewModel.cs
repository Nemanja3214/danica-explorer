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

    public MainWindowViewModel(Window parent)
    {
        _parent = parent;
        Tcvm = new TripCreateViewModel();
    }

    public TripCreateViewModel Tcvm { get; set; }

}
