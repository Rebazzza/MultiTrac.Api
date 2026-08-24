using AutoMapper;
using Multitrac.Application.DTOs;
using Multitrac.Domain.Entities;

namespace Multitrac.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Catálogos simples
        CreateMap<Moneda, MonedaDto>().ReverseMap();
        CreateMap<Banco, BancoDto>().ReverseMap();
        CreateMap<Cargo, CargoDto>().ReverseMap();
        CreateMap<NivelEducativo, NivelEducativoDto>().ReverseMap();
        CreateMap<Afp, AfpDto>().ReverseMap();
        CreateMap<Flota, FlotaDto>().ReverseMap();
        CreateMap<Actividad, ActividadDto>().ReverseMap();
        CreateMap<Turno, TurnoDto>().ReverseMap();
        CreateMap<TipoPago, TipoPagoDto>().ReverseMap();
        CreateMap<TipoOcurrencia, TipoOcurrenciaDto>().ReverseMap();

        // Operaciones
        CreateMap<Operacion, OperacionDto>().ReverseMap();
        CreateMap<OperacionGeneral, OperacionGeneralDto>().ReverseMap();
        CreateMap<OperacionGeneralEquipo, OperacionGeneralEquipoDto>().ReverseMap();
        CreateMap<OperacionFlete, OperacionFleteDto>().ReverseMap();
        CreateMap<OperacionInforme, OperacionInformeDto>().ReverseMap();
        CreateMap<OperacionHorario, OperacionHorarioDto>().ReverseMap();
        CreateMap<OperacionTurno, OperacionTurnoDto>().ReverseMap();
        CreateMap<OperacionCarga, OperacionCargaDto>().ReverseMap();
        CreateMap<OperacionTipo, OperacionTipoDto>().ReverseMap();
        CreateMap<TipoCarga, TipoCargaDto>().ReverseMap();
        CreateMap<Unidad, UnidadDto>().ReverseMap();
        CreateMap<Convoy, ConvoyDto>().ReverseMap();

        // Personal
        CreateMap<Personal, PersonalDto>().ReverseMap();
        CreateMap<PersonalDocumento, PersonalDocumentoDto>().ReverseMap();
        CreateMap<PersonalCargo, PersonalCargoDto>().ReverseMap();
        CreateMap<PersonalEquipo, PersonalEquipoDto>().ReverseMap();
        CreateMap<PersonalEpp, PersonalEppDto>().ReverseMap();
        CreateMap<PersonalEppKardex, PersonalEppKardexDto>().ReverseMap();
        CreateMap<PersonalRecord, PersonalRecordDto>().ReverseMap();
        CreateMap<PersonalVacaciones, PersonalVacacionesDto>().ReverseMap();
        CreateMap<PersonalVacacionesRegistro, PersonalVacacionesRegistroDto>().ReverseMap();
        CreateMap<PersonalLicenciaConducir, PersonalLicenciaConducirDto>().ReverseMap();
        CreateMap<PersonalSueno, PersonalSuenoDto>().ReverseMap();
        CreateMap<Contratista, ContratistaDto>().ReverseMap();

        // Equipos
        CreateMap<Equipo, EquipoDto>().ReverseMap();
        CreateMap<EquipoCombustible, EquipoCombustibleDto>().ReverseMap();
        CreateMap<EquipoKilometraje, EquipoKilometrajeDto>().ReverseMap();
        CreateMap<EquipoMantenimiento, EquipoMantenimientoDto>().ReverseMap();
        CreateMap<EquipoMantenimientoDetalle, EquipoMantenimientoDetalleDto>().ReverseMap();
        CreateMap<EquipoDocumentoTracto, EquipoDocumentoTractoDto>().ReverseMap();
        CreateMap<EquipoDocumentoCarreta, EquipoDocumentoCarretaDto>().ReverseMap();

        // Cliente/Proveedor/Area/Empresa
        CreateMap<Cliente, ClienteDto>().ReverseMap();
        CreateMap<Proveedor, ProveedorDto>().ReverseMap();
        CreateMap<Area, AreaDto>().ReverseMap();
        CreateMap<TipoDocumento, TipoDocumentoDto>().ReverseMap();
        CreateMap<Empresa, EmpresaDto>().ReverseMap();
    }
}
