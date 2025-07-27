using Microsoft.AspNetCore.Mvc;
using Api_SIDCOP.API.Models.Ventas;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.Ventas
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class PagosCuentasPorCobrarController : Controller
    {
        private readonly VentaServices _ventasServices;
        private readonly IMapper _mapper;

        public PagosCuentasPorCobrarController(VentaServices ventasServices, IMapper mapper)
        {
            _ventasServices = ventasServices;
            _mapper = mapper;
        }

        /// <summary>
        /// Registra un nuevo pago para una cuenta por cobrar
        /// </summary>
        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] PagosCuentasPorCobrarViewModel pagoViewModel)
        {
            if (pagoViewModel == null)
            {
                return BadRequest("Información inválida.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pago = _mapper.Map<tbPagosCuentasPorCobrar>(pagoViewModel);
            var result = _ventasServices.InsertarPagoCuentaPorCobrar(pago);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        /// <summary>
        /// Lista todos los pagos asociados a una cuenta por cobrar específica
        /// </summary>
        [HttpGet("ListarPorCuentaPorCobrar/{cpcId}")]
        public IActionResult ListarPorCuentaPorCobrar(int cpcId)
        {
            if (cpcId <= 0)
            {
                return BadRequest("ID de cuenta por cobrar inválido.");
            }

            var result = _ventasServices.ListarPagosPorCuentaPorCobrar(cpcId);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        /// <summary>
        /// Lista todas las cuentas por cobrar con sus pagos asociados
        /// </summary>
        [HttpGet("ListarCuentasPorCobrar")]
        public IActionResult ListarCuentasPorCobrar([FromQuery] int? clienteId = null, [FromQuery] bool soloActivas = true, [FromQuery] bool soloVencidas = false)
        {
            var result = _ventasServices.ListarCuentasPorCobrar(clienteId, soloActivas, soloVencidas);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        /// <summary>
        /// Anula un pago de cuenta por cobrar
        /// </summary>
        [HttpPost("Anular")]
        public IActionResult Anular([FromBody] AnularPagoViewModel anularViewModel)
        {
            if (anularViewModel == null)
            {
                return BadRequest("Información inválida.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _ventasServices.AnularPagoCuentaPorCobrar(
                anularViewModel.Pago_Id,
                anularViewModel.Usua_Modificacion,
                anularViewModel.Motivo_Anulacion);

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