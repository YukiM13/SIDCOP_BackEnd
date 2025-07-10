using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;

namespace Api_SIDCOP.API.Controllers.Inventario
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class ProductosController : Controller
    {
        public readonly InventarioServices _inventarioServices;
        public readonly IMapper _mapper;

        public ProductosController(InventarioServices inventarioServices, IMapper mapper)
        {
            _inventarioServices = inventarioServices;
            _mapper = mapper;

        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _inventarioServices.ListarProductos();
            return Ok(list);
        }

        [HttpPut("Eliminar/{id}")]
        public IActionResult Eliminar(int? id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }
            //var producto = _mapper.Map<SIDCOP_Backend.Entities.Entities.tbProductos>(productosViewModel);
            var result = _inventarioServices.EliminarProducto(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }
            var productos = _inventarioServices.BuscarProducto(id);
            if (productos != null)
            {
                return Ok(productos);
            }
            else
            {
                return NotFound("Productos No encontrados.");
            }
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] Models.Inventario.ProductosViewModel productosViewModel)
        {
            if (productosViewModel == null)
            {
                return BadRequest("Informacion invalida.");
            }
            var productos = _mapper.Map<SIDCOP_Backend.Entities.Entities.tbProductos>(productosViewModel);
            var result = _inventarioServices.InsertarProducto(productos);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPut("Actualizar")]
        public IActionResult Actualizar([FromBody] Models.Inventario.ProductosViewModel productosViewModel)
        {
            if (productosViewModel == null)
            {
                return BadRequest("Informacion invalida.");
            }
            var productos = _mapper.Map<SIDCOP_Backend.Entities.Entities.tbProductos>(productosViewModel);
            var result = _inventarioServices.ActualizarProducto(productos);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }



        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
