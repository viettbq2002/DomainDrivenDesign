using Application.Queries;
using Domain.ShareKernel;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationExtension).Assembly));
        services.AddAutoMapper(cfg => cfg.AddMaps(typeof(ApplicationExtension).Assembly));
        services.AddScoped<IOrderQueries, OrderQueries>();
        services.AddTransient<IDomainEventDispatcher, DomainEventDispatcher>();
        return services;
    }
}