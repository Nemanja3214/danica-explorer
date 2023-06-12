using app.Model;
using app.Repositories;
using app.Repositories.Interfaces;
using Splat;

namespace app.Dependency_injection;

public static class RepositoryRegister
{
    public static void Register(IMutableDependencyResolver services,
        IReadonlyDependencyResolver resolver)
    {
        services.RegisterLazySingleton<IAttractionRepository>(() =>
            new AttractionRepository(resolver.GetService<DanicaExplorerContext>()));
        services.RegisterLazySingleton<ILocationRepository>(() =>
            new LocationRepository(resolver.GetService<DanicaExplorerContext>()));
        services.RegisterLazySingleton<IReservationRepository>(() =>
            new ReservationRepository(resolver.GetService<DanicaExplorerContext>()));
        services.RegisterLazySingleton<IServiceRepository>(() =>
            new ServiceRepository(resolver.GetService<DanicaExplorerContext>()));
        services.RegisterLazySingleton<ITripServiceRepository>(() =>
            new TripServiceRepository(resolver.GetService<DanicaExplorerContext>()));
        services.RegisterLazySingleton<ITripAttractionRepository>(() =>
            new TripAttractionRepository(resolver.GetService<DanicaExplorerContext>()));
        services.RegisterLazySingleton<ITripRepository>(() =>
            new TripRepository(resolver.GetService<DanicaExplorerContext>()));
        services.RegisterLazySingleton<IUserRepository>(() =>
            new UserRepository(resolver.GetService<DanicaExplorerContext>()));
    }
}