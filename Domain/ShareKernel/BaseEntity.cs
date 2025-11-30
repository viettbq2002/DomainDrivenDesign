namespace Domain.ShareKernel;

/// <summary>
/// Base entity with an integer identifier and domain event support.
/// </summary>
public abstract class BaseEntity : HasDomainEventsBase
{

    public int Id { get; set; }
}
/// <summary>
/// Base entity with a generic identifier type and domain event support.
/// </summary>
/// <typeparam name="TId">Identifier type. Must be a value type and implement <see cref="IEquatable{TId}"/>.</typeparam>
public abstract class EntityBase<TId> : HasDomainEventsBase
    where TId : struct, IEquatable<TId>
{

    public TId Id { get; set; } = default!;
}