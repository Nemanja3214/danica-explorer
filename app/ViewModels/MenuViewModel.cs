using System.Windows.Input;
using app.Commands;
using app.Commands.Navigation;
using app.ViewModels;

namespace app.ViewModels;

public class MenuViewModel : BaseViewModel
{
    public BaseCommand HomeCommand { get; }
    public BaseCommand TripsCommand { get; }
    public BaseCommand AttractionsCommand { get; }
    public BaseCommand AuthCommand { get; }

    public MenuViewModel()
    {
        this.HomeCommand = new HomeCommand();
        this.TripsCommand = new TripsCommand();
        this.AttractionsCommand = new AttractionsCommand();
        this.AuthCommand = new AuthCommand();
    }
}