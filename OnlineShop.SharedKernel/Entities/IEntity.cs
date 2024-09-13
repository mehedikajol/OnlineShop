namespace OnlineShop.SharedKernel.Entities;

public interface IEntity<TId>
{
    TId Id { get; }
}
