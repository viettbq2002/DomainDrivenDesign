using Application.Commands;
using AutoMapper;

namespace Application.MappingProfile;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        // CreateOrderCommand to Order mapping
        CreateMap<CreateOrderCommand, Domain.Aggregates.OrderAggregate.Order>().ReverseMap();
    }
    
}