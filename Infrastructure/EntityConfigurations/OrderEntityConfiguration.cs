using Domain.Aggregates.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("orders");
        builder.Ignore(b => b.DomainEvents);
        builder.Property(o => o.Id).UseHiLo("order_seq");
        builder.OwnsOne(o => o.Address);
        builder
            .Property(o => o.OrderStatus)
            .HasConversion(x => x.Value, x=> OrderStatus.FromValue(x))
            .HasMaxLength(30);
        
    }
}