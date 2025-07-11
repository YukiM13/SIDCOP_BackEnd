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
    public class DepartamentosController: Controller
    {
        private readonly GeneralServices _generalServices;
        private readonly IMapper _mapper;

        public DepartamentosController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] DepartamentoViewModel item)
        {
            var mapped = _mapper.Map<tbDepartamentos>(item);
            var result = _generalServices.InsertarDepartamento(mapped);
            return Ok(result);
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {

            var result = _generalServices.ListarDepartamentos();
            return Ok(result);
        }



        [HttpPost("Buscar/{id}")]
        public IActionResult Buscar(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id Invalida.");
            }

            var deparatemnto = _generalServices.BuscarDepartamento(id);
            if (deparatemnto != null)
            {
                return Ok(deparatemnto);
            }
            else
            {
                return NotFound("Sucursal no encontrada con el ID proporcionado.");
            }
        }


        [HttpPost("Eliminar/{id}")]
        public IActionResult Eliminar(string? id)
        {
            if (string.IsNullOrEmpty(id) || id.Length < 0)
            {
                return BadRequest("Codigo llego mal.");
            }

            var result = _generalServices.EliminarDepartamento(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPut("Editar")]
        public IActionResult Editar([FromBody] DepartamentoViewModel item)
        {
            var mapped = _mapper.Map<tbDepartamentos>(item);
            var result = _generalServices.EditarDepartamento(mapped);
            return Ok(result);
        }

    }
}
