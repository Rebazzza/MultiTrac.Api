namespace Multitrac.Domain.Entities;

public class OperacionInforme
{
    public int IdOperacionInforme { get; set; }
    public int? IdOperacionGeneral { get; set; }
    public int? Convoy { get; set; }
    public DateTime? FechaInforme { get; set; }
    public DateTime? FechaSalida { get; set; }
    public string? HoraSalida { get; set; }
    public DateTime? FechaLlegada { get; set; }
    public string? HoraLlegada { get; set; }
    public string? Informe { get; set; }
    public string? InformeMantto { get; set; }
    public bool? Evento { get; set; }
    public int? IdClasificacionIncident { get; set; }
    public string? DescripcionIncident { get; set; }
    public int? IdConsecuencia { get; set; }
    public int? RequiereInvestigacion { get; set; }
    public string? DescripcionReqInv { get; set; }
}
