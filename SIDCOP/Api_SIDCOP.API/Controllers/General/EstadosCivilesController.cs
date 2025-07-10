using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using SIDCOP_Backend.BusinessLogic.Services;
using Api_SIDCOP.API.Models.Acceso;
using MailKit.Security;
using SIDCOP_Backend.Entities.Entities;


namespace Api_SIDCOP.API.Controllers.General
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]

    public class EstadosCivilesController :  Controller
    {
        public readonly GeneralServices _generalServices;
        public readonly IMapper _mapper;

        public EstadosCivilesController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;

        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _generalServices.ListEsCi();
            return Ok(list);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] tbEstadosCiviles item)
        {
            var result = _generalServices.InsertEsCi(item);
            return Ok(result);
        }

        [HttpPut("Actualizar")]
        public IActionResult Actualizar([FromBody] tbEstadosCiviles item)
        {
            var result = _generalServices.ActualizarEsCi(item);
            return Ok(result);
        }

        [HttpPost("Eliminar/{id}")]
        public IActionResult Eliminar(int? id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalido.");
            }
            var result = _generalServices.EliminarEsCi(id);
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
            var marca = _generalServices.BuscarEsCi(id);
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
