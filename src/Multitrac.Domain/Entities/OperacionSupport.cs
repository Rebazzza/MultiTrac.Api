namespace Multitrac.Domain.Entities;

public class OperacionHorario
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

public class OperacionTurno
{
    public int IdOperacionTurno { get; set; }
    public int? IdPersonalRegistro { get; set; }
    public int? IdTurno { get; set; }
    public int? IdOperacion { get; set; }
    public string? Turno { get; set; }
    public DateTime? FechaRegistro { get; set; }
    public string? Observacion { get; set; }
}

public class OperacionCarga
{
    public int IdOperacionCarga { get; set; }
    public int? IdOperacion { get; set; }
    public int? IdTipoCarga { get; set; }
    public string? Estado { get; set; }
}

public class OperacionTipo
{
    public int IdOperacionTipo { get; set; }
    public string? OperacionTipoNombre { get; set; }
    public string? ObservacionTipo { get; set; }
}

public class TipoCarga
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

public class Unidad
{
    public int IdUnidad { get; set; }
    public string? AbreviaturaUnidad { get; set; }
    public string? NombreUnidad { get; set; }
}

public class Convoy
{
    public int IdConvoy { get; set; }
    public int IdOperacion { get; set; }
    public int IdCargo { get; set; }
    public int? NroPersonal { get; set; }
    public int? NroUnidades { get; set; }
    public int? NroConvoys { get; set; }
}
