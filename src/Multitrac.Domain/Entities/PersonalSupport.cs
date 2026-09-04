namespace Multitrac.Domain.Entities;

public class PersonalCargo
{
    public int IdPersonalCargo { get; set; }
    public int IdPersonal { get; set; }
    public int IdCargo { get; set; }
    public DateTime? FechaInicioCargo { get; set; }
    public DateTime? FechaFinCargo { get; set; }
    public string? Estado { get; set; }
}

public class PersonalEquipo
{
    public int IdPersonalEquipo { get; set; }
    public int IdPersonal { get; set; }
    public string CodEquipo { get; set; } = null!;
    public DateTime? FechIni { get; set; }
    public DateTime? FechFin { get; set; }
    public int? IdRemplazo { get; set; }
    public string? Estado { get; set; }
}

public class PersonalEpp
{
    public int IdPersonalEpp { get; set; }
    public int? IdPersonal { get; set; }
    public int? IdRequerimientoGeneral { get; set; }
    public string? Talla { get; set; }
    public string? Observacion { get; set; }
    public string? Estado { get; set; }
}

public class PersonalEppKardex
{
    public int IdPersonalEppKardex { get; set; }
    public int? IdPersonalEpp { get; set; }
    public DateTime? FechaEntrega { get; set; }
    public int? IdEppCondicionEntrega { get; set; }
    public DateTime? FechaRevision { get; set; }
    public int? IdEppCondicionRevision { get; set; }
    public DateTime? FechaReposicion { get; set; }
    public int? IdEppCondicionReposicion { get; set; }
    public string? Estado { get; set; }
    public decimal? Cantidad { get; set; }
    public int? IdUndidadCantidad { get; set; }
}

public class PersonalRecord
{
    public int IdPersonalRecord { get; set; }
    public int? IdPersonal { get; set; }
    public int? IdTipoOcurrencia { get; set; }
    public DateTime? FechaOcurrencia { get; set; }
    public string? DescripcionOcurrencia { get; set; }
    public string? MedidasAImplementar { get; set; }
    public int? IdPersonalMedImpl { get; set; }
    public int? RecordInicial { get; set; }
    public int? RecordFinal { get; set; }
    public int? Merito { get; set; }
    public int? Demerito { get; set; }
    public int? IdPersonalVerificacion { get; set; }
    public DateTime? FechaReporte { get; set; }
}

public class PersonalVacaciones
{
    public int IdPersonalVacaciones { get; set; }
    public int? IdPersonal { get; set; }
    public int? PeriodoIni { get; set; }
    public int? PeriodoFin { get; set; }
    public DateTime? FechaIng { get; set; }
    public int? DiasPendientes { get; set; }
    public string? Observaciones { get; set; }
    public string? Estado { get; set; }
}

public class PersonalVacacionesRegistro
{
    public int IdPersonalVacacionesReg { get; set; }
    public int? IdPersonalVacaciones { get; set; }
    public DateTime? FechaSalVac { get; set; }
    public DateTime? FechaRetVac { get; set; }
    public int? DiasVac { get; set; }
    public string? Memo { get; set; }
    public string? Observaciones { get; set; }
    public string? Archivo { get; set; }
}

public class PersonalLicenciaConducir
{
    public int IdLicPersonal { get; set; }
    public string? NombreLicPersonal { get; set; }
    public string? Observaciones { get; set; }
}

public class PersonalSueno
{
    public int IdSueno { get; set; }
    public int? IdPersonal { get; set; }
    public int? IdEmpresa { get; set; }
    public int? IdOperacionGeneral { get; set; }
    public DateTime? Fecha { get; set; }
    public int? Estado { get; set; }
    public string? Sueno { get; set; }
    public int? CHM { get; set; }
    public string? Foto { get; set; }
    public string? Observaciones { get; set; }
}
