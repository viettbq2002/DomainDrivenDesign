namespace Domain.Aggregates.OrderAggregate.Events;

public sealed class OrderStartedDomainEvent: DomainEventBase
{
   public Order Order { get; }
   public string UserId { get; }
   public string UserName { get; }
   public OrderStartedDomainEvent(Order order, string userId, string userName)
   {
      Order = order;
      UserId = userId;
      UserName = userName;
   }
}