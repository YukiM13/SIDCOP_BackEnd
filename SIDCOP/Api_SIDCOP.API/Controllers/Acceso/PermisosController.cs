using Api_SIDCOP.API.Models.Acceso;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.Acceso
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]

    public class PermisosController : Controller
    {
        public readonly AccesoServices _accesoServices;
        public readonly IMapper _mapper;

        public PermisosController(AccesoServices accesoServices, IMapper mapper)
        {
            _accesoServices = accesoServices;
            _mapper = mapper;

        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _accesoServices.ListPermisos();
            return Ok(list);
        }

        [HttpPost("Insertar")]
        public IActionResult Insert([FromBody] PermisoViewModel item)
        {
            var mapped = _mapper.Map<tbPermisos>(item);
            var insert = _accesoServices.InsertPermiso(mapped);
            return Ok(insert);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update([FromBody] PermisoViewModel item)
        {
            var mapped = _mapper.Map<tbPermisos>(item);
            var update = _accesoServices.UpdatePermiso(mapped);
            return Ok(update);
        }

        [HttpPost("Eliminar")]
        public IActionResult Delete([FromBody] PermisoViewModel item)
        {
            var mapped = _mapper.Map<tbPermisos>(item);
            var delete = _accesoServices.EliminarPermiso(mapped);
            return Ok(delete);
        }

        [HttpPost("Buscar")]
        public IActionResult Find([FromBody] PermisoViewModel item)
        {
            var mapped = _mapper.Map<tbPermisos>(item);
            var list = _accesoServices.BuscarPermiso(mapped);
            return Ok(list);
        }
    }
}
