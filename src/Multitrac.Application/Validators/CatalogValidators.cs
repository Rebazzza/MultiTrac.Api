using FluentValidation;
using Multitrac.Application.DTOs;

namespace Multitrac.Application.Validators;

public class MonedaValidator : AbstractValidator<MonedaDto>
{
    public MonedaValidator()
    {
        RuleFor(x => x.NombreMoneda)
            .NotEmpty().WithMessage("El nombre de la moneda es requerido")
            .MaximumLength(50).WithMessage("El nombre no puede exceder 50 caracteres");
        
        RuleFor(x => x.AbreviaturaMoneda)
            .MaximumLength(50).WithMessage("La abreviatura no puede exceder 50 caracteres");
    }
}

public class BancoValidator : AbstractValidator<BancoDto>
{
    public BancoValidator()
    {
        RuleFor(x => x.BancoNombre)
            .NotEmpty().WithMessage("El nombre del banco es requerido")
            .MaximumLength(250).WithMessage("El nombre no puede exceder 250 caracteres");
        
        RuleFor(x => x.Observaciones)
            .MaximumLength(250).WithMessage("Las observaciones no pueden exceder 250 caracteres");
    }
}

public class CargoValidator : AbstractValidator<CargoDto>
{
    public CargoValidator()
    {
        RuleFor(x => x.TituloCargo)
            .NotEmpty().WithMessage("El título del cargo es requerido")
            .MaximumLength(50).WithMessage("El título no puede exceder 50 caracteres");
        
        RuleFor(x => x.DescripcionCargo)
            .MaximumLength(50).WithMessage("La descripción no puede exceder 50 caracteres");
    }
}

public class NivelEducativoValidator : AbstractValidator<NivelEducativoDto>
{
    public NivelEducativoValidator()
    {
        RuleFor(x => x.DescripcionNivelEducativo)
            .NotEmpty().WithMessage("La descripción del nivel educativo es requerida")
            .MaximumLength(150).WithMessage("La descripción no puede exceder 150 caracteres");
    }
}

public class AfpValidator : AbstractValidator<AfpDto>
{
    public AfpValidator()
    {
        RuleFor(x => x.NomAfp)
            .NotEmpty().WithMessage("El nombre de la AFP es requerido")
            .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres");
    }
}

public class FlotaValidator : AbstractValidator<FlotaDto>
{
    public FlotaValidator()
    {
        RuleFor(x => x.DescFlota)
            .NotEmpty().WithMessage("La descripción de la flota es requerida")
            .MaximumLength(250).WithMessage("La descripción no puede exceder 250 caracteres");
    }
}

public class ActividadValidator : AbstractValidator<ActividadDto>
{
    public ActividadValidator()
    {
        RuleFor(x => x.Descripcion)
            .NotEmpty().WithMessage("La descripción de la actividad es requerida")
            .MaximumLength(250).WithMessage("La descripción no puede exceder 250 caracteres");
    }
}

public class TurnoValidator : AbstractValidator<TurnoDto>
{
    public TurnoValidator()
    {
        RuleFor(x => x.IdContratista)
            .NotEmpty().WithMessage("El ID del contratista es requerido");
        
        RuleFor(x => x.IdOperacion)
            .NotEmpty().WithMessage("El ID de la operación es requerido");
    }
}

public class TipoPagoValidator : AbstractValidator<TipoPagoDto>
{
    public TipoPagoValidator()
    {
        RuleFor(x => x.DescTipoPago)
            .NotEmpty().WithMessage("La descripción del tipo de pago es requerida")
            .MaximumLength(200).WithMessage("La descripción no puede exceder 200 caracteres");
    }
}

public class TipoOcurrenciaValidator : AbstractValidator<TipoOcurrenciaDto>
{
    public TipoOcurrenciaValidator()
    {
        RuleFor(x => x.TipoOcurrenciaNombre)
            .NotEmpty().WithMessage("El nombre del tipo de ocurrencia es requerido")
            .MaximumLength(50).WithMessage("El nombre no puede exceder 50 caracteres");
    }
}
