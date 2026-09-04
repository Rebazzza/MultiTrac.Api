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

public class PersonalRecordValidator : AbstractValidator<PersonalRecordDto>
{
    public PersonalRecordValidator()
    {
        RuleFor(x => x.IdPersonal)
            .GreaterThan(0).When(x => x.IdPersonal.HasValue)
            .WithMessage("El personal no es válido");

        RuleFor(x => x.DescripcionOcurrencia)
            .MaximumLength(1000).WithMessage("La descripción no puede exceder 1000 caracteres");

        RuleFor(x => x.MedidasAImplementar)
            .MaximumLength(1000).WithMessage("Las medidas a implementar no pueden exceder 1000 caracteres");

        RuleFor(x => x.RecordInicial)
            .GreaterThanOrEqualTo(0).When(x => x.RecordInicial.HasValue)
            .WithMessage("El record inicial no puede ser negativo");

        RuleFor(x => x.RecordFinal)
            .GreaterThanOrEqualTo(0).When(x => x.RecordFinal.HasValue)
            .WithMessage("El record final no puede ser negativo");

        RuleFor(x => x.Merito)
            .GreaterThanOrEqualTo(0).When(x => x.Merito.HasValue)
            .WithMessage("El mérito no puede ser negativo");

        RuleFor(x => x.Demerito)
            .GreaterThanOrEqualTo(0).When(x => x.Demerito.HasValue)
            .WithMessage("El demérito no puede ser negativo");
    }
}

public class PersonalEquipoValidator : AbstractValidator<PersonalEquipoDto>
{
    public PersonalEquipoValidator()
    {
        RuleFor(x => x.IdPersonal)
            .GreaterThan(0).WithMessage("El personal es requerido");

        RuleFor(x => x.CodEquipo)
            .NotEmpty().WithMessage("El código del equipo es requerido")
            .MaximumLength(50).WithMessage("El código del equipo no puede exceder 50 caracteres");

        RuleFor(x => x.Estado)
            .MaximumLength(20).WithMessage("El estado no puede exceder 20 caracteres");
    }
}

public class PersonalEppValidator : AbstractValidator<PersonalEppDto>
{
    public PersonalEppValidator()
    {
        RuleFor(x => x.IdPersonal)
            .GreaterThan(0).When(x => x.IdPersonal.HasValue)
            .WithMessage("El personal no es válido");

        RuleFor(x => x.IdRequerimientoGeneral)
            .GreaterThan(0).When(x => x.IdRequerimientoGeneral.HasValue)
            .WithMessage("El requerimiento general no es válido");

        RuleFor(x => x.Talla)
            .MaximumLength(20).WithMessage("La talla no puede exceder 20 caracteres");

        RuleFor(x => x.Observacion)
            .MaximumLength(500).WithMessage("La observación no puede exceder 500 caracteres");

        RuleFor(x => x.Estado)
            .MaximumLength(20).WithMessage("El estado no puede exceder 20 caracteres");
    }
}

public class PersonalEppKardexValidator : AbstractValidator<PersonalEppKardexDto>
{
    public PersonalEppKardexValidator()
    {
        RuleFor(x => x.IdPersonalEpp)
            .GreaterThan(0).When(x => x.IdPersonalEpp.HasValue)
            .WithMessage("El personal EPP no es válido");

        RuleFor(x => x.IdEppCondicionEntrega)
            .GreaterThan(0).When(x => x.IdEppCondicionEntrega.HasValue)
            .WithMessage("La condición de entrega no es válida");

        RuleFor(x => x.IdEppCondicionRevision)
            .GreaterThan(0).When(x => x.IdEppCondicionRevision.HasValue)
            .WithMessage("La condición de revisión no es válida");

        RuleFor(x => x.IdEppCondicionReposicion)
            .GreaterThan(0).When(x => x.IdEppCondicionReposicion.HasValue)
            .WithMessage("La condición de reposición no es válida");

        RuleFor(x => x.Cantidad)
            .GreaterThanOrEqualTo(0).When(x => x.Cantidad.HasValue)
            .WithMessage("La cantidad no puede ser negativa");

        RuleFor(x => x.IdUndidadCantidad)
            .GreaterThan(0).When(x => x.IdUndidadCantidad.HasValue)
            .WithMessage("La unidad de cantidad no es válida");

        RuleFor(x => x.Estado)
            .MaximumLength(20).WithMessage("El estado no puede exceder 20 caracteres");
    }
}

public class PersonalVacacionesRegistroValidator : AbstractValidator<PersonalVacacionesRegistroDto>
{
    public PersonalVacacionesRegistroValidator()
    {
        RuleFor(x => x.IdPersonalVacaciones)
            .GreaterThan(0).When(x => x.IdPersonalVacaciones.HasValue)
            .WithMessage("Las vacaciones no son válidas");

        RuleFor(x => x.DiasVac)
            .GreaterThan(0).When(x => x.DiasVac.HasValue)
            .WithMessage("Los días de vacaciones deben ser mayores a 0");

        RuleFor(x => x.Memo)
            .MaximumLength(200).WithMessage("El memo no puede exceder 200 caracteres");

        RuleFor(x => x.Observaciones)
            .MaximumLength(500).WithMessage("Las observaciones no pueden exceder 500 caracteres");

        RuleFor(x => x.Archivo)
            .MaximumLength(500).WithMessage("El archivo no puede exceder 500 caracteres");
    }
}

public class PersonalLicenciaConducirValidator : AbstractValidator<PersonalLicenciaConducirDto>
{
    public PersonalLicenciaConducirValidator()
    {
        RuleFor(x => x.NombreLicPersonal)
            .NotEmpty().WithMessage("El nombre de la licencia es requerido")
            .MaximumLength(200).WithMessage("El nombre de la licencia no puede exceder 200 caracteres");

        RuleFor(x => x.Observaciones)
            .MaximumLength(500).WithMessage("Las observaciones no pueden exceder 500 caracteres");
    }
}

public class PersonalSuenoValidator : AbstractValidator<PersonalSuenoDto>
{
    public PersonalSuenoValidator()
    {
        RuleFor(x => x.IdPersonal)
            .GreaterThan(0).When(x => x.IdPersonal.HasValue)
            .WithMessage("El personal no es válido");

        RuleFor(x => x.IdEmpresa)
            .GreaterThan(0).When(x => x.IdEmpresa.HasValue)
            .WithMessage("La empresa no es válida");

        RuleFor(x => x.IdOperacionGeneral)
            .GreaterThan(0).When(x => x.IdOperacionGeneral.HasValue)
            .WithMessage("La operación general no es válida");

        RuleFor(x => x.Sueno)
            .MaximumLength(1000).WithMessage("El sueño no puede exceder 1000 caracteres");

        RuleFor(x => x.Foto)
            .MaximumLength(500).WithMessage("La foto no puede exceder 500 caracteres");

        RuleFor(x => x.Observaciones)
            .MaximumLength(500).WithMessage("Las observaciones no pueden exceder 500 caracteres");
    }
}
