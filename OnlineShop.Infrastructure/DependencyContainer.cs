﻿using Microsoft.EntityFrameworkCore;
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
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString(connectionStringName));  
        });

        services.AddScoped<ICouponRepository, CouponRepository>();

        services.AddScoped<ICouponService, CouponService>();

        return services;
    }
}
