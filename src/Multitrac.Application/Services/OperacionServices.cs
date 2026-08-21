using AutoMapper;
using Multitrac.Application.DTOs;
using Multitrac.Application.Interfaces;
using Multitrac.Domain.Entities;
using Multitrac.Domain.Interfaces;

namespace Multitrac.Application.Services;

public class OperacionService : IService<OperacionDto, Operacion>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OperacionService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperacionDto?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Repository<Operacion>().GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<OperacionDto>(entity);
    }

    public async Task<IEnumerable<OperacionDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<Operacion>().GetAllAsync();
        return _mapper.Map<IEnumerable<OperacionDto>>(entities);
    }

    public async Task<OperacionDto> CreateAsync(OperacionDto dto)
    {
        var entity = _mapper.Map<Operacion>(dto);
        await _unitOfWork.Repository<Operacion>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<OperacionDto>(entity);
    }

    public async Task UpdateAsync(int id, OperacionDto dto)
    {
        var entity = await _unitOfWork.Repository<Operacion>().GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"Operacion with ID {id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Repository<Operacion>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<Operacion>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<Operacion>().ExistsAsync(id);
    }
}

public class OperacionGeneralService : IService<OperacionGeneralDto, OperacionGeneral>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OperacionGeneralService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperacionGeneralDto?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Repository<OperacionGeneral>().GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<OperacionGeneralDto>(entity);
    }

    public async Task<IEnumerable<OperacionGeneralDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<OperacionGeneral>().GetAllAsync();
        return _mapper.Map<IEnumerable<OperacionGeneralDto>>(entities);
    }

    public async Task<OperacionGeneralDto> CreateAsync(OperacionGeneralDto dto)
    {
        var entity = _mapper.Map<OperacionGeneral>(dto);
        await _unitOfWork.Repository<OperacionGeneral>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<OperacionGeneralDto>(entity);
    }

    public async Task UpdateAsync(int id, OperacionGeneralDto dto)
    {
        var entity = await _unitOfWork.Repository<OperacionGeneral>().GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"OperacionGeneral with ID {id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Repository<OperacionGeneral>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<OperacionGeneral>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<OperacionGeneral>().ExistsAsync(id);
    }
}

public class OperacionGeneralEquipoService : IService<OperacionGeneralEquipoDto, OperacionGeneralEquipo>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OperacionGeneralEquipoService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperacionGeneralEquipoDto?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Repository<OperacionGeneralEquipo>().GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<OperacionGeneralEquipoDto>(entity);
    }

    public async Task<IEnumerable<OperacionGeneralEquipoDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<OperacionGeneralEquipo>().GetAllAsync();
        return _mapper.Map<IEnumerable<OperacionGeneralEquipoDto>>(entities);
    }

    public async Task<OperacionGeneralEquipoDto> CreateAsync(OperacionGeneralEquipoDto dto)
    {
        var entity = _mapper.Map<OperacionGeneralEquipo>(dto);
        await _unitOfWork.Repository<OperacionGeneralEquipo>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<OperacionGeneralEquipoDto>(entity);
    }

    public async Task UpdateAsync(int id, OperacionGeneralEquipoDto dto)
    {
        var entity = await _unitOfWork.Repository<OperacionGeneralEquipo>().GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"OperacionGeneralEquipo with ID {id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Repository<OperacionGeneralEquipo>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<OperacionGeneralEquipo>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<OperacionGeneralEquipo>().ExistsAsync(id);
    }
}

public class OperacionFleteService : IService<OperacionFleteDto, OperacionFlete>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OperacionFleteService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperacionFleteDto?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Repository<OperacionFlete>().GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<OperacionFleteDto>(entity);
    }

    public async Task<IEnumerable<OperacionFleteDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<OperacionFlete>().GetAllAsync();
        return _mapper.Map<IEnumerable<OperacionFleteDto>>(entities);
    }

    public async Task<OperacionFleteDto> CreateAsync(OperacionFleteDto dto)
    {
        var entity = _mapper.Map<OperacionFlete>(dto);
        await _unitOfWork.Repository<OperacionFlete>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<OperacionFleteDto>(entity);
    }

    public async Task UpdateAsync(int id, OperacionFleteDto dto)
    {
        var entity = await _unitOfWork.Repository<OperacionFlete>().GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"OperacionFlete with ID {id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Repository<OperacionFlete>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<OperacionFlete>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<OperacionFlete>().ExistsAsync(id);
    }
}

public class OperacionInformeService : IService<OperacionInformeDto, OperacionInforme>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OperacionInformeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperacionInformeDto?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Repository<OperacionInforme>().GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<OperacionInformeDto>(entity);
    }

    public async Task<IEnumerable<OperacionInformeDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<OperacionInforme>().GetAllAsync();
        return _mapper.Map<IEnumerable<OperacionInformeDto>>(entities);
    }

    public async Task<OperacionInformeDto> CreateAsync(OperacionInformeDto dto)
    {
        var entity = _mapper.Map<OperacionInforme>(dto);
        await _unitOfWork.Repository<OperacionInforme>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<OperacionInformeDto>(entity);
    }

    public async Task UpdateAsync(int id, OperacionInformeDto dto)
    {
        var entity = await _unitOfWork.Repository<OperacionInforme>().GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"OperacionInforme with ID {id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Repository<OperacionInforme>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<OperacionInforme>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<OperacionInforme>().ExistsAsync(id);
    }
}

public class TipoCargaService : IService<TipoCargaDto, TipoCarga>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TipoCargaService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<TipoCargaDto?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Repository<TipoCarga>().GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<TipoCargaDto>(entity);
    }

    public async Task<IEnumerable<TipoCargaDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<TipoCarga>().GetAllAsync();
        return _mapper.Map<IEnumerable<TipoCargaDto>>(entities);
    }

    public async Task<TipoCargaDto> CreateAsync(TipoCargaDto dto)
    {
        var entity = _mapper.Map<TipoCarga>(dto);
        await _unitOfWork.Repository<TipoCarga>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<TipoCargaDto>(entity);
    }

    public async Task UpdateAsync(int id, TipoCargaDto dto)
    {
        var entity = await _unitOfWork.Repository<TipoCarga>().GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"TipoCarga with ID {id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Repository<TipoCarga>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<TipoCarga>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<TipoCarga>().ExistsAsync(id);
    }
}

public class UnidadService : IService<UnidadDto, Unidad>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UnidadService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UnidadDto?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Repository<Unidad>().GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<UnidadDto>(entity);
    }

    public async Task<IEnumerable<UnidadDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<Unidad>().GetAllAsync();
        return _mapper.Map<IEnumerable<UnidadDto>>(entities);
    }

    public async Task<UnidadDto> CreateAsync(UnidadDto dto)
    {
        var entity = _mapper.Map<Unidad>(dto);
        await _unitOfWork.Repository<Unidad>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<UnidadDto>(entity);
    }

    public async Task UpdateAsync(int id, UnidadDto dto)
    {
        var entity = await _unitOfWork.Repository<Unidad>().GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"Unidad with ID {id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Repository<Unidad>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<Unidad>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<Unidad>().ExistsAsync(id);
    }
}
