using Api_SIDCOP.API.Models.Logistica;
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
    public class PuntoEmisionController : Controller
    {
        public readonly VentaServices _ventaServices;
        public readonly IMapper _mapper;
        //private readonly EmailService _emailService;

        public PuntoEmisionController(VentaServices ventaServices, IMapper mapper)
        {
            _ventaServices = ventaServices;
            _mapper = mapper;
        }


        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _ventaServices.ListPuntosEmision();
            var mapped = _mapper.Map<IEnumerable<PuntoEmisionViewModel>>(list);
            return Ok(mapped);
        }


        [HttpPost("Insertar")]
        public IActionResult Insertar(PuntoEmisionViewModel item)
        {
            var mapped = _mapper.Map<tbPuntosEmision>(item);
            var result = _ventaServices.InsertPuntoEmision(mapped);

            return Ok(result);
        }


        [HttpPut("Actualizar")]
        public IActionResult Actualizar(PuntoEmisionViewModel item)
        {
            var mapped = _mapper.Map<tbPuntosEmision>(item);
            var result = _ventaServices.UpdatePuntoEmision(mapped);

            return Ok(result);
        }


        [HttpPut("Eliminar")]
        public IActionResult Eliminar(PuntoEmisionViewModel item)
        {
            var mapped = _mapper.Map<tbPuntosEmision>(item);
            var result = _ventaServices.DeletePuntoEmision(mapped);

            return Ok(result);
        }


        [HttpGet("Buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            var result = _ventaServices.FindPuntoEmision(id);

            try
            {
                result.Data = _mapper.Map<PuntoEmisionViewModel>(result.Data);
            }
            catch (Exception ex) { }


            return Ok(result);
        }

    }
}




    