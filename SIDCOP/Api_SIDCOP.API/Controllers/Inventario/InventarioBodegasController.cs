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



        [HttpGet("IniciarJornada")]
        public IActionResult IniciarJornada([FromQuery] int Vend_Id , [FromQuery] int Usuario_Creacion)
        {
            try
            {
                var list = _inventarioServices.IniciarJornada(Vend_Id, Usuario_Creacion);
                return Ok(list);
            }
            catch (Exception ex)
            {
                // Log del error si tienes sistema de logging
                return StatusCode(500, "Error interno del servidor");
            }
        }
        [HttpGet("CierreJornada")]
        public IActionResult CierreJornada([FromQuery] int Vend_Id)
        {
            try
            {
                var list = _inventarioServices.CierreJornada(Vend_Id);
                return Ok(list);
            }
            catch (Exception ex)
            {
                // Log del error si tienes sistema de logging
                return StatusCode(500, "Error interno del servidor");
            }
        }


        [HttpGet("InventarioAsignado")]
        public IActionResult ObtenerInventarioAsignadoPorVendedor([FromQuery] int Vend_Id)
        {
            try
            {
                var list = _inventarioServices.ObtenerInventarioAsignadoPorVendedor(Vend_Id);
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
