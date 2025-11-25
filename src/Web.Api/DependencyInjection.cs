namespace Web.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddCustomServices()
                .AddHttpContextAccessor();


        return services;
    }

    private static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        // for simple dependency injection Transient/Singleton/Scoped

        return services;
    }
}
