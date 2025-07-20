using Api_SIDCOP.API.Models.General;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Cmp;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.General
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class DireccionesPorClienteController : Controller
    {
        public readonly GeneralServices _generalServices;
        public readonly IMapper _mapper;

        public DireccionesPorClienteController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult ListarDireccionesPorCLiente()
        {
            var list = _generalServices.ListarDireccionesPorCliente();
            return Ok(list);
        }

        [HttpPost("Insertar")]
        public IActionResult InsertarDireccionPorCliente([FromBody] DireccionesPorClienteViewModel item)
        {
            var mapped = _mapper.Map<tbDireccionesPorCliente>(item);
            var insert = _generalServices.InsertarDireccionPorCliente(mapped);
            return Ok(insert);
        }

        [HttpPut("Actualizar")]
        public IActionResult ActualizarCargo([FromBody] DireccionesPorClienteViewModel item)
        {
            var mapped = _mapper.Map<tbDireccionesPorCliente>(item);
            var update = _generalServices.ActualizarDireccionPorCliente(mapped);
            return Ok(update);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarDireccionesPorCliente(int? id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }
            var cargo = _generalServices.DireccionesPorCliente_Buscar(id);
            if (cargo != null)
            {
                return Ok(cargo);
            }
            else
            {
                return NotFound("No se encontró el cargo.");
            }
        }

        [HttpPost("Eliminar/{id}")]
        public IActionResult Eliminar(int? id)
        {

            var list = _generalServices.EliminarDireccionesPorCliente(id);
            return Ok(list);
        }
    }
}
