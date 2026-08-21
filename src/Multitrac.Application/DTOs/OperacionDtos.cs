namespace Multitrac.Application.DTOs;

public class OperacionDto
{
    public int IdOperacion { get; set; }
    public string? DescOperacion { get; set; }
    public int? HhTransporteProm { get; set; }
    public int? HhTrabajoProm { get; set; }
    public int OIdUbicacionOp { get; set; }
    public int DIdUbicacionOp { get; set; }
    public int? IdTipoCarga { get; set; }
    public decimal? Dimension { get; set; }
    public decimal? Peso { get; set; }
    public int IdUnidad { get; set; }
    public decimal? KilometrajeRecorrido { get; set; }
    public decimal? CostoFlete { get; set; }
    public int? Convoy { get; set; }
    public int? Orden { get; set; }
    public int? TipoOperacion { get; set; }
    public int? Ploteo { get; set; }
    public int? FechaSalidaManual { get; set; }
    public int? FacturacionMultitrac { get; set; }
    public string? Origen { get; set; }
    public string? Origen1 { get; set; }
    public string? Origen2 { get; set; }
    public string? Origen3 { get; set; }
    public string? Destino { get; set; }
    public string? Destino1 { get; set; }
    public string? Destino2 { get; set; }
    public string? Destino3 { get; set; }
    public decimal? ValorRefrencial { get; set; }
    public int? FactPlacas { get; set; }
    public int? FactCant { get; set; }
    public int? FactUnid { get; set; }
    public int? FactGTr { get; set; }
    public decimal? FactPreUnt { get; set; }
    public int? FactConf { get; set; }
    public int? FactDestino { get; set; }
    public int? LiqTipo { get; set; }
    public int? Estiba { get; set; }
    public int? DescuentoHospedaje { get; set; }
    public double? LatCentroGIda { get; set; }
    public double? LngCentroGIda { get; set; }
    public int? ZoomGIda { get; set; }
    public double? LatCentroGVuelta { get; set; }
    public double? LngCentroGVuelta { get; set; }
    public int? ZoomGVuelta { get; set; }
    public int? GuiaRemisionPolicia { get; set; }
    public int? TipoFechaHoraVuelta { get; set; }
    public int? OperRep { get; set; }
    public string? TipoProducto { get; set; }
    public string? RutaPrincipal { get; set; }
    public string? RutaAlterna { get; set; }
    public string? RutaNoAutorizada { get; set; }
    public string? Camino { get; set; }
}

public class OperacionGeneralDto
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
}

public class OperacionGeneralEquipoDto
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
    public string? Estado { get; set; }
}

public class OperacionFleteDto
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
    public decimal? ComisionTerceros { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public string? Estado { get; set; }
}

public class OperacionInformeDto
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
}

public class OperacionHorarioDto
{
    public int IdHorarioOperacion { get; set; }
    public int IdOperacion { get; set; }
    public string? HoraInicio { get; set; }
    public string? HoraFin { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public string? Estado { get; set; }
    public int? IdUbicacionOp { get; set; }
    public int? Tipo { get; set; }
}

public class OperacionTurnoDto
{
    public int IdOperacionTurno { get; set; }
    public int? IdPersonalRegistro { get; set; }
    public int? IdTurno { get; set; }
    public int? IdOperacion { get; set; }
    public string? Turno { get; set; }
    public DateTime? FechaRegistro { get; set; }
    public string? Observacion { get; set; }
}

public class OperacionCargaDto
{
    public int IdOperacionCarga { get; set; }
    public int? IdOperacion { get; set; }
    public int? IdTipoCarga { get; set; }
    public string? Estado { get; set; }
}

public class OperacionTipoDto
{
    public int IdOperacionTipo { get; set; }
    public string? OperacionTipoNombre { get; set; }
    public string? ObservacionTipo { get; set; }
}

public class TipoCargaDto
{
    public int IdTipoCarga { get; set; }
    public string? NombreTipoCarga { get; set; }
    public string? DescripcionTipoCarga { get; set; }
    public string? NomInsumoQuimicoFiscalizado { get; set; }
    public string? NomInsumoComercial { get; set; }
    public decimal? Concentracion { get; set; }
    public string? ProveedorCertificado { get; set; }
    public string? ProveedorDireccionEmbarque { get; set; }
    public string? PropietarioCertificado { get; set; }
    public string? PropietarioDireccionEntrega { get; set; }
    public int? IdTipoProducto { get; set; }
    public string? CodigoSunat { get; set; }
}

public class UnidadDto
{
    public int IdUnidad { get; set; }
    public string? AbreviaturaUnidad { get; set; }
    public string? NombreUnidad { get; set; }
}

public class ConvoyDto
{
    public int IdConvoy { get; set; }
    public int IdOperacion { get; set; }
    public int IdCargo { get; set; }
    public int? NroPersonal { get; set; }
    public int? NroUnidades { get; set; }
    public int? NroConvoys { get; set; }
}
