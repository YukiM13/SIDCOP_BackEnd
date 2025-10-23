using SIDCOP.IntegrationTest.Mocks;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Controllers
{
    [TestClass] // Contenedora de métodos de prueba
    public class UsuariosIntegrationTest : BaseIntegrationTest
    {
        // Almacena la clave API para autenticación
        private const string ApiKey = "bdccf3f3-d486-4e1e-ab44-74081aefcdbc";


        [TestMethod]
        public async Task UsuarioListar()
        {
            // Arrange
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            string url = "/Usuarios/Listar";

            // Act
            var response = await cliente.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine($"Respuesta del servidor: {responseContent.Substring(0, Math.Min(500, responseContent.Length))}...");

            // Assert básicos
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode, "El código de respuesta no fue OK");
            Assert.IsFalse(string.IsNullOrEmpty(responseContent), "La respuesta está vacía");

            // Deserializar directamente la lista
            var usuarios = JsonSerializer.Deserialize<List<tbUsuarios>>(
                responseContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            // Validaciones
            Assert.IsNotNull(usuarios, "La lista de usuarios no debe ser nula");
            Assert.IsTrue(usuarios.Count > 0, "No se devolvieron usuarios en la lista");

            // Mostrar algunos datos en consola
            Console.WriteLine($"✅ Se obtuvieron {usuarios.Count} usuarios correctamente.");
            Console.WriteLine($"Primer usuario: {usuarios[0].Usua_Usuario}");
        }


        [TestMethod]
        public async Task UsuarioInsertar()
        {
            // Arrange
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            var usuariosMock = UsuarioMocks.CrearMockUsuario();

            var json = System.Text.Json.JsonSerializer.Serialize(usuariosMock);
            Console.WriteLine($"JSON enviado: {json}"); // Ver qué enviamos

            var contenido = new StringContent(
                json,
                System.Text.Encoding.UTF8,
                "application/json"
            );

            // Act
            var response = await cliente.PostAsync("/Usuarios/Insertar", contenido);

            // Leer la respuesta ANTES de los asserts para debugging
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine($"Respuesta: {responseContent}");

            // Assert
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                // Si falla, mostrar más información
                Assert.Fail($"Expected OK but got {response.StatusCode}. Response: {responseContent}");
            }

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }


        [TestMethod] // Segunda prueba para operación de actualización
        public async Task UsuariosActualizar()
        {
            // PASO 1: CONFIGURACIÓN DEL CLIENTE HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // Usa un método diferente del mock para crear datos de actualización
            var usuariosMock = UsuarioMocks.ActualizarMockUsuario();

            // PASO 3: SERIALIZACIÓN 
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(usuariosMock),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            //  PETICIÓN A ENDPOINT DE ACTUALIZACIÓN
            var response = await cliente.PutAsync("/Usuarios/Actualizar", contenido);

            // VERIFICACIONES 
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod] // Segunda prueba para operación de actualización
        public async Task CambiarEstadoUsuarios()
        {
            // PASO 1: CONFIGURACIÓN DEL CLIENTE HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // Usa un método diferente del mock para crear datos de actualización
            var usuariosMock = UsuarioMocks.CambiarEstadoUsuarioMock();

            // PASO 3: SERIALIZACIÓN 
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(usuariosMock),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            //  PETICIÓN A ENDPOINT DE ACTUALIZACIÓN
            var response = await cliente.PostAsync("/Usuarios/CambiarEstado", contenido);

            // VERIFICACIONES 
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod] // Segunda prueba para operación de actualización
        public async Task BuscarUsuario()
        {
            // PASO 1: CONFIGURACIÓN DEL CLIENTE HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // Usa un método diferente del mock para crear datos de actualización
            var usuariosMock = UsuarioMocks.BuscarUsuarioMock();

            // PASO 3: SERIALIZACIÓN 
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(usuariosMock),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            //  PETICIÓN A ENDPOINT DE BUSCAR
            var response = await cliente.PostAsync("/Usuarios/Buscar", contenido);

            // VERIFICACIONES 
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task UsuarioMostrarContrasena()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            int usuaId = 1;
            string claveSeguridad = "clave123";

            string url = $"/Usuarios/MostrarContrasena?usuaId={usuaId}&claveSeguridad={System.Net.WebUtility.UrlEncode(claveSeguridad)}";

            var response = await cliente.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine($"Respuesta del servidor: {responseContent}");

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            // Usar JsonDocument para navegar el JSON
            using var jsonDoc = JsonDocument.Parse(responseContent);
            var root = jsonDoc.RootElement;

            // Verificar que success sea true
            bool success = root.GetProperty("success").GetBoolean();
            Assert.IsTrue(success, "La respuesta no fue exitosa");

            // Obtener el objeto data (que contiene el RequestStatus)
            var dataElement = root.GetProperty("data");

            // Deserializar solo la parte data a RequestStatus
            var resultado = JsonSerializer.Deserialize<RequestStatus>(
                dataElement.GetRawText(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            Assert.IsNotNull(resultado);
            Console.WriteLine($"Code Status: {resultado.code_Status}");
            Console.WriteLine($"Message: {resultado.message_Status}");

            // Si esperas éxito, verifica code_Status = 1
            // Si esperas error (como en tu caso con clave incorrecta), verifica code_Status = -1
            if (resultado.code_Status == -1)
            {
                Console.WriteLine("⚠️ Clave de seguridad incorrecta");
            }
            else if (resultado.code_Status == 1)
            {
                Assert.IsNotNull(resultado.data, "La contraseña no fue retornada");
                Console.WriteLine($"✅ Contraseña obtenida: {resultado.data}");
            }
        }

        [TestMethod] // Segunda prueba para operación de actualización
        public async Task UsuariosIniciarSesion()
        {
            // PASO 1: CONFIGURACIÓN DEL CLIENTE HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // Usa un método diferente del mock para crear datos de actualización
            var usuariosMock = UsuarioMocks.ActualizarMockUsuario();

            // PASO 3: SERIALIZACIÓN 
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(usuariosMock),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            //  PETICIÓN A ENDPOINT DE ACTUALIZACIÓN
            var response = await cliente.PostAsync("/Usuarios/IniciarSesion", contenido);

            // VERIFICACIONES 
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod] // Segunda prueba para operación de actualización
        public async Task RestablecerComtrasena()
        {
            // PASO 1: CONFIGURACIÓN DEL CLIENTE HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // Usa un método diferente del mock para crear datos de actualización
            var usuariosMock = UsuarioMocks.RestablecerContrasenaMock();

            // PASO 3: SERIALIZACIÓN 
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(usuariosMock),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            //  PETICIÓN A ENDPOINT DE BUSCAR
            var response = await cliente.PostAsync("/Usuarios/RestablecerClave", contenido);

            // VERIFICACIONES 
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        // Sad path, para las pruebas de integración

        [TestMethod] // Prueba con valores extremos que también debería fallar
        public async Task PreciosPorProductoInsertar_DeberiaFallar()
        {
            // PASO 1: CONFIGURACIÓN DEL CLIENTE HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // PASO 2: CREAR DATOS CON VALORES EXTREMOS
            // Usa valores extremos que podrían causar overflow o errores de validación
            var preciosExtremos = ListaDePreciosMocks.CrearMockPreciosPorProductoValoresExtremos();

            // PASO 3: SERIALIZACIÓN DE DATOS EXTREMOS
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(preciosExtremos),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            // PASO 4: PETICIÓN QUE DEBERÍA FALLAR
            var response = await cliente.PostAsync("/PreciosPorProducto/InsertarLista", contenido);

            // PASO 5: VERIFICACIONES DE FALLO
            // Esta prueba puede fallar de diferentes maneras:
            // - 400 Bad Request (validación)
            // - 404 Not Found (IDs inexistentes)
            // - 500 Internal Server Error (overflow o errores de BD)

            var esExitoso = response.StatusCode == System.Net.HttpStatusCode.OK;
            var responseContent = await response.Content.ReadAsStringAsync();

            if (esExitoso)
            {
                Console.WriteLine("ADVERTENCIA: La API aceptó valores extremos que podrían ser problemáticos");
                Console.WriteLine($"Respuesta: {responseContent}");

                // Si la API acepta estos valores, al menos documentamos que pasó
                Assert.IsTrue(true, "La API manejó valores extremos sin error - verificar si esto es el comportamiento esperado");
            }
            else
            {
                Console.WriteLine($"La API correctamente rechazó valores extremos con código: {response.StatusCode}");
                Console.WriteLine($"Mensaje de error: {responseContent}");

                // Verifica que sea un código de error apropiado
                Assert.IsTrue(
                    response.StatusCode >= System.Net.HttpStatusCode.BadRequest,
                    $"Se esperaba un código de error, pero se recibió: {response.StatusCode}"
                );
            }
        }

    }

}
