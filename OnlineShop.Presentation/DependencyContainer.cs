using OnlineShop.Presentation.Extensions;
using OnlineShop.Presentation.Middlewares;

namespace OnlineShop.Presentation;

public static class DependencyContainer
{
    public static IServiceCollection ResolvePresentationDependencies(this IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.SuppressAsyncSuffixInActionNames = false;
        })
        .ConfigureApiBehaviorOptions(options =>
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                return context.HandleValidationErrors();
            };
        });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddExceptionHandler<ExceptionHandler>();
        services.AddProblemDetails();

        return services;
    }
}
