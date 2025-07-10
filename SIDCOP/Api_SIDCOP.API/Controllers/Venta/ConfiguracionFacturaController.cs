using Api_SIDCOP.API.Models.Venta;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.Venta
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class ConfiguracionFacturaController : Controller
    {
        public readonly VentaServices _ventaServices;
        public readonly IMapper _mapper;
        //private readonly EmailService _emailService;

        public ConfiguracionFacturaController(VentaServices ventaServices, IMapper mapper)
        {
            _ventaServices = ventaServices;
            _mapper = mapper;
        }


        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _ventaServices.ListConfiguracionFactura();
            var mapped = _mapper.Map<IEnumerable<ConfiguracionFacturaViewModel>>(list);
            return Ok(mapped);
        }


        [HttpPost("Insertar")]
        public IActionResult Insertar(ConfiguracionFacturaViewModel item)
        {
            var mapped = _mapper.Map<tbConfiguracionFacturas>(item);
            var result = _ventaServices.InsertConfiguracionFactura(mapped);
            
            return Ok(result);
        }


        [HttpPut("Actualizar")]
        public IActionResult Actualizar(ConfiguracionFacturaViewModel item)
        {
            var mapped = _mapper.Map<tbConfiguracionFacturas>(item);
            var result = _ventaServices.UpdateConfiguracionFactura(mapped);

            return Ok(result);
        }


        [HttpPost("Eliminar")]
        public IActionResult Eliminar(ConfiguracionFacturaViewModel item)
        {
            var mapped = _mapper.Map<tbConfiguracionFacturas>(item);
            var result = _ventaServices.DeleteConfiguracionFactura(mapped);

            return Ok(result);
        }


        [HttpGet("Buscar")]
        public IActionResult Buscar(int id)
        {
            var result = _ventaServices.FindConfiguracionFactura(id);

            try
            {
                result.Data = _mapper.Map<ConfiguracionFacturaViewModel>(result.Data);
            }
            catch (Exception ex) { }
            

            return Ok(result);
        }

    }
}
