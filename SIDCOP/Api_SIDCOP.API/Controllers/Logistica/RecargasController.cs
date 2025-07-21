using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;

namespace Api_SIDCOP.API.Controllers.Logistica
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class RecargasController : Controller
    {
        public readonly LogisticaServices _logisticaServices;
        public readonly IMapper _mapper;

        public RecargasController(LogisticaServices logisticaServices, IMapper mapper)
        {
            _logisticaServices = logisticaServices;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _logisticaServices.ListRecargas();
            return Ok(list);
        }


    }
}
