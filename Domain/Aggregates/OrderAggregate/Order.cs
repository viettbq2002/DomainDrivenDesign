using Domain.Aggregates.OrderAggregate.Events;
using Domain.Exceptions;

namespace Domain.Aggregates.OrderAggregate;

public class Order : BaseAuditableEntity, IAggregateRoot
{
    [Required] public Address Address { get; private set; }
    public string Description { get; private set; }
    public DateTime OrderDate { get; set; }
    private readonly List<OrderItem> _orderItems = [];
#pragma warning disable CS0169 // Field is never used
    private bool _isDraft;
#pragma warning restore CS0169 // Field is never used
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();
    public OrderStatus OrderStatus { get; }

    public Order()
    {
    }

    public Order(string userId, string userName, Address address, string description,
        DateTime orderDate, string? createdBy = "Admin")
    {
        Address = address;
        Description = description;
        CreatedDate = DateTime.UtcNow;
        CreatedBy = createdBy;
        OrderDate = orderDate;
        OrderStatus = OrderStatus.Submitted;
        AddOrderStartedDomainEvent(userId, userName);
    }
    public void AddOrderItem(int productId, string productName, decimal unitPrice, decimal discount, int units)
    {
        var orderItem = new OrderItem(productId, productName, unitPrice, discount, units);
        _orderItems.Add(orderItem);
    }

    #region Private Methods

    private void AddOrderStartedDomainEvent(string userId, string userName)
    {
        var orderStartedDomainEvent = new OrderStartedDomainEvent(this, userId, userName);
        AddDomainEvent(orderStartedDomainEvent);
    }

    private void statusChangeException(OrderStatus desiredStatus)
    {
        throw new OrderingDomainException(
            $"Is not possible change the order status from {OrderStatus} to {desiredStatus}.");
    }

    #endregion
}