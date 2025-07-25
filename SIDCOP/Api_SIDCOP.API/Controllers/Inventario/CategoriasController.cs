using Api_SIDCOP.API.Models.General;
using Api_SIDCOP.API.Models.Inventario;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.Inventario
{
    [Route("/[controller]")]
    [ApiController]
    [ApiKey]

    public class CategoriasController : ControllerBase
    {
        private readonly InventarioServices _inventarioServices;
        private readonly IMapper _mapper;


        public CategoriasController(InventarioServices inventarioServices, IMapper mapper)
        {
            _inventarioServices = inventarioServices;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _inventarioServices.ListarCategorias();
            list = _mapper.Map<IEnumerable<tbCategorias>>(list);
            return Ok(list);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] CategoriaViewModel item)
        {
            var mapped = _mapper.Map<tbCategorias>(item);
            var list = _inventarioServices.InsertarCategoria(mapped);
            return Ok(list);
        }

        [HttpPut("Actualizar")]
        public IActionResult Actualizar([FromBody] CategoriaViewModel item)
        {
            var mapped = _mapper.Map<tbCategorias>(item);
            var list = _inventarioServices.ActualizarCategoria(mapped);
            return Ok(list);
        }

        [HttpPost("Eliminar")]
        public IActionResult Eliminar(int? id)
        {
   
            var list = _inventarioServices.EliminarCategoria(id);
            return Ok(list);
        }

        [HttpPost("Buscar")]
        public IActionResult Find([FromBody] CategoriaViewModel item)
        {
            var mapped = _mapper.Map<tbCategorias>(item);
            var list = _inventarioServices.BuscarCategoria(mapped);
            return Ok(list);
        }

        [HttpPost("FiltrarSubcategorias")]
        public IActionResult FilterSubcategorias([FromBody] CategoriaViewModel item)
        {
            var mapped = _mapper.Map<tbCategorias>(item);
            var list = _inventarioServices.FiltrarSubcategorias(mapped);
            return Ok(list);
        }
    }
}
