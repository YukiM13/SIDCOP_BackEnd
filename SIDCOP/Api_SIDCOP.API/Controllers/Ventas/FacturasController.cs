using Microsoft.AspNetCore.Mvc;
using Api_SIDCOP.API.Models.Ventas;
using Api_SIDCOP.API.Models.Ventas.DTOs;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.Ventas
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class FacturasController : Controller
    {
        private readonly VentaServices _ventaServices;
        private readonly IMapper _mapper;

        public FacturasController(VentaServices ventaServices, IMapper mapper)
        {
            _ventaServices = ventaServices;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var result = _ventaServices.ListFacturas();

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpGet("ListarConLimiteDevolucion")]
        public IActionResult ListarFactDevo()
        {
            var result = _ventaServices.ListFacturasDevoLimite();

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("ObtenerCompleta/{id}")]
        public IActionResult ObtenerCompleta(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID de factura inválido.");
            }

            try
            {
                var result = _ventaServices.ObtenerFacturaCompleta(id);

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Success = false,
                    Message = "Error interno del servidor",
                    Details = ex.Message
                });
            }
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] SIDCOP_Backend.Entities.Entities.VentaInsertarDTO ventaDTO)
        {
            if (ventaDTO == null)
            {
                return BadRequest("Información de la venta inválida.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = _ventaServices.InsertVentas(ventaDTO);

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Success = false,
                    Message = "Error interno del servidor",
                    Details = ex.Message
                });
            }
        }

        [HttpPost("InsertarEnSucursal")]
        public IActionResult InsertarEnSucursal([FromBody] SIDCOP_Backend.Entities.Entities.VentaInsertarDTO ventaDTO)
        {
            if (ventaDTO == null)
            {
                return BadRequest("Información de la venta inválida.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = _ventaServices.InsertVentasSucursal(ventaDTO);

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Success = false,
                    Message = "Error interno del servidor",
                    Details = ex.Message
                });
            }
        }

        [HttpPost("Validar")]
        public IActionResult Validar([FromBody] SIDCOP_Backend.Entities.Entities.VentaInsertarDTO ventaDTO)
        {
            if (ventaDTO == null)
            {
                return BadRequest("Información de la venta inválida.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = _ventaServices.ValidarVenta(ventaDTO);

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Success = false,
                    Message = "Error interno del servidor",
                    Details = ex.Message
                });
            }
        }

        [HttpGet("ListarPorVendedor/{vendId}")]
        public IActionResult ListarPorVendedor(int vendId)
        {
            if (vendId <= 0)
            {
                return BadRequest("ID de vendedor inválido.");
            }

            try
            {
                var result = _ventaServices.ListarFacturasPorVendedor(vendId);

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Success = false,
                    Message = "Error interno del servidor",
                    Details = ex.Message
                });
            }
        }

        [HttpPost("AnularFactura")]
        public IActionResult AnularFactura([FromBody] FacturaAnularViewModel item)
        {
            var mapped = _mapper.Map<tbFacturas>(item);
            var result = _ventaServices.AnularFactura(mapped);

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