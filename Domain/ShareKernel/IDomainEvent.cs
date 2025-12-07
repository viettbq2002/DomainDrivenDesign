namespace Domain.ShareKernel;
public interface IDomainEvent : INotification
{
     DateTime OccuredOn { get; }
}