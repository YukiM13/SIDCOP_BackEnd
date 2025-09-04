using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;
using System.Diagnostics;

namespace Api_SIDCOP.API.Controllers.Acceso
{

    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class MigracionController : Controller
    {

        public readonly AccesoServices _accesoServices;
        public readonly IMapper _mapper;
        //private readonly EmailService _emailService;

        public MigracionController(AccesoServices accesoServices, IMapper mapper)
        {
            _accesoServices = accesoServices;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _accesoServices.ListarMigraciones();
            return Ok(list);
        }


        [HttpPost("Migrar/{paquete},{rutaFisica}")]
        public IActionResult EjecutarPaquete(string paquete, string rutaFisica)
        {
            try
            {
         

                // Ruta final del paquete
                string rutaPaquete = Path.Combine(rutaFisica, paquete + ".dtsx");

                string passwordPaquete ="admin123";
                // Argumentos para dtexec
                string argumentos = $"/F \"{rutaPaquete}\" /De \"{passwordPaquete}\"";

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = @"C:\Program Files\Microsoft SQL Server\140\DTS\Binn\DTExec.exe",
                    Arguments = argumentos,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process proceso = new Process { StartInfo = psi })
                {
                    proceso.Start();
                    string salida = proceso.StandardOutput.ReadToEnd();
                   string error = proceso.StandardError.ReadToEnd();
                    proceso.WaitForExit();

                    if (proceso.ExitCode == 0)
                        return Ok(new { success = true, message = $"Migración de {paquete} ejecutada correctamente. Salida: {salida}" });

                    else
                        return BadRequest(new { success = false, message = $"Error al migrar {paquete}. Error: {salida}" });

                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Excepción: {ex.Message}");
            }
        }



    }
}
