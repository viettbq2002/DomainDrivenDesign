using Domain.Aggregates.OrderAggregate;

namespace Infrastructure.Repositories;

public class OrderRepository(OrderingContext dbContext) : EfRepository<Order>(dbContext), IOrderRepository
{
    
}