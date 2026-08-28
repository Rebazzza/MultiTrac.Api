using System.Linq.Expressions;

namespace Multitrac.Domain.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<T?> FindAsync(params object[] keyValues);
    Task<bool> DeleteByKeysAsync(params object[] keyValues);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<(IEnumerable<T> Items, int TotalCount)> GetPaginatedAsync(
        int page, int pageSize,
        Expression<Func<T, bool>>? filter = null,
        string? sortBy = null,
        bool descending = false);
}
