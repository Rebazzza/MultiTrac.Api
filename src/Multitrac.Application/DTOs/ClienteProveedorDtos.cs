namespace Multitrac.Application.DTOs;

public class ClienteDto
{
    public int IdCliente { get; set; }
    public string? RazonSocialCliente { get; set; }
    public string? ClienteNombre { get; set; }
    public string? RucCliente { get; set; }
    public string? DomicilioFiscalCliente { get; set; }
    public string? TlfCliente { get; set; }
    public int? RpcCliente { get; set; }
    public string? RpmCliente { get; set; }
    public string? EmailCliente { get; set; }
    public string? WebSiteCliente { get; set; }
    public int? DiasDemoraPagoCliente { get; set; }
    public int? FacturacionMultiple { get; set; }
}

public class ProveedorDto
{
    public int PrvCod { get; set; }
    public string? PrvNom { get; set; }
    public string? PrvRuc { get; set; }
    public string? CodUbi { get; set; }
    public string? PrvDir { get; set; }
    public string? PrvRep { get; set; }
    public string? PrvTel { get; set; }
    public string? PrvFax { get; set; }
    public string? PrvCrr { get; set; }
    public string? PrvWeb { get; set; }
    public DateTime? PrvFecAlt { get; set; }
    public DateTime? PrvFecBaj { get; set; }
    public string? PrvObs { get; set; }
    public int? IdBanco { get; set; }
    public string? NroCuenta { get; set; }
    public int? IdBancoDolares { get; set; }
    public string? NroCuentaDolares { get; set; }
}

public class AreaDto
{
    public int AreCod { get; set; }
    public string? AreNom { get; set; }
    public int? SubareCod { get; set; }
    public int? DiaxMes { get; set; }
    public decimal? PagoxMes { get; set; }
    public int? Pertenece { get; set; }
}

public class TipoDocumentoDto
{
    public int TipCod { get; set; }
    public string? TipDoc { get; set; }
}

public class EmpresaDto
{
    public int IdEmpresa { get; set; }
    public string? NomEmpresa { get; set; }
    public long? RucEmpresa { get; set; }
    public string? DescEmpresa { get; set; }
    public string? AreasTrabajo { get; set; }
    public string? Usuario { get; set; }
}
