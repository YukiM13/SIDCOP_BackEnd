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
    public class DepartamentosController: Controller
    {
        private readonly GeneralServices _generalServices;
        private readonly IMapper _mapper;

        public DepartamentosController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] DepartamentoViewModel item)
        {
            var mapped = _mapper.Map<tbDepartamentos>(item);
            var result = _generalServices.InsertarDepartamento(mapped);
            return Ok(result);
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {

            var result = _generalServices.ListarDepartamentos();
            return Ok(result);
        }



        [HttpPost("Buscar")]
        public IActionResult Find([FromBody] DepartamentoViewModel item)
        {
            var mapped = _mapper.Map<tbDepartamentos>(item);
            var result = _generalServices.BuscarDepartamento(mapped);
            return Ok(result);
        }

        [HttpPost("Eliminar")]
        public IActionResult Eliminar([FromBody] DepartamentoViewModel item)
        {
            var mapped = _mapper.Map<tbDepartamentos>(item);
            var result = _generalServices.EliminarDepartamento(mapped);
            return Ok(result);
        }

        [HttpPut("Editar")]
        public IActionResult Editar([FromBody] DepartamentoViewModel item)
        {
            var mapped = _mapper.Map<tbDepartamentos>(item);
            var result = _generalServices.EditarDepartamento(mapped);
            return Ok(result);
        }

    }
}
