namespace Multitrac.Domain.Entities;

public class OperacionGeneral
{
    public int IdOperacionGeneral { get; set; }
    public int IdOperacion { get; set; }
    public int IdTipoCarga { get; set; }
    public int? IdTipoOperacion { get; set; }
    public DateTime? FechaInicioPlanOp { get; set; }
    public string? HoraInicioPlanOp { get; set; }
    public int? NroConvoy { get; set; }
    public string? Observaciones { get; set; }
    public int? IdLiquidacionContratistaDescuento { get; set; }
    public int? ValidadoGps { get; set; }
    public int? NoAtendido { get; set; }
    public int? TurnoRansa { get; set; }
    public int? EnviarCorreo { get; set; }
    public string? Estado { get; set; }
    public string? Usuario { get; set; }
    public string? UserOrica { get; set; }
    public string? OCOrica { get; set; }
    public string? Estatus { get; set; }
    public string? Turno { get; set; }
    public string? TurnoVerif { get; set; }
    public DateTime? FechaCarga { get; set; }
    public DateTime? FechaGr { get; set; }
    public DateTime? HoraGr { get; set; }
    public string? DetalleMercaderia { get; set; }
    public string? Contenedor { get; set; }
    public string? Proveedor { get; set; }
    public string? PuntoCarga { get; set; }
    public int? IdPuntoCarga { get; set; }
    public string? DemoraSobrestadia { get; set; }
    public string? HoraCita { get; set; }
    public string? HoraLlegada { get; set; }
    public string? HoraInicioCarguio { get; set; }
    public string? HoraFinCarguio { get; set; }
    public string? HoraAStandBy { get; set; }
    public string? HorasStandBy { get; set; }
    public string? GRTransportista { get; set; }
    public DateTime? FechaHoraSalida { get; set; }
    public string? GRRemitente { get; set; }
    public decimal? Peso { get; set; }
    public int? IdUnidadPeso { get; set; }
    public string? GRMultitrac { get; set; }
    public string? Gestor { get; set; }
    public string? PrimerPuntoPernocte { get; set; }
    public int? IdPrimerPuntoPernocte { get; set; }
    public string? PuntoDescarga { get; set; }
    public int? IdPuntoDescarga { get; set; }
    public string? UbActual { get; set; }
    public int? IdUbActual { get; set; }
    public byte[]? TipoUnidad { get; set; }
    public int? IdTipoServicio { get; set; }
    public int? IdClientePrincipal { get; set; }
}
