namespace OnlineShop.Domain.Entities.Base;

public abstract class Entity<TId> : IEntity<TId>
{
    public required TId Id { get; set; }

    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid UpdatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
}