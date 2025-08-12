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

    [HttpGet("ReporteProductosPorRuta")]
    public IActionResult ReporteProductosPorRuta([FromQuery] int? rutaId = null)
    {
        try
        {
            var list = _reportesServices.ReporteProductosPorRuta(rutaId);
            return Ok(list);
        }
        catch (Exception ex)
        {
            // Log del error si tienes sistema de logging
            return StatusCode(500, "Error interno del servidor");
        }
    }
    [HttpGet("ReporteRecargasPorBodega")]
    public IActionResult ReporteRecargasPorBodega([FromQuery] int? bodega )
    {
        try
        {
            var list = _reportesServices.ReporteRecargasPorBodega(bodega);
            return Ok(list);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpGet("ReporteClientesMasFacturados")]
    public IActionResult ReporteClientesMasFacturados([FromQuery] DateTime? fechaInicio = null,[FromQuery] DateTime? fechaFin = null){
        try
        {
            var list = _reportesServices.ReporteClientesMasFacturados(fechaInicio, fechaFin);
            return Ok(list);
        }
        catch (Exception ex)
        {
            // Log del error si tienes sistema de logging
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpGet("ReporteDevoluciones")]
    public IActionResult ReporteDevoluciones()
    {
        try
        {
            var list = _reportesServices.ReporteDevoluciones();
            return Ok(list);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpGet("ReporteProductosVendidos")]
    public IActionResult ReporteProductosVendidos(
        [FromQuery] int? categoriaId = null,
        [FromQuery] int? subcategoriaId = null,
        [FromQuery] int? marcaId = null)
    {
        try
        {
            var list = _reportesServices.ReporteProductosVendidos(categoriaId, subcategoriaId, marcaId);
            return Ok(list);
        }
        catch (Exception ex)
        {
            // Log del error si tienes sistema de logging
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpGet("ReporteVendedoresTotalVentas")]
    public IActionResult ReporteVendedoresTotalVentas([FromQuery] DateTime? fechaInicio = null, [FromQuery] DateTime? fechaFin = null)
    {
        try
        {
            var list = _reportesServices.ReporteVendedoresVentas(fechaInicio, fechaFin);
            return Ok(list);
        }
        catch (Exception ex)
        {
            // Log del error si tienes sistema de logging
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpGet("ReporteCuentasPorCliente")]
    public IActionResult ReporteCuentasPorCliente([FromQuery] int? clienteId = null)
    {
        try
        {
            var list = _reportesServices.ReporteClienteCuentas(clienteId);
            return Ok(list);
        }
        catch (Exception ex)
        {
            // Log del error si tienes sistema de logging
            return StatusCode(500, "Error interno del servidor");
        }
    }


    [HttpGet("ReportePedidosPorFecha")]
    public IActionResult ReportePedidosPorFecha([FromQuery] DateTime? fechaInicio = null, [FromQuery] DateTime? fechaFin = null)
    {
        try
        {
            var list = _reportesServices.ReportePedidosPorFecha(fechaInicio, fechaFin);
            return Ok(list);
        }
        catch (Exception ex)
        {
            // Log del error si tienes sistema de logging
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpGet("ReporteVendedoresPorRuta")]
    public IActionResult ReporteVendedoresPorRuta([FromQuery] int? rutaId = null)
    {
        try
        {
            var list = _reportesServices.ReporteVendedoresPorRuta(rutaId);
            return Ok(list);
        }
        catch (Exception ex)
        {
            // Log del error si tienes sistema de logging
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpGet("ReporteClientesPorCanalesFecha")]
    public IActionResult ReporteClientesPorCanalesFecha([FromQuery] DateTime? fechaInicio = null, [FromQuery] DateTime? fechaFin = null, [FromQuery] int? canaId = null)
    {
        try
        {
            var list = _reportesServices.ReporteClientesPorCanalesFecha(fechaInicio, fechaFin, canaId);
            return Ok(list);
        }
        catch (Exception ex)
        {
            // Log del error si tienes sistema de logging
            return StatusCode(500, "Error interno del servidor");
        }
    }
}