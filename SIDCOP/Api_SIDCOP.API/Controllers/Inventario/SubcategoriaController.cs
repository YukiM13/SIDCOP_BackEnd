using Api_SIDCOP.API.Models.Inventario;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.Inventario
{
    [Route("/[controller]")]
    [ApiController]
    public class SubcategoriaController : ControllerBase
    {
        private readonly InventarioServices _inventarioServices;
        private readonly IMapper _mapper;


        public SubcategoriaController(InventarioServices deporteservice, IMapper mapper)
        {
            _inventarioServices = deporteservice;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _inventarioServices.ListarSubCategorias();
            list = _mapper.Map<IEnumerable<tbSubcategorias>>(list);
            return Ok(list);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] SubcategoriaViewModel item)
        {
            var mapped = _mapper.Map<tbSubcategorias>(item);
            var list = _inventarioServices.InsertarSubCategoria(mapped);
            return Ok(list);
        }

        [HttpPut("Actualizar")]
        public IActionResult Actualizar([FromBody] SubcategoriaViewModel item)
        {
            var mapped = _mapper.Map<tbSubcategorias>(item);
            var list = _inventarioServices.ActualizarSubCategoria(mapped);
            return Ok(list);
        }

        [HttpPost("Eliminar")]
        public IActionResult Eliminar([FromBody] SubcategoriaViewModel item)
        {
            var mapped = _mapper.Map<tbSubcategorias>(item);
            var list = _inventarioServices.EliminarSubCategoria(mapped);
            return Ok(list);
        }

        [HttpPost("Buscar")]
        public IActionResult Find([FromBody] SubcategoriaViewModel item)
        {
            var mapped = _mapper.Map<tbSubcategorias>(item);
            var list = _inventarioServices.BuscarSubCategoria(mapped);
            return Ok(list);
        }
    }
}
