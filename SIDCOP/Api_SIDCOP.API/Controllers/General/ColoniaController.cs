using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;

using MimeKit;
using MailKit.Net.Smtp;
using Api_SIDCOP.API.Models.Acceso;
using MailKit.Security;
using SIDCOP_Backend.Entities.Entities;
using Api_SIDCOP.API.Models.General;

namespace Api_SIDCOP.API.Controllers.General
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]


    public class ColoniaController : Controller
    {
        public readonly GeneralServices _generalServices;
        public readonly IMapper _mapper;



        public ColoniaController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;

        }

        [HttpGet("Listar")]
        public IActionResult ListarColonia()
        {
            var list = _generalServices.ListarColonia();
            return Ok(list);
        }

    
        [HttpPost("Insertar")]
        public IActionResult Insert([FromBody] ColoniaViewModel item)
        {
            var mapped = _mapper.Map<tbColonias>(item);
            var result = _generalServices.InsertarColonia(mapped);
            return Ok(result);
        }


        [HttpPut("Actualizar")]
        public IActionResult Update([FromBody] ColoniaViewModel item)
        {
            var mapped = _mapper.Map<tbColonias>(item);
            var result = _generalServices.UpdateColonia(mapped);
            return Ok(result);
        }




        [HttpPost("Eliminar/{id}")]
        public IActionResult Eliminar(int? id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }
            var result = _generalServices.DeleteColonia(id);
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
                return BadRequest("Id Invalida.");
            }
            var Colonia = _generalServices.BuscarColonia(id);
            if (Colonia != null)
            {
                return Ok(Colonia);
            }
            else
            {
                return NotFound("Colonia not found.");
            }
        }

    }
}
