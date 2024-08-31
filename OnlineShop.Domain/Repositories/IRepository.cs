using OnlineShop.Domain.Entities.Base;
using OnlineShop.Domain.Models;
using System.Linq.Expressions;

namespace OnlineShop.Domain.Repositories;

public interface IRepository<TEntity>
    where TEntity : class, IEntity
{
    Task<IReadOnlyCollection<TEntity>> GetAllAsync();
    Task<IReadOnlyCollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
    Task<PaginatedData<T>> GetPaginatedDataAsync<T>(IQueryable<T> query, PaginatedRequest request);
    Task<TEntity?> GetAsync(Guid id);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate);
    Task CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(Guid id);
}
