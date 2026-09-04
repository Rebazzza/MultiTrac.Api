using AutoMapper;
using Multitrac.Application.DTOs;
using Multitrac.Application.Interfaces;
using Multitrac.Domain.Entities;
using Multitrac.Domain.Interfaces;

namespace Multitrac.Application.Services;

public class BaucherCajaService : ServiceBase<BaucherCajaDto, BaucherCaja>
{
    public BaucherCajaService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<BaucherCajaDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<BaucherCajaDto>(entity);
    }

    public override async Task<IEnumerable<BaucherCajaDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<BaucherCaja>().GetAllAsync();
        return _mapper.Map<IEnumerable<BaucherCajaDto>>(entities);
    }

    public override async Task<BaucherCajaDto> CreateAsync(BaucherCajaDto dto)
    {
        var entity = _mapper.Map<BaucherCaja>(dto);
        await SetNextIdAsync(entity);
        await _unitOfWork.Repository<BaucherCaja>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<BaucherCajaDto>(entity);
    }

    public override async Task UpdateAsync(int id, BaucherCajaDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<BaucherCaja>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<BaucherCaja>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<BaucherCaja>().ExistsAsync(id);
    }
}

public class BaucherEgresoService : ServiceBase<BaucherEgresoDto, BaucherEgreso>
{
    public BaucherEgresoService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<BaucherEgresoDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<BaucherEgresoDto>(entity);
    }

    public override async Task<IEnumerable<BaucherEgresoDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<BaucherEgreso>().GetAllAsync();
        return _mapper.Map<IEnumerable<BaucherEgresoDto>>(entities);
    }

    public override async Task<BaucherEgresoDto> CreateAsync(BaucherEgresoDto dto)
    {
        var entity = _mapper.Map<BaucherEgreso>(dto);
        await SetNextIdAsync(entity);
        await _unitOfWork.Repository<BaucherEgreso>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<BaucherEgresoDto>(entity);
    }

    public override async Task UpdateAsync(int id, BaucherEgresoDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<BaucherEgreso>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<BaucherEgreso>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<BaucherEgreso>().ExistsAsync(id);
    }
}
