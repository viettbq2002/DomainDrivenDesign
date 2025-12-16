using Application.DTOs;
using Application.Models;

namespace Application.Commands;

public class CreateOrderCommand : IRequest<MinimalApiResponse<int>>
{
    private readonly List<OrderItemDto> _orderItems;
    public string UserId { get;  set; }

    public string UserName { get;  set; }
    public string Description { get; set; }

    public string City { get;  set; }

    public string Street { get;  set; }

    public string State { get;  set; }

    public string Country { get;  set; }

    public string ZipCode { get;  set; }
    public DateTime OrderDate { get; set; }
    public IEnumerable<OrderItemDto> OrderItems { get; set;} = Array.Empty<OrderItemDto>();

    public CreateOrderCommand()
    {
        
    }

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

