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
        public IActionResult Insertar([FromBody] Models.General.SucursalesViewModel sucursalViewModel)
        {
            if (sucursalViewModel == null)
            {
                return BadRequest("Invalid data.");
            }
            var sucursal = _mapper.Map<SIDCOP_Backend.Entities.Entities.tbSucursales>(sucursalViewModel);
            var result = _generalServices.InsertarSucursal(sucursal);

            if (result.Ok)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }

        }

        /*
          
         public IActionResult Insert([FromBody] CarroDTO item)
        {
            var mapped = _mapper.Map<CarroDTO>(item);
            var insertResult = _vehiServices.InsertCarroCompleto(mapped);

            return Ok(insertResult);

        }
         
         */
    }
}
