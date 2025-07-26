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

    public class CuentasPorCobrarController : Controller
    {
        private readonly VentaServices _ventaServices;
        private readonly IMapper _mapper;


        public CuentasPorCobrarController(VentaServices ventaServices, IMapper mapper)
        {
            _ventaServices = ventaServices;
            _mapper = mapper;
        }




        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var result = _ventaServices.ListCuentasPorCobrar();
            
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        
        [HttpGet("ListarConFiltro")]
        public IActionResult ListarConFiltro([FromQuery] int? clienteId = null, [FromQuery] bool soloActivas = true, [FromQuery] bool soloVencidas = false)
        {
            var result = _ventaServices.ListarCuentasPorCobrar(clienteId, soloActivas, soloVencidas);
            
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        
        [HttpGet("Detalle/{id}")]
        public IActionResult ObtenerDetalle(int id)
        {
            if (id <= 0)
            {
                return BadRequest("El ID de la cuenta por cobrar debe ser mayor a cero.");
            }
            
            var result = _ventaServices.ObtenerDetalleCuentaPorCobrar(id);
            
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


    }
}
