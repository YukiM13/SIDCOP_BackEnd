using Api_SIDCOP.API.Models.Logistica;
using Api_SIDCOP.API.Models.Ventas;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;
using System.Runtime.CompilerServices;

namespace Api_SIDCOP.API.Controllers.Ventas
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]

    public class RegistrosCaiSController : Controller
    {
        private readonly VentaServices _ventaServices;
        private readonly IMapper _mapper;

        public RegistrosCaiSController(VentaServices ventaServices, IMapper mapper) { 
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
            
            var registro = _ventaServices.BuscarRegistroCaiS(id);
            if (registro != null)
            {
                return Ok(registro);
            }
            else
            {
                return NotFound("Registro no encontrado.");
            }
        }

        [HttpGet("Listar")]
        public IActionResult listar()
        {
            // Mapeo de la lista de registros CAI
            var list = _ventaServices.ListarRegistrosCaiS();
            list = _mapper.Map<IEnumerable<tbRegistrosCAI>>(list);
            return Ok(list);
        }

        [HttpPost("Crear")]
        public IActionResult Insert([FromBody] RegistrosCaiSViewModel item)
        {
            var mapped = _mapper.Map<tbRegistrosCAI>(item);
            var result = _ventaServices.CrearRegistroCAi(mapped);
            return Ok(result);
        }


        [HttpPut("Modificar")]
        public IActionResult Modificar([FromBody] RegistrosCaiSViewModel item)
        {
            var mapped = _mapper.Map<tbRegistrosCAI>(item);
            var update = _ventaServices.ModificarRegistroCai(mapped);
            return Ok(update);
        }


        [HttpPut("Eliminar")]
        public IActionResult Eliminar([FromBody] RegistrosCaiSViewModel item)
        {
            var mapped = _mapper.Map<tbRegistrosCAI>(item);
            var update = _ventaServices.EliminarRegistroCai(mapped);
            return Ok(update);
        }
    }
}
