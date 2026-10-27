using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Lab08_MaxiFranco.Models;

namespace Lab08_MaxiFranco.Repositories.Implementaciones;

public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class
{
    protected readonly Lab08DbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public GenericRepository(Lab08DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }
    public IQueryable<TEntity> GetQueryable()
    {
        return _dbSet.AsNoTracking();
    }
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }
    
    public async Task<IEnumerable<TEntity>> FindAsync(
        Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }
    
    public async Task InsertAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }
    
    public Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        return Task.CompletedTask;
    }
    
    public Task DeleteAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
        return Task.CompletedTask;
    }
}