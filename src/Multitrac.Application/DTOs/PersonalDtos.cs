namespace Multitrac.Application.DTOs;

public class PersonalDto
{
    public int IdPersonal { get; set; }
    public int? EmpCod { get; set; }
    public int IdContratista { get; set; }
    public int IdNivelEducativo { get; set; }
    public string? FotPersonal { get; set; }
    public string? DniPersonal { get; set; }
    public string? ApPersonal { get; set; }
    public string? AmPersonal { get; set; }
    public string? NomPersonal { get; set; }
    public string? LicPersonal { get; set; }
    public int? IdLicPersonal { get; set; }
    public string? TlfPesronal { get; set; }
    public string? RpcPersonal { get; set; }
    public string? RpmPersonal { get; set; }
    public string? CelPersonal { get; set; }
    public DateTime? FechNacPersonal { get; set; }
    public string? SexoPersonal { get; set; }
    public string? EmailPersonal { get; set; }
    public string? FotoPersonal { get; set; }
    public string? EstadoCivilPersonal { get; set; }
    public string? PasaportePersonal { get; set; }
    public DateTime? FechaAdmitidoPersonal { get; set; }
    public DateTime? FechaBajaPersonal { get; set; }
    public decimal? SueldoBrutoPersonal { get; set; }
    public string? Sctr { get; set; }
    public string? UsuarioPersonal { get; set; }
    public string? Cussp { get; set; }
    public int? AfpPersonal { get; set; }
    public DateTime? FechaIngresoAfp { get; set; }
    public string? EsaludAutoGenerado { get; set; }
    public string? LugarResidenciaPersonal { get; set; }
    public string? LugarNacimientoPersonal { get; set; }
    public string? DireccionPersonal { get; set; }
    public int? StatusOp { get; set; }
    public int? Requerimientos { get; set; }
    public string? Firma { get; set; }
}

public class PersonalCargoDto
{
    public int IdPersonalCargo { get; set; }
    public int IdPersonal { get; set; }
    public int IdCargo { get; set; }
    public DateTime? FechaInicioCargo { get; set; }
    public DateTime? FechaFinCargo { get; set; }
    public string? Estado { get; set; }
}

public class PersonalEquipoDto
{
    public int IdPersonalEquipo { get; set; }
    public int IdPersonal { get; set; }
    public string CodEquipo { get; set; } = null!;
    public DateTime? FechIni { get; set; }
    public DateTime? FechFin { get; set; }
    public int? IdRemplazo { get; set; }
    public string? Estado { get; set; }
}

public class PersonalEppDto
{
    public int IdPersonalEpp { get; set; }
    public int? IdPersonal { get; set; }
    public int? IdRequerimientoGeneral { get; set; }
    public string? Talla { get; set; }
    public string? Observacion { get; set; }
    public string? Estado { get; set; }
}

public class PersonalEppKardexDto
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

public class PersonalRecordDto
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

public class PersonalVacacionesDto
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

public class PersonalVacacionesRegistroDto
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

public class PersonalLicenciaConducirDto
{
    public int IdLicPersonal { get; set; }
    public string? NombreLicPersonal { get; set; }
    public string? Observaciones { get; set; }
}

public class PersonalSuenoDto
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

public class ContratistaDto
{
    public int IdContratista { get; set; }
    public string? NomContratista { get; set; }
    public string? APContratista { get; set; }
    public string? AMContratista { get; set; }
    public string? RazonSocialContratista { get; set; }
    public string? Socio { get; set; }
    public long? RUCContratista { get; set; }
    public string? NomRepLegalContratista { get; set; }
    public string? EmailRepLegalContratista { get; set; }
    public string? DireccionRepLegalContratista { get; set; }
    public int? Combustible { get; set; }
    public string? NombreProveedorDetraccion { get; set; }
    public int? IdContratistaTipo { get; set; }
}
