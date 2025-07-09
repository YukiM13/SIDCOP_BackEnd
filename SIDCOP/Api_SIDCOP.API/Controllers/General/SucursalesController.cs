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

        [HttpGet("ListarSucursales")]
        public IActionResult Listar()
        {
            var list = _generalServices.ListSucursales();
            return Ok(list);
        }

        [HttpPost("InsertarSucursal")]
        public IActionResult Insertar([FromBody] Models.General.SucursalesViewModel SucursalesViewModel)
        {
            if (SucursalesViewModel == null)
            {
                return BadRequest("Invalid data.");
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

        [HttpPut("ActualizarSucursal")]
        public IActionResult Actualizar([FromBody] Models.General.SucursalesViewModel SucursalesViewModel)
        {
            if (SucursalesViewModel == null)
            {
                return BadRequest("Invalid data.");
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

    }
}
