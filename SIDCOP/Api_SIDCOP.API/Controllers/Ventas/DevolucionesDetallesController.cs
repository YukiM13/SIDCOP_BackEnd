using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;

namespace Api_SIDCOP.API.Controllers.Ventas
{
    [Route("/[controller]")]
    [ApiController]
    [ApiKey]
    public class DevolucionesDetallesController : ControllerBase
    {

        private readonly VentaServices _ventaServices;
        private readonly IMapper _mapper;


        public DevolucionesDetallesController(VentaServices ventaServices, IMapper mapper)
        {
            _ventaServices = ventaServices;
            _mapper = mapper;

        }


        [HttpGet("Buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }
            var productos = _ventaServices.BuscarDevolucionDetalle(id);
            if (productos != null)
            {
                return Ok(productos);
            }
            else
            {
                return NotFound("Detalle No encontrados.");
            }
        }

    }
}
