namespace Domain.ShareKernel;

public interface IAuditable
{
    DateTime CreatedDate { get; set; }
    string CreatedBy { get; set; }
    DateTime? LastModifiedDate { get; set; }
    string? LastModifiedBy { get; set; }
}