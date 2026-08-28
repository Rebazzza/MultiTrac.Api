using Multitrac.Application.DTOs;

namespace Multitrac.Application.Interfaces;

public interface IOperacionFleteSpRepository
{
    Task<CalcularFleteResponseDto?> GetFleteByIdOperacionAsync(int idOperacion);
    Task<IEnumerable<CalcularFleteResponseDto>> GetFletesByClienteAndTipoCargaAsync(int idCliente, int idTipoCarga);
    Task<IEnumerable<ReporteFacturacionResponseDto>> GetReporteFacturacionAsync(ReporteFacturacionRequestDto request);
    Task<IEnumerable<IndicadoresResponseDto>> CalcularIndicadoresAsync(int anio, int mes);
    Task<IEnumerable<ContratistaDescuentoDto>> GetContratistaDescuentosByIdOperacionGeneralAsync(int idOperacionGeneral);
}
