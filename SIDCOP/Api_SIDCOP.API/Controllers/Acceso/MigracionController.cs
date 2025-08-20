using Api_Sistema_Reportes.API.Helpers;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.SqlServer.Dts.Runtime;

namespace Api_SIDCOP.API.Controllers.Acceso
{

    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class MigracionController : Controller
    {
        [HttpPost("Grupos")]
        public IActionResult EjecutarPaquete(string paquete)
        {
            try
            {
                // Carpeta base de la app (donde se ejecuta)
                string basePath = AppDomain.CurrentDomain.BaseDirectory;

                // Subimos niveles hasta llegar a la carpeta donde están los .dtsx
                string rutaPaquetes = Path.Combine(basePath, @"..\..\..\SIDCOP_Backend.ETL\Paquetes");

                // Ruta final del paquete
                string rutaPaquete = Path.Combine(rutaPaquetes, paquete + ".dtsx");

                // Normaliza la ruta para que sea absoluta
                rutaPaquete = Path.GetFullPath(rutaPaquete);

                if (!System.IO.File.Exists(rutaPaquete))
                    return NotFound($"No se encontró el paquete: {rutaPaquete}");

                // Cargar y ejecutar el paquete
                Application app = new Application();
                Package pkg = app.LoadPackage(rutaPaquete, null);
                DTSExecResult resultado = pkg.Execute();

                return Ok($"Migracion para {paquete} ejecutada con resultado: {resultado}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al ejecutar el paquete: {ex.Message}");
            }
        }
    }
}
