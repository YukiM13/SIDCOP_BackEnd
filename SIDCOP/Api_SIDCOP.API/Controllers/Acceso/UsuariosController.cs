using Api_Sistema_Reportes.API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using SIDCOP_Backend.BusinessLogic.Services;
using Api_SIDCOP.API.Models.Acceso;
using MailKit.Security;
using System.Drawing;
using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Controllers.Acceso
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class UsuariosController : Controller
    {
        public readonly AccesoServices _accesoServices;
        public readonly IMapper _mapper;
        //private readonly EmailService _emailService;

        public UsuariosController(AccesoServices accesoServices, IMapper mapper)
        {
            _accesoServices = accesoServices;
            _mapper = mapper;
           
        }

        //[HttpPost("IniciarSesion")]
        //public IActionResult IniciarSesion([FromBody] UsuarioViewModel item)
        //{
        //    var mapped = _mapper.Map<tbUsuarios>(item);
        //    var result = _accesoServices.IniciarSesion(mapped);

        //    if (result == null || !result.Any()) // <-- aquí está la clave
        //    {
        //        return BadRequest(new
        //        {
        //            code_Status = -1,
        //            message_Status = "Usuario o contraseña incorrectos."
        //        });
        //    }

        //    return Ok(new
        //    {
        //        code_Status = 1,
        //        message_Status = "Sesión iniciada correctamente",
        //        data = result
        //    });
        //}

        [HttpPost("IniciarSesion")]
        public IActionResult IniciarSesion([FromBody] UsuarioViewModel item)
        {
            var mapped = _mapper.Map<tbUsuarios>(item);
            var result = _accesoServices.IniciarSesion(mapped);

            if (result == null || result.code_Status != 1)
            {
                return BadRequest(new
                {
                    code_Status = result?.code_Status ?? -1,
                    message_Status = result?.message_Status ?? "Usuario o contraseña incorrectos."
                });
            }

            return Ok(new
            {
                data = result
            });
        }



        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var list = _accesoServices.ListUsuarios();
            return Ok(list);
        }

        [HttpPost("Insertar")]
        public IActionResult Insert([FromBody] UsuarioViewModel item)
        {
            var mapped = _mapper.Map<tbUsuarios>(item);
            var insert = _accesoServices.InsertUsuario(mapped);
            return Ok(insert);
        }

        [HttpPut("Actualizar")]
        public IActionResult Update([FromBody] UsuarioViewModel item)
        {
            var mapped = _mapper.Map<tbUsuarios>(item);
            var update = _accesoServices.UpdateUsuario(mapped);
            return Ok(update);
        }

        [HttpPost("CambiarEstado")]
        public IActionResult Delete([FromBody] UsuarioViewModel item)
        {
            var mapped = _mapper.Map<tbUsuarios>(item);
            var delete = _accesoServices.CambiarEstadoUsuario(mapped);
            return Ok(delete);
        }

        [HttpPost("Buscar")]
        public IActionResult Find([FromBody] UsuarioViewModel item)
        {
            var mapped = _mapper.Map<tbUsuarios>(item);
            var list = _accesoServices.BuscarUsuario(mapped);
            return Ok(list);
        }

        [HttpPost("RestablecerClave")]
        public IActionResult RestablecerClave([FromBody] UsuarioViewModel item)
        {
            var mapped = _mapper.Map<tbUsuarios>(item);
            var result = _accesoServices.RestablecerContrasena(mapped);
            return Ok(result);
        }

        [HttpPost("EnviarCorreo")]
        public async Task<IActionResult> GenerarCodigo([FromBody] EmailRequest request)
        {
            try
            {
                var servicioCorreo = new EmailService();
                await servicioCorreo.EnviarCodigoVerificacionAsync(request);
                return Ok(new { mensaje = "Correo enviado exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        public class EmailService
        {
            public async Task EnviarCodigoVerificacionAsync(EmailRequest item)
            {
                var mensaje = new MimeMessage();
                mensaje.From.Add(new MailboxAddress("SIDCOP", "sidcop.soporte@gmail.com"));
                mensaje.To.Add(new MailboxAddress("", item.to_email));
                mensaje.Subject = "Código de verificación para restablecer contraseña";

                string htmlConCodigo = $@"
<!DOCTYPE html>
<html>
<head>
  <meta charset='UTF-8'>
  <style>
    body {{
      background-color: #1c1c1e;
      color: #ffffff;
      font-family: Arial, sans-serif;
      padding: 40px;
      margin: 0;
    }}
    .container {{
      max-width: 500px;
      margin: auto;
      background-color: #141A2F;
      padding: 30px;
      border-radius: 10px;
      text-align: center;
    }}
    .logo {{
      width: 100px;
      margin-bottom: 20px;
    }}
    .code {{
      font-size: 36px;
      font-weight: bold;
      color: #D6B68A;
      margin: 20px 0;
    }}
    .footer {{
      margin-top: 30px;
      font-size: 12px;
      color: #aaaaaa;
    }}
    a {{
      color: #00aaff;
    }}
    .im {{
        color: #f9f5f9;
     }}
  </style>
</head>
<body>
   <div class='container'>
    <img src='https://firebasestorage.googleapis.com/v0/b/fir-upload-pdf-d2c3f.firebasestorage.app/o/logo%2Flogo_original.png?alt=media&token=bb1b29e0-0494-4873-a6e6-cef4c02d6c52' alt='Logo' class='logo' />
    <h2 style=""color: #ffffff;"">Tu código de verificación</h2>
    <div class='code'>{item.codigo}</div>
    <p style=""color: #ffffff;"">No compartas este código con nadie. Si no fuiste tú quien lo solicitó, te recomendamos cambiar tu contraseña.</p>
    <p style=""color: #ffffff;"">Muchas gracias,</p>
    <p style=""color: #ffffff;"">El equipo de SIDCOP</p>
    <div class='footer'>
      &copy; 2025 SIDCOP. Todos los derechos reservados.
    </div>
  </div>
</body>
</html>";

                var builder = new BodyBuilder
                {
                    HtmlBody = htmlConCodigo
                };

                mensaje.Body = builder.ToMessageBody();

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync("sidcop.soporte@gmail.com", "pbpg xsqp otkj eqdx");
                await smtp.SendAsync(mensaje);
                await smtp.DisconnectAsync(true);
            }
        }
    }


}
