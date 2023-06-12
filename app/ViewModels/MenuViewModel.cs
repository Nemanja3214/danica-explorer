using System.Windows.Input;
using app.Commands.Navigation;
using app.ViewModels;

namespace app.ViewModels;

public class MenuViewModel : BaseViewModel
{
    public ICommand HomeCommand { get; }
    public ICommand TripsCommand { get; }
    public ICommand AttractionsCommand { get; }
    public ICommand AuthCommand { get; }

    public MenuViewModel()
    {
        this.HomeCommand = new HomeCommand();
        this.TripsCommand = new TripsCommand();
        this.AttractionsCommand = new AttractionsCommand();
        this.AuthCommand = new AuthCommand();
    }
}