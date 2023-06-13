using System.Windows.Input;
using app.Commands;
using app.Commands.Auth;
using app.Commands.Navigation;
using app.ViewModels;

namespace app.ViewModels;

public class MenuViewModel : BaseViewModel
{
    public BaseCommand HomeCommand { get; }
    public BaseCommand AllTripsCommand { get; }
    public BaseCommand CreateTripCommand { get; }
    public BaseCommand MyReservationsCommand { get; }
    public BaseCommand AllAttractionsCommand { get; }
    public BaseCommand CreateAttractionCommand { get; }
    
    public BaseCommand AllAcommodationsCommand { get; }
    public BaseCommand CreateAcommodationCommand { get; }
    
    public BaseCommand AllRestaurantsCommand { get; }
    public BaseCommand CreateRestaurantCommand { get; }
    
    public BaseCommand StatisticMonthCommand { get;  }
    public BaseCommand StatisticsTripCommand { get;  }
    
    public BaseCommand AuthCommand { get; }
    public BaseCommand LogoutCommand { get; }

    public MenuViewModel()
    {
        HomeCommand = new HomeCommand();
        
        AllTripsCommand = new AllTripsCommand();
        CreateTripCommand = new CreateTripCommand();
        MyReservationsCommand = new MyReservationsCommand();
        
        AllAttractionsCommand = new AllAttractionsCommand();
        CreateAttractionCommand = new CreateAttractionCommand();

        AllRestaurantsCommand = new AllRestaurantsCommand();
        CreateRestaurantCommand = new CreateRestaurantCommand();

        AllAcommodationsCommand = new AllAccomodationsCommand();
        CreateAcommodationCommand = new CreateAccomodationCommand();

        StatisticMonthCommand = new StatisticsMonthCommand();
        StatisticsTripCommand = new StatisticsTripCommand();
        
        AuthCommand = new AuthCommand();
        LogoutCommand = new LogoutCommand();
    }
}