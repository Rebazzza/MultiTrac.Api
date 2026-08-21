namespace Multitrac.Domain.Entities;

public class OperacionGeneralEquipo
{
    public int IdOperacionGeneralEquipo { get; set; }
    public int IdOperacionGeneral { get; set; }
    public int? Convoy { get; set; }
    public int? Posicion { get; set; }
    public string CodEquipoTracto { get; set; } = null!;
    public string CodEquipoCarreta { get; set; } = null!;
    public int? CarretaTercero { get; set; }
    public int IdPersonal { get; set; }
    public int? KmUltimo { get; set; }
    public int? KmSalida { get; set; }
    public int? KmFinal { get; set; }
    public string? Carga { get; set; }
    public string? Tipo { get; set; }
    public int? PorcentajeCarga { get; set; }
    public string? Observaciones { get; set; }
    public int? Combustible { get; set; }
    public int? GuiaRemision { get; set; }
    public int? CheckListMantto { get; set; }
    public DateTime? FechaCheckListMantto { get; set; }
    public string? HoraCheckListMantto { get; set; }
    public int? EqOpeCheckListMantto { get; set; }
    public int? IdPersonalCheckListMantto { get; set; }
    public string? ObsCheckListMantto { get; set; }
    public int? CheckListPdP { get; set; }
    public DateTime? FechaCheckListPdP { get; set; }
    public string? HoraCheckListPdP { get; set; }
    public int? EqOpeCheckListPdP { get; set; }
    public int? IdPersonalCheckListPdP { get; set; }
    public string? ObsCheckListPdP { get; set; }
    public int? IdOperacionGeneralEstado { get; set; }
    public string? OperacionInformeMantto { get; set; }
    public string? OperacionInformePdP { get; set; }
}
