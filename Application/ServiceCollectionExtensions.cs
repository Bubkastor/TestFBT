using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }

}
