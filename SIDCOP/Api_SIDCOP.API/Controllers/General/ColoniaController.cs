using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;

using MimeKit;
using MailKit.Net.Smtp;
using Api_SIDCOP.API.Models.Acceso;
using MailKit.Security;

namespace Api_SIDCOP.API.Controllers.General
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]


    public class ColoniaController : Controller
    {
        public readonly GeneralServices _generalServices;
        public readonly IMapper _mapper;



        public ColoniaController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;

        }

        [HttpGet("ListarColonia")]
        public IActionResult ListarColonia()
        {
            var list = _generalServices.ListarColonia();
            return Ok(list);
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
