using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;

namespace Api_SIDCOP.API.Controllers.Acceso
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class UsuariosController : Controller
    {
        public readonly AccesoServices _accesoServices;
        public readonly IMapper _mapper;
        //private readonly EmailService _emailService;

        public UsuariosController(AccesoServices accesoServices, IMapper mapper)
        {
            _accesoServices = accesoServices;
            _mapper = mapper;
           
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _accesoServices.ListUsuario();
            return Ok(list);
        }

    }
}
