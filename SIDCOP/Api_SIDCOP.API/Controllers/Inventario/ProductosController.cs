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

        [HttpPost("Eliminar/{id}")]
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

        [HttpGet("ListaPrecio/{id}")]
        public IActionResult ListaPrecio(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }
            var productos = _inventarioServices.ListaPrecioClientes(id);
            if (productos != null)
            {
                return Ok(productos);
            }
            else
            {
                return NotFound("Productos No encontrados.");
            }
        }

        [HttpGet("BuscarPorFactura/{id}")]
        public IActionResult BuscarPorFactura(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }
            var productos = _inventarioServices.BuscarProductoPorFactura(id);
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
                return BadRequest(result);
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
                return BadRequest(result);
            }
        }

        [HttpGet("ProductosDescuentoPorClienteVendedor/{clieId}/{vendId}")]
        public async Task<IActionResult> ProductosDescuentoPorClienteVendedor(int clieId, int vendId)
        {
            if (clieId <= 0 || vendId <= 0)
            {
                return BadRequest("Id de Cliente o Id de Vendedor inválidos.");
            }

            var productos = await _inventarioServices.ObtenerProductosDescuentoPrecioPorClienteVendedorAsync(clieId, vendId);
            if (productos != null && productos.Any())
            {
                return Ok(productos);
            }
            else
            {
                return NotFound("Productos no encontrados para el cliente y vendedor especificados.");
            }
        }



        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
