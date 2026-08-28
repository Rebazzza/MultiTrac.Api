using Microsoft.EntityFrameworkCore;
using Multitrac.Domain.Interfaces;
using Multitrac.Infrastructure.Data;
using System.Linq.Expressions;

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

    public async Task<T?> FindAsync(params object[] keyValues)
    {
        return await _dbSet.FindAsync(keyValues);
    }

    public async Task<bool> DeleteByKeysAsync(params object[] keyValues)
    {
        var entity = await _dbSet.FindAsync(keyValues);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            return true;
        }
        return false;
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

    public async Task<(IEnumerable<T> Items, int TotalCount)> GetPaginatedAsync(
        int page, int pageSize,
        Expression<Func<T, bool>>? filter = null,
        string? sortBy = null,
        bool descending = false)
    {
        IQueryable<T> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        var totalCount = await query.CountAsync();

        if (!string.IsNullOrEmpty(sortBy))
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, sortBy);
            var lambda = Expression.Lambda<Func<T, object>>(Expression.Convert(property, typeof(object)), parameter);

            query = descending
                ? Queryable.OrderByDescending(query, lambda)
                : Queryable.OrderBy(query, lambda);
        }

        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (items, totalCount);
    }
}
