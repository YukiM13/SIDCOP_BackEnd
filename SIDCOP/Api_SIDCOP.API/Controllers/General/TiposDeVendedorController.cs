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

    public class TiposDeVendedorController : Controller
    {
        public readonly GeneralServices _generalServices;
        public readonly IMapper _mapper;

        public TiposDeVendedorController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;


        }



        [HttpGet("Listar")]
        public IActionResult ListarTipoVendedor()
        {
            var list = _generalServices?.ListarTipoDeVendedor();
            return Ok(list);
        }


        [HttpPost("Insertar")]
        public IActionResult Insert([FromBody] TiposDeVendedorViewModel item)
        {
            var mapped = _mapper.Map<tbTiposDeVendedor>(item);
            var result = _generalServices.InsertarTipoDeVendedor(mapped);
            return Ok(result);
        }


        [HttpPut("Actualizar")]
        public IActionResult Update([FromBody] TiposDeVendedorViewModel item)
        {
            var mapped = _mapper.Map<tbTiposDeVendedor>(item);
            var result = _generalServices.UpdateTipoDeVendedor(mapped);
            return Ok(result);
        }




        [HttpPost("Eliminar/{id}")]
        public IActionResult Eliminar(int? id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }
            var result = _generalServices.DeleteTipoDeVendedor(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }




    }
}
