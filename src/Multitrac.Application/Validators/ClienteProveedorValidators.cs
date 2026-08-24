using FluentValidation;
using Multitrac.Application.DTOs;

namespace Multitrac.Application.Validators;

public class ClienteValidator : AbstractValidator<ClienteDto>
{
    public ClienteValidator()
    {
        RuleFor(x => x.IdCliente).GreaterThan(0);
    }
}

public class ProveedorValidator : AbstractValidator<ProveedorDto>
{
    public ProveedorValidator()
    {
        RuleFor(x => x.PrvCod).GreaterThan(0);
    }
}

public class AreaValidator : AbstractValidator<AreaDto>
{
    public AreaValidator()
    {
        RuleFor(x => x.AreCod).GreaterThan(0);
    }
}

public class TipoDocumentoValidator : AbstractValidator<TipoDocumentoDto>
{
    public TipoDocumentoValidator()
    {
        RuleFor(x => x.TipCod).GreaterThan(0);
    }
}

public class EmpresaValidator : AbstractValidator<EmpresaDto>
{
    public EmpresaValidator()
    {
        RuleFor(x => x.IdEmpresa).GreaterThan(0);
    }
}
