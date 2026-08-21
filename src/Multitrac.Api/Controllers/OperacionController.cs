using Microsoft.AspNetCore.Mvc;
using Multitrac.Application.DTOs;
using Multitrac.Application.Interfaces;
using Multitrac.Domain.Entities;

namespace Multitrac.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OperacionController : ControllerBase
{
    private readonly IService<OperacionDto, Multitrac.Domain.Entities.Operacion> _service;

    public OperacionController(IService<OperacionDto, Multitrac.Domain.Entities.Operacion> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OperacionDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OperacionDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<OperacionDto>> Create([FromBody] OperacionDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdOperacion }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] OperacionDto dto)
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
public class OperacionGeneralController : ControllerBase
{
    private readonly IService<OperacionGeneralDto, Multitrac.Domain.Entities.OperacionGeneral> _service;

    public OperacionGeneralController(IService<OperacionGeneralDto, Multitrac.Domain.Entities.OperacionGeneral> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OperacionGeneralDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OperacionGeneralDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<OperacionGeneralDto>> Create([FromBody] OperacionGeneralDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdOperacionGeneral }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] OperacionGeneralDto dto)
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
public class OperacionGeneralEquipoController : ControllerBase
{
    private readonly IService<OperacionGeneralEquipoDto, Multitrac.Domain.Entities.OperacionGeneralEquipo> _service;

    public OperacionGeneralEquipoController(IService<OperacionGeneralEquipoDto, Multitrac.Domain.Entities.OperacionGeneralEquipo> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OperacionGeneralEquipoDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OperacionGeneralEquipoDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<OperacionGeneralEquipoDto>> Create([FromBody] OperacionGeneralEquipoDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdOperacionGeneralEquipo }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] OperacionGeneralEquipoDto dto)
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
public class TipoCargaController : ControllerBase
{
    private readonly IService<TipoCargaDto, Multitrac.Domain.Entities.TipoCarga> _service;

    public TipoCargaController(IService<TipoCargaDto, Multitrac.Domain.Entities.TipoCarga> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TipoCargaDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TipoCargaDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<TipoCargaDto>> Create([FromBody] TipoCargaDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdTipoCarga }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] TipoCargaDto dto)
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
public class UnidadController : ControllerBase
{
    private readonly IService<UnidadDto, Multitrac.Domain.Entities.Unidad> _service;

    public UnidadController(IService<UnidadDto, Multitrac.Domain.Entities.Unidad> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UnidadDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UnidadDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<UnidadDto>> Create([FromBody] UnidadDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdUnidad }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UnidadDto dto)
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
public class OperacionFleteController : ControllerBase
{
    private readonly IService<OperacionFleteDto, OperacionFlete> _service;

    public OperacionFleteController(IService<OperacionFleteDto, OperacionFlete> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OperacionFleteDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OperacionFleteDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<OperacionFleteDto>> Create([FromBody] OperacionFleteDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdOperacionFlete }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] OperacionFleteDto dto)
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
public class OperacionInformeController : ControllerBase
{
    private readonly IService<OperacionInformeDto, OperacionInforme> _service;

    public OperacionInformeController(IService<OperacionInformeDto, OperacionInforme> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OperacionInformeDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OperacionInformeDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<OperacionInformeDto>> Create([FromBody] OperacionInformeDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdOperacionInforme }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] OperacionInformeDto dto)
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
