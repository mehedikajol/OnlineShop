using NetCore.Essentials.Events;
using OnlineShop.Products.Contracts;
using OnlineShop.SharedKernel.Entities;

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

        AddDomainEvent(new ProductCreatedEvent(Id, title, description, price));
    }

    public void Update(string title, string description, decimal price)
    {
        Title = title;
        Description = description;
        Price = price;

        AddDomainEvent(new ProductUpdatedEvent(Id, title, description, price));
    }
}
