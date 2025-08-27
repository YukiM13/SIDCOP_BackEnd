using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.DataAccess.Repositories.Dashboards;
using System.Collections.Generic;

namespace Api_SIDCOP.API.Controllers.Dashboards
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]

    public class DashboardsController : Controller
    {
        private readonly DashboardServices _dashboardServices;
        private readonly IMapper _mapper;


        public DashboardsController(DashboardServices dashboardServices, IMapper mapper)
        {
            _dashboardServices = dashboardServices;
            _mapper = mapper;
        }

        [HttpGet("VentasPorMes")]
        public IActionResult VentasPorMes()
        {
            try
            {
                var list = _dashboardServices.VentasPorMes();
                return Ok(list);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPost("VentasPorMesProductos")]
        public IActionResult VentasPorMesProductos(DashboardsViewModel item)
        {
            try
            {
                var list = _dashboardServices.VentasPorMesProductos(item);
                return Ok(list);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPost("VentasPorMesCategorias")]
        public IActionResult VentasPorMesCategorias(DashboardsViewModel item)
        {
            try
            {
                var list = _dashboardServices.VentasPorMesCategorias(item);
                return Ok(list);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPost("TopVendedoresPorMes")]
        public IActionResult TopVendedoresPorMes(DashboardsViewModel item)
        {
            try
            {
                var list = _dashboardServices.Top5VendedoresPorMes(item);
                return Ok(list);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPost("TopProductosPorCategoria")]
        public IActionResult TopProductosPorCategoria(DashboardsViewModel item)
        {
            try
            {
                var list = _dashboardServices.Top5ProductosCategoria(item);
                return Ok(list);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("DashboardTop5MarcasMasVendidas")]
        public IActionResult DashboardTop5MarcasMasVendidas(
            [FromQuery] DateTime? fechaInicio = null,
            [FromQuery] DateTime? fechaFin = null)
        {
            try
            {
                var list = _dashboardServices.Top5MarcasMasVendidas(fechaInicio, fechaFin);
                return Ok(list);
            }
            catch (Exception ex)
            {
                // Log del error si tienes sistema de logging
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("ReporteDeProductos")]
        public IActionResult ReporteDeProductos(
            [FromQuery] int marcaId,
            [FromQuery] DateTime? fechaInicio = null,
            [FromQuery] DateTime? fechaFin = null)
        {
            if (marcaId == 0)
            {
                return Ok("Ingrese una marca");
            }
            try
            {
                var list = _dashboardServices.ProductosPorMarcas(marcaId, fechaInicio, fechaFin);
                return Ok(list);
            }
            catch (Exception ex)
            {
                // Log del error si tienes sistema de logging
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
