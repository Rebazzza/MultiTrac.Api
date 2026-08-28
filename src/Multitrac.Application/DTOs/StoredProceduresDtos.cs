namespace Multitrac.Application.DTOs;

public class CalcularFleteRequestDto
{
    public int IdOperacion { get; set; }
    public int? IdContratista { get; set; }
    public int? IdTipoCarga { get; set; }
    public int? IdMoneda { get; set; }
    public int? IdUnidad { get; set; }
    public decimal? PesoToneladas { get; set; }
    public decimal? TarifaFlete { get; set; }
    public decimal? TipoCambio { get; set; }
}

public class CalcularFleteResponseDto
{
    public int IdOperacionFlete { get; set; }
    public int IdOperacion { get; set; }
    public int? IdTipoCarga { get; set; }
    public string? TipoCargaNombre { get; set; }
    public int? IdMoneda { get; set; }
    public string? MonedaAbreviatura { get; set; }
    public int? IdUnidad { get; set; }
    public string? UnidadNombre { get; set; }
    public int? IdOperacionTipo { get; set; }
    public string? ConfVeTracto { get; set; }
    public string? ConfVeCarreta { get; set; }
    public decimal? PorcentajeFlete { get; set; }
    public decimal? ValorVentaFlete { get; set; }
    public decimal? ValorReferencial { get; set; }
    public decimal? PesoPromedioTn { get; set; }
    public decimal? ComisionMultitrac { get; set; }
    public decimal? ComisionTerceros { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public string? Estado { get; set; }
    public string? DescOperacion { get; set; }
    public string? NombreCliente { get; set; }
    public string? NombreContratista { get; set; }
}

public class ReporteFacturacionRequestDto
{
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public int IdOperacion { get; set; } = 0;
    public int IdContratista { get; set; } = 0;
    public string Moneda { get; set; } = "0";
    public decimal TipoCambio { get; set; } = 1;
    public int IdCliente { get; set; } = 0;
}

public class ReporteFacturacionResponseDto
{
    public string? NumeroDocumento { get; set; }
    public string? NumeroGuiaRemision { get; set; }
    public string? NumeroGuiaTransportista { get; set; }
    public string? NumeroGuiaRemitente { get; set; }
    public string? CodigoEquipoTracto { get; set; }
    public string? Socio { get; set; }
    public string? DescOperacion { get; set; }
    public DateTime? FechaInicioPlanOp { get; set; }
    public DateTime? FechaRecepcion { get; set; }
    public string? EstadoFacturacion { get; set; }
    public decimal? ValorVenta { get; set; }
    public decimal? Igv { get; set; }
    public decimal? MontoLiquidacion { get; set; }
    public long? IdTr { get; set; }
    public int? IdContratista { get; set; }
    public int? IdGuiaRemision { get; set; }
    public int? IdOperacion { get; set; }
    public int? IdOperacionGeneral { get; set; }
}

public class IndicadoresRequestDto
{
    public int Anio { get; set; }
    public int Mes { get; set; }
}

public class IndicadoresResponseDto
{
    public int Anio { get; set; }
    public string? MesNombre { get; set; }
    public int IdIndicador { get; set; }
    public decimal? Indicador { get; set; }
    public string? NombreIndicador { get; set; }
}

public class ContratistaDescuentoDto
{
    public int IdContratistaDescuento { get; set; }
    public int IdOperacionGeneral { get; set; }
    public int? IdOperacionGeneralEquipo { get; set; }
    public int? IdOperacionGeneralPersonal { get; set; }
    public int? Convoy { get; set; }
    public int? IdPersonal { get; set; }
    public string? DescripcionCargo { get; set; }
    public string? CodigoEquipoTracto { get; set; }
    public string? CodigoEquipoCarreta { get; set; }
    public DateTime? FechaInicioPlanOp { get; set; }
    public decimal? MontoCuota { get; set; }
    public int? Activo { get; set; }
}
