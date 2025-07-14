using Api_SIDCOP.API.Models.Logistica;
using Api_SIDCOP.API.Models.Ventas;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.Ventas
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]

    public class CaiSController : Controller
    {
        private readonly VentaServices _ventaServices;
        private readonly IMapper _mapper;


        public CaiSController(VentaServices ventaServices, IMapper mapper)
        {
            _ventaServices = ventaServices;
            _mapper = mapper;
        }




        [HttpGet("Buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            var result = _ventaServices.BuscarCaiS(id);

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

        [HttpGet("Listar")]
        public IActionResult listar()
        {
            var list = _ventaServices.ListarCaiS();
            list = _mapper.Map<IEnumerable<tbCAIs>>(list);
            return Ok(list);
        }


        [HttpPost("Crear")]
        public IActionResult Insert([FromBody] CaiSViewModel item)
        {
            var mapped = _mapper.Map<tbCAIs>(item);
            var result = _ventaServices.CrearCai(mapped);
            return Ok(result);
        }

        [HttpPut("Eliminar")]
        public IActionResult Modificar([FromBody] CaiSViewModel item)
        {
            var mapped = _mapper.Map<tbCAIs>(item);
            var update = _ventaServices.EliminarCai(mapped);
            return Ok(update);
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
