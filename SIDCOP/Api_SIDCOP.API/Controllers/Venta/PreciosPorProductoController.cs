using Api_SIDCOP.API.Models.Venta;
using Api_SIDCOP.API.Models.Ventas;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.Venta
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class PreciosPorProductoController : Controller
    {
        public readonly VentaServices _ventaServices;
        public readonly IMapper _mapper;

        public PreciosPorProductoController(VentaServices ventaServices, IMapper mapper)
        {
            _ventaServices = ventaServices;
            _mapper = mapper;
        }

        [HttpGet("ListarPorProducto")]
        public IActionResult ListarPorProducto(int? id)
        {
            var list = _ventaServices.ListPreciosPorProducto_PorProducto(id);
            var mapped = _mapper.Map<IEnumerable<PreciosPorProductoViewModel>>(list);
            return Ok(mapped);
        }


        [HttpPost("InsertarLista")]
        public IActionResult InsertarLista(PreciosPorProductoViewModel item)
        {
            var mapped = _mapper.Map<tbPreciosPorProducto>(item);
            var result = _ventaServices.InsertPreciosPorProductoLista(mapped);

            return Ok(result);
        }

        [HttpPost("EliminarLista")]
        public IActionResult EliminarLista(PreciosPorProductoViewModel item)
        {
            var mapped = _mapper.Map<tbPreciosPorProducto>(item);
            var result = _ventaServices.DeletePreciosPorProductoLista(mapped);

            return Ok(result);
        }

        [HttpPost("ActualizarLista")]
        public IActionResult ActualizarLista(PreciosPorProductoViewModel item)
        {
            var mapped = _mapper.Map<tbPreciosPorProducto>(item);
            var result = _ventaServices.UpdatePreciosPorProductoLista(mapped);

            return Ok(result);
        }
    }
}
