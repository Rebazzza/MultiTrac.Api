using AutoMapper;
using Multitrac.Application.DTOs;
using Multitrac.Application.Interfaces;
using Multitrac.Domain.Entities;
using Multitrac.Domain.Interfaces;

namespace Multitrac.Application.Services;

public class EquipoService : IService<EquipoDto, Equipo>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EquipoService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<EquipoDto?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Repository<Equipo>().GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<EquipoDto>(entity);
    }

    public async Task<IEnumerable<EquipoDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<Equipo>().GetAllAsync();
        return _mapper.Map<IEnumerable<EquipoDto>>(entities);
    }

    public async Task<EquipoDto> CreateAsync(EquipoDto dto)
    {
        var entity = _mapper.Map<Equipo>(dto);
        await _unitOfWork.Repository<Equipo>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<EquipoDto>(entity);
    }

    public async Task UpdateAsync(int id, EquipoDto dto)
    {
        var entity = await _unitOfWork.Repository<Equipo>().GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"Equipo with ID {id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Repository<Equipo>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<Equipo>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<Equipo>().ExistsAsync(id);
    }
}

public class EquipoCombustibleService : IService<EquipoCombustibleDto, EquipoCombustible>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EquipoCombustibleService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<EquipoCombustibleDto?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Repository<EquipoCombustible>().GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<EquipoCombustibleDto>(entity);
    }

    public async Task<IEnumerable<EquipoCombustibleDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<EquipoCombustible>().GetAllAsync();
        return _mapper.Map<IEnumerable<EquipoCombustibleDto>>(entities);
    }

    public async Task<EquipoCombustibleDto> CreateAsync(EquipoCombustibleDto dto)
    {
        var entity = _mapper.Map<EquipoCombustible>(dto);
        await _unitOfWork.Repository<EquipoCombustible>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<EquipoCombustibleDto>(entity);
    }

    public async Task UpdateAsync(int id, EquipoCombustibleDto dto)
    {
        var entity = await _unitOfWork.Repository<EquipoCombustible>().GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"EquipoCombustible with ID {id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Repository<EquipoCombustible>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<EquipoCombustible>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<EquipoCombustible>().ExistsAsync(id);
    }
}

public class EquipoKilometrajeService : IService<EquipoKilometrajeDto, EquipoKilometraje>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EquipoKilometrajeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<EquipoKilometrajeDto?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Repository<EquipoKilometraje>().GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<EquipoKilometrajeDto>(entity);
    }

    public async Task<IEnumerable<EquipoKilometrajeDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<EquipoKilometraje>().GetAllAsync();
        return _mapper.Map<IEnumerable<EquipoKilometrajeDto>>(entities);
    }

    public async Task<EquipoKilometrajeDto> CreateAsync(EquipoKilometrajeDto dto)
    {
        var entity = _mapper.Map<EquipoKilometraje>(dto);
        await _unitOfWork.Repository<EquipoKilometraje>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<EquipoKilometrajeDto>(entity);
    }

    public async Task UpdateAsync(int id, EquipoKilometrajeDto dto)
    {
        var entity = await _unitOfWork.Repository<EquipoKilometraje>().GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"EquipoKilometraje with ID {id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Repository<EquipoKilometraje>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<EquipoKilometraje>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<EquipoKilometraje>().ExistsAsync(id);
    }
}

public class EquipoMantenimientoService : IService<EquipoMantenimientoDto, EquipoMantenimiento>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EquipoMantenimientoService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<EquipoMantenimientoDto?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Repository<EquipoMantenimiento>().GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<EquipoMantenimientoDto>(entity);
    }

    public async Task<IEnumerable<EquipoMantenimientoDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<EquipoMantenimiento>().GetAllAsync();
        return _mapper.Map<IEnumerable<EquipoMantenimientoDto>>(entities);
    }

    public async Task<EquipoMantenimientoDto> CreateAsync(EquipoMantenimientoDto dto)
    {
        var entity = _mapper.Map<EquipoMantenimiento>(dto);
        await _unitOfWork.Repository<EquipoMantenimiento>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<EquipoMantenimientoDto>(entity);
    }

    public async Task UpdateAsync(int id, EquipoMantenimientoDto dto)
    {
        var entity = await _unitOfWork.Repository<EquipoMantenimiento>().GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"EquipoMantenimiento with ID {id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Repository<EquipoMantenimiento>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<EquipoMantenimiento>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<EquipoMantenimiento>().ExistsAsync(id);
    }
}
