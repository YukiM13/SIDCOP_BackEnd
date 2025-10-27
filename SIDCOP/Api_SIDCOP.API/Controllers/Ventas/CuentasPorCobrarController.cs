using Microsoft.AspNetCore.Mvc;
using Api_SIDCOP.API.Models.Logistica;
using Api_SIDCOP.API.Models.Ventas;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.Ventas
{
    // Controlador para manejar las operaciones relacionadas con las cuentas por cobrar
    [ApiController]
    [Route("[controller]")]
    [ApiKey] // Protección con API Key
    public class CuentasPorCobrarController : Controller
    {
        // Servicios necesarios inyectados por dependencia
        private readonly VentaServices _ventaServices;

        private readonly IMapper _mapper;

        // Constructor que recibe los servicios y el mapeador
        public CuentasPorCobrarController(VentaServices ventaServices, IMapper mapper)
        {
            // Asignación de servicios a las variables de instancia
            _ventaServices = ventaServices;
            _mapper = mapper;
        }

        // GET: /CuentasPorCobrar/Listar
        // Lista todas las cuentas por cobrar registradas en el sistema
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

        // GET: /CuentasPorCobrar/ListarConFiltro
        // Lista las cuentas por cobrar aplicando filtros opcionales:
        // - clienteId: filtra por cliente específico (opcional)
        // - soloActivas: incluye únicamente las cuentas activas (por defecto: true)
        // - soloVencidas: incluye únicamente las cuentas vencidas (por defecto: false)
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

        // GET: /CuentasPorCobrar/Detalle/{id}
        // Obtiene el detalle completo de una cuenta por cobrar específica por su ID
        // GET: /CuentasPorCobrar/Detalle/{id}
        // Obtiene el detalle completo de una cuenta por cobrar específica
        [HttpGet("Detalle/{id}")]
        public IActionResult ObtenerDetalle(int id)
        {
            // Validación del ID recibido
            if (id <= 0)
            {
                return BadRequest("El ID de la cuenta por cobrar debe ser mayor a cero.");
            }

            // Busca el detalle de la cuenta por cobrar
            var result = _ventaServices.ObtenerDetalleCuentaPorCobrar(id);

            // Retorna resultado según el éxito de la operación
            if (result.Success)
            {
                return Ok(result); // Retorna el detalle encontrado
            }
            else
            {
                return BadRequest(result); // Retorna error
            }
        }

        [HttpGet("ListaFiltrada/{id}")]
        public IActionResult ListarFiltrado(int id)
        {
            // Validación del ID recibido
            if (id <= 0)
            {
                return BadRequest("El ID de la cuenta por cobrar debe ser mayor a cero.");
            }

            // Busca el detalle de la cuenta por cobrar
            var result = _ventaServices.ListarFiltrado(id);

            // Retorna resultado según el éxito de la operación
            if (result.Success)
            {
                return Ok(result); // Retorna el detalle encontrado
            }
            else
            {
                return BadRequest(result); // Retorna error
            }
        }

        // GET: /CuentasPorCobrar/ResumenAntiguedad
        // Obtiene un resumen de las cuentas por cobrar agrupadas por antigüedad (ej. 0-30 días, 31-60 días, etc.)
        // GET: /CuentasPorCobrar/ResumenAntiguedad
        // Obtiene un resumen agrupado por antigüedad de las cuentas por cobrar
        [HttpGet("ResumenAntiguedad")]
        public IActionResult ResumenAntiguedad()
        {
            // Obtiene el resumen desde la capa de lógica
            var result = _ventaServices.ResumenAntiguedad();

            // Retorna resultado según el éxito de la operación
            if (result.Success)
            {
                return Ok(result); // Retorna el resumen
            }
            else
            {
                return BadRequest(result); // Retorna error
            }
        }

        // GET: /CuentasPorCobrar/ResumenCliente
        // Obtiene un resumen general de las cuentas por cobrar por cliente (total adeudado, número de facturas, etc.)
        [HttpGet("ResumenCliente")]
        public IActionResult ResumenCliente()
        {
            var result = _ventaServices.ResumenCliente();

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        // GET: /CuentasPorCobrar/timeLineCliente/{clie_Id}
        // Obtiene la línea de tiempo de transacciones o movimientos relacionados con un cliente específico
        // GET: /CuentasPorCobrar/timeLineCliente/{clie_Id}
        // Obtiene la línea de tiempo de movimientos de un cliente específico
        [HttpGet("timeLineCliente/{clie_Id}")]
        public IActionResult timeLineCliente(int clie_Id)
        {
            // Obtiene la línea de tiempo desde la capa de lógica
            var result = _ventaServices.timeLineCliente(clie_Id);

            // Retorna resultado según el éxito de la operación
            if (result.Success)
            {
                return Ok(result); // Retorna la línea de tiempo
            }
            else
            {
                return BadRequest(result); // Retorna error
            }
        }
    }
}