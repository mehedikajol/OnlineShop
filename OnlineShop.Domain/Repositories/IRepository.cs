using OnlineShop.Domain.Entities.Base;
using System.Linq.Expressions;

namespace OnlineShop.Domain.Repositories;

public interface IRepository<TEntity, TId>
    where TEntity : class, IEntity<TId>
{
    Task<IReadOnlyCollection<TEntity>> GetAllAsync();
    Task<IReadOnlyCollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
    Task<(IReadOnlyCollection<TEntity> Data, int Total, bool HasPrevious, bool HasNext)> GetPagedAsync(int pageSize, int pageIndex, string orderColumn, string orderBy);
    Task<TEntity?> GetAsync(TId id);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate);
    Task CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TId id);
}
