using Api_SIDCOP.API.Models.Inventario;
using Api_SIDCOP.API.Models.Logistica;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;
using System.Xml.Linq;

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

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _inventarioServices.ListarDescuentos(); // Obtiene lista desde la capa de lógica
            var mapped = _mapper.Map<IEnumerable<DescuentoViewModel>>(list); // Mapea a ViewModel
            return Ok(mapped); // Retorna lista
        }


        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] DescuentoViewModel item)
        {
            var xml = new XElement("Escalas",
               item.escalas_Json.Select(e =>
                   new XElement("Escala",
                       new XElement("Inicio", e.deEs_InicioEscala),
                       new XElement("Fin", e.deEs_FinEscala),
                       new XElement("Valor", e.deEs_Valor)
                   )
               )
           );

            item.escalas = xml.ToString();

            var mapped = _mapper.Map<tbDescuentos>(item);
            var list = _inventarioServices.Insertar(mapped);
            return Ok(list);
        }

       


        [HttpPut("Actualizar")]
        public IActionResult Actualizar([FromBody] DescuentoViewModel item)
        {
            // Convertir la lista a JSON
            var xml = new XElement("Escalas",
                item.escalas_Json.Select(e =>
                    new XElement("Escala",
                        new XElement("Inicio", e.deEs_InicioEscala),
                        new XElement("Fin", e.deEs_FinEscala),
                        new XElement("Valor", e.deEs_Valor)
                    )
                )
            );

            item.escalas = xml.ToString();

            // Mapear a entidad del dominio
            var mapped = _mapper.Map<tbDescuentos>(item);

            // Enviar a capa de lógica de negocio
            var result = _inventarioServices.ActualizarDescuentos(mapped);

            return Ok(result);
        }

        [HttpPost("Eliminar/{id}")]
        public IActionResult Eliminar(int id)
        {

            var result = _inventarioServices.EliminarDescuento(id);

            return Ok(result);
        }
    }
}
