using OnlineShop.Products.Infrastructure;

namespace OnlineShop.Products.Presentation;

public static class ProductsModule
{
    public static IServiceCollection RegisterProductsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddProductsInfrastructure(configuration);

        return services;
    }
}
