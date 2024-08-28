using OnlineShop.Domain.Entities.Base;
using OnlineShop.Domain.Repositories;
using System.Linq.Expressions;

namespace OnlineShop.Infrastructure.Repositories;

internal abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : class, IEntity<TId>
{
    public Task CreateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<TEntity>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity?> GetAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<(IReadOnlyCollection<TEntity> Data, int Total, bool HasPrevious, bool HasNext)> GetPagedAsync(int pageSize, int pageIndex, string orderColumn, string orderBy)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
}
