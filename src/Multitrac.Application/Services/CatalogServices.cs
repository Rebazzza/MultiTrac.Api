using AutoMapper;
using Multitrac.Application.DTOs;
using Multitrac.Application.Interfaces;
using Multitrac.Domain.Entities;
using Multitrac.Domain.Interfaces;

namespace Multitrac.Application.Services;

public class MonedaService : IService<MonedaDto, Moneda>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MonedaService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<MonedaDto?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Repository<Moneda>().GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<MonedaDto>(entity);
    }

    public async Task<IEnumerable<MonedaDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<Moneda>().GetAllAsync();
        return _mapper.Map<IEnumerable<MonedaDto>>(entities);
    }

    public async Task<MonedaDto> CreateAsync(MonedaDto dto)
    {
        var entity = _mapper.Map<Moneda>(dto);
        await _unitOfWork.Repository<Moneda>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<MonedaDto>(entity);
    }

    public async Task UpdateAsync(int id, MonedaDto dto)
    {
        var entity = await _unitOfWork.Repository<Moneda>().GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"Moneda with ID {id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Repository<Moneda>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<Moneda>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<Moneda>().ExistsAsync(id);
    }
}

public class BancoService : IService<BancoDto, Banco>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BancoService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BancoDto?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Repository<Banco>().GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<BancoDto>(entity);
    }

    public async Task<IEnumerable<BancoDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<Banco>().GetAllAsync();
        return _mapper.Map<IEnumerable<BancoDto>>(entities);
    }

    public async Task<BancoDto> CreateAsync(BancoDto dto)
    {
        var entity = _mapper.Map<Banco>(dto);
        await _unitOfWork.Repository<Banco>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<BancoDto>(entity);
    }

    public async Task UpdateAsync(int id, BancoDto dto)
    {
        var entity = await _unitOfWork.Repository<Banco>().GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"Banco with ID {id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Repository<Banco>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<Banco>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<Banco>().ExistsAsync(id);
    }
}

public class CargoService : IService<CargoDto, Cargo>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CargoService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CargoDto?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Repository<Cargo>().GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<CargoDto>(entity);
    }

    public async Task<IEnumerable<CargoDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<Cargo>().GetAllAsync();
        return _mapper.Map<IEnumerable<CargoDto>>(entities);
    }

    public async Task<CargoDto> CreateAsync(CargoDto dto)
    {
        var entity = _mapper.Map<Cargo>(dto);
        await _unitOfWork.Repository<Cargo>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<CargoDto>(entity);
    }

    public async Task UpdateAsync(int id, CargoDto dto)
    {
        var entity = await _unitOfWork.Repository<Cargo>().GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"Cargo with ID {id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Repository<Cargo>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<Cargo>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<Cargo>().ExistsAsync(id);
    }
}

public class NivelEducativoService : IService<NivelEducativoDto, NivelEducativo>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public NivelEducativoService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<NivelEducativoDto?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Repository<NivelEducativo>().GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<NivelEducativoDto>(entity);
    }

    public async Task<IEnumerable<NivelEducativoDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<NivelEducativo>().GetAllAsync();
        return _mapper.Map<IEnumerable<NivelEducativoDto>>(entities);
    }

    public async Task<NivelEducativoDto> CreateAsync(NivelEducativoDto dto)
    {
        var entity = _mapper.Map<NivelEducativo>(dto);
        await _unitOfWork.Repository<NivelEducativo>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<NivelEducativoDto>(entity);
    }

    public async Task UpdateAsync(int id, NivelEducativoDto dto)
    {
        var entity = await _unitOfWork.Repository<NivelEducativo>().GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"NivelEducativo with ID {id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Repository<NivelEducativo>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<NivelEducativo>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<NivelEducativo>().ExistsAsync(id);
    }
}

public class AfpService : IService<AfpDto, Afp>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AfpService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<AfpDto?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Repository<Afp>().GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<AfpDto>(entity);
    }

    public async Task<IEnumerable<AfpDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<Afp>().GetAllAsync();
        return _mapper.Map<IEnumerable<AfpDto>>(entities);
    }

    public async Task<AfpDto> CreateAsync(AfpDto dto)
    {
        var entity = _mapper.Map<Afp>(dto);
        await _unitOfWork.Repository<Afp>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<AfpDto>(entity);
    }

    public async Task UpdateAsync(int id, AfpDto dto)
    {
        var entity = await _unitOfWork.Repository<Afp>().GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"Afp with ID {id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Repository<Afp>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<Afp>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<Afp>().ExistsAsync(id);
    }
}

public class FlotaService : IService<FlotaDto, Flota>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FlotaService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<FlotaDto?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Repository<Flota>().GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<FlotaDto>(entity);
    }

    public async Task<IEnumerable<FlotaDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<Flota>().GetAllAsync();
        return _mapper.Map<IEnumerable<FlotaDto>>(entities);
    }

    public async Task<FlotaDto> CreateAsync(FlotaDto dto)
    {
        var entity = _mapper.Map<Flota>(dto);
        await _unitOfWork.Repository<Flota>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<FlotaDto>(entity);
    }

    public async Task UpdateAsync(int id, FlotaDto dto)
    {
        var entity = await _unitOfWork.Repository<Flota>().GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"Flota with ID {id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Repository<Flota>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<Flota>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<Flota>().ExistsAsync(id);
    }
}

public class ActividadService : IService<ActividadDto, Actividad>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ActividadService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ActividadDto?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Repository<Actividad>().GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<ActividadDto>(entity);
    }

    public async Task<IEnumerable<ActividadDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<Actividad>().GetAllAsync();
        return _mapper.Map<IEnumerable<ActividadDto>>(entities);
    }

    public async Task<ActividadDto> CreateAsync(ActividadDto dto)
    {
        var entity = _mapper.Map<Actividad>(dto);
        await _unitOfWork.Repository<Actividad>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<ActividadDto>(entity);
    }

    public async Task UpdateAsync(int id, ActividadDto dto)
    {
        var entity = await _unitOfWork.Repository<Actividad>().GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"Actividad with ID {id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Repository<Actividad>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<Actividad>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<Actividad>().ExistsAsync(id);
    }
}

public class TurnoService : IService<TurnoDto, Turno>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TurnoService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<TurnoDto?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Repository<Turno>().GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<TurnoDto>(entity);
    }

    public async Task<IEnumerable<TurnoDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<Turno>().GetAllAsync();
        return _mapper.Map<IEnumerable<TurnoDto>>(entities);
    }

    public async Task<TurnoDto> CreateAsync(TurnoDto dto)
    {
        var entity = _mapper.Map<Turno>(dto);
        await _unitOfWork.Repository<Turno>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<TurnoDto>(entity);
    }

    public async Task UpdateAsync(int id, TurnoDto dto)
    {
        var entity = await _unitOfWork.Repository<Turno>().GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"Turno with ID {id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Repository<Turno>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<Turno>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<Turno>().ExistsAsync(id);
    }
}

public class TipoPagoService : IService<TipoPagoDto, TipoPago>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TipoPagoService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<TipoPagoDto?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Repository<TipoPago>().GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<TipoPagoDto>(entity);
    }

    public async Task<IEnumerable<TipoPagoDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<TipoPago>().GetAllAsync();
        return _mapper.Map<IEnumerable<TipoPagoDto>>(entities);
    }

    public async Task<TipoPagoDto> CreateAsync(TipoPagoDto dto)
    {
        var entity = _mapper.Map<TipoPago>(dto);
        await _unitOfWork.Repository<TipoPago>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<TipoPagoDto>(entity);
    }

    public async Task UpdateAsync(int id, TipoPagoDto dto)
    {
        var entity = await _unitOfWork.Repository<TipoPago>().GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"TipoPago with ID {id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Repository<TipoPago>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<TipoPago>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<TipoPago>().ExistsAsync(id);
    }
}

public class TipoOcurrenciaService : IService<TipoOcurrenciaDto, TipoOcurrencia>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TipoOcurrenciaService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<TipoOcurrenciaDto?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.Repository<TipoOcurrencia>().GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<TipoOcurrenciaDto>(entity);
    }

    public async Task<IEnumerable<TipoOcurrenciaDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.Repository<TipoOcurrencia>().GetAllAsync();
        return _mapper.Map<IEnumerable<TipoOcurrenciaDto>>(entities);
    }

    public async Task<TipoOcurrenciaDto> CreateAsync(TipoOcurrenciaDto dto)
    {
        var entity = _mapper.Map<TipoOcurrencia>(dto);
        await _unitOfWork.Repository<TipoOcurrencia>().CreateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<TipoOcurrenciaDto>(entity);
    }

    public async Task UpdateAsync(int id, TipoOcurrenciaDto dto)
    {
        var entity = await _unitOfWork.Repository<TipoOcurrencia>().GetByIdAsync(id);
        if (entity == null) throw new KeyNotFoundException($"TipoOcurrencia with ID {id} not found");

        _mapper.Map(dto, entity);
        await _unitOfWork.Repository<TipoOcurrencia>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Repository<TipoOcurrencia>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _unitOfWork.Repository<TipoOcurrencia>().ExistsAsync(id);
    }
}
