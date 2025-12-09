using Domain.Aggregates.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("order_items");
        builder.Property(o => o.Id)
            .UseHiLo("order_item_seq");
        builder.Ignore(b => b.DomainEvents);
        builder.Property<int>("OrderId");
        builder.Property(o => o.UnitPrice).HasPrecision(18,4);
        builder.Property(o => o.Discount).HasPrecision(18,4);

    }
}