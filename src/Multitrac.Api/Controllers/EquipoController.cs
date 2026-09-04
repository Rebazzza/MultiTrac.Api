using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Multitrac.Application.DTOs;
using Multitrac.Application.Interfaces;
using Multitrac.Domain.Entities;

namespace Multitrac.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EquipoController : ControllerBase
{
    private readonly IEquipoService _service;
    private readonly IValidator<EquipoDto> _validator;

    public EquipoController(
        IEquipoService service,
        IValidator<EquipoDto> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EquipoDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedResult<EquipoDto>>> GetPaged([FromQuery] PaginationRequest request)
    {
        var result = await _service.GetPaginatedAsync(request);
        return Ok(result);
    }

    [HttpGet("{tipoEquipo}/{codEquipo}")]
    public async Task<ActionResult<EquipoDto>> GetByCompositeKey(string tipoEquipo, string codEquipo)
    {
        var result = await _service.GetByCompositeKeyAsync(tipoEquipo, codEquipo);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<EquipoDto>> Create([FromBody] EquipoDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetByCompositeKey),
            new { tipoEquipo = result.TipoEquipo, codEquipo = result.CodEquipo }, result);
    }

    [HttpPut("{tipoEquipo}/{codEquipo}")]
    public async Task<IActionResult> Update(string tipoEquipo, string codEquipo, [FromBody] EquipoDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        await _service.UpdateAsync(tipoEquipo, codEquipo, dto);
        return NoContent();
    }

    [HttpDelete("{tipoEquipo}/{codEquipo}")]
    public async Task<IActionResult> Delete(string tipoEquipo, string codEquipo)
    {
        await _service.DeleteAsync(tipoEquipo, codEquipo);
        return NoContent();
    }
}

[ApiController]
[Route("api/[controller]")]
public class EquipoCombustibleController : ControllerBase
{
    private readonly IService<EquipoCombustibleDto, EquipoCombustible> _service;
    private readonly IValidator<EquipoCombustibleDto> _validator;

    public EquipoCombustibleController(
        IService<EquipoCombustibleDto, EquipoCombustible> service,
        IValidator<EquipoCombustibleDto> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EquipoCombustibleDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedResult<EquipoCombustibleDto>>> GetPaged([FromQuery] PaginationRequest request)
    {
        var result = await _service.GetPaginatedAsync(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EquipoCombustibleDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<EquipoCombustibleDto>> Create([FromBody] EquipoCombustibleDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdCombustibleEquipo }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] EquipoCombustibleDto dto)
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
public class EquipoKilometrajeController : ControllerBase
{
    private readonly IService<EquipoKilometrajeDto, EquipoKilometraje> _service;
    private readonly IValidator<EquipoKilometrajeDto> _validator;

    public EquipoKilometrajeController(
        IService<EquipoKilometrajeDto, EquipoKilometraje> service,
        IValidator<EquipoKilometrajeDto> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EquipoKilometrajeDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedResult<EquipoKilometrajeDto>>> GetPaged([FromQuery] PaginationRequest request)
    {
        var result = await _service.GetPaginatedAsync(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EquipoKilometrajeDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<EquipoKilometrajeDto>> Create([FromBody] EquipoKilometrajeDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdEquipoKilometraje }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] EquipoKilometrajeDto dto)
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
public class EquipoMantenimientoController : ControllerBase
{
    private readonly IService<EquipoMantenimientoDto, EquipoMantenimiento> _service;
    private readonly IValidator<EquipoMantenimientoDto> _validator;

    public EquipoMantenimientoController(
        IService<EquipoMantenimientoDto, EquipoMantenimiento> service,
        IValidator<EquipoMantenimientoDto> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EquipoMantenimientoDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedResult<EquipoMantenimientoDto>>> GetPaged([FromQuery] PaginationRequest request)
    {
        var result = await _service.GetPaginatedAsync(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EquipoMantenimientoDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<EquipoMantenimientoDto>> Create([FromBody] EquipoMantenimientoDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdEquipoMantenimiento }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] EquipoMantenimientoDto dto)
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
public class EquipoMantenimientoDetalleController : ControllerBase
{
    private readonly IService<EquipoMantenimientoDetalleDto, EquipoMantenimientoDetalle> _service;
    private readonly IValidator<EquipoMantenimientoDetalleDto> _validator;

    public EquipoMantenimientoDetalleController(
        IService<EquipoMantenimientoDetalleDto, EquipoMantenimientoDetalle> service,
        IValidator<EquipoMantenimientoDetalleDto> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EquipoMantenimientoDetalleDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedResult<EquipoMantenimientoDetalleDto>>> GetPaged([FromQuery] PaginationRequest request)
    {
        var result = await _service.GetPaginatedAsync(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EquipoMantenimientoDetalleDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<EquipoMantenimientoDetalleDto>> Create([FromBody] EquipoMantenimientoDetalleDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdEquipoMantenimientoDetalle }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] EquipoMantenimientoDetalleDto dto)
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
public class EquipoDocumentoTractoController : ControllerBase
{
    private readonly IService<EquipoDocumentoTractoDto, EquipoDocumentoTracto> _service;

    public EquipoDocumentoTractoController(IService<EquipoDocumentoTractoDto, EquipoDocumentoTracto> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EquipoDocumentoTractoDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedResult<EquipoDocumentoTractoDto>>> GetPaged([FromQuery] PaginationRequest request)
    {
        var result = await _service.GetPaginatedAsync(request);
        return Ok(result);
    }
}

[ApiController]
[Route("api/[controller]")]
public class EquipoDocumentoCarretaController : ControllerBase
{
    private readonly IService<EquipoDocumentoCarretaDto, EquipoDocumentoCarreta> _service;

    public EquipoDocumentoCarretaController(IService<EquipoDocumentoCarretaDto, EquipoDocumentoCarreta> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EquipoDocumentoCarretaDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedResult<EquipoDocumentoCarretaDto>>> GetPaged([FromQuery] PaginationRequest request)
    {
        var result = await _service.GetPaginatedAsync(request);
        return Ok(result);
    }
}
