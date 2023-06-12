using System;
using System.Reactive;
using app.Views;
using Avalonia.Controls;
using ReactiveUI;

namespace app.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly Window _parent;

    public MainWindowViewModel(Window parent)
    {
        _parent = parent;
        AcmVm = new RestaurantCreateViewModel(_parent);
    }

    public RestaurantCreateViewModel AcmVm { get; set; }
}
