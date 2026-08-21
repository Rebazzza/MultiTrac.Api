using AutoMapper;
using Multitrac.Application.DTOs;
using Multitrac.Application.Interfaces;
using Multitrac.Domain.Entities;
using Multitrac.Domain.Interfaces;

namespace Multitrac.Application.Services;

public class PersonalService : IService<PersonalDto, Personal>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PersonalService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PersonalDto?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Repository<Personal>().GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<PersonalDto>(entity);
    }

    public async Task<IEnumerable<PersonalDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<Personal>().GetAllAsync();
        return _mapper.Map<IEnumerable<PersonalDto>>(entities);
    }

    public async Task<PersonalDto> CreateAsync(PersonalDto dto)
    {
        var entity = _mapper.Map<Personal>(dto);
        await _unitOfWork.Repository<Personal>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<PersonalDto>(entity);
    }

    public async Task UpdateAsync(int id, PersonalDto dto)
    {
        var entity = await _unitOfWork.Repository<Personal>().GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"Personal with ID {id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Repository<Personal>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<Personal>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<Personal>().ExistsAsync(id);
    }
}

public class PersonalCargoService : IService<PersonalCargoDto, PersonalCargo>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PersonalCargoService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PersonalCargoDto?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Repository<PersonalCargo>().GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<PersonalCargoDto>(entity);
    }

    public async Task<IEnumerable<PersonalCargoDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<PersonalCargo>().GetAllAsync();
        return _mapper.Map<IEnumerable<PersonalCargoDto>>(entities);
    }

    public async Task<PersonalCargoDto> CreateAsync(PersonalCargoDto dto)
    {
        var entity = _mapper.Map<PersonalCargo>(dto);
        await _unitOfWork.Repository<PersonalCargo>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<PersonalCargoDto>(entity);
    }

    public async Task UpdateAsync(int id, PersonalCargoDto dto)
    {
        var entity = await _unitOfWork.Repository<PersonalCargo>().GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"PersonalCargo with ID {id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Repository<PersonalCargo>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<PersonalCargo>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<PersonalCargo>().ExistsAsync(id);
    }
}

public class PersonalVacacionesService : IService<PersonalVacacionesDto, PersonalVacaciones>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PersonalVacacionesService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PersonalVacacionesDto?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Repository<PersonalVacaciones>().GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<PersonalVacacionesDto>(entity);
    }

    public async Task<IEnumerable<PersonalVacacionesDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<PersonalVacaciones>().GetAllAsync();
        return _mapper.Map<IEnumerable<PersonalVacacionesDto>>(entities);
    }

    public async Task<PersonalVacacionesDto> CreateAsync(PersonalVacacionesDto dto)
    {
        var entity = _mapper.Map<PersonalVacaciones>(dto);
        await _unitOfWork.Repository<PersonalVacaciones>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<PersonalVacacionesDto>(entity);
    }

    public async Task UpdateAsync(int id, PersonalVacacionesDto dto)
    {
        var entity = await _unitOfWork.Repository<PersonalVacaciones>().GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"PersonalVacaciones with ID {id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Repository<PersonalVacaciones>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<PersonalVacaciones>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<PersonalVacaciones>().ExistsAsync(id);
    }
}

public class ContratistaService : IService<ContratistaDto, Contratista>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ContratistaService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ContratistaDto?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Repository<Contratista>().GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<ContratistaDto>(entity);
    }

    public async Task<IEnumerable<ContratistaDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<Contratista>().GetAllAsync();
        return _mapper.Map<IEnumerable<ContratistaDto>>(entities);
    }

    public async Task<ContratistaDto> CreateAsync(ContratistaDto dto)
    {
        var entity = _mapper.Map<Contratista>(dto);
        await _unitOfWork.Repository<Contratista>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<ContratistaDto>(entity);
    }

    public async Task UpdateAsync(int id, ContratistaDto dto)
    {
        var entity = await _unitOfWork.Repository<Contratista>().GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"Contratista with ID {id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Repository<Contratista>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<Contratista>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<Contratista>().ExistsAsync(id);
    }
}
