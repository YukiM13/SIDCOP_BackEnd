using Api_SIDCOP.API.Models.Inventario;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;
using System.Xml.Linq;

namespace Api_SIDCOP.API.Controllers.Inventario
{
    [Route("/[controller]")]
    [ApiController]
    [ApiKey]
    public class PromocionesController : Controller
    {

        private readonly InventarioServices _inventarioServices;
        private readonly IMapper _mapper;


        public PromocionesController(InventarioServices deporteservice, IMapper mapper)
        {
            _inventarioServices = deporteservice;
            _mapper = mapper;
        }
        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _inventarioServices.ListarPromociones(); // Obtiene lista desde la capa de lógica
            var mapped = _mapper.Map<IEnumerable<PromocionViewModel>>(list); // Mapea a ViewModel
            return Ok(mapped); // Retorna lista
        } 

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] PromocionViewModel item)
        {
            var xml = new XElement("Producto",
               item.productos_Json.Select(e =>
                   new XElement("Producto",
                       new XElement("Id", e.prod_Id),
                       new XElement("Cantidad", e.prDe_Cantidad)
               )
            )
            );

            item.productos = xml.ToString();

            var mapped = _mapper.Map<tbProductos>(item);
            var list = _inventarioServices.InsertarPromocines(mapped);
            return Ok(list);
        }


        [HttpPut("Actualizar")]
        public IActionResult Actualizar([FromBody] PromocionViewModel item)
        {
            var xml = new XElement("Producto",
               item.productos_Json.Select(e =>
                   new XElement("Producto",
                       new XElement("Id", e.prod_Id),
                       new XElement("Cantidad", e.prDe_Cantidad)
               )
            )
            );

            item.productos = xml.ToString();

            var mapped = _mapper.Map<tbProductos>(item);
            var list = _inventarioServices.ActualizarPromocines(mapped);
            return Ok(list);
        }


        [HttpPut("CambiarEstado/{id}")]
        public IActionResult CambiarEstado(int id)
        {

            var result = _inventarioServices.CambiarEstadoPromociones(id);

            return Ok(result);
        }
    }
}
