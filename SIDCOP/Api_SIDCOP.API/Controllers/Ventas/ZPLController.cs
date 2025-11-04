using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIDCOP_Backend.BusinessLogic.Services;

namespace Api_SIDCOP.API.Controllers.Ventas
{

    public class ConvertBase64Request
    {
        public string ImageBase64 { get; set; }
        public int? Threshold { get; set; }
        public int? TargetWidth { get; set; }
        public int? TargetHeight { get; set; }
    }


    public class ZPLController : Controller
    {
        public readonly VentaServices _ventaServices;
        public readonly IMapper _mapper;

        public ZPLController(VentaServices ventaServices, IMapper mapper)
        {
            _ventaServices = ventaServices;
            _mapper = mapper;
        }


        [HttpPost("ConvertirImagenAZPL")]
        public async Task<IActionResult> ConvertirImagenAZPL(
            IFormFile imageFile,
            [FromForm] int threshold = 128,
            [FromForm] int? targetWidth = null,
            [FromForm] int? targetHeight = null)
        {
            try
            {
                // Validar que se envió una imagen
                if (imageFile == null || imageFile.Length == 0)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "No se proporcionó ninguna imagen"
                    });
                }

                // Validar el tipo de archivo
                var allowedExtensions = new[] { ".png", ".jpg", ".jpeg", ".bmp", ".gif" };
                var fileExtension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();

                if (!Array.Exists(allowedExtensions, ext => ext == fileExtension))
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "Formato de imagen no válido. Solo se permiten: PNG, JPG, JPEG, BMP, GIF"
                    });
                }

                // Validar el tamaño del archivo (máximo 5MB)
                if (imageFile.Length > 5 * 1024 * 1024)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "La imagen es demasiado grande. Tamaño máximo: 5MB"
                    });
                }

                // Leer la imagen como bytes
                byte[] imageBytes;
                using (var memoryStream = new MemoryStream())
                {
                    await imageFile.CopyToAsync(memoryStream);
                    imageBytes = memoryStream.ToArray();
                }

                // Redimensionar si se especificaron dimensiones
                if (targetWidth.HasValue && targetHeight.HasValue)
                {
                    imageBytes = _ventaServices.ResizeImage(
                        imageBytes,
                        targetWidth.Value,
                        targetHeight.Value
                    );
                }

                // Validar el tamaño de la imagen
                if (!_ventaServices.ValidateImageSize(imageBytes, 500, 500))
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "La imagen es demasiado grande. Dimensiones máximas: 500x500 píxeles"
                    });
                }

                // Convertir a ZPL
                string zplCode = _ventaServices.ConvertImageToZpl(imageBytes, threshold);

                return Ok(new
                {
                    success = true,
                    message = "Imagen convertida exitosamente",
                    data = new
                    {
                        zplCode = zplCode,
                        length = zplCode.Length,
                        fileName = imageFile.FileName
                    }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error al convertir la imagen a ZPL",
                    error = ex.Message
                });
            }
        }

        /// <summary>
        /// Convierte una imagen en Base64 a formato ZPL
        /// </summary>
        /// <param name="request">Objeto con la imagen en base64</param>
        /// <returns>Código ZPL generado</returns>
        [HttpPost("ConvertirBase64AZPL")]
        public IActionResult ConvertirBase64AZPL([FromBody] ConvertBase64Request request)
        {
            try
            {
                // Validar que se envió el base64
                if (string.IsNullOrWhiteSpace(request.ImageBase64))
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "No se proporcionó ninguna imagen en base64"
                    });
                }

                // Limpiar el string base64 (remover prefijos si existen)
                string base64String = request.ImageBase64;
                if (base64String.Contains(","))
                {
                    base64String = base64String.Split(',')[1];
                }

                // Convertir base64 a bytes
                byte[] imageBytes = Convert.FromBase64String(base64String);

                // Redimensionar si se especificaron dimensiones
                if (request.TargetWidth.HasValue && request.TargetHeight.HasValue)
                {
                    imageBytes = _ventaServices.ResizeImage(
                        imageBytes,
                        request.TargetWidth.Value,
                        request.TargetHeight.Value
                    );
                }

                // Validar el tamaño de la imagen
                if (!_ventaServices.ValidateImageSize(imageBytes, 500, 500))
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "La imagen es demasiado grande. Dimensiones máximas: 500x500 píxeles"
                    });
                }

                // Convertir a ZPL
                string zplCode = _ventaServices.ConvertImageToZpl(
                    imageBytes,
                    request.Threshold ?? 128
                );

                return Ok(new
                {
                    success = true,
                    message = "Imagen convertida exitosamente",
                    data = new
                    {
                        zplCode = zplCode,
                        length = zplCode.Length
                    }
                });
            }
            catch (FormatException)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "El formato Base64 no es válido"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error al convertir la imagen a ZPL",
                    error = ex.Message
                });
            }
        }
    }
}
