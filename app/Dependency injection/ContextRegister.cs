using app.Model;
using Splat;

namespace app.Dependency_injection;

public static class ContextRegister
{
    public static void Register(IMutableDependencyResolver services,
        IReadonlyDependencyResolver resolver)
    {
        services.RegisterLazySingleton(() => new DanicaExplorerContext());
    }
}