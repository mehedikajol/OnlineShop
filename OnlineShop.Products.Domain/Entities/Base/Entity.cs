using OnlineShop.SharedKernel.Entities;

namespace OnlineShop.Products.Domain.Entities.Base;

public class Entity : IEntity<Guid>
{
    public Guid Id { get; protected set; }
}