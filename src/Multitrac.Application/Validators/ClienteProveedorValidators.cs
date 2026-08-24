using FluentValidation;
using Multitrac.Application.DTOs;

namespace Multitrac.Application.Validators;

public class ClienteValidator : AbstractValidator<ClienteDto>
{
    public ClienteValidator()
    {
        RuleFor(x => x.RazonSocialCliente)
            .NotEmpty().WithMessage("La razón social del cliente es requerida")
            .MaximumLength(300).WithMessage("La razón social no puede exceder 300 caracteres");

        RuleFor(x => x.ClienteNombre)
            .MaximumLength(200).WithMessage("El nombre del cliente no puede exceder 200 caracteres");

        RuleFor(x => x.RucCliente)
            .MaximumLength(20).WithMessage("El RUC no puede exceder 20 caracteres");

        RuleFor(x => x.DomicilioFiscalCliente)
            .MaximumLength(300).WithMessage("El domicilio fiscal no puede exceder 300 caracteres");

        RuleFor(x => x.TlfCliente)
            .MaximumLength(30).WithMessage("El teléfono no puede exceder 30 caracteres");

        RuleFor(x => x.EmailCliente)
            .EmailAddress().When(x => !string.IsNullOrEmpty(x.EmailCliente))
            .WithMessage("El email no tiene un formato válido")
            .MaximumLength(200).WithMessage("El email no puede exceder 200 caracteres");

        RuleFor(x => x.WebSiteCliente)
            .MaximumLength(200).WithMessage("El sitio web no puede exceder 200 caracteres");

        RuleFor(x => x.RpmCliente)
            .MaximumLength(20).WithMessage("El RPM no puede exceder 20 caracteres");

        RuleFor(x => x.DiasDemoraPagoCliente)
            .GreaterThanOrEqualTo(0).When(x => x.DiasDemoraPagoCliente.HasValue)
            .WithMessage("Los días de demora de pago no pueden ser negativos");
    }
}

public class ProveedorValidator : AbstractValidator<ProveedorDto>
{
    public ProveedorValidator()
    {
        RuleFor(x => x.PrvNom)
            .NotEmpty().WithMessage("El nombre del proveedor es requerido")
            .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres");

        RuleFor(x => x.PrvRuc)
            .MaximumLength(20).WithMessage("El RUC no puede exceder 20 caracteres");

        RuleFor(x => x.PrvDir)
            .MaximumLength(300).WithMessage("La dirección no puede exceder 300 caracteres");

        RuleFor(x => x.PrvRep)
            .MaximumLength(200).WithMessage("El representante no puede exceder 200 caracteres");

        RuleFor(x => x.PrvTel)
            .MaximumLength(30).WithMessage("El teléfono no puede exceder 30 caracteres");

        RuleFor(x => x.PrvFax)
            .MaximumLength(30).WithMessage("El fax no puede exceder 30 caracteres");

        RuleFor(x => x.PrvCrr)
            .MaximumLength(200).WithMessage("El correo no puede exceder 200 caracteres");

        RuleFor(x => x.PrvWeb)
            .MaximumLength(200).WithMessage("El sitio web no puede exceder 200 caracteres");

        RuleFor(x => x.PrvObs)
            .MaximumLength(500).WithMessage("Las observaciones no pueden exceder 500 caracteres");

        RuleFor(x => x.NroCuenta)
            .MaximumLength(30).WithMessage("El número de cuenta no puede exceder 30 caracteres");

        RuleFor(x => x.NroCuentaDolares)
            .MaximumLength(30).WithMessage("El número de cuenta en dólares no puede exceder 30 caracteres");
    }
}

public class AreaValidator : AbstractValidator<AreaDto>
{
    public AreaValidator()
    {
        RuleFor(x => x.AreNom)
            .NotEmpty().WithMessage("El nombre del área es requerida")
            .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres");

        RuleFor(x => x.DiaxMes)
            .InclusiveBetween(1, 31).When(x => x.DiaxMes.HasValue)
            .WithMessage("Los días por mes deben estar entre 1 y 31");

        RuleFor(x => x.PagoxMes)
            .GreaterThanOrEqualTo(0).When(x => x.PagoxMes.HasValue)
            .WithMessage("El pago por mes no puede ser negativo");
    }
}

public class TipoDocumentoValidator : AbstractValidator<TipoDocumentoDto>
{
    public TipoDocumentoValidator()
    {
        RuleFor(x => x.TipDoc)
            .NotEmpty().WithMessage("La descripción del tipo de documento es requerida")
            .MaximumLength(200).WithMessage("La descripción no puede exceder 200 caracteres");
    }
}

public class EmpresaValidator : AbstractValidator<EmpresaDto>
{
    public EmpresaValidator()
    {
        RuleFor(x => x.NomEmpresa)
            .NotEmpty().WithMessage("El nombre de la empresa es requerido")
            .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres");

        RuleFor(x => x.RucEmpresa)
            .InclusiveBetween(10000000000, 99999999999).When(x => x.RucEmpresa.HasValue)
            .WithMessage("El RUC debe tener 11 dígitos");

        RuleFor(x => x.DescEmpresa)
            .MaximumLength(500).WithMessage("La descripción no puede exceder 500 caracteres");

        RuleFor(x => x.AreasTrabajo)
            .MaximumLength(500).WithMessage("Las áreas de trabajo no pueden exceder 500 caracteres");

        RuleFor(x => x.Usuario)
            .MaximumLength(50).WithMessage("El usuario no puede exceder 50 caracteres");
    }
}
