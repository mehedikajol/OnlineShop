using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.IServices;
using OnlineShop.Domain.Repositories;
using OnlineShop.Infrastructure.Data;
using OnlineShop.Infrastructure.Repositories;
using OnlineShop.Infrastructure.Services;

namespace OnlineShop.Infrastructure;

public static class DependencyContainer
{
    public static IServiceCollection ResolveInfrastructureDependencies(
        this IServiceCollection services, 
        IConfigurationManager config, 
        string connectionStringName = "DefaultConnection")
    {
        // context
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString(connectionStringName));  
        });

        // repositories
        services.AddScoped<ICouponRepository, CouponRepository>();

        // services
        services.AddScoped<ICouponService, CouponService>();

        return services;
    }
}
