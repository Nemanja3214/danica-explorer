using System;
using System.Reactive;
using app.Views;
using ReactiveUI;

namespace app.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        Tdvm = new TripDetailsViewModel();
        Accvm = new AccomodationCreateViewModel();
    }

    public AccomodationCreateViewModel Accvm { get; set; }

    public TripDetailsViewModel Tdvm { get; set; }
}
