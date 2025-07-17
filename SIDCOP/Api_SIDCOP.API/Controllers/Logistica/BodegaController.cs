using Api_SIDCOP.API.Models.Logistica;
using Api_SIDCOP.API.Models.Venta;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.Logistica
{

    // Controlador para manejar las operaciones CRUD sobre las bodegas
    [ApiController]
    [Route("[controller]")]
    [ApiKey] // Protección con API Key
    public class BodegaController : Controller
    {
        // Servicios necesarios inyectados por dependencia
        public readonly LogisticaServices _logisticaServices;
        public readonly IMapper _mapper;
        

        public BodegaController(LogisticaServices logisticaServices, IMapper mapper)
        {
            _logisticaServices  = logisticaServices;
            _mapper = mapper;
        }


        // GET: /Bodega/Listar
        // Lista todas las bodegas registradas en el sistema
        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _logisticaServices.ListBodegas(); // Obtiene lista desde la capa de lógica
            var mapped = _mapper.Map<IEnumerable<BodegaViewModel>>(list); // Mapea a ViewModel
            return Ok(mapped); // Retorna lista
        }


        // POST: /Bodega/Insertar
        // Inserta una nueva bodega
        [HttpPost("Insertar")]
        public IActionResult Insertar(BodegaViewModel item)
        {
            var mapped = _mapper.Map<tbBodegas>(item);  // Convierte de ViewModel a entidad
            var result = _logisticaServices.InsertBodega(mapped); // Ejecuta inserción

            return Ok(result); // Retorna resultado
        }


        // PUT: /Bodega/Actualizar
        // Actualiza una bodega existente
        [HttpPut("Actualizar")]
        public IActionResult Actualizar(BodegaViewModel item)
        {
            var mapped = _mapper.Map<tbBodegas>(item); // Convierte de ViewModel a entidad
            var result = _logisticaServices.UpdateBodega(mapped); //Ejecuta actualización

            return Ok(result); // Retorna resultado
        }


        // POST: /Bodega/Eliminar/{id}
        // Elimina una bodega por ID
        [HttpPost("Eliminar/{id}")]
        public IActionResult Eliminar(int id)
        {

            var result = _logisticaServices.DeleteBodega(id); // Llama al servicio de eliminación

            return Ok(result); // Retorna resultado
        }


        [HttpGet("Buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            // Buscar bodega por ID en base de datosD
            var result = _logisticaServices.FindBodega(id);

            try
            {
                // Convierte a ViewModel para retornar al cliente
                result.Data = _mapper.Map<BodegaViewModel>(result.Data);
            }
            catch (Exception ex) { }

             
            return Ok(result); // Retorna el objeto encontrado
        }
    }
}
