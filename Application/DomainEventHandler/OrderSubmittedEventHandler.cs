using Domain.Aggregates.OrderAggregate.Events;
using Microsoft.Extensions.Logging;

namespace Application.DomainEventHandler;

public class OrderSubmittedEventHandler(ILogger<OrderSubmittedEventHandler> logger)
    : INotificationHandler<OrderStartedDomainEvent>
{
    public Task Handle(OrderStartedDomainEvent notification, CancellationToken cancellationToken)
    {
        var order = notification.Order;
        var username = notification.UserName;
        logger.LogInformation(
            "Domain Event: Order submitted. OrderId: {OrderId}, Description: {Description}, CreatedAt: {CreatedAt}, Username: {Username}",
            order.Id,
            order.Description,
            order.CreatedDate,
            username
        );
        return Task.CompletedTask;
    }
}