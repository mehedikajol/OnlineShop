using Microsoft.EntityFrameworkCore;
using OnlineShop.Products.Domain.Entities;

namespace OnlineShop.Products.Infrastructure.Data;

internal class ProductsDbContext : DbContext
{
    public ProductsDbContext(DbContextOptions<ProductsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Product");

        base.OnModelCreating(modelBuilder);
    }
}
