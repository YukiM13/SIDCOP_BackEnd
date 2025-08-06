using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.DataAccess.Repositories.Dashboards;

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

    }
}
