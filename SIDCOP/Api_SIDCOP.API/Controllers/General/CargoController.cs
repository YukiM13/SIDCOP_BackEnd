using Api_SIDCOP.API.Models.General;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.General
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class CargoController : Controller
    {
        public readonly GeneralServices _generalServices;
        public readonly IMapper _mapper;

        public CargoController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult ListarCargos()
        {
            var list = _generalServices.ListarCargos();
            return Ok(list);
        }

        [HttpPost("Insertar")]
        public IActionResult InsertarCargo([FromBody] CargoViewModel item)
        {
            var mapped = _mapper.Map<tbCargos>(item);
            var insert = _generalServices.InsertarCargo(mapped);
            return Ok(insert);
        }

        [HttpPut("Actualizar")]
        public IActionResult ActualizarCargo([FromBody] CargoViewModel item)
        {
            var mapped = _mapper.Map<tbCargos>(item);
            var update = _generalServices.ActualizarCargo(mapped);
            return Ok(update);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarCargo(int? id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }
            var cargo = _generalServices.BuscarCargo(id);
            if (cargo != null)
            {
                return Ok(cargo);
            }
            else
            {
                return NotFound("No se encontró el cargo.");
            }
        }

        [HttpPut("Eliminar/{id}")]
        public IActionResult EliminarCargo(int? id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }
            var delete = _generalServices.EliminarCargo(id);
            if (delete.Success)
            {
                return Ok(delete);
            }
            else
            {
                return NotFound(delete);
            }
        }
    }
}
