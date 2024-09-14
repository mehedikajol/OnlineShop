﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Products.Application.Interfaces;
using OnlineShop.Products.Domain.Entities;
using OnlineShop.Products.Infrastructure.Data;
using OnlineShop.Products.Infrastructure.Services;
using OnlineShop.SharedKernel;

namespace OnlineShop.Products.Infrastructure;

public static class DependencyResolver
{
    public static IServiceCollection AddProductsInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddNetCoreEssentials();
        services.UseSharedKernel();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ProductsDbContext>(options => options.UseSqlServer(connectionString));

        services.AddEntityRepository<Product, Guid, ProductsDbContext>();

        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}
