using Api_SIDCOP.API.Models.Logistica;
using Api_SIDCOP.API.Models.Ventas;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.Logistica
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class RecargasController : Controller
    {
        public readonly LogisticaServices _logisticaServices;
        public readonly IMapper _mapper;

        public RecargasController(LogisticaServices logisticaServices, IMapper mapper)
        {
            _logisticaServices = logisticaServices;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _logisticaServices.ListRecargas();
            return Ok(list);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] Models.Logistica.RecargasViewModel RecargasViewModel)
        {
            if (RecargasViewModel == null)
            {
                return BadRequest("Informacion invalida.");
            }
            var recarga = _mapper.Map<SIDCOP_Backend.Entities.Entities.tbRecargas>(RecargasViewModel);
            var result = _logisticaServices.InsertRecargas(recarga);

            return Ok(result);

        }

        [HttpPut("Actualizar")]
        public IActionResult Actualizar([FromBody] Models.Logistica.RecargasViewModel RecargasViewModel)
        {
            var mapped = _mapper.Map<SIDCOP_Backend.Entities.Entities.tbRecargas>(RecargasViewModel);
            var result = _logisticaServices.UpdateRecargas(mapped);

            return Ok(result);
        }


        [HttpPut("Confirmar")]
        public IActionResult Confirmar([FromBody] RecargasViewModel item)
        {
            var mapped = _mapper.Map<tbRecargas>(item);
            var update = _logisticaServices.ConfirmRecargas(mapped);
            return Ok(update);
        }

        [HttpGet("ListarVendedor/{id}")]
        public IActionResult Buscar(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }
            var sucursal = _logisticaServices.FindRecargas(id);
            if (sucursal != null)
            {
                return Ok(sucursal);
            }
            else
            {
                return NotFound("Sucursal no encontrada.");
            }
        }


        [HttpGet("ListarsPorSucursal/{id}/{esAdmin}")]
        public IActionResult ListarRecargas(int id, bool esAdmin)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }

            var result = _logisticaServices.FindRecargasSucu(id, esAdmin);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }




    }
}
