using Microsoft.Extensions.Logging;

namespace Domain.ShareKernel;

public class DomainEventDispatcher(IMediator mediator, ILogger<DomainEventDispatcher> logger) : IDomainEventDispatcher
{
    private readonly IMediator _mediator = mediator;
    private readonly ILogger<DomainEventDispatcher> _logger = logger;

    public async Task DispatchAndClearEventsAsync(IEnumerable<IHasDomainEvents> entitiesWithEvents)
    {
        foreach (var entity in entitiesWithEvents)
        {
            if (entity is IHasDomainEvents hasDomainEvents)
            {
                IDomainEvent[] events = hasDomainEvents.DomainEvents.ToArray();
                hasDomainEvents.ClearDomainEvents();

                foreach (var domainEvent in events)
                    await _mediator.Publish(domainEvent).ConfigureAwait(false);
            }
            else
            {
                _logger.LogError(
                    "Entity of type {EntityType} does not inherit from {BaseType}. Unable to clear domain events.",
                    entity.GetType().Name,
                    nameof(IHasDomainEvents));
            }
        }
    }
}