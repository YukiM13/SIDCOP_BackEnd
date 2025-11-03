using Api_SIDCOP.API.Models.Acceso;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        public readonly AccesoServices _accesoServices;

        public HealthController(AccesoServices accesoServices)
        {
            _accesoServices = accesoServices;
        }

        /// <summary>
        /// Endpoint simple para verificar la disponibilidad del servidor
        /// </summary>
        /// <returns>Estado OK si el servidor está disponible</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { status = "ok", timestamp = DateTime.Now });
        }


        [HttpGet("database")]
        public IActionResult HealthCheck()
        {

            var insert = _accesoServices.HealthCheck();
            return Ok(insert);
        }
    }
}
