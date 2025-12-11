using System.Reflection;
using Domain.Aggregates.OrderAggregate;
using Domain.ShareKernel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class OrderingContext(DbContextOptions options, IDomainEventDispatcher dispatcher) : DbContext(options)
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var entitiesWithEvents = ChangeTracker.Entries<HasDomainEventsBase>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToArray();

        dispatcher.DispatchAndClearEventsAsync(entitiesWithEvents).ConfigureAwait(false);
        entitiesWithEvents.ToList()
            .ForEach(entity => entity.ClearDomainEvents());
        return base.SaveChangesAsync(cancellationToken);
    }
};