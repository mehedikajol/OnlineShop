using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities.Base;
using OnlineShop.Domain.Repositories;
using OnlineShop.Infrastructure.Data;
using System.Linq.Expressions;

namespace OnlineShop.Infrastructure.Repositories;

internal abstract class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    protected Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<IReadOnlyCollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public async Task<TEntity?> GetAsync(Guid id)
    {
        return await GetAsync(p => p.Id == id);
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }

    public Task<(IReadOnlyCollection<TEntity> Data, int Total, bool HasPrevious, bool HasNext)> GetPagedAsync(int pageSize, int pageIndex, string orderColumn, string orderBy)
    {
        throw new NotImplementedException();
    }

    public async Task CreateAsync(TEntity entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _dbSet.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _dbSet.Attach(entity);
        }

        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity is null)
        {
            return;
        }

        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
