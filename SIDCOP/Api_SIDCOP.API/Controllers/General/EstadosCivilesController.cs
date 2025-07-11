using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using SIDCOP_Backend.BusinessLogic.Services;
using Api_SIDCOP.API.Models.Acceso;
using MailKit.Security;


namespace Api_SIDCOP.API.Controllers.General
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]

    public class EstadosCivilesController :  Controller
    {
        public readonly GeneralServices _generalServices;
        public readonly IMapper _mapper;

        public EstadosCivilesController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;

        }

        [HttpGet("ListarEstadosCiviles")]
        public IActionResult Listar()
        {
            var list = _generalServices.ListEsCi();
            return Ok(list);
        }

    }
}
