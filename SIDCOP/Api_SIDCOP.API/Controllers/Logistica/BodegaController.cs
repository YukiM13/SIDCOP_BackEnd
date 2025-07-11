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
    public class BodegaController : Controller
    {

        public readonly LogisticaServices _logisticaServices;
        public readonly IMapper _mapper;
        //private readonly EmailService _emailService;

        public BodegaController(LogisticaServices logisticaServices, IMapper mapper)
        {
            _logisticaServices  = logisticaServices;
            _mapper = mapper;
        }


        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _logisticaServices.ListBodegas();
            var mapped = _mapper.Map<IEnumerable<BodegaViewModel>>(list);
            return Ok(mapped);
        }


        [HttpPost("Insertar")]
        public IActionResult Insertar(BodegaViewModel item)
        {
            var mapped = _mapper.Map<tbBodegas>(item);
            var result = _logisticaServices.InsertBodega(mapped);

            return Ok(result);
        }


        [HttpPut("Actualizar")]
        public IActionResult Actualizar(BodegaViewModel item)
        {
            var mapped = _mapper.Map<tbBodegas>(item);
            var result = _logisticaServices.UpdateBodega(mapped);

            return Ok(result);
        }


        [HttpPost("Eliminar")]
        public IActionResult Eliminar(BodegaViewModel item)
        {
            var mapped = _mapper.Map<tbBodegas>(item);
            var result = _logisticaServices.DeleteBodega(mapped);

            return Ok(result);
        }


        [HttpGet("Buscar")]
        public IActionResult Buscar(int id)
        {
            var result = _logisticaServices.FindBodega(id);

            try
            {
                result.Data = _mapper.Map<BodegaViewModel>(result.Data);
            }
            catch (Exception ex) { }


            return Ok(result);
        }
    }
}
