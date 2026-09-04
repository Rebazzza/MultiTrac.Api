using FluentValidation;
using Multitrac.Application.DTOs;

namespace Multitrac.Application.Validators;

public class BaucherCajaValidator : AbstractValidator<BaucherCajaDto>
{
    public BaucherCajaValidator()
    {
        RuleFor(x => x.Total)
            .GreaterThanOrEqualTo(0).When(x => x.Total.HasValue)
            .WithMessage("El total no puede ser negativo");
    }
}

public class BaucherEgresoValidator : AbstractValidator<BaucherEgresoDto>
{
    public BaucherEgresoValidator()
    {
        RuleFor(x => x.ImporteTotal)
            .GreaterThanOrEqualTo(0).When(x => x.ImporteTotal.HasValue)
            .WithMessage("El importe total no puede ser negativo");
    }
}
