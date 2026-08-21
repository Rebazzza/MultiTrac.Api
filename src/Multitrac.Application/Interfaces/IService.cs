namespace Multitrac.Application.Interfaces;

public interface IService<TDto, TEntity> where TEntity : class
{
    Task<TDto?> GetByIdAsync(int id);
    Task<IEnumerable<TDto>> GetAllAsync();
    Task<TDto> CreateAsync(TDto dto);
    Task UpdateAsync(int id, TDto dto);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
