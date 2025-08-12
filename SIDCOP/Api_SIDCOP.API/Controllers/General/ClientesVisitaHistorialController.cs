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


        [HttpGet("Listar")]
        public IActionResult ListarVisitas()
        {
            var list = _generalServices.ListVisitasClientes();
            return Ok(list);
        }

        [HttpPost("Insertar")]
        public IActionResult InsertarCliente([FromBody] ClientesVisitaHistorialViewModel item)
        {
            var mapped = _mapper.Map<tbClientesVisitaHistorial>(item);
            var insert = _generalServices.InsertVisitaCliente(mapped);
            return Ok(insert);
        }
    }

}
