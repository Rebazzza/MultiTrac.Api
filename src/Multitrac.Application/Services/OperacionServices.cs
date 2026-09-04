using AutoMapper;
using Multitrac.Application.DTOs;
using Multitrac.Application.Interfaces;
using Multitrac.Domain.Entities;
using Multitrac.Domain.Exceptions;
using Multitrac.Domain.Interfaces;

namespace Multitrac.Application.Services;

public class OperacionService : ServiceBase<OperacionDto, Operacion>
{
    public OperacionService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<OperacionDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<OperacionDto>(entity);
    }

    public override async Task<IEnumerable<OperacionDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<Operacion>().GetAllAsync();
        return _mapper.Map<IEnumerable<OperacionDto>>(entities);
    }

    public override async Task<OperacionDto> CreateAsync(OperacionDto dto)
    {
        var entity = _mapper.Map<Operacion>(dto);
        await _unitOfWork.Repository<Operacion>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<OperacionDto>(entity);
    }

    public override async Task UpdateAsync(int id, OperacionDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<Operacion>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<Operacion>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<Operacion>().ExistsAsync(id);
    }
}

public class OperacionGeneralService : ServiceBase<OperacionGeneralDto, OperacionGeneral>
{
    public OperacionGeneralService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<OperacionGeneralDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<OperacionGeneralDto>(entity);
    }

    public override async Task<IEnumerable<OperacionGeneralDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<OperacionGeneral>().GetAllAsync();
        return _mapper.Map<IEnumerable<OperacionGeneralDto>>(entities);
    }

    public override async Task<OperacionGeneralDto> CreateAsync(OperacionGeneralDto dto)
    {
        var entity = _mapper.Map<OperacionGeneral>(dto);
        await _unitOfWork.Repository<OperacionGeneral>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<OperacionGeneralDto>(entity);
    }

    public override async Task UpdateAsync(int id, OperacionGeneralDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<OperacionGeneral>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<OperacionGeneral>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<OperacionGeneral>().ExistsAsync(id);
    }
}

public class OperacionGeneralEquipoService : ServiceBase<OperacionGeneralEquipoDto, OperacionGeneralEquipo>
{
    public OperacionGeneralEquipoService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<OperacionGeneralEquipoDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<OperacionGeneralEquipoDto>(entity);
    }

    public override async Task<IEnumerable<OperacionGeneralEquipoDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<OperacionGeneralEquipo>().GetAllAsync();
        return _mapper.Map<IEnumerable<OperacionGeneralEquipoDto>>(entities);
    }

    public override async Task<OperacionGeneralEquipoDto> CreateAsync(OperacionGeneralEquipoDto dto)
    {
        var entity = _mapper.Map<OperacionGeneralEquipo>(dto);
        await _unitOfWork.Repository<OperacionGeneralEquipo>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<OperacionGeneralEquipoDto>(entity);
    }

    public override async Task UpdateAsync(int id, OperacionGeneralEquipoDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<OperacionGeneralEquipo>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<OperacionGeneralEquipo>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<OperacionGeneralEquipo>().ExistsAsync(id);
    }
}

public class OperacionFleteService : ServiceBase<OperacionFleteDto, OperacionFlete>
{
    private readonly IOperacionFleteSpRepository _spRepository;

    public OperacionFleteService(IUnitOfWork unitOfWork, IMapper mapper, IOperacionFleteSpRepository spRepository) : base(unitOfWork, mapper)
    {
        _spRepository = spRepository;
    }

    public override async Task<OperacionFleteDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<OperacionFleteDto>(entity);
    }

    public override async Task<IEnumerable<OperacionFleteDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<OperacionFlete>().GetAllAsync();
        return _mapper.Map<IEnumerable<OperacionFleteDto>>(entities);
    }

    public override async Task<OperacionFleteDto> CreateAsync(OperacionFleteDto dto)
    {
        var entity = _mapper.Map<OperacionFlete>(dto);
        await _unitOfWork.Repository<OperacionFlete>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<OperacionFleteDto>(entity);
    }

    public override async Task UpdateAsync(int id, OperacionFleteDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<OperacionFlete>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<OperacionFlete>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<OperacionFlete>().ExistsAsync(id);
    }

    public async Task<CalcularFleteResponseDto?> GetFleteByIdOperacionAsync(int idOperacion)
    {
        return await _spRepository.GetFleteByIdOperacionAsync(idOperacion);
    }

    public async Task<IEnumerable<CalcularFleteResponseDto>> GetFletesByClienteAndTipoCargaAsync(int idCliente, int idTipoCarga)
    {
        return await _spRepository.GetFletesByClienteAndTipoCargaAsync(idCliente, idTipoCarga);
    }

    public async Task<IEnumerable<ReporteFacturacionResponseDto>> GetReporteFacturacionAsync(ReporteFacturacionRequestDto request)
    {
        return await _spRepository.GetReporteFacturacionAsync(request);
    }

    public async Task<IEnumerable<IndicadoresResponseDto>> CalcularIndicadoresAsync(int anio, int mes)
    {
        return await _spRepository.CalcularIndicadoresAsync(anio, mes);
    }

    public async Task<IEnumerable<ContratistaDescuentoDto>> GetContratistaDescuentosAsync(int idOperacionGeneral)
    {
        return await _spRepository.GetContratistaDescuentosByIdOperacionGeneralAsync(idOperacionGeneral);
    }
}

public class OperacionInformeService : ServiceBase<OperacionInformeDto, OperacionInforme>
{
    public OperacionInformeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<OperacionInformeDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<OperacionInformeDto>(entity);
    }

    public override async Task<IEnumerable<OperacionInformeDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<OperacionInforme>().GetAllAsync();
        return _mapper.Map<IEnumerable<OperacionInformeDto>>(entities);
    }

    public override async Task<OperacionInformeDto> CreateAsync(OperacionInformeDto dto)
    {
        var entity = _mapper.Map<OperacionInforme>(dto);
        await _unitOfWork.Repository<OperacionInforme>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<OperacionInformeDto>(entity);
    }

    public override async Task UpdateAsync(int id, OperacionInformeDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<OperacionInforme>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<OperacionInforme>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<OperacionInforme>().ExistsAsync(id);
    }
}

public class TipoCargaService : ServiceBase<TipoCargaDto, TipoCarga>
{
    public TipoCargaService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<TipoCargaDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<TipoCargaDto>(entity);
    }

    public override async Task<IEnumerable<TipoCargaDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<TipoCarga>().GetAllAsync();
        return _mapper.Map<IEnumerable<TipoCargaDto>>(entities);
    }

    public override async Task<TipoCargaDto> CreateAsync(TipoCargaDto dto)
    {
        var entity = _mapper.Map<TipoCarga>(dto);
        await _unitOfWork.Repository<TipoCarga>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<TipoCargaDto>(entity);
    }

    public override async Task UpdateAsync(int id, TipoCargaDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<TipoCarga>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<TipoCarga>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<TipoCarga>().ExistsAsync(id);
    }
}

public class UnidadService : ServiceBase<UnidadDto, Unidad>
{
    public UnidadService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<UnidadDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<UnidadDto>(entity);
    }

    public override async Task<IEnumerable<UnidadDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<Unidad>().GetAllAsync();
        return _mapper.Map<IEnumerable<UnidadDto>>(entities);
    }

    public override async Task<UnidadDto> CreateAsync(UnidadDto dto)
    {
        var entity = _mapper.Map<Unidad>(dto);
        await _unitOfWork.Repository<Unidad>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<UnidadDto>(entity);
    }

    public override async Task UpdateAsync(int id, UnidadDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<Unidad>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<Unidad>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<Unidad>().ExistsAsync(id);
    }
}

public class OperacionHorarioService : ServiceBase<OperacionHorarioDto, OperacionHorario>
{
    public OperacionHorarioService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<OperacionHorarioDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<OperacionHorarioDto>(entity);
    }

    public override async Task<IEnumerable<OperacionHorarioDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<OperacionHorario>().GetAllAsync();
        return _mapper.Map<IEnumerable<OperacionHorarioDto>>(entities);
    }

    public override async Task<OperacionHorarioDto> CreateAsync(OperacionHorarioDto dto)
    {
        var entity = _mapper.Map<OperacionHorario>(dto);
        await _unitOfWork.Repository<OperacionHorario>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<OperacionHorarioDto>(entity);
    }

    public override async Task UpdateAsync(int id, OperacionHorarioDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<OperacionHorario>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<OperacionHorario>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<OperacionHorario>().ExistsAsync(id);
    }
}

public class OperacionTurnoService : ServiceBase<OperacionTurnoDto, OperacionTurno>
{
    public OperacionTurnoService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<OperacionTurnoDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<OperacionTurnoDto>(entity);
    }

    public override async Task<IEnumerable<OperacionTurnoDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<OperacionTurno>().GetAllAsync();
        return _mapper.Map<IEnumerable<OperacionTurnoDto>>(entities);
    }

    public override async Task<OperacionTurnoDto> CreateAsync(OperacionTurnoDto dto)
    {
        var entity = _mapper.Map<OperacionTurno>(dto);
        await _unitOfWork.Repository<OperacionTurno>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<OperacionTurnoDto>(entity);
    }

    public override async Task UpdateAsync(int id, OperacionTurnoDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<OperacionTurno>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<OperacionTurno>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<OperacionTurno>().ExistsAsync(id);
    }
}

public class OperacionCargaService : ServiceBase<OperacionCargaDto, OperacionCarga>
{
    public OperacionCargaService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<OperacionCargaDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<OperacionCargaDto>(entity);
    }

    public override async Task<IEnumerable<OperacionCargaDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<OperacionCarga>().GetAllAsync();
        return _mapper.Map<IEnumerable<OperacionCargaDto>>(entities);
    }

    public override async Task<OperacionCargaDto> CreateAsync(OperacionCargaDto dto)
    {
        var entity = _mapper.Map<OperacionCarga>(dto);
        await _unitOfWork.Repository<OperacionCarga>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<OperacionCargaDto>(entity);
    }

    public override async Task UpdateAsync(int id, OperacionCargaDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<OperacionCarga>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<OperacionCarga>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<OperacionCarga>().ExistsAsync(id);
    }
}

public class OperacionTipoService : ServiceBase<OperacionTipoDto, OperacionTipo>
{
    public OperacionTipoService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<OperacionTipoDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<OperacionTipoDto>(entity);
    }

    public override async Task<IEnumerable<OperacionTipoDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<OperacionTipo>().GetAllAsync();
        return _mapper.Map<IEnumerable<OperacionTipoDto>>(entities);
    }

    public override async Task<OperacionTipoDto> CreateAsync(OperacionTipoDto dto)
    {
        var entity = _mapper.Map<OperacionTipo>(dto);
        await _unitOfWork.Repository<OperacionTipo>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<OperacionTipoDto>(entity);
    }

    public override async Task UpdateAsync(int id, OperacionTipoDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<OperacionTipo>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<OperacionTipo>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<OperacionTipo>().ExistsAsync(id);
    }
}
