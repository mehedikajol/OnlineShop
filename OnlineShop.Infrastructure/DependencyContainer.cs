using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.IServices;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.Base;
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
        //services.AddScoped<IRepository<Coupon>, Repository<Coupon, AppDbContext>>();
        services.AddRepository<Coupon, AppDbContext>();

        // services
        services.AddScoped<ICouponService, CouponService>();

        return services;
    }

    public static IServiceCollection AddRepository<TEntity, TContext>(this IServiceCollection services)
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        return services.AddScoped<IRepository<TEntity>, Repository<TEntity, TContext>>();
    }
}
