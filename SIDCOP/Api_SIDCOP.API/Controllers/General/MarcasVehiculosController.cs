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
    public class MarcasVehiculosController: Controller
    {
        private readonly GeneralServices _generalServices;
        private readonly IMapper _mapper;

        public MarcasVehiculosController(GeneralServices generalServices, IMapper mapper)
        {
            _generalServices = generalServices;
            _mapper = mapper;
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] MarcaVehiculoViewModel item)
        {
            var mapped = _mapper.Map<tbMarcasVehiculos>(item);
            var result = _generalServices.InsertarMarcaVehiculo(mapped);
            return Ok(result);
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {

            var result = _generalServices.ListarMarcaVehiculo();
            return Ok(result);
        }


        [HttpPost("Buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            if ( id <= 0 )
            {
                return BadRequest("Id Invalida.");
            }

            var deparatemnto = _generalServices.BuscarMarcaVehiculo(id);
            if (deparatemnto != null)
            {
                return Ok(deparatemnto);
            }
            else
            {
                return NotFound("Marca no encontrada con el ID proporcionado.");
            }
        }


        [HttpPost("BuscarModelo/{id}")]
        public IActionResult BuscarModelo(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }

            var modelo = _generalServices.BuscarModeloDeMarca(id);
            if (modelo != null)
            {
                return Ok(modelo);
            }
            else
            {
                return NotFound("Modelo no encontrado con el ID proporcionado.");
            }
        }


        [HttpPost("Eliminar/{id}")]
        public IActionResult Eliminar(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }

            var result = _generalServices.EliminarMarcavehiculo(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("Editar")]
        public IActionResult Editar([FromBody] MarcaVehiculoViewModel item)
        {
            var mapped = _mapper.Map<tbMarcasVehiculos>(item);
            var result = _generalServices.EditarMarcaVehiculo(mapped);
            return Ok(result);
        }

    }
}
