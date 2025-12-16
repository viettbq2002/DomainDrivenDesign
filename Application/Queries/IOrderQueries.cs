using Application.DTOs;

namespace Application.Queries;
/// <summary>
/// Don't need to use mediator for queries because they are read-only operations and avoiding the overhead of mediator improves performance.
/// </summary>
public interface IOrderQueries
{
    Task<OrderDto> GetOrderAsync(int id);

    Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
}