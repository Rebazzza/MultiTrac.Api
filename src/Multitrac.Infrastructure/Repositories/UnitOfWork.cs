using Multitrac.Domain.Interfaces;
using Multitrac.Infrastructure.Data;

namespace Multitrac.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly BdmultitracContext _context;
    private readonly Dictionary<Type, object> _repositories = new();

    public UnitOfWork(BdmultitracContext context)
    {
        _context = context;
    }

    public IRepository<T> Repository<T>() where T : class
    {
        var type = typeof(T);
        if (!_repositories.ContainsKey(type))
        {
            var repository = new Repository<T>(_context);
            _repositories[type] = repository;
        }
        return (IRepository<T>)_repositories[type];
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
