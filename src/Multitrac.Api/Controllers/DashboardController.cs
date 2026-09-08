using Microsoft.AspNetCore.Mvc;
using Multitrac.Application.DTOs;
using Multitrac.Domain.Entities;
using Multitrac.Domain.Interfaces;

namespace Multitrac.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public DashboardController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet("resumen")]
    public async Task<ActionResult<DashboardResumenDto>> GetResumen()
    {
        var hoy = DateTime.Today;

        var docTracto = await _unitOfWork.Repository<EquipoDocumentoTracto>().GetAllAsync();
        var docCarreta = await _unitOfWork.Repository<EquipoDocumentoCarreta>().GetAllAsync();
        var operaciones = await _unitOfWork.Repository<OperacionGeneralEquipo>().GetAllAsync();
        var suenos = await _unitOfWork.Repository<PersonalSueno>().GetAllAsync();

        var documentosExpirados = docTracto.Count(d => d.FechaCaducidad.HasValue && d.FechaCaducidad < hoy)
            + docCarreta.Count(d => d.FechaCaducidad.HasValue && d.FechaCaducidad < hoy);

        var checklistsRegistrados = operaciones.Count(o =>
            o.FechaCheckListMantto.HasValue || o.FechaCheckListPdP.HasValue);

        var suenosHoy = suenos.Count(s => s.Fecha.HasValue && s.Fecha.Value.Date == hoy);

        return Ok(new DashboardResumenDto
        {
            DocumentosExpirados = documentosExpirados,
            ChecklistsRegistrados = checklistsRegistrados,
            SuenosHoy = suenosHoy,
        });
    }
}