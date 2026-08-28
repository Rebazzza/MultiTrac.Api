using AutoMapper;
using Multitrac.Application.DTOs;
using Multitrac.Application.Interfaces;
using Multitrac.Domain.Entities;
using Multitrac.Domain.Exceptions;
using Multitrac.Domain.Interfaces;

namespace Multitrac.Application.Services;

public class PersonalService : ServiceBase<PersonalDto, Personal>
{
    public PersonalService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<PersonalDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<PersonalDto>(entity);
    }

    public override async Task<IEnumerable<PersonalDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<Personal>().GetAllAsync();
        return _mapper.Map<IEnumerable<PersonalDto>>(entities);
    }

    public override async Task<PersonalDto> CreateAsync(PersonalDto dto)
    {
        var entity = _mapper.Map<Personal>(dto);
        await _unitOfWork.Repository<Personal>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<PersonalDto>(entity);
    }

    public override async Task UpdateAsync(int id, PersonalDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<Personal>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        var deleted = await _unitOfWork.ExecuteSqlRawAsync(
            "DELETE FROM PERSONAL WHERE Id_Personal = {0}", id);
        if (deleted == 0)
            throw new NotFoundException(typeof(Personal).Name, id);
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<Personal>().ExistsAsync(id);
    }
}

public class PersonalCargoService : ServiceBase<PersonalCargoDto, PersonalCargo>
{
    public PersonalCargoService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<PersonalCargoDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<PersonalCargoDto>(entity);
    }

    public override async Task<IEnumerable<PersonalCargoDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<PersonalCargo>().GetAllAsync();
        return _mapper.Map<IEnumerable<PersonalCargoDto>>(entities);
    }

    public override async Task<PersonalCargoDto> CreateAsync(PersonalCargoDto dto)
    {
        var entity = _mapper.Map<PersonalCargo>(dto);
        await _unitOfWork.Repository<PersonalCargo>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<PersonalCargoDto>(entity);
    }

    public override async Task UpdateAsync(int id, PersonalCargoDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<PersonalCargo>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<PersonalCargo>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<PersonalCargo>().ExistsAsync(id);
    }
}

public class PersonalVacacionesService : ServiceBase<PersonalVacacionesDto, PersonalVacaciones>
{
    public PersonalVacacionesService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<PersonalVacacionesDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<PersonalVacacionesDto>(entity);
    }

    public override async Task<IEnumerable<PersonalVacacionesDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<PersonalVacaciones>().GetAllAsync();
        return _mapper.Map<IEnumerable<PersonalVacacionesDto>>(entities);
    }

    public override async Task<PersonalVacacionesDto> CreateAsync(PersonalVacacionesDto dto)
    {
        var entity = _mapper.Map<PersonalVacaciones>(dto);
        await SetNextIdAsync(entity);
        await _unitOfWork.Repository<PersonalVacaciones>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<PersonalVacacionesDto>(entity);
    }

    public override async Task UpdateAsync(int id, PersonalVacacionesDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<PersonalVacaciones>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<PersonalVacaciones>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<PersonalVacaciones>().ExistsAsync(id);
    }
}

public class ContratistaService : ServiceBase<ContratistaDto, Contratista>
{
    public ContratistaService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<ContratistaDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<ContratistaDto>(entity);
    }

    public override async Task<IEnumerable<ContratistaDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<Contratista>().GetAllAsync();
        return _mapper.Map<IEnumerable<ContratistaDto>>(entities);
    }

    public override async Task<ContratistaDto> CreateAsync(ContratistaDto dto)
    {
        var entity = _mapper.Map<Contratista>(dto);
        await SetNextIdAsync(entity);
        await _unitOfWork.Repository<Contratista>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<ContratistaDto>(entity);
    }

    public override async Task UpdateAsync(int id, ContratistaDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<Contratista>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<Contratista>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<Contratista>().ExistsAsync(id);
    }
}
