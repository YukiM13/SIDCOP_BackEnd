using Api_Sistema_Reportes.API.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_SIDCOP.API.Controllers.General
{
    [Route("[controller]")]
    [ApiController]
    [ApiKey]
    public class ImagenController : ControllerBase
    {
        [HttpPost("Subir")]
        public async Task<IActionResult> SubirImagen(IFormFile imagen)
        {
            if (imagen == null || imagen.Length == 0)
            {
                return BadRequest("No se ha proporcionado una imagen válida.");
            }

            try
            {
                // Ruta donde se guardará la imagen
                var carpetaDestino = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagenes");
                if (!Directory.Exists(carpetaDestino))
                {
                    Directory.CreateDirectory(carpetaDestino);
                }

                // Generar un nombre único para la imagen
                var nombreArchivo = $"{Guid.NewGuid()}{Path.GetExtension(imagen.FileName)}";
                var rutaCompleta = Path.Combine(carpetaDestino, nombreArchivo);

                // Guardar la imagen en el servidor
                using (var stream = new FileStream(rutaCompleta, FileMode.Create))
                {
                    await imagen.CopyToAsync(stream);
                }

                // Devolver la ruta relativa de la imagen
                var rutaImagen = $"/imagenes/{nombreArchivo}";
                return Ok(new { ruta = rutaImagen });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al guardar la imagen: {ex.Message}");
            }
        }
    }
}
