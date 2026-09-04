namespace Multitrac.Application.DTOs;

public class BaucherCajaDto
{
    public int IdBaucherCaja { get; set; }
    public DateTime? FechaDoc { get; set; }
    public string? Concepto { get; set; }
    public decimal? Total { get; set; }
    public string? Estado { get; set; }
}

public class BaucherEgresoDto
{
    public int IdBaucherEgresos { get; set; }
    public string? NroBaucher { get; set; }
    public DateTime? FechaBaucher { get; set; }
    public decimal? ImporteTotal { get; set; }
    public string? Referencia { get; set; }
}
