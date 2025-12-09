namespace Domain.ShareKernel;

public interface IDomainEventDispatcher
{
    Task DispatchAndClearEventsAsync(IEnumerable<IHasDomainEvents> entitiesWithEvents);
}