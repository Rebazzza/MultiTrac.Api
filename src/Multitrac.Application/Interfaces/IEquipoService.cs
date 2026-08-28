using Multitrac.Application.DTOs;

namespace Multitrac.Application.Interfaces;

public interface IEquipoService
{
    Task<EquipoDto?> GetByCompositeKeyAsync(string tipoEquipo, string codEquipo);
    Task<IEnumerable<EquipoDto>> GetAllAsync();
    Task<EquipoDto> CreateAsync(EquipoDto dto);
    Task UpdateAsync(string tipoEquipo, string codEquipo, EquipoDto dto);
    Task DeleteAsync(string tipoEquipo, string codEquipo);
    Task<bool> ExistsAsync(string tipoEquipo, string codEquipo);
    Task<PaginatedResult<EquipoDto>> GetPaginatedAsync(PaginationRequest request);
}
