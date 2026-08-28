using AutoMapper;
using Multitrac.Application.DTOs;
using Multitrac.Application.Interfaces;
using Multitrac.Domain.Entities;
using Multitrac.Domain.Exceptions;
using Multitrac.Domain.Interfaces;

namespace Multitrac.Application.Services;

public class EquipoService : ServiceBase<EquipoDto, Equipo>, IEquipoService
{
    public EquipoService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<EquipoDto?> GetByIdAsync(int id)
    {
        throw new NotSupportedException("Equipo uses composite key. Use GetByCompositeKeyAsync instead.");
    }

    public override async Task<IEnumerable<EquipoDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<Equipo>().GetAllAsync();
        return _mapper.Map<IEnumerable<EquipoDto>>(entities);
    }

    public override async Task<EquipoDto> CreateAsync(EquipoDto dto)
    {
        var entity = _mapper.Map<Equipo>(dto);
        await _unitOfWork.Repository<Equipo>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<EquipoDto>(entity);
    }

    public override async Task UpdateAsync(int id, EquipoDto dto)
    {
        throw new NotSupportedException("Equipo uses composite key. Use UpdateAsync(tipoEquipo, codEquipo, dto) instead.");
    }

    public override async Task DeleteAsync(int id)
    {
        throw new NotSupportedException("Equipo uses composite key. Use DeleteAsync(tipoEquipo, codEquipo) instead.");
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        throw new NotSupportedException("Equipo uses composite key. Use ExistsAsync(tipoEquipo, codEquipo) instead.");
    }

    public async Task<EquipoDto?> GetByCompositeKeyAsync(string tipoEquipo, string codEquipo)
    {
        var entity = await _unitOfWork.Repository<Equipo>().FindAsync(tipoEquipo, codEquipo);
        if (entity == null)
            throw new NotFoundException(typeof(Equipo).Name, $"{tipoEquipo}-{codEquipo}");
        return _mapper.Map<EquipoDto>(entity);
    }

    public async Task UpdateAsync(string tipoEquipo, string codEquipo, EquipoDto dto)
    {
        var entity = await _unitOfWork.Repository<Equipo>().FindAsync(tipoEquipo, codEquipo)
            ?? throw new NotFoundException(typeof(Equipo).Name, $"{tipoEquipo}-{codEquipo}");
        _mapper.Map(dto, entity);
        await _unitOfWork.Repository<Equipo>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(string tipoEquipo, string codEquipo)
    {
        var deleted = await _unitOfWork.Repository<Equipo>().DeleteByKeysAsync(tipoEquipo, codEquipo);
        if (!deleted)
            throw new NotFoundException(typeof(Equipo).Name, $"{tipoEquipo}-{codEquipo}");
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(string tipoEquipo, string codEquipo)
    {
        return await _unitOfWork.Repository<Equipo>().FindAsync(tipoEquipo, codEquipo) != null;
    }
}

public class EquipoCombustibleService : ServiceBase<EquipoCombustibleDto, EquipoCombustible>
{
    public EquipoCombustibleService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<EquipoCombustibleDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<EquipoCombustibleDto>(entity);
    }

    public override async Task<IEnumerable<EquipoCombustibleDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<EquipoCombustible>().GetAllAsync();
        return _mapper.Map<IEnumerable<EquipoCombustibleDto>>(entities);
    }

    public override async Task<EquipoCombustibleDto> CreateAsync(EquipoCombustibleDto dto)
    {
        var entity = _mapper.Map<EquipoCombustible>(dto);
        await _unitOfWork.Repository<EquipoCombustible>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<EquipoCombustibleDto>(entity);
    }

    public override async Task UpdateAsync(int id, EquipoCombustibleDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<EquipoCombustible>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<EquipoCombustible>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<EquipoCombustible>().ExistsAsync(id);
    }
}

public class EquipoKilometrajeService : ServiceBase<EquipoKilometrajeDto, EquipoKilometraje>
{
    public EquipoKilometrajeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<EquipoKilometrajeDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<EquipoKilometrajeDto>(entity);
    }

    public override async Task<IEnumerable<EquipoKilometrajeDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<EquipoKilometraje>().GetAllAsync();
        return _mapper.Map<IEnumerable<EquipoKilometrajeDto>>(entities);
    }

    public override async Task<EquipoKilometrajeDto> CreateAsync(EquipoKilometrajeDto dto)
    {
        var entity = _mapper.Map<EquipoKilometraje>(dto);
        await SetNextIdAsync(entity);
        await _unitOfWork.Repository<EquipoKilometraje>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<EquipoKilometrajeDto>(entity);
    }

    public override async Task UpdateAsync(int id, EquipoKilometrajeDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<EquipoKilometraje>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<EquipoKilometraje>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<EquipoKilometraje>().ExistsAsync(id);
    }
}

public class EquipoMantenimientoService : ServiceBase<EquipoMantenimientoDto, EquipoMantenimiento>
{
    public EquipoMantenimientoService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<EquipoMantenimientoDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<EquipoMantenimientoDto>(entity);
    }

    public override async Task<IEnumerable<EquipoMantenimientoDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<EquipoMantenimiento>().GetAllAsync();
        return _mapper.Map<IEnumerable<EquipoMantenimientoDto>>(entities);
    }

    public override async Task<EquipoMantenimientoDto> CreateAsync(EquipoMantenimientoDto dto)
    {
        var entity = _mapper.Map<EquipoMantenimiento>(dto);
        await SetNextIdAsync(entity);
        await _unitOfWork.Repository<EquipoMantenimiento>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<EquipoMantenimientoDto>(entity);
    }

    public override async Task UpdateAsync(int id, EquipoMantenimientoDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<EquipoMantenimiento>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<EquipoMantenimiento>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<EquipoMantenimiento>().ExistsAsync(id);
    }
}
