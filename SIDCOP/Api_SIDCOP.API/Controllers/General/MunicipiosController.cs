using Api_SIDCOP.API.Models.Acceso;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.Acceso
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class MunicipiosController : Controller
    {
        public readonly GeneralServices _generalServices;
        public readonly IMapper _mapper;
        //private readonly EmailService _emailService;

        public MunicipiosController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;
           
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] MunicipioViewModel municipioViewModel)
        {
            var municipio = _mapper.Map<tbMunicipios>(municipioViewModel);
          
            var response = _generalServices.InsertarMunicipios(municipio);
            return Ok(response);
        }

    }
}
