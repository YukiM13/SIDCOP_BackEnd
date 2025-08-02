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
    public class PedidoController : Controller
    {
        public readonly VentaServices _ventaServices;
        public readonly IMapper _mapper;
        //private readonly EmailService _emailService;

        public PedidoController(VentaServices ventaServices, IMapper mapper)
        {
            _ventaServices = ventaServices;
            _mapper = mapper;
        }


        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _ventaServices.ListarPedidos();
            var mapped = _mapper.Map<IEnumerable<PedidosViewModel>>(list);
            return Ok(mapped);
        }


        [HttpPost("Insertar")]
        public IActionResult Insertar(PedidosViewModel item)
        {
            var mapped = _mapper.Map<tbPedidos>(item);
            var result = _ventaServices.InsertarPedido(mapped);

            return Ok(result);
        }


        [HttpPut("Actualizar")]
        public IActionResult Actualizar(PedidosViewModel item)
        {
            var mapped = _mapper.Map<tbPedidos>(item);
            var result = _ventaServices.EditarPedido(mapped);

            return Ok(result);
        }


        [HttpPost("Eliminar/{id}")]
        public IActionResult Eliminar(int id)
        {

            var result = _ventaServices.EliminarPedido(id);

            return Ok(result);
        }



    }
}
