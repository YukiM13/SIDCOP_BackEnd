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

        [HttpGet("Listar")]
        public IActionResult ListarEmpleado()
        {
            var list = _generalServices.ListarEmpleado();
            return Ok(list);
        }


        [HttpPost("Insertar")]
        public IActionResult Insert([FromBody] EmpleadoViewModel item)
        {
            var mapped = _mapper.Map<tbEmpleados>(item);
            var result = _generalServices.InsertarEmpleados(mapped);
            return Ok(result);
        }


        [HttpPut("Actualizar")]
        public IActionResult Update([FromBody] EmpleadoViewModel item)
        {
            var mapped = _mapper.Map<tbEmpleados>(item);
            var result = _generalServices.UpdateEmpleados(mapped);
            return Ok(result);
        }




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
