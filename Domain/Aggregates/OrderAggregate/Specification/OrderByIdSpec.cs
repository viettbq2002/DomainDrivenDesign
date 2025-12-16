namespace Domain.Aggregates.OrderAggregate.Specification;

public class OrderByIdSpec : Specification<Order>
{
    public OrderByIdSpec(int orderId)
    {
        Query.Where(order => order.Id == orderId).Include(i => i.OrderItems);
    }
    
}