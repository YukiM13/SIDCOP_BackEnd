using Api_SIDCOP.API.Models.Acceso;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.Acceso
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class MunicipiosController : Controller
    {
        public readonly GeneralServices _generalServices;
        public readonly IMapper _mapper;
        //private readonly EmailService _emailService;

        public MunicipiosController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _generalServices.ListarMunicipios();
            return Ok(list);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] MunicipioViewModel municipioViewModel)
        {
            var municipio = _mapper.Map<tbMunicipios>(municipioViewModel);

            var response = _generalServices.InsertarMunicipios(municipio);
            return Ok(response);
        }

        [HttpPost("Actualizar")]
        public IActionResult Actualizar([FromBody] MunicipioViewModel municipioViewModel)
        {
            var municipio = _mapper.Map<tbMunicipios>(municipioViewModel);

            var response = _generalServices.ActualizarMunicipios(municipio);
            return Ok(response);
        }

        [HttpPost("Buscar/{id}")]
        public IActionResult Buscar(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id Invalida.");
            }

            var municipio = _generalServices.BuscarMunicipio(id);
            if (municipio != null)
            {
                return Ok(municipio);
            }
            else
            {
                return NotFound("municipio no encontrada con el ID proporcionado.");
            }
        }

        [HttpPost("Eliminar/{id}")]
        public IActionResult Eliminar(string? id)
        {
            if (string.IsNullOrEmpty(id) || id.Length < 0)
            {
                return BadRequest("Codigo llego mal.");
            }

            var result = _generalServices.EliminarMunicipio(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }


        [HttpPost("SucursalPorMunicipio/{id}")]
        public IActionResult BuscarSucursal(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id Invalida.");
            }

            var municipio = _generalServices.Municipio_ListarSucursales(id);
            if (municipio != null)
            {
                return Ok(municipio);
            }
            else
            {
                return NotFound("municipio no encontrada con el ID proporcionado.");
            }
        }
    }
}