namespace Application.DTOs;

public record OrderItemDto
{
    public string ProductName { get; set; } = null!;
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; private set; }
    public int Units { get; private set; }
    public int ProductId { get; private set; }
}

public record AddressDto
{
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
}
public class OrderDto
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public DateTime OrderDate { get; set; }
    public string? OrderStatus { get; set; }
    public AddressDto? Address { get; set; }
    public IEnumerable<OrderItemDto> OrderItems { get; set; } = Array.Empty<OrderItemDto>();
    public DateTime CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public string? LastModifiedBy { get; set; }
}