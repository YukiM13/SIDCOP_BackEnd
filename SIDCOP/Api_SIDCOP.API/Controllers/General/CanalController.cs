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
    public class CanalController : Controller
    {
        public readonly GeneralServices _generalServices;
        public readonly IMapper _mapper;

        public CanalController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult ListarCanales()
        {
            var list = _generalServices.ListarCanales();
            return Ok(list);
        }

        [HttpPost("Insertar")]
        public IActionResult InsertarCanal([FromBody]CanalViewModel item)
        {
            var mapped = _mapper.Map<tbCanales>(item);
            var insert = _generalServices.InsertarCanal(mapped);
            return Ok(insert);
        }

        [HttpPut("Actualizar")]
        public IActionResult ActualizarCanal([FromBody] CanalViewModel item)
        {
            var mapped = _mapper.Map<tbCanales>(item);
            var update = _generalServices.ActualizarCanal(mapped);
            return Ok(update);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarCanal(int? id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }
            var canal = _generalServices.BuscarCanal(id);
            if (canal != null)
            {
                return Ok(canal);
            }
            else
            {
                return NotFound("Canal no encontrado.");
            }
        }

        [HttpPut("Eliminar/{id}")]
        public IActionResult Eliminar(int? id)
        {
            if(id<=0)
            {
                return BadRequest("Id Invalida.");
            }
            var delete = _generalServices.EliminarCanal(id);
            if(delete.Success)
            {
                return Ok(delete);
            }
            else
            {
                return BadRequest(delete);
            }
        }
    }
}