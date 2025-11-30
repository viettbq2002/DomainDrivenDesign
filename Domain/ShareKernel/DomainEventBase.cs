namespace Domain.ShareKernel;
/// <summary>
/// A base type for domain events. Depends on Mediatr INotification.
/// Includes OccuredOn which is set on creation.
/// </summary>
public class DomainEventBase : IDomainEvent
{
    public DateTime OccuredOn { get; protected set; } = DateTime.UtcNow;
}