using Api_SIDCOP.API.Models.General;
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
    public class ImpuestosController : ControllerBase
    {

        private readonly VentaServices _ventaServices;
        private readonly IMapper _mapper;


        public ImpuestosController(VentaServices deporteservice, IMapper mapper)
        {
            _ventaServices = deporteservice;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _ventaServices.ListImpuestos();
            list = _mapper.Map<IEnumerable<tbImpuestos>>(list);
            return Ok(list);
        }


        [HttpPut("Actualizar")]
        public IActionResult Actualizar([FromBody] ModeloViewModel item)
        {
            var mapped = _mapper.Map<tbImpuestos>(item);
            var list = _ventaServices.ActualizarImpuestos(mapped);
            return Ok(list);
        }




    }
}
