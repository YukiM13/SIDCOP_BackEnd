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
        public IActionResult Insertar([FromBody] tbMarcas item)
        {
            var result = _generalServices.InsertMarca(item);
            return Ok(result);
        }

    }
}
