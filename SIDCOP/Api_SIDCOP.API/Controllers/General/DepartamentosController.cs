using Api_SIDCOP.API.Models.General;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.General
{
    // Controlador para manejar las operaciones CRUD sobre los departamentos
    [ApiController]
    [Route("[controller]")]
    [ApiKey] // Protección con API Key
    public class DepartamentosController: Controller
    {
        // Servicios necesarios inyectados por dependencia
        private readonly GeneralServices _generalServices;
        private readonly IMapper _mapper;

        // Constructor que recibe los servicios y el mapeador
        public DepartamentosController(GeneralServices generalServices, IMapper mapper)
        {
            // Asignación de servicios a las variables de instancia
            _generalServices = generalServices;
            _mapper = mapper;
        }

        // POST: /Departamentos/Insertar
        // Inserta un nuevo departamento
        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] DepartamentoViewModel item)
        {
            var mapped = _mapper.Map<tbDepartamentos>(item); // Convierte de ViewModel a entidad
            var result = _generalServices.InsertarDepartamento(mapped); // Ejecuta inserción
            return Ok(result); // Retorna resultado
        }

        // GET: /Departamentos/Listar
        // Lista todos los departamentos registrados en el sistema
        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var result = _generalServices.ListarDepartamentos(); // Obtiene lista desde la capa de lógica
            return Ok(result); // Retorna lista
        }



        // POST: /Departamentos/Buscar/{id}
        // Busca un departamento por código
        [HttpPost("Buscar/{id}")]
        public IActionResult Buscar(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id Invalida.");
            }

            // Buscar departamento por código en base de datos
            var deparatemnto = _generalServices.BuscarDepartamento(id);
            if (deparatemnto != null)
            {
                return Ok(deparatemnto); // Retorna el objeto encontrado
            }
            else
            {
                return NotFound("Departamento no encontrado con el código proporcionado.");
            }
        }


        // POST: /Departamentos/Eliminar/{id}
        // Elimina un departamento por código
        [HttpPost("Eliminar/{id}")]
        public IActionResult Eliminar(string? id)
        {
            if (string.IsNullOrEmpty(id) || id.Length < 0)
            {
                return BadRequest("Codigo llego mal.");
            }

            var result = _generalServices.EliminarDepartamento(id); // Llama al servicio de eliminación
            if (result.Success)
            {
                return Ok(result); // Retorna resultado
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        // PUT: /Departamentos/Editar
        // Actualiza un departamento existente
        [HttpPut("Editar")]
        public IActionResult Editar([FromBody] DepartamentoViewModel item)
        {
            var mapped = _mapper.Map<tbDepartamentos>(item); // Convierte de ViewModel a entidad
            var result = _generalServices.EditarDepartamento(mapped); // Ejecuta actualización
            return Ok(result); // Retorna resultado
        }

    }
}
