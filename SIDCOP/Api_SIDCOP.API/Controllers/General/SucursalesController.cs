using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;

namespace Api_SIDCOP.API.Controllers.General
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]

    public class SucursalesController : Controller
    {
        public readonly GeneralServices _generalServices;
        public readonly IMapper _mapper;

        public SucursalesController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;

        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _generalServices.ListSucursales();
            return Ok(list);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] Models.General.SucursalesViewModel SucursalesViewModel)
        {
            if (SucursalesViewModel == null)
            {
                return BadRequest("Informacion invalida.");
            }
            var sucursal = _mapper.Map<SIDCOP_Backend.Entities.Entities.tbSucursales>(SucursalesViewModel);
            var result = _generalServices.InsertarSucursal(sucursal);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }

        }

        [HttpPut("Actualizar")]
        public IActionResult Actualizar([FromBody] Models.General.SucursalesViewModel SucursalesViewModel)
        {
            if (SucursalesViewModel == null)
            {
                return BadRequest("Informacion invalida.");
            }
            var sucursal = _mapper.Map<SIDCOP_Backend.Entities.Entities.tbSucursales>(SucursalesViewModel);
            var result = _generalServices.ActualizarSucursal(sucursal);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPut("Eliminar/{id}")]
        public IActionResult Eliminar(int? id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }
            //var sucursal = _mapper.Map<SIDCOP_Backend.Entities.Entities.tbSucursales>(id);
            var result = _generalServices.EliminarSucursal(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }
            var sucursal = _generalServices.BuscarSucursal(id);
            if (sucursal != null)
            {
                return Ok(sucursal);
            }
            else
            {
                return NotFound("Sucursal not found.");
            }
        }
    }
}
