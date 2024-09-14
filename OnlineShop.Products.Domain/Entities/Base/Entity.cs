using OnlineShop.SharedKernel.Entities;

namespace OnlineShop.Products.Domain.Entities.Base;

public class Entity : IEntity<Guid>
{
    public Guid Id { get; protected set; }

    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid UpdatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
}