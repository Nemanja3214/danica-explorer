using app.Model;
using app.Repositories;
using app.Repositories.Interfaces;
using app.Services;
using app.Services.Interfaces;
using app.ViewModels;
using app.Views;
using Splat;
using TripService = app.Model.TripService;

namespace app.Dependency_injection;

public static class ServiceRegister
{
    public static void Register(IMutableDependencyResolver services,
        IReadonlyDependencyResolver resolver)
    {
        services.RegisterLazySingleton<IAttractionService>(() =>
            new AttractionService(resolver.GetService<IAttractionRepository>()));
        services.RegisterLazySingleton<ILocationService>(() =>
            new LocationService(resolver.GetService<ILocationRepository>()));
        services.RegisterLazySingleton<IReservationService>(() =>
            new ReservationService(resolver.GetService<IReservationRepository>()));
        services.RegisterLazySingleton<IServiceService>(() =>
            new ServiceService(resolver.GetService<IServiceRepository>()));
        services.RegisterLazySingleton<ITripAttractionService>(() =>
            new TripAttractionService(resolver.GetService<ITripAttractionRepository>()));
        services.RegisterLazySingleton<ITripService>(() =>
            new Services.TripService(resolver.GetService<ITripRepository>()));
        services.RegisterLazySingleton<ITripServiceService>(() =>
            new TripServiceService(resolver.GetService<ITripServiceRepository>()));
        services.RegisterLazySingleton<IUserService>(() =>
            new UserService(resolver.GetService<IUserRepository>()));
        services.RegisterLazySingleton<ISearchService<Attraction>>(() =>
            new AttractionService(resolver.GetService<IAttractionRepository>()));
        services.RegisterLazySingleton<ISearchService<Service>>(() =>
            new ServiceService(resolver.GetService<IServiceRepository>()));
        services.RegisterLazySingleton<ISearchRepository<Attraction>>(() =>
            new AttractionRepository(resolver.GetService<DanicaExplorerContext>()));
        services.RegisterLazySingleton<ISearchRepository<Service>>(() =>
            new ServiceRepository(resolver.GetService<DanicaExplorerContext>()));
    }
}