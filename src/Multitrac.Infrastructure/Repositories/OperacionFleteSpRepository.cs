using Microsoft.EntityFrameworkCore;
using Multitrac.Application.DTOs;
using Multitrac.Application.Interfaces;
using Multitrac.Infrastructure.Data;

namespace Multitrac.Infrastructure.Repositories;

public class OperacionFleteSpRepository : IOperacionFleteSpRepository
{
    private readonly BdmultitracContext _context;

    public OperacionFleteSpRepository(BdmultitracContext context)
    {
        _context = context;
    }

    public async Task<CalcularFleteResponseDto?> GetFleteByIdOperacionAsync(int idOperacion)
    {
        var result = await _context.Database
            .SqlQueryRaw<CalcularFleteResponseDto>(@"
                SELECT Id_Operacion_Flete AS IdOperacionFlete,
                       Id_Operacion AS IdOperacion,
                       CASE WHEN Id_TipoCarga IS NULL THEN 0 ELSE Id_TipoCarga END AS IdTipoCarga,
                       CAST(NULL AS NVARCHAR(255)) AS TipoCargaNombre,
                       Id_Moneda AS IdMoneda,
                       CAST(NULL AS NVARCHAR(10)) AS MonedaAbreviatura,
                       Id_Unidad AS IdUnidad,
                       CAST(NULL AS NVARCHAR(100)) AS UnidadNombre,
                       Id_OperacionTipo AS IdOperacionTipo,
                       CASE WHEN Conf_Ve_Tracto IS NULL OR Conf_Ve_Tracto = '' THEN '--' ELSE Conf_Ve_Tracto END AS ConfVeTracto,
                       CASE WHEN Conf_Ve_Carreta IS NULL OR Conf_Ve_Carreta = '' THEN '--' ELSE Conf_Ve_Carreta END AS ConfVeCarreta,
                       Porc_Flete AS PorcentajeFlete,
                       ValorVenta_Flete AS ValorVentaFlete,
                       ValorReferencial,
                       PesoPromedioTN AS PesoPromedioTn,
                       ComisionMultitrac,
                       CAST(NULL AS DECIMAL(18,2)) AS ComisionTerceros,
                       Fecha_Inicio AS FechaInicio,
                       Fecha_Fin AS FechaFin,
                       Estado,
                       CAST(NULL AS NVARCHAR(255)) AS DescOperacion,
                       CAST(NULL AS NVARCHAR(255)) AS NombreCliente,
                       CAST(NULL AS NVARCHAR(255)) AS NombreContratista
                FROM OPERACION_FLETE
                WHERE Id_Operacion = {0}", idOperacion)
            .FirstOrDefaultAsync();

        if (result == null) return null;

        var descOperacion = await _context.Operaciones
            .Where(o => o.IdOperacion == idOperacion)
            .Select(o => o.DescOperacion)
            .FirstOrDefaultAsync();

        result.DescOperacion = descOperacion;
        return result;
    }

    public async Task<IEnumerable<CalcularFleteResponseDto>> GetFletesByClienteAndTipoCargaAsync(int idCliente, int idTipoCarga)
    {
        var clienteFilter = idCliente == 0 ? "%" : idCliente.ToString();
        var tipoCargaFilter = idTipoCarga == 0 ? "%" : idTipoCarga.ToString();

        var results = await _context.Database
            .SqlQueryRaw<CalcularFleteResponseDto>(@"
                SELECT OPERACION_FLETE.Id_Operacion_FLETE AS IdOperacionFlete,
                       OPERACION_FLETE.Id_Operacion AS IdOperacion,
                       CASE WHEN OPERACION_FLETE.Id_TipoCarga IS NULL THEN 0 ELSE OPERACION_FLETE.Id_TipoCarga END AS IdTipoCarga,
                       TIPO_CARGA.Descripcion_TipoCarga AS TipoCargaNombre,
                       OPERACION_FLETE.Id_Moneda AS IdMoneda,
                       MONEDA.Abreviatura_Moneda AS MonedaAbreviatura,
                       OPERACION_FLETE.Id_Unidad AS IdUnidad,
                       UNIDAD_CANTIDAD.Nombre_Unidad AS UnidadNombre,
                       OPERACION_FLETE.Id_OperacionTipo AS IdOperacionTipo,
                       OPERACION_FLETE.Conf_Ve_Tracto AS ConfVeTracto,
                       OPERACION_FLETE.Conf_Ve_Carreta AS ConfVeCarreta,
                       OPERACION_FLETE.Porc_Flete AS PorcentajeFlete,
                       OPERACION_FLETE.ValorVenta_Flete AS ValorVentaFlete,
                       OPERACION_FLETE.ValorReferencial,
                       OPERACION_FLETE.PesoPromedioTN AS PesoPromedioTn,
                       OPERACION_FLETE.ComisionMultitrac,
                       OPERACION_FLETE.ComisionTerceros,
                       OPERACION_FLETE.Fecha_Inicio AS FechaInicio,
                       OPERACION_FLETE.Fecha_Fin AS FechaFin,
                       OPERACION_FLETE.Estado,
                       OPERACION.Desc_Operacion AS DescOperacion,
                       CLIENTE.RazonSocial_Cliente AS NombreCliente,
                       CAST(NULL AS NVARCHAR(255)) AS NombreContratista
                FROM OPERACION_FLETE
                INNER JOIN OPERACION ON OPERACION_FLETE.Id_Operacion = OPERACION.Id_Operacion
                INNER JOIN OPERACION_CONTACTO ON OPERACION.Id_Operacion = OPERACION_CONTACTO.Id_Operacion
                INNER JOIN CONTACTO ON OPERACION_CONTACTO.Id_Contacto = CONTACTO.Id_Contacto
                INNER JOIN CLIENTE ON CONTACTO.Id_Cliente = CLIENTE.Id_Cliente
                INNER JOIN TIPO_CARGA ON OPERACION_FLETE.Id_TipoCarga = TIPO_CARGA.Id_TipoCarga
                INNER JOIN MONEDA ON OPERACION_FLETE.Id_Moneda = MONEDA.Id_Moneda
                INNER JOIN UNIDAD_CANTIDAD ON OPERACION_FLETE.Id_Unidad = UNIDAD_CANTIDAD.IdUnidadCantidad
                WHERE CLIENTE.Id_Cliente LIKE {0}
                  AND OPERACION_FLETE.Id_TipoCarga LIKE {1}
                ORDER BY CLIENTE.RazonSocial_Cliente",
                clienteFilter, tipoCargaFilter)
            .ToListAsync();

        return results;
    }

    public async Task<IEnumerable<ReporteFacturacionResponseDto>> GetReporteFacturacionAsync(ReporteFacturacionRequestDto request)
    {
        var idOperacionFilter = request.IdOperacion == 0 ? "%" : request.IdOperacion.ToString();
        var idContratistaFilter = request.IdContratista == 0 ? "%" : request.IdContratista.ToString();
        var monedaFilter = request.Moneda == "0" ? "%" : request.Moneda;
        var idClienteFilter = request.IdCliente == 0 ? "%" : request.IdCliente.ToString();

        var results = await _context.Database
            .SqlQueryRaw<ReporteFacturacionResponseDto>(@"
                SELECT _Tr.Numero_Documento AS NumeroDocumento,
                       GUIA_REMISION.Num_GuiaRemision AS NumeroGuiaRemision,
                       GUIA_REMISION.Num_GuiaTransportista AS NumeroGuiaTransportista,
                       GUIA_REMISION.Num_GuiaRemitente AS NumeroGuiaRemitente,
                       OPERACION_GENERAL_EQUIPO.Cod_Equipo_Tracto AS CodigoEquipoTracto,
                       CAST(NULL AS NVARCHAR(255)) AS Socio,
                       OPERACION.Desc_Operacion AS DescOperacion,
                       OPERACION_GENERAL.FechaInicio_Plan_OP AS FechaInicioPlanOp,
                       GUIA_REMISION.FechaRecepcion,
                       CAST(NULL AS NVARCHAR(50)) AS EstadoFacturacion,
                       CAST(0 AS DECIMAL(18,2)) AS ValorVenta,
                       CAST(0 AS DECIMAL(18,2)) AS Igv,
                       CAST(0 AS DECIMAL(18,2)) AS MontoLiquidacion,
                       _Tr.IdTr,
                       CAST(NULL AS INT) AS IdContratista,
                       GUIA_REMISION.Id_GuiaRemision AS IdGuiaRemision,
                       OPERACION.Id_Operacion AS IdOperacion,
                       OPERACION_GENERAL.Id_OperacionGeneral AS IdOperacionGeneral
                FROM _Tr
                INNER JOIN GUIA_REMISION ON _Tr.IdTr = GUIA_REMISION.IdTr
                INNER JOIN OPERACION_GENERAL_EQUIPO ON GUIA_REMISION.Id_Operacion_General_Equipo = OPERACION_GENERAL_EQUIPO.Id_OperacionGeneralEquipo
                INNER JOIN OPERACION_GENERAL ON OPERACION_GENERAL_EQUIPO.Id_OperacionGeneral = OPERACION_GENERAL.Id_OperacionGeneral
                INNER JOIN OPERACION ON OPERACION_GENERAL.Id_Operacion = OPERACION.Id_Operacion
                WHERE GUIA_REMISION.Fecha_Emision BETWEEN {0} AND {1}
                  AND OPERACION.Id_Operacion LIKE {2}
                ORDER BY GUIA_REMISION.Fecha_Emision DESC",
                request.FechaInicio, request.FechaFin, idOperacionFilter)
            .ToListAsync();

        return results;
    }

    public async Task<IEnumerable<IndicadoresResponseDto>> CalcularIndicadoresAsync(int anio, int mes)
    {
        var results = await _context.Database
            .SqlQueryRaw<IndicadoresResponseDto>(@"
                SELECT IdIndicador,
                       Indicador AS NombreIndicador,
                       CAST(NULL AS NVARCHAR(50)) AS MesNombre,
                       CAST({0} AS INT) AS Anio,
                       CAST(0 AS DECIMAL(10,3)) AS Indicador
                FROM INDICADORES
                WHERE Estado = 'A'
                ORDER BY Orden",
                anio)
            .ToListAsync();

        return results;
    }

    public async Task<IEnumerable<ContratistaDescuentoDto>> GetContratistaDescuentosByIdOperacionGeneralAsync(int idOperacionGeneral)
    {
        var results = await _context.Database
            .SqlQueryRaw<ContratistaDescuentoDto>(@"
                SELECT Id_ContratistaDescuento AS IdContratistaDescuento,
                       Id_OperacionGeneral AS IdOperacionGeneral,
                       Id_OperacionGeneralEquipo AS IdOperacionGeneralEquipo,
                       Id_OperacionGeneralPersonal AS IdOperacionGeneralPersonal,
                       Convoy,
                       Id_Personal AS IdPersonal,
                       Descripcion_Cargo AS DescripcionCargo,
                       Cod_Equipo_Tracto AS CodigoEquipoTracto,
                       Cod_Equipo_Carreta AS CodigoEquipoCarreta,
                       CASE WHEN FechaInicio_Plan_OP IS NULL OR FechaInicio_Plan_OP = '' THEN NULL ELSE CONVERT(DATETIME, FechaInicio_Plan_OP, 103) END AS FechaInicioPlanOp,
                       MontoCuota,
                       Activo
                FROM VIEW_CONTRATISTA_DESCUENTO_DescuentoHospedaje
                WHERE Id_OperacionGeneral = {0}
                ORDER BY Convoy, Descripcion_Cargo DESC",
                idOperacionGeneral)
            .ToListAsync();

        return results;
    }
}
