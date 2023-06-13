using app.ViewModels;
using Splat;

namespace app.Dependency_injection;

public static class ViewModelRegister
{
    public static void Register(IMutableDependencyResolver services,
        IReadonlyDependencyResolver resolver)
    {
        services.Register(() => new AccomodationCreateFormViewModel());
        services.Register(() => new AccomodationCreateViewModel());
        services.Register(() => new UploadViewModel());

        services.Register(() => new AttractionCreateFormViewModel());
        services.Register(() => new AttractionCreateViewModel());
        
        services.Register(() => new RestaurantCreateFormViewModel());
        services.Register(() => new RestaurantCreateViewModel());

        // services.Register(() => new DragNDropViewModel());
        services.Register(() => new TripCreateViewModel());
        services.Register(() => new TripDetailsViewModel());
        
        services.Register(() => new MyReservationsViewModel());
        services.Register(() => new AllRestaurantsViewModel());
        services.Register(() => new AllHotelsViewModel());

        services.Register(() => new AllAttractionsViewModel());
        services.Register(() => new AllTripsViewModel());
        services.Register(() => new AttractionCardViewModel());
        services.Register(() => new AttractionDetailsViewModel());
        services.Register(() => new AuthViewModel());
        services.Register(() => new LandingViewModel());
        services.Register(() => new MapViewModel());
        services.Register(() => new MenuViewModel());
        services.Register(() => new MonthStatisticsItemViewModel());
        services.Register(() => new MonthStatisticsViewModel());
        services.Register(() => new TripCardViewModel());
        services.Register(() => new TripStatisticsItemViewModel());
        services.Register(() => new TripStatisticsViewModel());

    }

}