using Application.DTOs;
using Domain.Aggregates.OrderAggregate;

namespace Application.Queries;

public class OrderQueries(IOrderRepository orderRepository) : IOrderQueries
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public Task<OrderDto> GetOrderAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<OrderDto>> GetOrdersFromUserAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
    {
        throw new NotImplementedException();
    }
}