using Splat;

namespace app.Dependency_injection;

public static class DependencyInjection
{
    public static void Register(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
        ContextRegister.Register(services, resolver);
        RepositoryRegister.Register(services, resolver);
        ServiceRegister.Register(services, resolver);
        ViewModelRegister.Register(services, resolver);
    }
}
