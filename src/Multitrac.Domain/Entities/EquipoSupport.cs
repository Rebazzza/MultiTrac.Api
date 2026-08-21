namespace Multitrac.Domain.Entities;

public class EquipoDocumentoTracto
{
    public int IdEquipoDocumentoTracto { get; set; }
    public string? CodEquipo { get; set; }
    public int? IdDocumento { get; set; }
    public DateTime? FechaEmision { get; set; }
    public DateTime? FechaVencimiento { get; set; }
    public string? NroDocumento { get; set; }
    public string? Observaciones { get; set; }
    public int? Estado { get; set; }
}

public class EquipoDocumentoCarreta
{
    public int IdEquipoDocumentoCarreta { get; set; }
    public string? CodEquipo { get; set; }
    public int? IdDocumento { get; set; }
    public DateTime? FechaEmision { get; set; }
    public DateTime? FechaVencimiento { get; set; }
    public string? NroDocumento { get; set; }
    public string? Observaciones { get; set; }
    public int? Estado { get; set; }
}

public class EquipoCombustible
{
    public int IdCombustibleEquipo { get; set; }
    public int? IdOperacionGeneralEquipo { get; set; }
    public int? IdOperacionGeneralPersonal { get; set; }
    public int? IdPersonal { get; set; }
    public string? CodEquipo { get; set; }
    public int? IdGrifo { get; set; }
    public string? NumVale { get; set; }
    public string? NumValeGrifo { get; set; }
    public DateTime? FechaVale { get; set; }
    public int? IdCombustible { get; set; }
    public decimal? Cantidad { get; set; }
    public int? IdUnidad { get; set; }
    public string? Motivo { get; set; }
    public int? IdContratista { get; set; }
    public string? RUCContratista { get; set; }
    public int? IdAutorizado { get; set; }
    public int? IdVB { get; set; }
    public DateTime? FechaDespacho { get; set; }
    public string? HoraDespacho { get; set; }
    public decimal? KilometrajeDespacho { get; set; }
    public DateTime? FechaRetorno { get; set; }
    public int? Tipo { get; set; }
    public decimal? CantidadContabilidad { get; set; }
    public long? IdTr { get; set; }
    public int? IdLiquidacionContratistaDescuento { get; set; }
    public int? IdCombustibleEquipoFactura { get; set; }
    public string? NroCheque { get; set; }
    public DateTime? FechaCheque { get; set; }
    public int? IdBancoCheque { get; set; }
    public int? IdUsuarioRegistro { get; set; }
    public DateTime? FechaRegistro { get; set; }
    public decimal? CostoUnitario { get; set; }
    public decimal? Descuento { get; set; }
    public decimal? Costo { get; set; }
    public int? IdMoneda { get; set; }
    public int? IdBaucherCaja { get; set; }
    public int? IdBaucherEgresos { get; set; }
}

public class EquipoKilometraje
{
    public int IdEquipoKilometraje { get; set; }
    public string? CodEquipo { get; set; }
    public string? Acoplado { get; set; }
    public DateTime? Fecha { get; set; }
    public decimal? Kilometraje { get; set; }
    public string? Observacion { get; set; }
}

public class EquipoMantenimiento
{
    public int IdEquipoMantenimiento { get; set; }
    public string? CodEquipo { get; set; }
    public string? Acoplado { get; set; }
    public DateTime? FechaIngreso { get; set; }
    public string? HoraIngreso { get; set; }
    public DateTime? FechaEstimadaSalida { get; set; }
    public string? HoraEstimadaSalida { get; set; }
    public DateTime? FechaSalida { get; set; }
    public string? HoraSalida { get; set; }
    public double? KilometrajeIngreso { get; set; }
    public int? IdTipoMantto { get; set; }
    public int? IdManttoPM { get; set; }
    public int? IdPersonaResponsable { get; set; }
    public int? CantidadTrabajos { get; set; }
    public int? IdMarca { get; set; }
    public int? IdEquipoEstadoGeneral { get; set; }
    public string? NroOrden { get; set; }
    public string? Url { get; set; }
}

public class EquipoMantenimientoDetalle
{
    public int IdEquipoMantenimientoDetalle { get; set; }
    public int? IdEquipoMantenimiento { get; set; }
    public int? IdEquipoUbicacionMantto { get; set; }
    public int? IdTipoMantto { get; set; }
    public string? CodigoSistema { get; set; }
    public int? CheckPMCartilla { get; set; }
    public int? IdManttoPMCartilla { get; set; }
    public DateTime? FechaIngreso { get; set; }
    public string? HoraIngreso { get; set; }
    public DateTime? FechaSalida { get; set; }
    public string? HoraSalida { get; set; }
    public int? IdEquipoEstadoGeneral { get; set; }
    public string? DescripcionTrabajo { get; set; }
    public int? IdPersonaTrabajo { get; set; }
}
