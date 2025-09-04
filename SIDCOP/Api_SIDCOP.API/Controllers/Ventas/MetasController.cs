using Api_SIDCOP.API.Models.Ventas;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.Ventas
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]

    public class MetasController : Controller
    {

        public readonly VentaServices _ventaServices;
        public readonly IMapper _mapper;

        public MetasController(VentaServices ventaServices, IMapper mapper)
        {
            _ventaServices = ventaServices;
            _mapper = mapper;
        }

        [HttpGet("ListarCompleto")]
        public IActionResult ListarCompleto()
        {
            var list = _ventaServices.ListMetasCompleto();
            var mapped = _mapper.Map<IEnumerable<MetasViewModel>>(list);
            return Ok(mapped);
        }

        [HttpPut("ListarPorVendedor/{id}")]
        public IActionResult ListarPorVendedor(int? id)
        {
            var list = _ventaServices.ListarPorVendedor(id);
            //var mapped = _mapper.Map<IEnumerable<MetasViewModel>>(list);
            return Ok(list);
        }

        [HttpPut("Eliminar/{id}")]
        public IActionResult Eliminar(int? id)
        {

            var result = _ventaServices.EliminarMeta(id);
            return Ok(result);
        }


        [HttpPost("InsertarCompleto")]
        public IActionResult InsertarLista(MetasViewModel item)
        {
            var mapped = _mapper.Map<tbMetas>(item);
            var result = _ventaServices.InsertMetasCompleto(mapped);

            return Ok(result);
        }

        //[HttpPost("EliminarLista")]
        //public IActionResult EliminarLista(PreciosPorProductoViewModel item)
        //{
        //    var mapped = _mapper.Map<tbPreciosPorProducto>(item);
        //    var result = _ventaServices.DeletePreciosPorProductoLista(mapped);

        //    return Ok(result);
        //}

        [HttpPost("ActualizarCompleto")]
        public IActionResult ActualizarLista(MetasViewModel item)
        {
            var mapped = _mapper.Map<tbMetas>(item);
            var result = _ventaServices.UpdateMetasCompleto(mapped);

            return Ok(result);
        }

        [HttpPost("ActualizarProgreso")]
        public IActionResult ActualizarProgreso(MetasViewModel item)
        {
            var mapped = _mapper.Map<tbMetas>(item);
            var result = _ventaServices.ActualizarProgreso(mapped);

            return Ok(result);
        }

        
    }
}
