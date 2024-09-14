using Microsoft.Extensions.DependencyInjection;
using OnlineShop.SharedKernel.Event;

namespace OnlineShop.SharedKernel;

public static class DependencyContainer
{
    public static IServiceCollection UseSharedKernel(this IServiceCollection services)
    {
        services.AddScoped<IEventsPublisher, EventsPublisher>();

        return services;
    }
}
