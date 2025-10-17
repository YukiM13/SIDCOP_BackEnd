using Api_SIDCOP.API.Models.General;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.General
{
    // Controlador para manejar las operaciones CRUD sobre las marcas de vehículos
    [ApiController]
    [Route("[controller]")]
    [ApiKey] // Protección con API Key
    public class MarcasVehiculosController: Controller
    {
        // Servicios necesarios inyectados por dependencia
        private readonly GeneralServices _generalServices;
        private readonly IMapper _mapper;

        // Constructor que recibe los servicios y el mapeador
        public MarcasVehiculosController(GeneralServices generalServices, IMapper mapper)
        {
            // Asignación de servicios a las variables de instancia
            _generalServices = generalServices;
            _mapper = mapper;
        }

        // POST: /MarcasVehiculos/Insertar
        // Inserta una nueva marca de vehículo
        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] MarcaVehiculoViewModel item)
        {
            var mapped = _mapper.Map<tbMarcasVehiculos>(item); // Convierte de ViewModel a entidad
            var result = _generalServices.InsertarMarcaVehiculo(mapped); // Ejecuta inserción
            return Ok(result); // Retorna resultado
        }

        // GET: /MarcasVehiculos/Listar
        // Lista todas las marcas de vehículos registradas en el sistema
        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var result = _generalServices.ListarMarcaVehiculo(); // Obtiene lista desde la capa de lógica
            return Ok(result); // Retorna lista
        }


        // POST: /MarcasVehiculos/Buscar/{id}
        // Busca una marca de vehículo por ID
        [HttpPost("Buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            if ( id <= 0 )
            {
                return BadRequest("Id Invalida.");
            }

            // Buscar marca de vehículo por ID en base de datos
            var marcaVehiculo = _generalServices.BuscarMarcaVehiculo(id);
            if (marcaVehiculo != null)
            {
                return Ok(marcaVehiculo); // Retorna el objeto encontrado
            }
            else
            {
                return NotFound("Marca no encontrada con el ID proporcionado.");
            }
        }


        // POST: /MarcasVehiculos/BuscarModelo/{id}
        // Busca los modelos de una marca de vehículo por ID
        [HttpPost("BuscarModelo/{id}")]
        public IActionResult BuscarModelo(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }

            // Buscar modelos de la marca de vehículo por ID en base de datos
            var modelo = _generalServices.BuscarModeloDeMarca(id);
            if (modelo != null)
            {
                return Ok(modelo); // Retorna el objeto encontrado
            }
            else
            {
                return NotFound("Modelo no encontrado con el ID proporcionado.");
            }
        }


        // POST: /MarcasVehiculos/Eliminar/{id}
        // Elimina una marca de vehículo por ID
        [HttpPost("Eliminar/{id}")]
        public IActionResult Eliminar(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }

            var result = _generalServices.EliminarMarcavehiculo(id); // Llama al servicio de eliminación
            if (result.Success)
            {
                return Ok(result); // Retorna resultado
            }
            else
            {
                return BadRequest(result);
            }
        }

        // PUT: /MarcasVehiculos/Editar
        // Actualiza una marca de vehículo existente
        [HttpPut("Editar")]
        public IActionResult Editar([FromBody] MarcaVehiculoViewModel item)
        {
            var mapped = _mapper.Map<tbMarcasVehiculos>(item); // Convierte de ViewModel a entidad
            var result = _generalServices.EditarMarcaVehiculo(mapped); // Ejecuta actualización
            return Ok(result); // Retorna resultado
        }

    }
}
