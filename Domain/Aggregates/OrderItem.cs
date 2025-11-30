namespace Domain.Aggregates;
public class OrderItem
{
    [Required]
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; private set; }
    public int Units { get; private set; }
    public int ProductId { get; private set; }
}