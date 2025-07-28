using Api_SIDCOP.API.Models.Inventario;
using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.Inventario
{
    [Route("/[controller]")]
    [ApiController]
    [ApiKey]
    public class InventarioSucursalesController : Controller
    {

        private readonly InventarioServices _inventarioServices;
        private readonly IMapper _mapper;

        public InventarioSucursalesController(InventarioServices inventarioServices, IMapper mapper)
        {
            _inventarioServices = inventarioServices;
            _mapper = mapper;
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Invalida.");
            }
            var invent = _inventarioServices.ListInve(id);
            if (invent != null)
            {
                return Ok(invent);
            }
            else
            {
                return NotFound("Inventario No encontrados.");
            }
        }

    }
}
