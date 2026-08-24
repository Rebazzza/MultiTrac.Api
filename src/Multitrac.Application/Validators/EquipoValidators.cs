using FluentValidation;
using Multitrac.Application.DTOs;

namespace Multitrac.Application.Validators;

public class EquipoValidator : AbstractValidator<EquipoDto>
{
    public EquipoValidator()
    {
        RuleFor(x => x.TipoEquipo)
            .NotEmpty().WithMessage("El tipo de equipo es requerido")
            .MaximumLength(20).WithMessage("El tipo de equipo no puede exceder 20 caracteres");

        RuleFor(x => x.CodEquipo)
            .NotEmpty().WithMessage("El código del equipo es requerido")
            .MaximumLength(20).WithMessage("El código del equipo no puede exceder 20 caracteres");

        RuleFor(x => x.NoPlaca)
            .MaximumLength(20).WithMessage("La placa no puede exceder 20 caracteres");

        RuleFor(x => x.DescEquipo)
            .MaximumLength(250).WithMessage("La descripción no puede exceder 250 caracteres");

        RuleFor(x => x.Modelo)
            .MaximumLength(100).WithMessage("El modelo no puede exceder 100 caracteres");

        RuleFor(x => x.AnoFabricacion)
            .MaximumLength(10).WithMessage("El año de fabricación no puede exceder 10 caracteres");

        RuleFor(x => x.NoSerMotor)
            .MaximumLength(50).WithMessage("El número de serie del motor no puede exceder 50 caracteres");

        RuleFor(x => x.NoSerChasis)
            .MaximumLength(50).WithMessage("El número de serie del chasis no puede exceder 50 caracteres");

        RuleFor(x => x.Marca)
            .MaximumLength(100).WithMessage("La marca no puede exceder 100 caracteres");

        RuleFor(x => x.EstatusEquipo)
            .MaximumLength(20).WithMessage("El estatus no puede exceder 20 caracteres");

        RuleFor(x => x.Observaciones)
            .MaximumLength(500).WithMessage("Las observaciones no pueden exceder 500 caracteres");

        RuleFor(x => x.NoTarjetaPropiedad)
            .MaximumLength(50).WithMessage("El número de tarjeta de propiedad no puede exceder 50 caracteres");

        RuleFor(x => x.Soat)
            .MaximumLength(50).WithMessage("El SOAT no puede exceder 50 caracteres");

        RuleFor(x => x.Largo)
            .GreaterThanOrEqualTo(0).When(x => x.Largo.HasValue)
            .WithMessage("El largo no puede ser negativo");

        RuleFor(x => x.Ancho)
            .GreaterThanOrEqualTo(0).When(x => x.Ancho.HasValue)
            .WithMessage("El ancho no puede ser negativo");

        RuleFor(x => x.Alto)
            .GreaterThanOrEqualTo(0).When(x => x.Alto.HasValue)
            .WithMessage("El alto no puede ser negativo");

        RuleFor(x => x.CargaUtil)
            .GreaterThanOrEqualTo(0).When(x => x.CargaUtil.HasValue)
            .WithMessage("La carga útil no puede ser negativa");

        RuleFor(x => x.KilometrajeMantto)
            .GreaterThanOrEqualTo(0).When(x => x.KilometrajeMantto.HasValue)
            .WithMessage("El kilometraje de mantenimiento no puede ser negativo");

        RuleFor(x => x.Horometro)
            .GreaterThanOrEqualTo(0).When(x => x.Horometro.HasValue)
            .WithMessage("El horómetro no puede ser negativo");
    }
}

public class EquipoCombustibleValidator : AbstractValidator<EquipoCombustibleDto>
{
    public EquipoCombustibleValidator()
    {
        RuleFor(x => x.CodEquipo)
            .NotEmpty().WithMessage("El código del equipo es requerido")
            .MaximumLength(20).WithMessage("El código del equipo no puede exceder 20 caracteres");

        RuleFor(x => x.NumVale)
            .MaximumLength(50).WithMessage("El número de vale no puede exceder 50 caracteres");

        RuleFor(x => x.Cantidad)
            .GreaterThan(0).When(x => x.Cantidad.HasValue)
            .WithMessage("La cantidad debe ser mayor a 0");

        RuleFor(x => x.Motivo)
            .MaximumLength(250).WithMessage("El motivo no puede exceder 250 caracteres");

        RuleFor(x => x.CostoUnitario)
            .GreaterThanOrEqualTo(0).When(x => x.CostoUnitario.HasValue)
            .WithMessage("El costo unitario no puede ser negativo");

        RuleFor(x => x.Costo)
            .GreaterThanOrEqualTo(0).When(x => x.Costo.HasValue)
            .WithMessage("El costo no puede ser negativo");

        RuleFor(x => x.KilometrajeDespacho)
            .GreaterThanOrEqualTo(0).When(x => x.KilometrajeDespacho.HasValue)
            .WithMessage("El kilometraje de despacho no puede ser negativo");

        RuleFor(x => x.HoraDespacho)
            .MaximumLength(10).WithMessage("La hora de despacho no puede exceder 10 caracteres");
    }
}

public class EquipoKilometrajeValidator : AbstractValidator<EquipoKilometrajeDto>
{
    public EquipoKilometrajeValidator()
    {
        RuleFor(x => x.CodEquipo)
            .NotEmpty().WithMessage("El código del equipo es requerido")
            .MaximumLength(20).WithMessage("El código del equipo no puede exceder 20 caracteres");

        RuleFor(x => x.Fecha)
            .NotEmpty().WithMessage("La fecha es requerida");

        RuleFor(x => x.Kilometraje)
            .GreaterThan(0).When(x => x.Kilometraje.HasValue)
            .WithMessage("El kilometraje debe ser mayor a 0");

        RuleFor(x => x.Observacion)
            .MaximumLength(250).WithMessage("La observación no puede exceder 250 caracteres");

        RuleFor(x => x.Acoplado)
            .MaximumLength(20).WithMessage("El acoplado no puede exceder 20 caracteres");
    }
}

public class EquipoMantenimientoValidator : AbstractValidator<EquipoMantenimientoDto>
{
    public EquipoMantenimientoValidator()
    {
        RuleFor(x => x.CodEquipo)
            .NotEmpty().WithMessage("El código del equipo es requerido")
            .MaximumLength(20).WithMessage("El código del equipo no puede exceder 20 caracteres");

        RuleFor(x => x.FechaIngreso)
            .NotEmpty().WithMessage("La fecha de ingreso es requerida");

        RuleFor(x => x.HoraIngreso)
            .MaximumLength(10).WithMessage("La hora de ingreso no puede exceder 10 caracteres");

        RuleFor(x => x.HoraEstimadaSalida)
            .MaximumLength(10).WithMessage("La hora estimada de salida no puede exceder 10 caracteres");

        RuleFor(x => x.HoraSalida)
            .MaximumLength(10).WithMessage("La hora de salida no puede exceder 10 caracteres");

        RuleFor(x => x.NroOrden)
            .MaximumLength(50).WithMessage("El número de orden no puede exceder 50 caracteres");

        RuleFor(x => x.Acoplado)
            .MaximumLength(20).WithMessage("El acoplado no puede exceder 20 caracteres");

        RuleFor(x => x.KilometrajeIngreso)
            .GreaterThanOrEqualTo(0).When(x => x.KilometrajeIngreso.HasValue)
            .WithMessage("El kilometraje de ingreso no puede ser negativo");
    }
}
