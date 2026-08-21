using Microsoft.AspNetCore.Mvc;
using Multitrac.Application.DTOs;
using Multitrac.Application.Interfaces;
using Multitrac.Domain.Entities;

namespace Multitrac.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EquipoDataController : ControllerBase
{
    private readonly IService<EquipoDto, Equipo> _service;

    public EquipoDataController(IService<EquipoDto, Equipo> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EquipoDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EquipoDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<EquipoDto>> Create([FromBody] EquipoDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return Created(string.Empty, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] EquipoDto dto)
    {
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
public class EquipoCombustibleController : ControllerBase
{
    private readonly IService<EquipoCombustibleDto, EquipoCombustible> _service;

    public EquipoCombustibleController(IService<EquipoCombustibleDto, EquipoCombustible> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EquipoCombustibleDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EquipoCombustibleDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<EquipoCombustibleDto>> Create([FromBody] EquipoCombustibleDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdCombustibleEquipo }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] EquipoCombustibleDto dto)
    {
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

    public EquipoKilometrajeController(IService<EquipoKilometrajeDto, EquipoKilometraje> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EquipoKilometrajeDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EquipoKilometrajeDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<EquipoKilometrajeDto>> Create([FromBody] EquipoKilometrajeDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdEquipoKilometraje }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] EquipoKilometrajeDto dto)
    {
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

    public EquipoMantenimientoController(IService<EquipoMantenimientoDto, EquipoMantenimiento> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EquipoMantenimientoDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EquipoMantenimientoDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<EquipoMantenimientoDto>> Create([FromBody] EquipoMantenimientoDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdEquipoMantenimiento }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] EquipoMantenimientoDto dto)
    {
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
