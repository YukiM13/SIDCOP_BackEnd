using Api_SIDCOP.API.Models.Logistica;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.Logistica
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]

    public class RutasController : Controller
    {
        private readonly LogisticaServices _logisticaServices;
        private readonly IMapper _mapper;


        public RutasController(LogisticaServices logisticaServices, IMapper mapper)
        {
            _logisticaServices = logisticaServices;
            _mapper = mapper;
        }


        [HttpPost("Buscar")]
        public IActionResult Find([FromBody] RutasViewModel item)
        {
            var mapped = _mapper.Map<tbRutas>(item);
            var list = _logisticaServices.BuscarRuta(mapped);
            return Ok(list);
        }

        [HttpGet("Listar")]
        public IActionResult listar()
        {
            var list = _logisticaServices.ListRutas();
            list = _mapper.Map<IEnumerable<tbRutas>>(list);
            return Ok(list);
        }


        [HttpPost("Crear")]
        public IActionResult Insert([FromBody] RutasViewModel item)
        {
            var mapped = _mapper.Map<tbRutas>(item);
            var result = _logisticaServices.InsertarRuta(mapped);
            return Ok(result);
        }


        [HttpPut("Modificar")]
        public IActionResult Modificar([FromBody] RutasViewModel item)
        {
            var mapped = _mapper.Map<tbRutas>(item);
            var update = _logisticaServices.ModificarRuta(mapped);
            return Ok(update);
        }


        [HttpPost("Eliminar")]
        public IActionResult Delete([FromBody] RutasViewModel item)
        {
            var mapped = _mapper.Map<tbRutas>(item);
            var result = _logisticaServices.EliminarRuta(mapped);
            return Ok(result);
        }
    }
}
