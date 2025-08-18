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

    public class ImagenVisitaController : Controller
    {
        public readonly GeneralServices _generalServices;
        public readonly IMapper _mapper;

        public ImagenVisitaController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _generalServices.ListImVi();
            return Ok(list);
        }

        [HttpPost("ListarPorVisita/{id}")]
        public IActionResult ListPorVisita(int id)
        {
            var imvi = _generalServices.ListPorVisita(id);
            if (imvi != null)
            {
                return Ok(imvi);
            }
            else
            {
                return NotFound("Visita no encontrada con el ID proporcionado.");
            }
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] ImagenVisitaViewModel item)
        {
            var mapped = _mapper.Map<tbImagenesVisita>(item);
            var result = _generalServices.InsertImVi(mapped);
            return Ok(result);
        }
    }
}
