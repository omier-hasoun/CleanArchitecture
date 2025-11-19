using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddCustomServices();
        return services;
    }

    private static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        // for simple dependency injection Transient/Singleton/Scoped


        return services;
    }
}
