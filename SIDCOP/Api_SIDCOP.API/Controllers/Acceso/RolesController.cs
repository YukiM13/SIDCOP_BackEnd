using Api_SIDCOP.API.Models.Acceso;
using Api_SIDCOP.API.Models.General;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;
using System.Data;

namespace Api_SIDCOP.API.Controllers.Acceso
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class RolesController : Controller
    {
        public readonly AccesoServices _accesoServices;
        public readonly IMapper _mapper;
        public RolesController(AccesoServices accesoServices, IMapper mapper)
        {
            _accesoServices = accesoServices;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult ListarRoles()
        {
            var list = _accesoServices.ListarRoles();
            return Ok(list);
        }

        [HttpGet("ListarPantallas")]
        public IActionResult ListarPantallas()
        {
            var json = _accesoServices.ListarPantallasJson();

            if (json.StartsWith("{\"error\""))
                return StatusCode(500, json);

            // Devolver tal cual, en una sola línea
            return Content(json, "application/json");
        }

        [HttpGet("ListarAccionesPorPantalla")]
        public IActionResult ListarAccionesPorPantalla()
        {
            var list = _accesoServices.ListarAccionesPorPantalla();
            return Ok(list);
        }

        [HttpPost("Insertar")]
        public IActionResult InsertarRol([FromBody] RolViewModel item)
        {
            var mapped = _mapper.Map<tbRoles>(item);
            var insert = _accesoServices.InsertarRol(mapped);
            return Ok(insert);
        }

        [HttpPut("Actualizar")]
        public IActionResult ActualizarRol([FromBody] RolViewModel item)
        {
            var mapped = _mapper.Map<tbRoles>(item);
            var update = _accesoServices.ActualizarRol(mapped);
            return Ok(update);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult BuscarRol(int? id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }
            var canal = _accesoServices.BuscarRol(id);
            if (canal != null)
            {
                return Ok(canal);
            }
            else
            {
                return NotFound("Canal no encontrado.");
            }
        }

        [HttpPost("Eliminar/{id}")]
        public IActionResult Eliminar(int? id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalido.");
            }
            var result = _accesoServices.EliminarRol(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
