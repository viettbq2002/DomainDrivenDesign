using Application.DTOs;
using Application.Models;

namespace Application.Commands;

public class CreateOrderCommand : IRequest<MinimalApiResponse<int>>
{
    private readonly List<OrderItemDto> _orderItems;
    public string UserId { get; private set; }

    public string UserName { get; private set; }

    public string City { get; private set; }

    public string Street { get; private set; }

    public string State { get; private set; }

    public string Country { get; private set; }

    public string ZipCode { get; private set; }
    public IEnumerable<OrderItemDto> OrderItems => _orderItems;

    public CreateOrderCommand(List<OrderItemDto> orderItems)
    {
        _orderItems = [];
    }

    public CreateOrderCommand(string userId, string userName, string city, string street, string state, string country,
        string zipCode, List<OrderItemDto> orderItems)
    {
        UserId = userId;
        UserName = userName;
        City = city;
        Street = street;
        State = state;
        Country = country;
        ZipCode = zipCode;
        _orderItems = orderItems;
    }
}

