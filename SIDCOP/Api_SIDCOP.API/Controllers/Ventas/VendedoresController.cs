using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using System.Xml.Linq;

namespace Api_SIDCOP.API.Controllers.Ventas
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class VendedoresController : Controller
    {
        public readonly VentaServices _ventaServices;
        public readonly IMapper _mapper;

        public VendedoresController(VentaServices ventaServices, IMapper mapper)
        {
            _ventaServices = ventaServices;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
             var list = _ventaServices.ListarVendedores();
            return Ok(list);
        }

        [HttpGet("ListarPorRutas")]
        public IActionResult ListarVeRu()
        {
            var list = _ventaServices.ListarVendedoresPorRuta();
            return Ok(list);
        }


        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] Models.Ventas.VendedoresViewModel vendedoresViewModel)
        {
            if (vendedoresViewModel == null)
            {
                return BadRequest("Informacion invalida.");
            }
            var xml = new XElement("Ruta",
               vendedoresViewModel.rutas_Json.Select(e =>
                   new XElement("Ruta",
                       new XElement("Id", e.ruta_Id),
                       new XElement("dias", e.veRu_Dias)
               )
            )
            );

            vendedoresViewModel.rutas = xml.ToString();
            var vendedor = _mapper.Map<SIDCOP_Backend.Entities.Entities.tbVendedores>(vendedoresViewModel);
            var result = _ventaServices.InsertarVendedor(vendedor);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("Actualizar")]
        public IActionResult Actualizar([FromBody] Models.Ventas.VendedoresViewModel vendedoresViewModel)
        {
            if (vendedoresViewModel == null)
            {
                return BadRequest("Informacion invalida.");
            }

            var xml = new XElement("Ruta",
               vendedoresViewModel.rutas_Json.Select(e =>
                   new XElement("Ruta",
                       new XElement("Id", e.ruta_Id),
                       new XElement("dias", e.veRu_Dias)
               )
            )
            );

            vendedoresViewModel.rutas = xml.ToString();
            var vendedor = _mapper.Map<SIDCOP_Backend.Entities.Entities.tbVendedores>(vendedoresViewModel);
            var result = _ventaServices.ActualizarVendedor(vendedor);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("Eliminar/{id}")]
        public IActionResult Eliminar(int? id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }
            //var sucursal = _mapper.Map<SIDCOP_Backend.Entities.Entities.tbSucursales>(id);
            var result = _ventaServices.EliminarVendedor(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }
            var sucursal = _ventaServices.BuscarVendedor(id);
            if (sucursal != null)
            {
                return Ok(sucursal);
            }
            else
            {
                return NotFound("Vendedor no encontrado.");
            }
        }


        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
