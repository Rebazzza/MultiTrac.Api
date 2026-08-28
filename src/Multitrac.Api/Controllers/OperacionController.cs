using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Multitrac.Application.DTOs;
using Multitrac.Application.Interfaces;
using Multitrac.Application.Services;
using Multitrac.Domain.Entities;

namespace Multitrac.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OperacionController : ControllerBase
{
    private readonly IService<OperacionDto, Multitrac.Domain.Entities.Operacion> _service;
    private readonly IValidator<OperacionDto> _validator;

    public OperacionController(
        IService<OperacionDto, Multitrac.Domain.Entities.Operacion> service,
        IValidator<OperacionDto> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OperacionDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedResult<OperacionDto>>> GetPaged([FromQuery] PaginationRequest request)
    {
        var result = await _service.GetPaginatedAsync(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OperacionDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<OperacionDto>> Create([FromBody] OperacionDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdOperacion }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] OperacionDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        await _service.UpdateAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}

[ApiController]
[Route("api/[controller]")]
public class OperacionGeneralController : ControllerBase
{
    private readonly IService<OperacionGeneralDto, Multitrac.Domain.Entities.OperacionGeneral> _service;
    private readonly IValidator<OperacionGeneralDto> _validator;

    public OperacionGeneralController(
        IService<OperacionGeneralDto, Multitrac.Domain.Entities.OperacionGeneral> service,
        IValidator<OperacionGeneralDto> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OperacionGeneralDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedResult<OperacionGeneralDto>>> GetPaged([FromQuery] PaginationRequest request)
    {
        var result = await _service.GetPaginatedAsync(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OperacionGeneralDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<OperacionGeneralDto>> Create([FromBody] OperacionGeneralDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdOperacionGeneral }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] OperacionGeneralDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        await _service.UpdateAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}

[ApiController]
[Route("api/[controller]")]
public class OperacionGeneralEquipoController : ControllerBase
{
    private readonly IService<OperacionGeneralEquipoDto, Multitrac.Domain.Entities.OperacionGeneralEquipo> _service;
    private readonly IValidator<OperacionGeneralEquipoDto> _validator;

    public OperacionGeneralEquipoController(
        IService<OperacionGeneralEquipoDto, Multitrac.Domain.Entities.OperacionGeneralEquipo> service,
        IValidator<OperacionGeneralEquipoDto> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OperacionGeneralEquipoDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedResult<OperacionGeneralEquipoDto>>> GetPaged([FromQuery] PaginationRequest request)
    {
        var result = await _service.GetPaginatedAsync(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OperacionGeneralEquipoDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<OperacionGeneralEquipoDto>> Create([FromBody] OperacionGeneralEquipoDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdOperacionGeneralEquipo }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] OperacionGeneralEquipoDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        await _service.UpdateAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}

[ApiController]
[Route("api/[controller]")]
public class TipoCargaController : ControllerBase
{
    private readonly IService<TipoCargaDto, Multitrac.Domain.Entities.TipoCarga> _service;
    private readonly IValidator<TipoCargaDto> _validator;

    public TipoCargaController(
        IService<TipoCargaDto, Multitrac.Domain.Entities.TipoCarga> service,
        IValidator<TipoCargaDto> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TipoCargaDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedResult<TipoCargaDto>>> GetPaged([FromQuery] PaginationRequest request)
    {
        var result = await _service.GetPaginatedAsync(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TipoCargaDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<TipoCargaDto>> Create([FromBody] TipoCargaDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdTipoCarga }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] TipoCargaDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        await _service.UpdateAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}

[ApiController]
[Route("api/[controller]")]
public class UnidadController : ControllerBase
{
    private readonly IService<UnidadDto, Multitrac.Domain.Entities.Unidad> _service;
    private readonly IValidator<UnidadDto> _validator;

    public UnidadController(
        IService<UnidadDto, Multitrac.Domain.Entities.Unidad> service,
        IValidator<UnidadDto> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UnidadDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedResult<UnidadDto>>> GetPaged([FromQuery] PaginationRequest request)
    {
        var result = await _service.GetPaginatedAsync(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UnidadDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<UnidadDto>> Create([FromBody] UnidadDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdUnidad }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UnidadDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        await _service.UpdateAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}

[ApiController]
[Route("api/[controller]")]
public class OperacionFleteController : ControllerBase
{
    private readonly IService<OperacionFleteDto, OperacionFlete> _service;
    private readonly IValidator<OperacionFleteDto> _validator;
    private readonly OperacionFleteService _fleteService;

    public OperacionFleteController(
        IService<OperacionFleteDto, OperacionFlete> service,
        IValidator<OperacionFleteDto> validator,
        OperacionFleteService fleteService)
    {
        _service = service;
        _validator = validator;
        _fleteService = fleteService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OperacionFleteDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedResult<OperacionFleteDto>>> GetPaged([FromQuery] PaginationRequest request)
    {
        var result = await _service.GetPaginatedAsync(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OperacionFleteDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("by-operacion/{idOperacion}")]
    public async Task<ActionResult<CalcularFleteResponseDto>> GetFleteByIdOperacion(int idOperacion)
    {
        var result = await _fleteService.GetFleteByIdOperacionAsync(idOperacion);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet("by-cliente-tipo-carga")]
    public async Task<ActionResult<IEnumerable<CalcularFleteResponseDto>>> GetFletesByClienteAndTipoCarga(
        [FromQuery] int idCliente = 0,
        [FromQuery] int idTipoCarga = 0)
    {
        var result = await _fleteService.GetFletesByClienteAndTipoCargaAsync(idCliente, idTipoCarga);
        return Ok(result);
    }

    [HttpGet("reporte-facturacion")]
    public async Task<ActionResult<IEnumerable<ReporteFacturacionResponseDto>>> GetReporteFacturacion(
        [FromQuery] ReporteFacturacionRequestDto request)
    {
        var result = await _fleteService.GetReporteFacturacionAsync(request);
        return Ok(result);
    }

    [HttpGet("indicadores")]
    public async Task<ActionResult<IEnumerable<IndicadoresResponseDto>>> CalcularIndicadores(
        [FromQuery] int anio,
        [FromQuery] int mes)
    {
        var result = await _fleteService.CalcularIndicadoresAsync(anio, mes);
        return Ok(result);
    }

    [HttpGet("contratista-descuentos/{idOperacionGeneral}")]
    public async Task<ActionResult<IEnumerable<ContratistaDescuentoDto>>> GetContratistaDescuentos(int idOperacionGeneral)
    {
        var result = await _fleteService.GetContratistaDescuentosAsync(idOperacionGeneral);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<OperacionFleteDto>> Create([FromBody] OperacionFleteDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdOperacionFlete }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] OperacionFleteDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        await _service.UpdateAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}

[ApiController]
[Route("api/[controller]")]
public class OperacionInformeController : ControllerBase
{
    private readonly IService<OperacionInformeDto, OperacionInforme> _service;
    private readonly IValidator<OperacionInformeDto> _validator;

    public OperacionInformeController(
        IService<OperacionInformeDto, OperacionInforme> service,
        IValidator<OperacionInformeDto> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OperacionInformeDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedResult<OperacionInformeDto>>> GetPaged([FromQuery] PaginationRequest request)
    {
        var result = await _service.GetPaginatedAsync(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OperacionInformeDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<OperacionInformeDto>> Create([FromBody] OperacionInformeDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdOperacionInforme }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] OperacionInformeDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        await _service.UpdateAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
