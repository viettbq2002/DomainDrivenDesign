using Domain.Exceptions;

namespace Domain.Aggregates.OrderAggregate;
public class OrderItem : BaseAuditableEntity
{
    [Required]
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; private set; }
    public int Units { get; private set; }
    public int ProductId { get; private set; }
    public OrderItem(int productId, string productName, decimal unitPrice, decimal discount, int units = 1)
    {
        if (units <= 0)
        {
            throw new OrderingDomainException("Invalid number of units");
        }

        if ((unitPrice * units) < discount)
        {
            throw new OrderingDomainException("The total of order item is lower than applied discount");
        }

        ProductId = productId;

        ProductName = productName;
        UnitPrice = unitPrice;
        Discount = discount;
        Units = units;
    }
}