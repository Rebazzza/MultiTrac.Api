namespace Multitrac.Domain.Entities;

public class Contratista
{
    public int IdContratista { get; set; }
    public string? NomContratista { get; set; }
    public string? APContratista { get; set; }
    public string? AMContratista { get; set; }
    public string? RazonSocialContratista { get; set; }
    public string? Socio { get; set; }
    public long? RUCContratista { get; set; }
    public string? NomRepLegalContratista { get; set; }
    public string? APRepLegalContratista { get; set; }
    public string? AMRepLegalContratista { get; set; }
    public long? TlfRepLegalContratista { get; set; }
    public long? RPCRepLegalContratista { get; set; }
    public string? RPMRepLegalContratista { get; set; }
    public long? CelRepLegalContratista { get; set; }
    public DateTime? FechNacRepLegalContratista { get; set; }
    public string? EmailRepLegalContratista { get; set; }
    public string? DireccionRepLegalContratista { get; set; }
    public int? Combustible { get; set; }
    public string? NombreProveedorDetraccion { get; set; }
    public int? IdContratistaTipo { get; set; }
    public int? AlertaDocumentos { get; set; }
    public int? AlertaRendimiento { get; set; }
    public int? OperacionObservacion { get; set; }
    public int? ReporteOperaciones { get; set; }
    public int? DescuentoMantto { get; set; }
    public int? DescuentoManttoSup { get; set; }
    public int? PRDCod { get; set; }
}
