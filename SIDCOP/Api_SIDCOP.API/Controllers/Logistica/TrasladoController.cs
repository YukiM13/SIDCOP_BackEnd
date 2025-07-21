using Api_SIDCOP.API.Models.Logistica;
using Api_SIDCOP.API.Models.Venta;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.Logistica 
{

    [ApiController]
    [Route("[controller]")]
    [ApiKey]


    public class TrasladoController: Controller
    {
        public readonly LogisticaServices _logisticaServices;
        public readonly IMapper _mapper;

        public TrasladoController(LogisticaServices logisticaServices, IMapper mapper)
        {
            _logisticaServices = logisticaServices;
            _mapper = mapper;
        }


        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _logisticaServices.ListTraslados(); // Obtiene lista desde la capa de lógica
            var mapped = _mapper.Map<IEnumerable<TrasladoViewModel>>(list); // Mapea a ViewModel
            return Ok(mapped); // Retorna lista
        }

    }
}
