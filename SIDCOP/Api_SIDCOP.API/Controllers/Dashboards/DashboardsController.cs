using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;

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
        public IActionResult ReporteDeProductos()
        {
            try
            {
                var list = _dashboardServices.VentasPorMes();
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
