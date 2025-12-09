using Domain.Aggregates.OrderAggregate;
using Domain.ShareKernel;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class AddInfrastructure
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>))
            .AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>))
            .AddScoped<IOrderRepository, OrderRepository>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<OrderingContext>(o => { o.UseSqlServer(connectionString); });
        return services;
    }
}