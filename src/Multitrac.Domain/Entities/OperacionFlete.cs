namespace Multitrac.Domain.Entities;

public class OperacionFlete
{
    public int IdOperacionFlete { get; set; }
    public int? IdOperacion { get; set; }
    public int? IdTipoCarga { get; set; }
    public int? IdMoneda { get; set; }
    public int? IdUnidad { get; set; }
    public int? IdIgv { get; set; }
    public int? IdOperacionTipo { get; set; }
    public string? ConfVeTracto { get; set; }
    public string? ConfVeCarreta { get; set; }
    public decimal? PorcFlete { get; set; }
    public decimal? ValorVentaFlete { get; set; }
    public decimal? ValorReferencial { get; set; }
    public decimal? PesoPromedioTn { get; set; }
    public decimal? ComisionMultitrac { get; set; }
    public int? IdUnidadComisionMultitrac { get; set; }
    public decimal? ComisionTerceros { get; set; }
    public int? IdUnidadComisionTerceros { get; set; }
    public decimal? CalculoComision { get; set; }
    public int? IdUnidadCalculoComsion { get; set; }
    public decimal? CalculoComisionTerceros { get; set; }
    public int? IdUnidadCalculoComisionTerceros { get; set; }
    public decimal? CalculoLiquidez { get; set; }
    public int? IdUnidadCalculoLiquidez { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public string? Estado { get; set; }
}
