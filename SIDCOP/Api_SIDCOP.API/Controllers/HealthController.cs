using Microsoft.AspNetCore.Mvc;

namespace Api_SIDCOP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        /// <summary>
        /// Endpoint simple para verificar la disponibilidad del servidor
        /// </summary>
        /// <returns>Estado OK si el servidor está disponible</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { status = "ok", timestamp = DateTime.Now });
        }
    }
}
