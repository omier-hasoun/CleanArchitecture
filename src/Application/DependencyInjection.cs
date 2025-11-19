using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
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
