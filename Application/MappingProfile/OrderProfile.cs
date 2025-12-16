using Application.Commands;
using Application.DTOs;
using AutoMapper;
using Domain.Aggregates.OrderAggregate;

namespace Application.MappingProfile;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        // CreateOrderCommand to Order mapping
        CreateMap<Order, OrderDto>();
        CreateMap<Address, AddressDto>();
        CreateMap<OrderItem, OrderItemDto>();
    }
}