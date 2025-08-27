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
    public class EstadoVisitaController : Controller
    {

        public readonly GeneralServices _generalServices;
        public readonly IMapper _mapper;

        public EstadoVisitaController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _generalServices.ListarEstadosVisita();
            
            try
            {
                var mapped= _mapper.Map<List<EstadoVisitaViewModel>>(list);
                return Ok(mapped);

            }
            catch (Exception)
            {

            }
            
            return Ok(list);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] EstadoVisitaViewModel item)
        {
            var mapped = _mapper.Map<tbEstadosVisita>(item);
            var result = _generalServices.InsertarEstadoVisita(mapped);
            return Ok(result);
        }

        [HttpPut("Actualizar")]
        public IActionResult Actualizar([FromBody] EstadoVisitaViewModel item)
        {
            var mapped = _mapper.Map<tbEstadosVisita>(item);
            var result = _generalServices.ActualizarEstadoVisita(mapped);
            return Ok(result);
        }

        [HttpPost("Eliminar/{id}")]
        public IActionResult Eliminar(int? id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalido.");
            }
            var result = _generalServices.EliminarEstadoVisita(id);
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
            var marca = _generalServices.BuscarEstadoVisita(id);
            var mapped = _mapper.Map<EstadoVisitaViewModel>(marca);
            if (marca != null)
            {
                return Ok(marca);
            }
            else
            {
                return NotFound("Estado Civil not found.");
            }
        }

    }
}
