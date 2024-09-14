using Microsoft.EntityFrameworkCore;
using NetCore.Essentials.Events;
using OnlineShop.Products.Domain.Entities;
using OnlineShop.SharedKernel.Entities;
using OnlineShop.SharedKernel.Event;

namespace OnlineShop.Products.Infrastructure.Data;

internal class ProductsDbContext : DbContext
{
    private readonly IEventsPublisher _eventsPublisher;

    public ProductsDbContext(DbContextOptions<ProductsDbContext> options, IEventsPublisher eventsPublisher)
        : base(options)
    {
        _eventsPublisher = eventsPublisher;
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Product");

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<Entity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = Guid.NewGuid();
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedBy = Guid.NewGuid();
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    break;
                default:
                    break;
            }
        }

        var result = await base.SaveChangesAsync(cancellationToken);

        var events = ChangeTracker.Entries<IHaveDomainEvents>()
            .Select(p => p.Entity)
            .Where(p => p.DomainEvents.Any())
            .SelectMany(p => p.DomainEvents)
            .ToArray();

        _eventsPublisher.PublishAllEvents(events);

        return result;
    }
}
