using OnlineShop.Products.Domain.Entities.Base;

namespace OnlineShop.Products.Domain.Entities;

public sealed class Product : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
