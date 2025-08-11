using Api_SIDCOP.API.Models.Inventario;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.Inventario
{
    [Route("/[controller]")]
    [ApiController]
    [ApiKey]
    public class InventarioSucursalesController : Controller
    {

        private readonly InventarioServices _inventarioServices;
        private readonly IMapper _mapper;

        public InventarioSucursalesController(InventarioServices inventarioServices, IMapper mapper)
        {
            _inventarioServices = inventarioServices;
            _mapper = mapper;
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }
            var invent = _inventarioServices.ListInve(id);
            if (invent != null)
            {
                return Ok(invent);
            }
            else
            {
                return NotFound("Inventario No encontrados.");
            }
        }

        [HttpGet("ListarPorSucursal/{id}")]
        public IActionResult ListarPorSucursal(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }
            var invent = _inventarioServices.ListarPorSucursal(id);
            if (invent != null)
            {
                var inventarioViewModel = _mapper.Map<IEnumerable<InventarioSucursalesViewModel>>(invent);
                return Ok(inventarioViewModel);
            }
            else
            {
                return NotFound("Inventario No encontrados.");
            }
        }

        [HttpPost("ActualizarInventario/{sucu_id}/{usua_id}")]
        public IActionResult ActualizarInventario(int sucu_id, int usua_id)
        {
            var actualizar = _inventarioServices.ActualizarInventario(sucu_id, usua_id);
            return Ok(actualizar);
        }

        [HttpPut("ActualizarCantidades/{usua_id}/{inSu_FechaModificacion}")]
        public IActionResult ActualizarCantidades(int usua_id, DateTime inSu_FechaModificacion, [FromBody] List<InventarioSucursalesViewModel> lista)
        {
            if (lista == null || !lista.Any())
            {
                return BadRequest("La lista de inventarios está vacía.");
            }

            try
            {
                var xmlData = ConvertListToXml(lista);
                var resultado = _inventarioServices.ActualizarCantidadesInventario(usua_id, inSu_FechaModificacion, xmlData);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private string ConvertListToXml(List<InventarioSucursalesViewModel> lista)
        {
            var doc = new System.Xml.Linq.XDocument(new System.Xml.Linq.XElement("Inventarios",
                lista.Select(item =>
                    new System.Xml.Linq.XElement("Inventario",
                    new System.Xml.Linq.XElement("InSu_Id", item.InSu_Id),
                    new System.Xml.Linq.XElement("InSu_Cantidad", item.InSu_Cantidad)
                    ))
                )
            );
            return doc.ToString();
        }

    }
}
