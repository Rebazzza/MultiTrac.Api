using Multitrac.Application.DTOs;
using Multitrac.Application.Validators;
using Xunit;

namespace Multitrac.UnitTests;

public class BancoValidatorTests
{
    private readonly BancoValidator _validator;

    public BancoValidatorTests()
    {
        _validator = new BancoValidator();
    }

    [Fact]
    public void Validate_ValidBanco_ReturnsSuccess()
    {
        var banco = new BancoDto
        {
            BancoNombre = "Banco de Crédito del Perú"
        };

        var result = _validator.Validate(banco);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validate_EmptyNombre_ReturnsError()
    {
        var banco = new BancoDto
        {
            BancoNombre = ""
        };

        var result = _validator.Validate(banco);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == "BancoNombre");
    }
}
