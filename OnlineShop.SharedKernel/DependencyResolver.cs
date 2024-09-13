using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.SharedKernel.Entities;
using OnlineShop.SharedKernel.Events;
using OnlineShop.SharedKernel.Repositories;

namespace OnlineShop.SharedKernel;

public static class DependencyResolver
{
    public static IServiceCollection RegisterSharedKernel(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(DependencyResolver).Assembly);
        });

        services.AddScoped<IEventPublisher, EventPublisher>();

        return services;
    }

    public static IServiceCollection RegisterRepository<TEntity, TId, TContext>(this IServiceCollection services)
        where TEntity : class, IEntity<TId>
        where TContext : DbContext
    {
        return services.AddScoped<IRepository<TEntity, TId>, Repository<TEntity, TId, TContext>>();
    }
}
