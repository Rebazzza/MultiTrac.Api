using System.Reflection;
using AutoMapper;
using Multitrac.Application.DTOs;
using Multitrac.Application.Interfaces;
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
