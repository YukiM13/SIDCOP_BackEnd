using Api_SIDCOP.API.Models.Acceso;
using Api_SIDCOP.API.Models.General;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.General
{
    [Route("/[controller]")]
    [ApiController]
    [ApiKey]
    public class AvalController : Controller
    {
        public readonly GeneralServices _generalServices;
        public readonly IMapper _mapper;
        public AvalController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult ListarAvales()
        {
            var list = _generalServices.ListarAvales();
            return Ok(list);
        }

        [HttpPost("Insertar")]
        public IActionResult InsertarAval([FromBody] AvalViewModel
            item)
        {
            var mapped = _mapper.Map<tbAvales>(item);
            var insert = _generalServices.InsertarAval(mapped);
            return Ok(insert);
        }

        [HttpPut("Actualizar")]
        public IActionResult ActualizarAval([FromBody] AvalViewModel item)
        {
            var mapped = _mapper.Map<tbAvales>(item);
            var update = _generalServices.ActualizarAval(mapped);
            return Ok(update);
        }

        [HttpPut("Eliminar/{id}")]
        public IActionResult Eliminar(int? id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalido.");
            }
            var result = _generalServices.EliminarAval(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
