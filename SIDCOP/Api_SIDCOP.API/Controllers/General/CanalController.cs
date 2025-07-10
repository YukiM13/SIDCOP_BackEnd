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

        [HttpGet("ListarCanales")]
        public IActionResult ListarCanales()
        {
            var list = _generalServices.ListarCanales();
            return Ok(list);
        }

        [HttpPost("InsertarCanal")]
        public IActionResult InsertarCanal([FromBody]CanalViewModel item)
        {
            var mapped = _mapper.Map<tbCanales>(item);
            var insert = _generalServices.InsertarCanal(mapped);
            return Ok(insert);
        }

        [HttpPut("ActualizarCanal")]
        public IActionResult ActualizarCanal([FromBody] CanalViewModel item)
        {
            var mapped = _mapper.Map<tbCanales>(item);
            var update = _generalServices.ActualizarCanal(mapped);
            return Ok(update);
        }
    }
}