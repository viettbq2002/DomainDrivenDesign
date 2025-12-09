namespace Domain.Aggregates.OrderAggregate.Events;

public sealed class OrderStartedDomainEvent(Order order, string userId, string userName) : DomainEventBase
{
   public Order Order { get; } = order;
   public string UserId { get; } = userId;
   public string UserName { get; } = userName;
}