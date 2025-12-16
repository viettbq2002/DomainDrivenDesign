using Application.DTOs;
using Application.Models;
using AutoMapper;
using Domain.Aggregates.OrderAggregate;
using Domain.Aggregates.OrderAggregate.Events;
using Domain.ShareKernel;

namespace Application.Commands;

public class CreateOrderCommandHandlers(IOrderRepository orderRepository, IMapper mapper)
    : IRequestHandler<CreateOrderCommand, MinimalApiResponse<int>>
{
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IDomainEventDispatcher _domainEventDispatcher;

    public async Task<MinimalApiResponse<int>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var address = new Address(request.City, request.Street, request.State, request.Country, request.ZipCode);
            var order = new Order(request.UserId, request.UserName, address, request.Description, request.OrderDate);
            foreach (var orderItem in request.OrderItems)
            {
                order.AddOrderItem(orderItem.ProductId, orderItem.ProductName, orderItem.UnitPrice, orderItem.Discount,
                    orderItem.Units);
            }

            var createdOrder = await _orderRepository.AddAsync(order, cancellationToken);
            return MinimalApiResponse<int>.Ok(createdOrder.Id, "Order created successfully");
        }
        catch (Exception e)
        {
            return MinimalApiResponse<int>.Fail($"Failed to create order: {e.Message}");
        }
    }
}