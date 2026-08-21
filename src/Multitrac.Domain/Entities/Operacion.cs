namespace Multitrac.Domain.Entities;

public class Operacion
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
    public int? FactPreUnt { get; set; }
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
