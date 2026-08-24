using FluentValidation;
using Multitrac.Application.DTOs;

namespace Multitrac.Application.Validators;

public class PersonalValidator : AbstractValidator<PersonalDto>
{
    public PersonalValidator()
    {
        RuleFor(x => x.IdContratista)
            .GreaterThan(0).WithMessage("El contratista es requerido");

        RuleFor(x => x.NomPersonal)
            .NotEmpty().WithMessage("El nombre del personal es requerido")
            .MaximumLength(100).WithMessage("El nombre no puede exceder 100 caracteres");

        RuleFor(x => x.ApPersonal)
            .MaximumLength(100).WithMessage("El apellido paterno no puede exceder 100 caracteres");

        RuleFor(x => x.AmPersonal)
            .MaximumLength(100).WithMessage("El apellido materno no puede exceder 100 caracteres");

        RuleFor(x => x.DniPersonal)
            .MaximumLength(20).WithMessage("El DNI no puede exceder 20 caracteres");

        RuleFor(x => x.SexoPersonal)
            .MaximumLength(10).WithMessage("El sexo no puede exceder 10 caracteres");

        RuleFor(x => x.EmailPersonal)
            .EmailAddress().When(x => !string.IsNullOrEmpty(x.EmailPersonal))
            .WithMessage("El email no tiene un formato válido")
            .MaximumLength(200).WithMessage("El email no puede exceder 200 caracteres");

        RuleFor(x => x.EstadoCivilPersonal)
            .MaximumLength(20).WithMessage("El estado civil no puede exceder 20 caracteres");

        RuleFor(x => x.SueldoBrutoPersonal)
            .GreaterThanOrEqualTo(0).When(x => x.SueldoBrutoPersonal.HasValue)
            .WithMessage("El sueldo bruto no puede ser negativo");

        RuleFor(x => x.TlfPesronal)
            .MaximumLength(30).WithMessage("El teléfono no puede exceder 30 caracteres");

        RuleFor(x => x.CelPersonal)
            .MaximumLength(30).WithMessage("El celular no puede exceder 30 caracteres");

        RuleFor(x => x.DireccionPersonal)
            .MaximumLength(300).WithMessage("La dirección no puede exceder 300 caracteres");

        RuleFor(x => x.LugarResidenciaPersonal)
            .MaximumLength(200).WithMessage("El lugar de residencia no puede exceder 200 caracteres");

        RuleFor(x => x.LugarNacimientoPersonal)
            .MaximumLength(200).WithMessage("El lugar de nacimiento no puede exceder 200 caracteres");

        RuleFor(x => x.UsuarioPersonal)
            .MaximumLength(50).WithMessage("El usuario no puede exceder 50 caracteres");

        RuleFor(x => x.Cussp)
            .MaximumLength(20).WithMessage("El CUSSP no puede exceder 20 caracteres");

        RuleFor(x => x.RpcPersonal)
            .MaximumLength(20).WithMessage("El RPC no puede exceder 20 caracteres");

        RuleFor(x => x.RpmPersonal)
            .MaximumLength(20).WithMessage("El RPM no puede exceder 20 caracteres");
    }
}

public class PersonalCargoValidator : AbstractValidator<PersonalCargoDto>
{
    public PersonalCargoValidator()
    {
        RuleFor(x => x.IdPersonal)
            .GreaterThan(0).WithMessage("El personal es requerido");

        RuleFor(x => x.IdCargo)
            .GreaterThan(0).WithMessage("El cargo es requerido");

        RuleFor(x => x.Estado)
            .MaximumLength(20).WithMessage("El estado no puede exceder 20 caracteres");
    }
}

public class PersonalVacacionesValidator : AbstractValidator<PersonalVacacionesDto>
{
    public PersonalVacacionesValidator()
    {
        RuleFor(x => x.IdPersonal)
            .GreaterThan(0).WithMessage("El personal es requerido");

        RuleFor(x => x.PeriodoIni)
            .InclusiveBetween(2000, 2100).When(x => x.PeriodoIni.HasValue)
            .WithMessage("El periodo inicio debe ser un año válido");

        RuleFor(x => x.PeriodoFin)
            .InclusiveBetween(2000, 2100).When(x => x.PeriodoFin.HasValue)
            .WithMessage("El periodo fin debe ser un año válido");

        RuleFor(x => x.DiasPendientes)
            .GreaterThanOrEqualTo(0).When(x => x.DiasPendientes.HasValue)
            .WithMessage("Los días pendientes no pueden ser negativos");

        RuleFor(x => x.Observaciones)
            .MaximumLength(500).WithMessage("Las observaciones no pueden exceder 500 caracteres");

        RuleFor(x => x.Estado)
            .MaximumLength(20).WithMessage("El estado no puede exceder 20 caracteres");
    }
}

public class ContratistaValidator : AbstractValidator<ContratistaDto>
{
    public ContratistaValidator()
    {
        RuleFor(x => x.NomContratista)
            .NotEmpty().WithMessage("El nombre del contratista es requerido")
            .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres");

        RuleFor(x => x.RazonSocialContratista)
            .MaximumLength(300).WithMessage("La razón social no puede exceder 300 caracteres");

        RuleFor(x => x.APContratista)
            .MaximumLength(100).WithMessage("El apellido paterno no puede exceder 100 caracteres");

        RuleFor(x => x.AMContratista)
            .MaximumLength(100).WithMessage("El apellido materno no puede exceder 100 caracteres");

        RuleFor(x => x.Socio)
            .MaximumLength(100).WithMessage("El socio no puede exceder 100 caracteres");

        RuleFor(x => x.RUCContratista)
            .InclusiveBetween(10000000000, 99999999999).When(x => x.RUCContratista.HasValue)
            .WithMessage("El RUC debe tener 11 dígitos");

        RuleFor(x => x.NomRepLegalContratista)
            .MaximumLength(200).WithMessage("El nombre del representante legal no puede exceder 200 caracteres");

        RuleFor(x => x.EmailRepLegalContratista)
            .EmailAddress().When(x => !string.IsNullOrEmpty(x.EmailRepLegalContratista))
            .WithMessage("El email del representante legal no tiene un formato válido")
            .MaximumLength(200).WithMessage("El email no puede exceder 200 caracteres");

        RuleFor(x => x.DireccionRepLegalContratista)
            .MaximumLength(300).WithMessage("La dirección del representante legal no puede exceder 300 caracteres");

        RuleFor(x => x.NombreProveedorDetraccion)
            .MaximumLength(200).WithMessage("El nombre del proveedor de detracción no puede exceder 200 caracteres");
    }
}
