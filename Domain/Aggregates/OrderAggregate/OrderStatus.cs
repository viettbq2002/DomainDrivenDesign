using Ardalis.SmartEnum;

namespace Domain.Aggregates.OrderAggregate;

public class OrderStatus(string name, int value) : SmartEnum<OrderStatus>(name, value)
{
    public static readonly OrderStatus Submitted = new OrderStatus("Submitted", 1);
    public static readonly OrderStatus AwaitingValidation = new OrderStatus("AwaitingValidation", 2);
    public static readonly OrderStatus StockConfirmed = new OrderStatus("StockConfirmed", 3);
    public static readonly OrderStatus Paid = new OrderStatus("Paid", 4);
    public static readonly OrderStatus Shipped = new OrderStatus("Shipped", 5);
    public static readonly OrderStatus Cancelled = new OrderStatus("Cancelled", 6);
}