using Api_SIDCOP.API.Models.Inventario;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.Inventario
{
    [Route("/[controller]")]
    [ApiController]
    [ApiKey]
    public class DescuentosController : Controller
    {
        private readonly InventarioServices _inventarioServices;
        private readonly IMapper _mapper;


        public DescuentosController(InventarioServices deporteservice, IMapper mapper)
        {
            _inventarioServices = deporteservice;
            _mapper = mapper;
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] DescuentoViewModel item)
        {
            var mapped = _mapper.Map<tbDescuentos>(item);
            var list = _inventarioServices.Insertar(mapped);
            return Ok(list);
        }

        [HttpPost("InsertarDetalle")]
        public IActionResult InsertarDetalle([FromBody] DescuentoDetalleViewModel item)
        {
            var mapped = _mapper.Map<tbDescuentosDetalle>(item);
            var list = _inventarioServices.InsertarDescuentoDetalle(mapped);
            return Ok(list);
        }

        [HttpPost("InsertarDetalleCliente")]
        public IActionResult InsertarDetalleCliente([FromBody] DescuentoPorClienteViewModel item)
        {

            var mapped = _mapper.Map<tbDescuentoPorClientes>(item);
            var list = _inventarioServices.InsertarDescuentoPorCliente(mapped);
            return Ok(list);
        }

        [HttpPost("InsertarDetalleEscala")]
        public IActionResult InsertarDetalleEscala([FromBody] DescuentoPorEscalaViewModel item)
        {
            // Convertir la lista a JSON
            item.Escala_JSON = JsonConvert.SerializeObject(item.Escalas);

            // Mapear a entidad del dominio
            var mapped = _mapper.Map<tbDescuentosPorEscala>(item);

            // Enviar a capa de lógica de negocio
            var result = _inventarioServices.InsertarDescuentoPorEscala(mapped);

            return Ok(result);
        }
    }
}
