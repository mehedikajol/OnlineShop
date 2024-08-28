using OnlineShop.Infrastructure;
using OnlineShop.Presentation;
using OnlineShop.Presentation.Extensions;
using OnlineShop.Presentation.Middlewares;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.ResolvePresentationDependencies();
    builder.Services.ResolveInfrastructureDependencies(builder.Configuration);
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseExceptionHandler();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
