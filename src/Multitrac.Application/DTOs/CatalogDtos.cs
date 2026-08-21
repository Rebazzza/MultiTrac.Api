namespace Multitrac.Application.DTOs;

public class MonedaDto
{
    public int IdMoneda { get; set; }
    public string? NombreMoneda { get; set; }
    public string? AbreviaturaMoneda { get; set; }
}

public class BancoDto
{
    public int IdBanco { get; set; }
    public string? BancoNombre { get; set; }
    public string? Observaciones { get; set; }
}

public class CargoDto
{
    public int IdCargo { get; set; }
    public string? TituloCargo { get; set; }
    public string? DescripcionCargo { get; set; }
    public int? CrgCod { get; set; }
    public int? AreCod { get; set; }
    public string? CrgNom { get; set; }
    public string? CrgCer { get; set; }
    public string? CrgAdc { get; set; }
    public string? CrgExp { get; set; }
    public string? CrgPer { get; set; }
    public string? CrgObs { get; set; }
    public string? CtrlAsist { get; set; }
}

public class NivelEducativoDto
{
    public int IdNivelEducativo { get; set; }
    public int? CodInterno { get; set; }
    public string? DescripcionNivelEducativo { get; set; }
    public int? IdGradoInstruccion { get; set; }
}

public class AfpDto
{
    public int IdAfp { get; set; }
    public string? CodigoExcel { get; set; }
    public string? NomAfp { get; set; }
    public decimal? Comision { get; set; }
    public string? Estado { get; set; }
    public string? Observacion { get; set; }
}

public class FlotaDto
{
    public int IdFlota { get; set; }
    public string? DescFlota { get; set; }
    public string? Nivel { get; set; }
    public decimal? Budget { get; set; }
    public string? Tipo { get; set; }
    public int? PersEq { get; set; }
}

public class ActividadDto
{
    public int IdActividad { get; set; }
    public string? Descripcion { get; set; }
}

public class TurnoDto
{
    public int IdTurno { get; set; }
    public int IdContratista { get; set; }
    public int IdOperacion { get; set; }
    public int? PosicionTurno { get; set; }
    public DateTime? FechInicTurno { get; set; }
    public DateTime? FechFinTurno { get; set; }
    public string? Estado { get; set; }
}

public class TipoPagoDto
{
    public int IdTipoPago { get; set; }
    public string? DescTipoPago { get; set; }
    public string? Observaciones { get; set; }
}

public class TipoOcurrenciaDto
{
    public int IdTipoOcurrencia { get; set; }
    public string? TipoOcurrenciaNombre { get; set; }
    public string? Observaciones { get; set; }
}
