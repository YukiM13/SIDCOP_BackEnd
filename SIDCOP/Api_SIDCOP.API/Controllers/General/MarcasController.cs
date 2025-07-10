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

    public class MarcasController : Controller
    {
        public readonly GeneralServices _generalServices;
        public readonly IMapper _mapper;


        public MarcasController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;

        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _generalServices.ListMarcas();
            return Ok(list);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] MarcaViewModel item)
        {
            var mapped = _mapper.Map<tbMarcas>(item);
            var result = _generalServices.InsertMarca(mapped);
            return Ok(result);
        }

        [HttpPut("Actualizar")]
        public IActionResult Actualizar([FromBody] MarcaViewModel item)
        {
            var mapped = _mapper.Map<tbMarcas>(item);
            var result = _generalServices.ActualizarMarca(mapped);
            return Ok(result);
        }

        //[HttpPost("Eliminar")]
        //public IActionResult Eliminar([FromBody] tbMarcas item)
        //{
        //    var result = _generalServices.EliminarMarca(item);
        //    return Ok(result);
        //}

        [HttpPost("Eliminar/{id}")]
        public IActionResult Eliminar(int? id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalido.");
            }
            var result = _generalServices.EliminarMarca(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalido.");
            }
            var marca = _generalServices.BuscarMarca(id);
            if (marca != null)
            {
                return Ok(marca);
            }
            else
            {
                return NotFound("Marca not found.");
            }
        }

    }
}
