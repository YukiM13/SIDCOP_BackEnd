using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;

[ApiController]
[Route("[controller]")]
[ApiKey]
public class ReportesController : Controller
{
    private readonly ReportesServices _reportesServices;
    private readonly IMapper _mapper;


    public ReportesController(ReportesServices reportesServices, IMapper mapper)
    {
        _reportesServices = reportesServices;
        _mapper = mapper;
    }

    [HttpGet("ReporteDeProductos")]
    public IActionResult ReporteDeProductos(
        [FromQuery] DateTime? fechaInicio = null,
        [FromQuery] DateTime? fechaFin = null,
        [FromQuery] int? marcaId = null,
        [FromQuery] int? categoriaId = null)
    {
        try
        {
            var list = _reportesServices.ReporteProductos(fechaInicio, fechaFin, marcaId, categoriaId);
            return Ok(list);
        }
        catch (Exception ex)
        {
            // Log del error si tienes sistema de logging
            return StatusCode(500, "Error interno del servidor");
        }
    }
}