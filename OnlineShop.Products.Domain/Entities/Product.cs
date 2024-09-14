using OnlineShop.Products.Domain.Entities.Base;

namespace OnlineShop.Products.Domain.Entities;

public sealed class Product : Entity
{
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }

    public Product(string title, string description, decimal price)
    {
        Title = title;
        Description = description;
        Price = price;
    }

    public void Update(string title, string description, decimal price)
    {
        Title = title;
        Description = description;
        Price = price;
    }
}
