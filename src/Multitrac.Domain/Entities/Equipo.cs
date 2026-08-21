namespace Multitrac.Domain.Entities;

public class Equipo
{
    public string TipoEquipo { get; set; } = null!;
    public string CodEquipo { get; set; } = null!;
    public string? CodEllipse { get; set; }
    public string? NoPlaca { get; set; }
    public string? NoPlacaAnt { get; set; }
    public int? Flota { get; set; }
    public string? DescEquipo { get; set; }
    public string? DescAlternativa { get; set; }
    public string? AreaEspecifica { get; set; }
    public int? IdAreaEspec { get; set; }
    public string? AreGnral { get; set; }
    public int? IdAreaGral { get; set; }
    public string? EquipoReemplazar { get; set; }
    public string? Modelo { get; set; }
    public string? AnoFabricacion { get; set; }
    public string? NoSerMotor { get; set; }
    public string? NoSerChasis { get; set; }
    public string? RevisionEquipo { get; set; }
    public string? EstatusEquipo { get; set; }
    public string? NoTarjetaPropiedad { get; set; }
    public string? Soat { get; set; }
    public DateTime? FechaExpedSoat { get; set; }
    public string? FechaCaducidadSoat { get; set; }
    public string? Observaciones { get; set; }
    public double? Horometro { get; set; }
    public string? Sticker { get; set; }
    public string? Marca { get; set; }
    public string? ColorCamioneta { get; set; }
    public string? Tipo { get; set; }
    public string? Egi { get; set; }
    public string? Combustible { get; set; }
    public int? EstatusOp { get; set; }
    public int? GPS { get; set; }
    public decimal? Largo { get; set; }
    public decimal? Ancho { get; set; }
    public decimal? Alto { get; set; }
    public decimal? CargaUtil { get; set; }
    public decimal? KilometrajeMantto { get; set; }
}
