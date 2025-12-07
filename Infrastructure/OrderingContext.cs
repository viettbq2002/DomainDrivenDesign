using Domain.Aggregates.OrderAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class OrderingContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Order>  Orders { get; set;  }
};