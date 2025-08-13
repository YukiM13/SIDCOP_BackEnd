using Api_SIDCOP.API.Models.General;
using Api_SIDCOP.API.Models.Ventas;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.Ventas
{
    [Route("/[controller]")]
    [ApiController]
    [ApiKey]
    public class DevolucionesController : ControllerBase
    {
        private readonly VentaServices _ventaServices;
        private readonly IMapper _mapper;


        public DevolucionesController(VentaServices ventaServices, IMapper mapper)
        {
            _ventaServices = ventaServices;
            _mapper = mapper;
        }




        [HttpGet("Listar")]
        public IActionResult listar()
        {
            var list = _ventaServices.DevolucionesListar();
            list = _mapper.Map<IEnumerable<tbDevoluciones>>(list);
            return Ok(list);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] DevolucionesViewModel item)
        {
            var mapped = _mapper.Map<tbDevoluciones>(item);
            var result = _ventaServices.InsertarDevolucion(mapped);
            return Ok(result);
        }


    }
}
