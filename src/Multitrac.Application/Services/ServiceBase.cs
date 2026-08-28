using System.Reflection;
using AutoMapper;
using Multitrac.Application.DTOs;
using Multitrac.Application.Interfaces;
using Multitrac.Domain.Exceptions;
using Multitrac.Domain.Interfaces;

namespace Multitrac.Application.Services;

public abstract class ServiceBase<TDto, TEntity> : IService<TDto, TEntity> where TEntity : class where TDto : class
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;

    protected ServiceBase(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    protected async Task<TEntity> GetEntityByIdOrThrowAsync(int id)
    {
        var entity = await _unitOfWork.Repository<TEntity>().GetByIdAsync(id);
        if (entity == null)
            throw new NotFoundException(typeof(TEntity).Name, id);
        return entity;
    }

    protected async Task<int> GetNextIdAsync<TEntity>() where TEntity : class
    {
        var all = await _unitOfWork.Repository<TEntity>().GetAllAsync();
        if (!all.Any()) return 1;

        var pkProp = typeof(TEntity).GetProperties()
            .FirstOrDefault(p => p.PropertyType == typeof(int) && p.CanRead && p.Name.StartsWith("Id"))
            ?? typeof(TEntity).GetProperties().First(p => p.PropertyType == typeof(int) && p.CanRead);

        var maxId = all.Max(e => (int)(pkProp.GetValue(e) ?? 0));
        return maxId + 1;
    }

    protected async Task SetNextIdAsync<TEntity>(TEntity entity) where TEntity : class
    {
        var pkProp = typeof(TEntity).GetProperties()
            .FirstOrDefault(p => p.PropertyType == typeof(int) && p.CanRead && p.Name.StartsWith("Id"))
            ?? typeof(TEntity).GetProperties().First(p => p.PropertyType == typeof(int) && p.CanRead);

        var currentId = (int)(pkProp.GetValue(entity) ?? 0);
        if (currentId == 0)
        {
            var nextId = await GetNextIdAsync<TEntity>();
            pkProp.SetValue(entity, nextId);
        }
    }

    protected void RestorePrimaryKey<TEntity>(TEntity entity, int originalId) where TEntity : class
    {
        var pkProp = typeof(TEntity).GetProperties()
            .FirstOrDefault(p => p.PropertyType == typeof(int) && p.CanRead && p.Name.StartsWith("Id"))
            ?? typeof(TEntity).GetProperties().First(p => p.PropertyType == typeof(int) && p.CanRead);
        pkProp.SetValue(entity, originalId);
    }

    public abstract Task<TDto?> GetByIdAsync(int id);

    public abstract Task<IEnumerable<TDto>> GetAllAsync();

    public abstract Task<TDto> CreateAsync(TDto dto);

    public abstract Task UpdateAsync(int id, TDto dto);

    public abstract Task DeleteAsync(int id);

    public abstract Task<bool> ExistsAsync(int id);

    public async Task<PaginatedResult<TDto>> GetPaginatedAsync(PaginationRequest request)
    {
        System.Linq.Expressions.Expression<Func<TEntity, bool>>? filter = null;

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            var search = request.Search.Trim().ToLower();
            var parameter = System.Linq.Expressions.Expression.Parameter(typeof(TEntity), "e");
            System.Linq.Expressions.Expression? body = null;

            var stringProperties = typeof(TEntity).GetProperties()
                .Where(p => p.PropertyType == typeof(string) && p.CanRead);

            foreach (var prop in stringProperties)
            {
                var propertyAccess = System.Linq.Expressions.Expression.Property(parameter, prop);
                var nullCheck = System.Linq.Expressions.Expression.NotEqual(propertyAccess, System.Linq.Expressions.Expression.Constant(null, typeof(string)));
                var toLower = System.Linq.Expressions.Expression.Call(propertyAccess, typeof(string).GetMethod("ToLower", Type.EmptyTypes)!);
                var contains = System.Linq.Expressions.Expression.Call(toLower, typeof(string).GetMethod("Contains", new[] { typeof(string) })!, System.Linq.Expressions.Expression.Constant(search));

                var containsWithNull = System.Linq.Expressions.Expression.AndAlso(nullCheck, contains);

                body = body == null ? containsWithNull : System.Linq.Expressions.Expression.OrElse(body, containsWithNull);
            }

            if (body != null)
            {
                filter = System.Linq.Expressions.Expression.Lambda<Func<TEntity, bool>>(body, parameter);
            }
        }

        var (items, totalCount) = await _unitOfWork.Repository<TEntity>().GetPaginatedAsync(
            request.Page,
            request.PageSize,
            filter,
            request.SortBy,
            request.SortDirection?.ToLower() == "desc");

        return new PaginatedResult<TDto>
        {
            Items = _mapper.Map<IEnumerable<TDto>>(items),
            TotalCount = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
