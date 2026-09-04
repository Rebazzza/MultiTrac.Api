using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Multitrac.Application.DTOs;
using Multitrac.Application.Interfaces;
using Multitrac.Domain.Entities;

namespace Multitrac.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonalController : ControllerBase
{
    private readonly IService<PersonalDto, Personal> _service;
    private readonly IValidator<PersonalDto> _validator;

    public PersonalController(
        IService<PersonalDto, Personal> service,
        IValidator<PersonalDto> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonalDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedResult<PersonalDto>>> GetPaged([FromQuery] PaginationRequest request)
    {
        var result = await _service.GetPaginatedAsync(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PersonalDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<PersonalDto>> Create([FromBody] PersonalDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdPersonal }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PersonalDto dto)
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
public class PersonalCargoController : ControllerBase
{
    private readonly IService<PersonalCargoDto, PersonalCargo> _service;
    private readonly IValidator<PersonalCargoDto> _validator;

    public PersonalCargoController(
        IService<PersonalCargoDto, PersonalCargo> service,
        IValidator<PersonalCargoDto> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonalCargoDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedResult<PersonalCargoDto>>> GetPaged([FromQuery] PaginationRequest request)
    {
        var result = await _service.GetPaginatedAsync(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PersonalCargoDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<PersonalCargoDto>> Create([FromBody] PersonalCargoDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdPersonalCargo }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PersonalCargoDto dto)
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
public class ContratistaController : ControllerBase
{
    private readonly IService<ContratistaDto, Contratista> _service;
    private readonly IValidator<ContratistaDto> _validator;

    public ContratistaController(
        IService<ContratistaDto, Contratista> service,
        IValidator<ContratistaDto> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContratistaDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedResult<ContratistaDto>>> GetPaged([FromQuery] PaginationRequest request)
    {
        var result = await _service.GetPaginatedAsync(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ContratistaDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ContratistaDto>> Create([FromBody] ContratistaDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdContratista }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ContratistaDto dto)
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
public class PersonalVacacionesController : ControllerBase
{
    private readonly IService<PersonalVacacionesDto, PersonalVacaciones> _service;
    private readonly IValidator<PersonalVacacionesDto> _validator;

    public PersonalVacacionesController(
        IService<PersonalVacacionesDto, PersonalVacaciones> service,
        IValidator<PersonalVacacionesDto> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonalVacacionesDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedResult<PersonalVacacionesDto>>> GetPaged([FromQuery] PaginationRequest request)
    {
        var result = await _service.GetPaginatedAsync(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PersonalVacacionesDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<PersonalVacacionesDto>> Create([FromBody] PersonalVacacionesDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdPersonalVacaciones }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PersonalVacacionesDto dto)
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
public class PersonalRecordController : ControllerBase
{
    private readonly IService<PersonalRecordDto, PersonalRecord> _service;
    private readonly IValidator<PersonalRecordDto> _validator;

    public PersonalRecordController(
        IService<PersonalRecordDto, PersonalRecord> service,
        IValidator<PersonalRecordDto> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonalRecordDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedResult<PersonalRecordDto>>> GetPaged([FromQuery] PaginationRequest request)
    {
        var result = await _service.GetPaginatedAsync(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PersonalRecordDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<PersonalRecordDto>> Create([FromBody] PersonalRecordDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdPersonalRecord }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PersonalRecordDto dto)
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
public class PersonalEquipoController : ControllerBase
{
    private readonly IService<PersonalEquipoDto, PersonalEquipo> _service;
    private readonly IValidator<PersonalEquipoDto> _validator;

    public PersonalEquipoController(
        IService<PersonalEquipoDto, PersonalEquipo> service,
        IValidator<PersonalEquipoDto> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonalEquipoDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedResult<PersonalEquipoDto>>> GetPaged([FromQuery] PaginationRequest request)
    {
        var result = await _service.GetPaginatedAsync(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PersonalEquipoDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<PersonalEquipoDto>> Create([FromBody] PersonalEquipoDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdPersonalEquipo }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PersonalEquipoDto dto)
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
public class PersonalEppController : ControllerBase
{
    private readonly IService<PersonalEppDto, PersonalEpp> _service;
    private readonly IValidator<PersonalEppDto> _validator;

    public PersonalEppController(
        IService<PersonalEppDto, PersonalEpp> service,
        IValidator<PersonalEppDto> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonalEppDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedResult<PersonalEppDto>>> GetPaged([FromQuery] PaginationRequest request)
    {
        var result = await _service.GetPaginatedAsync(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PersonalEppDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<PersonalEppDto>> Create([FromBody] PersonalEppDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdPersonalEpp }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PersonalEppDto dto)
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
public class PersonalEppKardexController : ControllerBase
{
    private readonly IService<PersonalEppKardexDto, PersonalEppKardex> _service;
    private readonly IValidator<PersonalEppKardexDto> _validator;

    public PersonalEppKardexController(
        IService<PersonalEppKardexDto, PersonalEppKardex> service,
        IValidator<PersonalEppKardexDto> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonalEppKardexDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedResult<PersonalEppKardexDto>>> GetPaged([FromQuery] PaginationRequest request)
    {
        var result = await _service.GetPaginatedAsync(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PersonalEppKardexDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<PersonalEppKardexDto>> Create([FromBody] PersonalEppKardexDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdPersonalEppKardex }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PersonalEppKardexDto dto)
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
public class PersonalVacacionesRegistroController : ControllerBase
{
    private readonly IService<PersonalVacacionesRegistroDto, PersonalVacacionesRegistro> _service;
    private readonly IValidator<PersonalVacacionesRegistroDto> _validator;

    public PersonalVacacionesRegistroController(
        IService<PersonalVacacionesRegistroDto, PersonalVacacionesRegistro> service,
        IValidator<PersonalVacacionesRegistroDto> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonalVacacionesRegistroDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedResult<PersonalVacacionesRegistroDto>>> GetPaged([FromQuery] PaginationRequest request)
    {
        var result = await _service.GetPaginatedAsync(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PersonalVacacionesRegistroDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<PersonalVacacionesRegistroDto>> Create([FromBody] PersonalVacacionesRegistroDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdPersonalVacacionesReg }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PersonalVacacionesRegistroDto dto)
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
public class PersonalLicenciaConducirController : ControllerBase
{
    private readonly IService<PersonalLicenciaConducirDto, PersonalLicenciaConducir> _service;
    private readonly IValidator<PersonalLicenciaConducirDto> _validator;

    public PersonalLicenciaConducirController(
        IService<PersonalLicenciaConducirDto, PersonalLicenciaConducir> service,
        IValidator<PersonalLicenciaConducirDto> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonalLicenciaConducirDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedResult<PersonalLicenciaConducirDto>>> GetPaged([FromQuery] PaginationRequest request)
    {
        var result = await _service.GetPaginatedAsync(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PersonalLicenciaConducirDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<PersonalLicenciaConducirDto>> Create([FromBody] PersonalLicenciaConducirDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdLicPersonal }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PersonalLicenciaConducirDto dto)
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
public class PersonalSuenoController : ControllerBase
{
    private readonly IService<PersonalSuenoDto, PersonalSueno> _service;
    private readonly IValidator<PersonalSuenoDto> _validator;

    public PersonalSuenoController(
        IService<PersonalSuenoDto, PersonalSueno> service,
        IValidator<PersonalSuenoDto> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonalSuenoDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedResult<PersonalSuenoDto>>> GetPaged([FromQuery] PaginationRequest request)
    {
        var result = await _service.GetPaginatedAsync(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PersonalSuenoDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<PersonalSuenoDto>> Create([FromBody] PersonalSuenoDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdSueno }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PersonalSuenoDto dto)
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
