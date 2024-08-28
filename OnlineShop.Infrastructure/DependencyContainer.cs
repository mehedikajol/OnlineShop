using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Domain.Repositories;
using OnlineShop.Infrastructure.Data;
using OnlineShop.Infrastructure.Repositories;

namespace OnlineShop.Infrastructure;

public static class DependencyContainer
{
    public static IServiceCollection ResolveInfrastructureDependencies(
        this IServiceCollection services, 
        IConfigurationManager config, 
        string connectionStringName = "DefaultConnection")
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString(connectionStringName));  
        });

        services.AddScoped<ICouponRepository, CouponRepository>();

        return services;
    }
}
