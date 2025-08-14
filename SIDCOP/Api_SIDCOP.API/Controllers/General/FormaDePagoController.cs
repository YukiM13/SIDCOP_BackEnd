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

    public class FormaDePagoController: Controller
    {
        public readonly GeneralServices _generalServices;
        public readonly IMapper _mapper;

        public FormaDePagoController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {

            var result = _generalServices.ListarFormasDePago();
            return Ok(result);
        }
    }
}
