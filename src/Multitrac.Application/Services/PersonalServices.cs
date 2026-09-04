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

public class PersonalRecordService : ServiceBase<PersonalRecordDto, PersonalRecord>
{
    public PersonalRecordService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<PersonalRecordDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<PersonalRecordDto>(entity);
    }

    public override async Task<IEnumerable<PersonalRecordDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<PersonalRecord>().GetAllAsync();
        return _mapper.Map<IEnumerable<PersonalRecordDto>>(entities);
    }

    public override async Task<PersonalRecordDto> CreateAsync(PersonalRecordDto dto)
    {
        var entity = _mapper.Map<PersonalRecord>(dto);
        await _unitOfWork.Repository<PersonalRecord>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<PersonalRecordDto>(entity);
    }

    public override async Task UpdateAsync(int id, PersonalRecordDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<PersonalRecord>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<PersonalRecord>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<PersonalRecord>().ExistsAsync(id);
    }
}

public class PersonalEquipoService : ServiceBase<PersonalEquipoDto, PersonalEquipo>
{
    public PersonalEquipoService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<PersonalEquipoDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<PersonalEquipoDto>(entity);
    }

    public override async Task<IEnumerable<PersonalEquipoDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<PersonalEquipo>().GetAllAsync();
        return _mapper.Map<IEnumerable<PersonalEquipoDto>>(entities);
    }

    public override async Task<PersonalEquipoDto> CreateAsync(PersonalEquipoDto dto)
    {
        var entity = _mapper.Map<PersonalEquipo>(dto);
        await _unitOfWork.Repository<PersonalEquipo>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<PersonalEquipoDto>(entity);
    }

    public override async Task UpdateAsync(int id, PersonalEquipoDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<PersonalEquipo>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<PersonalEquipo>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<PersonalEquipo>().ExistsAsync(id);
    }
}

public class PersonalEppService : ServiceBase<PersonalEppDto, PersonalEpp>
{
    public PersonalEppService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<PersonalEppDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<PersonalEppDto>(entity);
    }

    public override async Task<IEnumerable<PersonalEppDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<PersonalEpp>().GetAllAsync();
        return _mapper.Map<IEnumerable<PersonalEppDto>>(entities);
    }

    public override async Task<PersonalEppDto> CreateAsync(PersonalEppDto dto)
    {
        var entity = _mapper.Map<PersonalEpp>(dto);
        await _unitOfWork.Repository<PersonalEpp>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<PersonalEppDto>(entity);
    }

    public override async Task UpdateAsync(int id, PersonalEppDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<PersonalEpp>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<PersonalEpp>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<PersonalEpp>().ExistsAsync(id);
    }
}

public class PersonalEppKardexService : ServiceBase<PersonalEppKardexDto, PersonalEppKardex>
{
    public PersonalEppKardexService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<PersonalEppKardexDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<PersonalEppKardexDto>(entity);
    }

    public override async Task<IEnumerable<PersonalEppKardexDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<PersonalEppKardex>().GetAllAsync();
        return _mapper.Map<IEnumerable<PersonalEppKardexDto>>(entities);
    }

    public override async Task<PersonalEppKardexDto> CreateAsync(PersonalEppKardexDto dto)
    {
        var entity = _mapper.Map<PersonalEppKardex>(dto);
        await _unitOfWork.Repository<PersonalEppKardex>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<PersonalEppKardexDto>(entity);
    }

    public override async Task UpdateAsync(int id, PersonalEppKardexDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<PersonalEppKardex>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<PersonalEppKardex>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<PersonalEppKardex>().ExistsAsync(id);
    }
}

public class PersonalVacacionesRegistroService : ServiceBase<PersonalVacacionesRegistroDto, PersonalVacacionesRegistro>
{
    public PersonalVacacionesRegistroService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<PersonalVacacionesRegistroDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<PersonalVacacionesRegistroDto>(entity);
    }

    public override async Task<IEnumerable<PersonalVacacionesRegistroDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<PersonalVacacionesRegistro>().GetAllAsync();
        return _mapper.Map<IEnumerable<PersonalVacacionesRegistroDto>>(entities);
    }

    public override async Task<PersonalVacacionesRegistroDto> CreateAsync(PersonalVacacionesRegistroDto dto)
    {
        var entity = _mapper.Map<PersonalVacacionesRegistro>(dto);
        await SetNextIdAsync(entity);
        await _unitOfWork.Repository<PersonalVacacionesRegistro>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<PersonalVacacionesRegistroDto>(entity);
    }

    public override async Task UpdateAsync(int id, PersonalVacacionesRegistroDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<PersonalVacacionesRegistro>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<PersonalVacacionesRegistro>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<PersonalVacacionesRegistro>().ExistsAsync(id);
    }
}

public class PersonalLicenciaConducirService : ServiceBase<PersonalLicenciaConducirDto, PersonalLicenciaConducir>
{
    public PersonalLicenciaConducirService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<PersonalLicenciaConducirDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<PersonalLicenciaConducirDto>(entity);
    }

    public override async Task<IEnumerable<PersonalLicenciaConducirDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<PersonalLicenciaConducir>().GetAllAsync();
        return _mapper.Map<IEnumerable<PersonalLicenciaConducirDto>>(entities);
    }

    public override async Task<PersonalLicenciaConducirDto> CreateAsync(PersonalLicenciaConducirDto dto)
    {
        var entity = _mapper.Map<PersonalLicenciaConducir>(dto);
        await _unitOfWork.Repository<PersonalLicenciaConducir>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<PersonalLicenciaConducirDto>(entity);
    }

    public override async Task UpdateAsync(int id, PersonalLicenciaConducirDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<PersonalLicenciaConducir>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<PersonalLicenciaConducir>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<PersonalLicenciaConducir>().ExistsAsync(id);
    }
}

public class PersonalSuenoService : ServiceBase<PersonalSuenoDto, PersonalSueno>
{
    public PersonalSuenoService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<PersonalSuenoDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<PersonalSuenoDto>(entity);
    }

    public override async Task<IEnumerable<PersonalSuenoDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<PersonalSueno>().GetAllAsync();
        return _mapper.Map<IEnumerable<PersonalSuenoDto>>(entities);
    }

    public override async Task<PersonalSuenoDto> CreateAsync(PersonalSuenoDto dto)
    {
        var entity = _mapper.Map<PersonalSueno>(dto);
        await SetNextIdAsync(entity);
        await _unitOfWork.Repository<PersonalSueno>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<PersonalSuenoDto>(entity);
    }

    public override async Task UpdateAsync(int id, PersonalSuenoDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<PersonalSueno>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<PersonalSueno>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<PersonalSueno>().ExistsAsync(id);
    }
}
