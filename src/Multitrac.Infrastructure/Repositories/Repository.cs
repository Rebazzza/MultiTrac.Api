using Microsoft.EntityFrameworkCore;
using Multitrac.Domain.Interfaces;
using Multitrac.Infrastructure.Data;

namespace Multitrac.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly BdmultitracContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(BdmultitracContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> CreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
        await Task.CompletedTask;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _dbSet.FindAsync(id) != null;
    }
}
