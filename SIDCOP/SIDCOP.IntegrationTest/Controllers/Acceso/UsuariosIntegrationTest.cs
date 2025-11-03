using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIDCOP.IntegrationTest.Mocks;
using SIDCOP_Backend.BusinessLogic;
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


        #region Listar
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
        #endregion

        #region Insertar
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
        #endregion

        #region Actualizar
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
        #endregion

        #region Cambiar Estado
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
        #endregion

        #region Buscar
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
        #endregion

        #region Mostrar Contraseña
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
        #endregion

        #region Iniciar Sesión
        [TestMethod] // Segunda prueba para operación de actualización
        public async Task IniciarSesion()
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
        #endregion

        #region Restablecer Contraseña
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
        #endregion

        #region Verificar Usuario Existente
        [TestMethod]

        public async Task VerificarUsuarioExistente()
        {
            // Arrange
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            var usuarioMock = UsuarioMocks.VerificarUsuarioExistenteMock();

            // 2. Ahora sí, verifica el usuario existente
            var buscarUsuario = new
            {
                Usua_Id = usuarioMock.Usua_Id,
                Usua_Usuario = usuarioMock.Usua_Usuario,
                Usua_Clave = usuarioMock.Usua_Clave,
                Role_Descripcion = usuarioMock.Role_Descripcion
            };
            var buscarJson = JsonSerializer.Serialize(buscarUsuario);
            var buscarContenido = new StringContent(buscarJson, Encoding.UTF8, "application/json");

            // Act
            var response = await cliente.PostAsync("/Usuarios/VerificarUsuario", buscarContenido);
            var responseContent = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine($"Respuesta: {responseContent}");

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "El código de respuesta no fue OK");
            Assert.IsFalse(string.IsNullOrEmpty(responseContent), "La respuesta está vacía");

            // Deserializa el ServiceResult
            var serviceResult = JsonSerializer.Deserialize<ServiceResult>(
                responseContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            Assert.IsNotNull(serviceResult, "El ServiceResult no debe ser nulo");
            Assert.IsTrue(serviceResult.Success, $"La operación no fue exitosa: {serviceResult.Message}");
            Assert.IsNotNull(serviceResult.Data, "La data no debe ser nula");

            // Deserializa la lista de usuarios desde Data
            var usuariosJson = serviceResult.Data.ToString();
            var usuarios = JsonSerializer.Deserialize<List<tbUsuarios>>(usuariosJson ?? "[]", new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            Assert.IsNotNull(usuarios, "La lista de usuarios no debe ser nula");

            // Si usuarios ya es List<tbUsuarios>, usa directamente.
            // Si usuarios es dynamic, deserializa así:
            var usuariosList = usuarios as List<tbUsuarios>;
            if (usuariosList == null)
            {
                usuariosList = JsonSerializer.Deserialize<List<tbUsuarios>>(
                    usuarios.ToString(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );
            }

            Assert.IsNotNull(usuariosList, "La lista de usuarios no debe ser nula");
            Assert.IsTrue(usuariosList.Any(u => u.Usua_Id == usuarioMock.Usua_Id), "No se encontró el usuario esperado");
            Console.WriteLine($"✅ Usuario existente verificado correctamente (ID: {usuarioMock.Usua_Id})");
        }
        #endregion

    }

}
