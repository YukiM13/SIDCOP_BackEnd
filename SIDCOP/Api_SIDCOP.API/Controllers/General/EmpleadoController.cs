using Api_SIDCOP.API.Models.General;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.General
{

    [ApiController]
    [Route("[controller]")]
    [ApiKey]

    public class EmpleadoController : Controller
    {
        public readonly GeneralServices _generalServices;
        public readonly IMapper _mapper;



        public EmpleadoController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;

        }

        /// Obtiene la lista completa de empleados registrados en el sistema.
        /// Llama al servicio para recuperar los datos y los retorna en formato JSON.
        [HttpGet("Listar")]
        public IActionResult ListarEmpleado()
        {
            var list = _generalServices.ListarEmpleado();
            return Ok(list);
        }

        /// Inserta un nuevo empleado en la base de datos.
        /// Recibe los datos desde el cliente, los mapea a la entidad y llama al servicio para realizar la inserción.
        [HttpPost("Insertar")]
        public IActionResult Insert([FromBody] EmpleadoViewModel item)
        {
            var mapped = _mapper.Map<tbEmpleados>(item);
            var result = _generalServices.InsertarEmpleados(mapped);
            return Ok(result);
        }

        /// Actualiza la información de un empleado existente.
        /// Recibe los datos actualizados, los mapea y llama al servicio para modificar el registro.
        [HttpPut("Actualizar")]
        public IActionResult Update([FromBody] EmpleadoViewModel item)
        {
            var mapped = _mapper.Map<tbEmpleados>(item);
            var result = _generalServices.UpdateEmpleados(mapped);
            return Ok(result);
        }


        /// Elimina un empleado según su identificador.
        /// Valida el parámetro recibido y llama al servicio para realizar la eliminación lógica o física.
        [HttpPost("Eliminar/{id}")]
        public IActionResult Eliminar(int? id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }
            var result = _generalServices.DeleteEmpleado(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        /// Busca y retorna los datos de un empleado por su identificador.
        /// Valida el parámetro y retorna el empleado si existe, o un error si no se encuentra.

        [HttpGet("Buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }
            var empleado = _generalServices.FindEmpleados(id);
            if (empleado != null)
            {
                return Ok(empleado);
            }
            else
            {
                return NotFound("Empleado not found.");
            }
        }

    }
}
