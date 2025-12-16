namespace Domain.Aggregates.OrderAggregate.Specification;

public class AllOrderSpec: Specification<Order>
{
    public AllOrderSpec()
    {
        Query.Include(i => i.OrderItems);
    }
}