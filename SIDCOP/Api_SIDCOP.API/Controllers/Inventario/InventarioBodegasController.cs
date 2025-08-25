using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;

namespace Api_SIDCOP.API.Controllers.Inventario
{
    [Route("/[controller]")]
    [ApiController]
    [ApiKey]
    public class InventarioBodegasController : Controller
    {

        private readonly InventarioServices _inventarioServices;
        private readonly IMapper _mapper;

        public InventarioBodegasController(InventarioServices inventarioServices, IMapper mapper)
        {
            _inventarioServices = inventarioServices;
            _mapper = mapper;
        }


        [HttpGet("JornadaDetallada/{vendId}")]
        public IActionResult ObtenerReporteJornadaDetallado(int vendId, [FromQuery] DateTime? fecha = null)
        {
            if (vendId <= 0)
            {
                return BadRequest("ID de vendedor inválido.");
            }

            try
            {
                var result = _inventarioServices.ObtenerReporteJornadaDetallado(vendId, fecha);

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Success = false,
                    Message = "Error interno del servidor",
                    Details = ex.Message
                });
            }
        }
    }
}
