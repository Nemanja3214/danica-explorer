using app.Stores;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using app.ViewModels;
using app.Views;

namespace app;

public partial class App : Application
{
    private readonly AppCore _core;
    private readonly NavigationStore _navigation;
    public App()
    {
        _core = AppCore.Instance();
        _navigation = NavigationStore.Instance();
    }
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            _navigation.CurrentViewModel = new LandingViewModel();
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel()
                
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}