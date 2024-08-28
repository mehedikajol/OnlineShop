namespace OnlineShop.Domain.Entities.Base;

public interface IEntity<TId>
{
    TId Id { get; }
}

public abstract class Entity<TId> : IEntity<TId>
{
    public required TId Id { get; set; }
}