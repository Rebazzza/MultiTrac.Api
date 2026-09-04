using FluentValidation;
using Multitrac.Application.DTOs;

namespace Multitrac.Application.Validators;

public class OperacionValidator : AbstractValidator<OperacionDto>
{
    public OperacionValidator()
    {
        RuleFor(x => x.DescOperacion)
            .NotEmpty().WithMessage("La descripción de la operación es requerida")
            .MaximumLength(250).WithMessage("La descripción no puede exceder 250 caracteres");

        RuleFor(x => x.OIdUbicacionOp)
            .GreaterThan(0).WithMessage("El origen de la operación es requerido");

        RuleFor(x => x.DIdUbicacionOp)
            .GreaterThan(0).WithMessage("El destino de la operación es requerido");

        RuleFor(x => x.IdUnidad)
            .GreaterThan(0).WithMessage("La unidad es requerida");

        RuleFor(x => x.Origen)
            .MaximumLength(250).WithMessage("El origen no puede exceder 250 caracteres");

        RuleFor(x => x.Destino)
            .MaximumLength(250).WithMessage("El destino no puede exceder 250 caracteres");

        RuleFor(x => x.CostoFlete)
            .GreaterThanOrEqualTo(0).When(x => x.CostoFlete.HasValue)
            .WithMessage("El costo de flete no puede ser negativo");

        RuleFor(x => x.KilometrajeRecorrido)
            .GreaterThanOrEqualTo(0).When(x => x.KilometrajeRecorrido.HasValue)
            .WithMessage("El kilometraje no puede ser negativo");

        RuleFor(x => x.TipoProducto)
            .MaximumLength(100).WithMessage("El tipo de producto no puede exceder 100 caracteres");

        RuleFor(x => x.RutaPrincipal)
            .MaximumLength(500).WithMessage("La ruta principal no puede exceder 500 caracteres");

        RuleFor(x => x.LatCentroGIda)
            .InclusiveBetween(-90, 90).When(x => x.LatCentroGIda.HasValue).WithMessage("Latitud de ida inválida");

        RuleFor(x => x.LngCentroGIda)
            .InclusiveBetween(-180, 180).When(x => x.LngCentroGIda.HasValue).WithMessage("Longitud de ida inválida");

        RuleFor(x => x.LatCentroGVuelta)
            .InclusiveBetween(-90, 90).When(x => x.LatCentroGVuelta.HasValue).WithMessage("Latitud de vuelta inválida");

        RuleFor(x => x.LngCentroGVuelta)
            .InclusiveBetween(-180, 180).When(x => x.LngCentroGVuelta.HasValue).WithMessage("Longitud de vuelta inválida");
    }
}

public class OperacionGeneralValidator : AbstractValidator<OperacionGeneralDto>
{
    public OperacionGeneralValidator()
    {
        RuleFor(x => x.IdOperacion)
            .GreaterThan(0).WithMessage("La operación es requerida");

        RuleFor(x => x.IdTipoCarga)
            .GreaterThan(0).WithMessage("El tipo de carga es requerido");

        RuleFor(x => x.Estado)
            .MaximumLength(20).WithMessage("El estado no puede exceder 20 caracteres");

        RuleFor(x => x.Usuario)
            .MaximumLength(50).WithMessage("El usuario no puede exceder 50 caracteres");

        RuleFor(x => x.Observaciones)
            .MaximumLength(500).WithMessage("Las observaciones no pueden exceder 500 caracteres");
    }
}

public class OperacionGeneralEquipoValidator : AbstractValidator<OperacionGeneralEquipoDto>
{
    public OperacionGeneralEquipoValidator()
    {
        RuleFor(x => x.IdOperacionGeneral)
            .GreaterThan(0).WithMessage("La operación general es requerida");

        RuleFor(x => x.CodEquipoTracto)
            .NotEmpty().WithMessage("El código del tracto es requerido")
            .MaximumLength(20).WithMessage("El código del tracto no puede exceder 20 caracteres");

        RuleFor(x => x.CodEquipoCarreta)
            .NotEmpty().WithMessage("El código de la carreta es requerido")
            .MaximumLength(20).WithMessage("El código de la carreta no puede exceder 20 caracteres");

        RuleFor(x => x.IdPersonal)
            .GreaterThan(0).WithMessage("El personal es requerido");

        RuleFor(x => x.KmSalida)
            .GreaterThanOrEqualTo(0).When(x => x.KmSalida.HasValue)
            .WithMessage("El kilometraje de salida no puede ser negativo");

        RuleFor(x => x.KmFinal)
            .GreaterThanOrEqualTo(0).When(x => x.KmFinal.HasValue)
            .WithMessage("El kilometraje final no puede ser negativo");

        RuleFor(x => x.Carga)
            .MaximumLength(100).WithMessage("La carga no puede exceder 100 caracteres");

        RuleFor(x => x.Observaciones)
            .MaximumLength(500).WithMessage("Las observaciones no pueden exceder 500 caracteres");

        RuleFor(x => x.Estado)
            .MaximumLength(20).WithMessage("El estado no puede exceder 20 caracteres");
    }
}

public class OperacionFleteValidator : AbstractValidator<OperacionFleteDto>
{
    public OperacionFleteValidator()
    {
        RuleFor(x => x.IdOperacion)
            .GreaterThan(0).WithMessage("La operación es requerida");

        RuleFor(x => x.IdTipoCarga)
            .GreaterThan(0).WithMessage("El tipo de carga es requerido");

        RuleFor(x => x.IdMoneda)
            .GreaterThan(0).WithMessage("La moneda es requerida");

        RuleFor(x => x.PorcFlete)
            .InclusiveBetween(0, 100).When(x => x.PorcFlete.HasValue)
            .WithMessage("El porcentaje de flete debe estar entre 0 y 100");

        RuleFor(x => x.ValorVentaFlete)
            .GreaterThanOrEqualTo(0).When(x => x.ValorVentaFlete.HasValue)
            .WithMessage("El valor de venta no puede ser negativo");

        RuleFor(x => x.ComisionMultitrac)
            .GreaterThanOrEqualTo(0).When(x => x.ComisionMultitrac.HasValue)
            .WithMessage("La comisión Multitrac no puede ser negativa");

        RuleFor(x => x.Estado)
            .MaximumLength(20).WithMessage("El estado no puede exceder 20 caracteres");
    }
}

public class OperacionInformeValidator : AbstractValidator<OperacionInformeDto>
{
    public OperacionInformeValidator()
    {
        RuleFor(x => x.IdOperacionGeneral)
            .GreaterThan(0).WithMessage("La operación general es requerida");

        RuleFor(x => x.FechaInforme)
            .NotEmpty().WithMessage("La fecha del informe es requerida");

        RuleFor(x => x.Informe)
            .MaximumLength(2000).WithMessage("El informe no puede exceder 2000 caracteres");

        RuleFor(x => x.InformeMantto)
            .MaximumLength(2000).WithMessage("El informe de mantenimiento no puede exceder 2000 caracteres");

        RuleFor(x => x.DescripcionIncident)
            .MaximumLength(1000).WithMessage("La descripción del incidente no puede exceder 1000 caracteres");
    }
}

public class OperacionHorarioValidator : AbstractValidator<OperacionHorarioDto>
{
    public OperacionHorarioValidator()
    {
        RuleFor(x => x.IdOperacion)
            .GreaterThan(0).WithMessage("La operación es requerida");

        RuleFor(x => x.HoraInicio)
            .MaximumLength(10).WithMessage("La hora de inicio no puede exceder 10 caracteres");

        RuleFor(x => x.HoraFin)
            .MaximumLength(10).WithMessage("La hora de fin no puede exceder 10 caracteres");

        RuleFor(x => x.Estado)
            .MaximumLength(20).WithMessage("El estado no puede exceder 20 caracteres");
    }
}

public class OperacionTurnoValidator : AbstractValidator<OperacionTurnoDto>
{
    public OperacionTurnoValidator()
    {
        RuleFor(x => x.IdOperacion)
            .GreaterThan(0).WithMessage("La operación es requerida");

        RuleFor(x => x.Turno)
            .MaximumLength(50).WithMessage("El turno no puede exceder 50 caracteres");

        RuleFor(x => x.Observacion)
            .MaximumLength(500).WithMessage("La observación no puede exceder 500 caracteres");
    }
}

public class OperacionCargaValidator : AbstractValidator<OperacionCargaDto>
{
    public OperacionCargaValidator()
    {
        RuleFor(x => x.IdOperacion)
            .GreaterThan(0).WithMessage("La operación es requerida");

        RuleFor(x => x.IdTipoCarga)
            .GreaterThan(0).WithMessage("El tipo de carga es requerido");

        RuleFor(x => x.Estado)
            .MaximumLength(20).WithMessage("El estado no puede exceder 20 caracteres");
    }
}

public class OperacionTipoValidator : AbstractValidator<OperacionTipoDto>
{
    public OperacionTipoValidator()
    {
        RuleFor(x => x.OperacionTipoNombre)
            .NotEmpty().WithMessage("El nombre del tipo de operación es requerido")
            .MaximumLength(100).WithMessage("El nombre no puede exceder 100 caracteres");

        RuleFor(x => x.ObservacionTipo)
            .MaximumLength(250).WithMessage("La observación no puede exceder 250 caracteres");
    }
}

public class TipoCargaValidator : AbstractValidator<TipoCargaDto>
{
    public TipoCargaValidator()
    {
        RuleFor(x => x.NombreTipoCarga)
            .NotEmpty().WithMessage("El nombre del tipo de carga es requerido")
            .MaximumLength(100).WithMessage("El nombre no puede exceder 100 caracteres");

        RuleFor(x => x.DescripcionTipoCarga)
            .MaximumLength(250).WithMessage("La descripción no puede exceder 250 caracteres");

        RuleFor(x => x.NomInsumoQuimicoFiscalizado)
            .MaximumLength(200).WithMessage("El nombre del insumo químico fiscalizado no puede exceder 200 caracteres");

        RuleFor(x => x.NomInsumoComercial)
            .MaximumLength(200).WithMessage("El nombre del insumo comercial no puede exceder 200 caracteres");

        RuleFor(x => x.ProveedorCertificado)
            .MaximumLength(200).WithMessage("El proveedor del certificado no puede exceder 200 caracteres");

        RuleFor(x => x.CodigoSunat)
            .MaximumLength(50).WithMessage("El código SUNAT no puede exceder 50 caracteres");
    }
}

public class UnidadValidator : AbstractValidator<UnidadDto>
{
    public UnidadValidator()
    {
        RuleFor(x => x.NombreUnidad)
            .NotEmpty().WithMessage("El nombre de la unidad es requerido")
            .MaximumLength(50).WithMessage("El nombre no puede exceder 50 caracteres");

        RuleFor(x => x.AbreviaturaUnidad)
            .MaximumLength(20).WithMessage("La abreviatura no puede exceder 20 caracteres");
    }
}

public class ConvoyValidator : AbstractValidator<ConvoyDto>
{
    public ConvoyValidator()
    {
        RuleFor(x => x.IdOperacion)
            .GreaterThan(0).WithMessage("La operación es requerida");

        RuleFor(x => x.IdCargo)
            .GreaterThan(0).WithMessage("El cargo es requerido");

        RuleFor(x => x.NroPersonal)
            .GreaterThanOrEqualTo(0).When(x => x.NroPersonal.HasValue)
            .WithMessage("El número de personal no puede ser negativo");

        RuleFor(x => x.NroUnidades)
            .GreaterThanOrEqualTo(0).When(x => x.NroUnidades.HasValue)
            .WithMessage("El número de unidades no puede ser negativo");
    }
}
