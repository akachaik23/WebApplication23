using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyInfrastructure.Services;

namespace MyInfrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
 
}
