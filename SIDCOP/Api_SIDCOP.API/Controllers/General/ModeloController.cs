using Api_SIDCOP.API.Models.General;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.General
{
    [Route("/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase
    {

        private readonly GeneralServices _generalServices;
        private readonly IMapper _mapper;


        public ModeloController(GeneralServices deporteservice, IMapper mapper)
        {
            _generalServices = deporteservice;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _generalServices.ListModelos();
            list = _mapper.Map<IEnumerable<tbModelos>>(list);
            return Ok(list);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] ModeloViewModel item)
        {
            var mapped = _mapper.Map<tbModelos>(item);
            var list = _generalServices.InsertarModelo(mapped);
            return Ok(list);
        }

        [HttpPut("Actualizar")]
        public IActionResult Actualizar([FromBody] ModeloViewModel item)
        {
            var mapped = _mapper.Map<tbModelos>(item);
            var list = _generalServices.ActualizarModelo(mapped);
            return Ok(list);
        }

        [HttpPost("Eliminar")]
        public IActionResult Eliminar([FromBody] ModeloViewModel item)
        {
            var mapped = _mapper.Map<tbModelos>(item);
            var list = _generalServices.EliminarModelo(mapped);
            return Ok(list);
        }

        [HttpPost("Buscar")]
        public IActionResult Find([FromBody] ModeloViewModel item)
        {
            var mapped = _mapper.Map<tbModelos>(item);
            var list = _generalServices.BuscarModelo(mapped);
            return Ok(list);
        }




    }
}
