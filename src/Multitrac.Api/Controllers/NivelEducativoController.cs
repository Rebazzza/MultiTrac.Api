using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Multitrac.Application.DTOs;
using Multitrac.Application.Interfaces;
using Multitrac.Domain.Entities;

namespace Multitrac.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NivelEducativoController : ControllerBase
{
    private readonly IService<NivelEducativoDto, Multitrac.Domain.Entities.NivelEducativo> _service;
    private readonly IValidator<NivelEducativoDto> _validator;

    public NivelEducativoController(
        IService<NivelEducativoDto, Multitrac.Domain.Entities.NivelEducativo> service,
        IValidator<NivelEducativoDto> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<NivelEducativoDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<NivelEducativoDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<NivelEducativoDto>> Create([FromBody] NivelEducativoDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdNivelEducativo }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] NivelEducativoDto dto)
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
