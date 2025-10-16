using Microsoft.AspNetCore.Mvc;
using Api_SIDCOP.API.Models.Ventas;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.Ventas
{
    // Controlador para manejar las operaciones relacionadas con los pagos de cuentas por cobrar
    [ApiController]
    [Route("[controller]")]
    [ApiKey] // Protección con API Key
    public class PagosCuentasPorCobrarController : Controller
    {
        // Servicios necesarios inyectados por dependencia
        private readonly VentaServices _ventasServices;
        private readonly IMapper _mapper;

        // Constructor que recibe los servicios y el mapeador
        public PagosCuentasPorCobrarController(VentaServices ventasServices, IMapper mapper)
        {
            // Asignación de servicios a las variables de instancia
            _ventasServices = ventasServices;
            _mapper = mapper;
        }

        // POST: /PagosCuentasPorCobrar/Insertar
        // Registra un nuevo pago para una cuenta por cobrar
        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] PagosCuentasPorCobrarViewModel pagoViewModel)
        {
            // Validación del modelo recibido
            if (pagoViewModel == null)
            {
                return BadRequest("Información inválida.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Mapeo y ejecución de la inserción
            var pago = _mapper.Map<tbPagosCuentasPorCobrar>(pagoViewModel); // Convierte de ViewModel a entidad
            var result = _ventasServices.InsertarPagoCuentaPorCobrar(pago); // Ejecuta inserción

            // Retorna resultado según el éxito de la operación
            if (result.Success)
            {
                return Ok(result); // Retorna resultado exitoso
            }
            else
            {
                return BadRequest(result); // Retorna error
            }
        }

        // GET: /PagosCuentasPorCobrar/ListarPorCuentaPorCobrar/{cpcId}
        // Lista todos los pagos asociados a una cuenta por cobrar específica
        [HttpGet("ListarPorCuentaPorCobrar/{cpcId}")]
        public IActionResult ListarPorCuentaPorCobrar(int cpcId)
        {
            // Validación del ID recibido
            if (cpcId <= 0)
            {
                return BadRequest("ID de cuenta por cobrar inválido.");
            }

            // Obtiene lista desde la capa de lógica
            var result = _ventasServices.ListarPagosPorCuentaPorCobrar(cpcId);

            // Retorna resultado según el éxito de la operación
            if (result.Success)
            {
                return Ok(result); // Retorna lista
            }
            else
            {
                return BadRequest(result); // Retorna error
            }
        }

        // GET: /PagosCuentasPorCobrar/ListarCuentasPorCobrar
        // Lista todas las cuentas por cobrar con sus pagos asociados, permitiendo filtros
        [HttpGet("ListarCuentasPorCobrar")]
        public IActionResult ListarCuentasPorCobrar([FromQuery] int? clienteId = null, [FromQuery] bool soloActivas = true, [FromQuery] bool soloVencidas = false)
        {
            // Obtiene lista filtrada desde la capa de lógica
            var result = _ventasServices.ListarCuentasPorCobrar(clienteId, soloActivas, soloVencidas);

            // Retorna resultado según el éxito de la operación
            if (result.Success)
            {
                return Ok(result); // Retorna lista filtrada
            }
            else
            {
                return BadRequest(result); // Retorna error
            }
        }

        // POST: /PagosCuentasPorCobrar/Anular
        // Anula un pago de cuenta por cobrar existente
        [HttpPost("Anular")]
        public IActionResult Anular([FromBody] AnularPagoViewModel anularViewModel)
        {
            // Validación del modelo recibido
            if (anularViewModel == null)
            {
                return BadRequest("Información inválida.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Ejecuta la anulación del pago
            var result = _ventasServices.AnularPagoCuentaPorCobrar(
                anularViewModel.Pago_Id,
                anularViewModel.Usua_Modificacion,
                anularViewModel.Motivo_Anulacion); // Llama al servicio de anulación

            // Retorna resultado según el éxito de la operación
            if (result.Success)
            {
                return Ok(result); // Retorna resultado exitoso
            }
            else
            {
                return BadRequest(result); // Retorna error
            }
        }
    }
}