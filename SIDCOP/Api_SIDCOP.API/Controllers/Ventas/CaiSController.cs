using Api_SIDCOP.API.Models.Logistica;
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

    public class CaiSController : Controller
    {
        private readonly VentaServices _ventaServices;
        private readonly IMapper _mapper;


        public CaiSController(VentaServices ventaServices, IMapper mapper)
        {
            _ventaServices = ventaServices;
            _mapper = mapper;
        }


        [HttpPost("BuscarCai")]
        public IActionResult Find([FromBody] CaiSViewModel item)
        {
            var mapped = _mapper.Map<tbCAIs>(item);
            var list = _ventaServices.BuscarCAiS(mapped);
            return Ok(list);
        }

        [HttpGet("ListarCais")]
        public IActionResult listar()
        {
            var list = _ventaServices.ListarCaiS();
            list = _mapper.Map<IEnumerable<tbCAIs>>(list);
            return Ok(list);
        }


        [HttpPost("CrearCai")]
        public IActionResult Insert([FromBody] CaiSViewModel item)
        {
            var mapped = _mapper.Map<tbCAIs>(item);
            var result = _ventaServices.InsertarCaiS(mapped);
            return Ok(result);
        }


        [HttpPost("EliminarCai")]
        public IActionResult Delete([FromBody] CaiSViewModel item)
        {
            var mapped = _mapper.Map<tbCAIs>(item);
            var result = _ventaServices.EliminarCaiS(mapped);
            return Ok(result);
        }
    }
}
