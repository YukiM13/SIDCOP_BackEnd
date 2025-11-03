using Api_SIDCOP.API.Models.Logistica;
using Api_SIDCOP.API.Models.Ventas;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.Ventas
{
    // Controlador para manejar las operaciones relacionadas con CAIs
    [ApiController]
    [Route("[controller]")]
    [ApiKey] // Protección con API Key

    public class CaiSController : Controller
    {
        private readonly VentaServices _ventaServices;
        private readonly IMapper _mapper;

        // Constructor que recibe los servicios y el mapeador
        public CaiSController(VentaServices ventaServices, IMapper mapper)
        {
            // Asignación de servicios a las variables de instancia
            _ventaServices = ventaServices;
            _mapper = mapper;
        }



        // GET: /CAIs/Buscar
        // Lista un registro en especifico de CAI el cual busca con el parametro:
        [HttpGet("Buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            var result = _ventaServices.BuscarCai(id);

            // Retorna respuesta estructurada independientemente del resultado
            if (result == null)
            {
                var notFoundResponse = new
                {
                    code = 200,
                    success = false,
                    message = "Cai no encontrado.",
                    data = (object)null
                };

                return Ok(notFoundResponse);
            }
            else
            {
                var successResponse = new
                {
                    code = 200,
                    success = true,
                    message = "Operación completada exitosamente.",
                    data = result
                };
                return Ok(successResponse);

            }
        }

        // GET: /CAIs/Listar
        // Lista todas los registros de CAIs registrados en el sistema
        [HttpGet("Listar")]
        public IActionResult listar()
        {
            var list = _ventaServices.ListarCaiS();
            // Mapeo redundante: la entidad ya es del tipo correcto
            list = _mapper.Map<IEnumerable<tbCAIs>>(list);
            return Ok(list);
        }

        // POST: /CAIs/Crear
        // Crea un nuevo registro de CAI con los datos proporcionados en el cuerpo de la solicitud
        [HttpPost("Crear")]
        public IActionResult Insert([FromBody] CaiSViewModel item)
        {
            var mapped = _mapper.Map<tbCAIs>(item);
            var result = _ventaServices.CrearCai(mapped);
            return Ok(result);
        }

        //
        [HttpPut("Eliminar/{id}")]
        public IActionResult Eliminar(int? id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }
            // Eliminación lógica mediante actualización de estado
            var delete = _ventaServices.EliminarCai(id);
            if (delete.Success)
            {
                return Ok(delete);
            }
            else
            {
                return BadRequest(delete);
            }
        }



        //[HttpPut("Eliminar/{id}")]
        //public IActionResult Eliminar(int? id)
        //{
        //    if (id <= 0)
        //    {
        //        return BadRequest("Id Invalida.");
        //    }
        //    var result = _ventaServices.EliminarCai(id);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        return BadRequest(result.Message);
        //    }
        //}
    }
}
