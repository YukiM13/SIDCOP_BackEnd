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

    public class UnidadDePesoController : Controller
    {
        public readonly GeneralServices _generalServices;
        public readonly IMapper _mapper;

        public UnidadDePesoController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;


        }



        [HttpGet("Listar")]
        public IActionResult ListarUniPeso()
        {
            var list = _generalServices?.ListarUnidadDePeso();
            return Ok(list);
        }


        [HttpPost("Insertar")]
        public IActionResult Insert([FromBody] UnidadDePesoViewModel item)
        {
            var mapped = _mapper.Map<tbUnidadesDePeso>(item);
            var result = _generalServices.InsertarUnidadDePeso(mapped);
            return Ok(result);
        }


        [HttpPut("Actualizar")]
        public IActionResult Update([FromBody] UnidadDePesoViewModel item)
        {
            var mapped = _mapper.Map<tbUnidadesDePeso>(item);
            var result = _generalServices.UpdateUnidadDePeso(mapped);
            return Ok(result);
        }




        [HttpPost("Eliminar/{id}")]
        public IActionResult Eliminar(int? id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }
            var result = _generalServices.DeleteUnidadPeso(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }




    }
}
