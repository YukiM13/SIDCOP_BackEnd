using Api_SIDCOP.API.Models.Logistica;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.Logistica 
{

    [ApiController]
    [Route("[controller]")]
    [ApiKey]


    public class TrasladoController: Controller
    {
        public readonly LogisticaServices _logisticaServices;
        public readonly IMapper _mapper;

        public TrasladoController(LogisticaServices logisticaServices, IMapper mapper)
        {
            _logisticaServices = logisticaServices;
            _mapper = mapper;
        }


        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _logisticaServices.ListTraslados(); // Obtiene lista desde la capa de lógica
            var mapped = _mapper.Map<IEnumerable<TrasladoViewModel>>(list); // Mapea a ViewModel
            return Ok(mapped); // Retorna lista
        }

        // POST: /Traslado/Insertar
        // Inserta un nuevo Traslado
        [HttpPost("Insertar")]
        public IActionResult Insertar(TrasladoViewModel item)
        {
            var mapped = _mapper.Map<tbTraslados>(item);  // Convierte de ViewModel a entidad
            var result = _logisticaServices.InsertTraslado(mapped); // Ejecuta inserción

            return Ok(result); // Retorna resultado
        }

        // POST: /TrasladoDetalle/Insertar
        // Inserta un nuevo detalle de traslado
        [HttpPost("InsertarDetalle")]
        public IActionResult InsertarDetalle(TrasladoDetalleViewModel item)
        {
            var mapped = _mapper.Map<tbTrasladosDetalle>(item);  // Convierte de ViewModel a entidad
            var result = _logisticaServices.InsertTrasladoDetalle(mapped); // Ejecuta inserción
            return Ok(result); // Retorna resultado
        }

        // GET: /Traslado/Buscar/{id}
        // Busca un Traslado por ID
        [HttpGet("Buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            // Buscar bodega por ID en base de datosD
            var result = _logisticaServices.BuscarTraslado(id);

            try
            {
                // Convierte a ViewModel para retornar al cliente
                result.Data = _mapper.Map<TrasladoViewModel>(result.Data);
            }
            catch (Exception ex) { }


            return Ok(result); // Retorna el objeto encontrado
        }

        [HttpGet("BuscarDetalle/{id}")]
        public IActionResult BuscarDetalle(int id)
        {
            var result = _logisticaServices.BuscarTrasladoDetalle(id);

            try
            {
                // Mapea la lista completa
                result.Data = _mapper.Map<IEnumerable<TrasladoDetalleViewModel>>(result.Data);
            }
            catch (Exception ex) { }

            return Ok(result);
        }


        // POST: /Traslado/Eliminar/{id}
        // Elimina un Traslado por ID
        [HttpPost("Eliminar/{id}")]
        public IActionResult Eliminar(int id)
        {

            var result = _logisticaServices.EliminarTraslado(id); // Llama al servicio de eliminación

            return Ok(result); // Retorna resultado
        }
    }
}
