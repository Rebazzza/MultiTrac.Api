using Multitrac.Application.DTOs;
using Multitrac.Application.Validators;
using Xunit;

namespace Multitrac.UnitTests;

public class MonedaValidatorTests
{
    private readonly MonedaValidator _validator;

    public MonedaValidatorTests()
    {
        _validator = new MonedaValidator();
    }

    [Fact]
    public void Validate_ValidMoneda_ReturnsSuccess()
    {
        var moneda = new MonedaDto
        {
            NombreMoneda = "Soles",
            AbreviaturaMoneda = "S/"
        };

        var result = _validator.Validate(moneda);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validate_EmptyNombre_ReturnsError()
    {
        var moneda = new MonedaDto
        {
            NombreMoneda = "",
            AbreviaturaMoneda = "S/"
        };

        var result = _validator.Validate(moneda);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == "NombreMoneda");
    }

    [Fact]
    public void Validate_NombreTooLong_ReturnsError()
    {
        var moneda = new MonedaDto
        {
            NombreMoneda = new string('A', 51),
            AbreviaturaMoneda = "S/"
        };

        var result = _validator.Validate(moneda);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == "NombreMoneda");
    }
}
