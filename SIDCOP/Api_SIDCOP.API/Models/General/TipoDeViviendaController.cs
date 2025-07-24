using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;

namespace Api_SIDCOP.API.Models.General
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class TipoDeViviendaController : Controller
    {
        private readonly GeneralServices _generalServices;
        private readonly IMapper _mapper;

        public TipoDeViviendaController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;
        }


        [HttpGet("Listar")]
        public IActionResult Listar()
        {

            var result = _generalServices.ListarTiposDeVivienda();
            return Ok(result);
        }

    }
}
