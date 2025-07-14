using Api_SIDCOP.API.Models.General;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.General
{
    [Route("/[controller]")]
    [ApiController]
    [ApiKey]

    public class ProveedorController : ControllerBase
    {

        private readonly GeneralServices _generalServices;
        private readonly IMapper _mapper;


        public ProveedorController(GeneralServices deporteservice, IMapper mapper)
        {
            _generalServices = deporteservice;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _generalServices.ListProveedores();
            list = _mapper.Map<IEnumerable<tbProveedores>>(list);
            return Ok(list);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] ProveedorViewModel item)
        {
            var mapped = _mapper.Map<tbProveedores>(item);
            var list = _generalServices.InsertarProveedor(mapped);
            return Ok(list);
        }

        [HttpPut("Actualizar")]
        public IActionResult Actualizar([FromBody] ProveedorViewModel item)
        {
            var mapped = _mapper.Map<tbProveedores>(item);
            var list = _generalServices.ActualizarProveedor(mapped);
            return Ok(list);
        }

        [HttpPost("Eliminar")]
        public IActionResult Eliminar(int? id)
        {
           
            var list = _generalServices.EliminarProveedor(id);
            return Ok(list);
        }

        [HttpPost("Buscar")]
        public IActionResult Find([FromBody] ProveedorViewModel item)
        {
            var mapped = _mapper.Map<tbProveedores>(item);
            var list = _generalServices.BuscarProveedor(mapped);
            return Ok(list);
        }




    }
}
