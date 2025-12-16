using Application.DTOs;
using AutoMapper;
using Domain.Aggregates.OrderAggregate;
using Domain.Aggregates.OrderAggregate.Specification;

namespace Application.Queries;

public class OrderQueries(IOrderRepository orderRepository, IMapper mapper) : IOrderQueries
{
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<OrderDto> GetOrderAsync(int id)
    {
        var spec = new OrderByIdSpec(id);
        var order = await _orderRepository.FirstOrDefaultAsync(spec);
        var orderDto = _mapper.Map<Order, OrderDto>(order);
        return orderDto;
        
    }

    public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
    {
        var orders = await _orderRepository.ListAsync(new AllOrderSpec());
        var orderDto = _mapper.Map<List<Order>, List<OrderDto>>(orders);
        return orderDto;
    }
}