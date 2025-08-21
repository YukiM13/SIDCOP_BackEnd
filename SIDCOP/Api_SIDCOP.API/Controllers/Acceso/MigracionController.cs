using Api_Sistema_Reportes.API.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api_SIDCOP.API.Controllers.Acceso
{

    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class MigracionController : Controller
    {
        [HttpPost("Migrar")]
    
        public IActionResult EjecutarPaquete(string paquete)
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;

                // Normaliza la ruta completa
                basePath = Path.GetFullPath(basePath);

                // Buscamos hasta la carpeta raíz del backend
                string rootPath = basePath.Split(new string[] { "SIDCOP_BackEnd" }, StringSplitOptions.None)[0] + "SIDCOP_BackEnd";

                // Ahora armamos la ruta hacia los paquetes
                string rutaPaquetes = Path.Combine(rootPath, @"SIDCOP\SIDCOP_Backend.ETL");

                // Ruta final del paquete
                string rutaPaquete = Path.Combine(rutaPaquetes, paquete + ".dtsx");
                // Argumentos para dtexec
                string argumentos = $"/F \"{rutaPaquete}\"";

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "dtexec",
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
                        return Ok($"Migracion de {paquete} ejecutada correctamente.\nSalida: {salida}");
                    else
                        return BadRequest($"Error al migrar {paquete}.\nError: {error}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Excepción: {ex.Message}");
            }
        }



    }
}
