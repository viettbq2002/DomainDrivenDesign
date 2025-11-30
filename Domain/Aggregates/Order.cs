
using System.ComponentModel.DataAnnotations;

namespace Domain.Aggregates;

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

}