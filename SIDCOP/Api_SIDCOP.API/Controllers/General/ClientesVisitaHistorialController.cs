using Api_SIDCOP.API.Models.General;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.General
{

    [ApiController]
    [Route("[controller]")]
    [ApiKey]

    public class ClientesVisitaHistorialController: Controller
    {
        public readonly GeneralServices _generalServices;
        public readonly IMapper _mapper;

        public ClientesVisitaHistorialController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;
        }


        //[HttpGet("Listar")]
        //public IActionResult ListarVisitas()
        //{
        //    var list = _generalServices.ListVisitasClientes();
        //    return Ok(list);
        //}

        [HttpGet("Listar")]
        public IActionResult ListarVisitasClientes()
        {
            var list = _generalServices.ListVisitasClientes();
            return Ok(list);
        }

        //[HttpGet("ListarVisitasClientes")]
        //public IActionResult ListVisitasClientes()
        //{
        //    var list = _generalServices.ListVisitasClientes();
        //    return Ok(list);
        //}

        [HttpGet("ListarVisitasPorVendedor")]
        public IActionResult ListVisitasPorVendedor([FromQuery]int vend_Id)
        {
            var list = _generalServices.VisitasPorVendedor(vend_Id);
            return Ok(list);
        }

        [HttpGet("ListarPorVendedor/{id}")]
        public IActionResult Buscar(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }
            var cliente = _generalServices.BuscarVisitaPorVendedor(id);
            if (cliente != null)
            {
                return Ok(cliente);
            }
            else
            {
                return NotFound("Cliente no encontrado.");
            }
        }

        [HttpPost("Insertar")]
        public IActionResult InsertarCliente([FromBody] VisitaClientePorVendedorDTO item)
        {
            var mapped = _mapper.Map<VisitaClientePorVendedorDTO>(item);
            var insert = _generalServices.InsertVisitaCliente(mapped);
            return Ok(insert);
        }
    }

}
