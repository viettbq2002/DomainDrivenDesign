namespace Domain.Aggregates.OrderAggregate;

public class Order: BaseEntity , IAggregateRoot , IAuditable
{
    [Required]
    public Address Address { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime OrderDate { get; set; }
    private readonly List<OrderItem> _orderItems;
#pragma warning disable CS0169 // Field is never used
    private bool _isDraft;
#pragma warning restore CS0169 // Field is never used
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();
}