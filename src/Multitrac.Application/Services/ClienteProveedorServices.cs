using AutoMapper;
using Multitrac.Application.DTOs;
using Multitrac.Application.Interfaces;
using Multitrac.Domain.Entities;
using Multitrac.Domain.Exceptions;
using Multitrac.Domain.Interfaces;

namespace Multitrac.Application.Services;

public class ClienteService : ServiceBase<ClienteDto, Cliente>
{
    public ClienteService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<ClienteDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<ClienteDto>(entity);
    }

    public override async Task<IEnumerable<ClienteDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<Cliente>().GetAllAsync();
        return _mapper.Map<IEnumerable<ClienteDto>>(entities);
    }

    public override async Task<ClienteDto> CreateAsync(ClienteDto dto)
    {
        var entity = _mapper.Map<Cliente>(dto);
        await _unitOfWork.Repository<Cliente>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<ClienteDto>(entity);
    }

    public override async Task UpdateAsync(int id, ClienteDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<Cliente>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<Cliente>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<Cliente>().ExistsAsync(id);
    }
}

public class ProveedorService : ServiceBase<ProveedorDto, Proveedor>
{
    public ProveedorService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<ProveedorDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<ProveedorDto>(entity);
    }

    public override async Task<IEnumerable<ProveedorDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<Proveedor>().GetAllAsync();
        return _mapper.Map<IEnumerable<ProveedorDto>>(entities);
    }

    public override async Task<ProveedorDto> CreateAsync(ProveedorDto dto)
    {
        var entity = _mapper.Map<Proveedor>(dto);
        await _unitOfWork.Repository<Proveedor>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<ProveedorDto>(entity);
    }

    public override async Task UpdateAsync(int id, ProveedorDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<Proveedor>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<Proveedor>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<Proveedor>().ExistsAsync(id);
    }
}

public class AreaService : ServiceBase<AreaDto, Area>
{
    public AreaService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<AreaDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<AreaDto>(entity);
    }

    public override async Task<IEnumerable<AreaDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<Area>().GetAllAsync();
        return _mapper.Map<IEnumerable<AreaDto>>(entities);
    }

    public override async Task<AreaDto> CreateAsync(AreaDto dto)
    {
        var entity = _mapper.Map<Area>(dto);
        await _unitOfWork.Repository<Area>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<AreaDto>(entity);
    }

    public override async Task UpdateAsync(int id, AreaDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<Area>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<Area>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<Area>().ExistsAsync(id);
    }
}

public class TipoDocumentoService : ServiceBase<TipoDocumentoDto, TipoDocumento>
{
    public TipoDocumentoService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<TipoDocumentoDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<TipoDocumentoDto>(entity);
    }

    public override async Task<IEnumerable<TipoDocumentoDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<TipoDocumento>().GetAllAsync();
        return _mapper.Map<IEnumerable<TipoDocumentoDto>>(entities);
    }

    public override async Task<TipoDocumentoDto> CreateAsync(TipoDocumentoDto dto)
    {
        var entity = _mapper.Map<TipoDocumento>(dto);
        await SetNextIdAsync(entity);
        await _unitOfWork.Repository<TipoDocumento>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<TipoDocumentoDto>(entity);
    }

    public override async Task UpdateAsync(int id, TipoDocumentoDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<TipoDocumento>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<TipoDocumento>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<TipoDocumento>().ExistsAsync(id);
    }
}

public class EmpresaService : ServiceBase<EmpresaDto, Empresa>
{
    public EmpresaService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<EmpresaDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<EmpresaDto>(entity);
    }

    public override async Task<IEnumerable<EmpresaDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<Empresa>().GetAllAsync();
        return _mapper.Map<IEnumerable<EmpresaDto>>(entities);
    }

    public override async Task<EmpresaDto> CreateAsync(EmpresaDto dto)
    {
        var entity = _mapper.Map<Empresa>(dto);
        await _unitOfWork.Repository<Empresa>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<EmpresaDto>(entity);
    }

    public override async Task UpdateAsync(int id, EmpresaDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<Empresa>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<Empresa>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<Empresa>().ExistsAsync(id);
    }
}

public class ConvoyService : ServiceBase<ConvoyDto, Convoy>
{
    public ConvoyService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    public override async Task<ConvoyDto?> GetByIdAsync(int id)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        return _mapper.Map<ConvoyDto>(entity);
    }

    public override async Task<IEnumerable<ConvoyDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<Convoy>().GetAllAsync();
        return _mapper.Map<IEnumerable<ConvoyDto>>(entities);
    }

    public override async Task<ConvoyDto> CreateAsync(ConvoyDto dto)
    {
        var entity = _mapper.Map<Convoy>(dto);
        await _unitOfWork.Repository<Convoy>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<ConvoyDto>(entity);
    }

    public override async Task UpdateAsync(int id, ConvoyDto dto)
    {
        var entity = await GetEntityByIdOrThrowAsync(id);
        _mapper.Map(dto, entity);
        RestorePrimaryKey(entity, id);
        await _unitOfWork.Repository<Convoy>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<Convoy>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public override async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<Convoy>().ExistsAsync(id);
    }
}
