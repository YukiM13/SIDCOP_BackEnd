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

    public class ClienteController : Controller
    {

        public readonly GeneralServices _generalServices;
        public readonly IMapper _mapper;



        public ClienteController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;

        }
      


        [HttpPost("Insertar")]
        public IActionResult InsertarCliente([FromBody] ClienteViewModel item)
        {
            var mapped = _mapper.Map<tbClientes>(item);
            var insert = _generalServices.InsertCliente(mapped);
            return Ok(insert);
        }

        [HttpPost("Actualizar")]
        public IActionResult ActualizarCliente([FromBody] ClienteViewModel item)
        {
            var mapped = _mapper.Map<tbClientes>(item);
            var insert = _generalServices. UpdateCliente(mapped);
            return Ok(insert);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }
            var sucursal = _generalServices.BuscarCliente(id);
            if (sucursal != null)
            {
                return Ok(sucursal);
            }
            else
            {
                return NotFound("Cliente not found.");
            }
        }


        [HttpPut("CambioEstado")]
        public IActionResult CambioEstado(int? id, DateTime? fecha)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }
            //var sucursal = _mapper.Map<SIDCOP_Backend.Entities.Entities.tbSucursales>(id);
            var result = _generalServices.CambioEstadoCliente(id, fecha);
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
