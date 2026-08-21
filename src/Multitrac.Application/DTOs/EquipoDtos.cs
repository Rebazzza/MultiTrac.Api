namespace Multitrac.Application.DTOs;

public class EquipoDto
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

public class EquipoCombustibleDto
{
    public int IdCombustibleEquipo { get; set; }
    public int? IdOperacionGeneralEquipo { get; set; }
    public int? IdPersonal { get; set; }
    public string? CodEquipo { get; set; }
    public int? IdGrifo { get; set; }
    public string? NumVale { get; set; }
    public DateTime? FechaVale { get; set; }
    public int? IdCombustible { get; set; }
    public decimal? Cantidad { get; set; }
    public int? IdUnidad { get; set; }
    public string? Motivo { get; set; }
    public int? IdContratista { get; set; }
    public DateTime? FechaDespacho { get; set; }
    public string? HoraDespacho { get; set; }
    public decimal? KilometrajeDespacho { get; set; }
    public DateTime? FechaRetorno { get; set; }
    public int? Tipo { get; set; }
    public decimal? CostoUnitario { get; set; }
    public decimal? Descuento { get; set; }
    public decimal? Costo { get; set; }
    public int? IdMoneda { get; set; }
}

public class EquipoKilometrajeDto
{
    public int IdEquipoKilometraje { get; set; }
    public string? CodEquipo { get; set; }
    public string? Acoplado { get; set; }
    public DateTime? Fecha { get; set; }
    public decimal? Kilometraje { get; set; }
    public string? Observacion { get; set; }
}

public class EquipoMantenimientoDto
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

public class EquipoMantenimientoDetalleDto
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

public class EquipoDocumentoTractoDto
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

public class EquipoDocumentoCarretaDto
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
