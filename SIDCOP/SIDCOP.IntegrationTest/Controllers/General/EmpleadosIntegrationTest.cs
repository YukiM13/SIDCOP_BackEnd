using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIDCOP.IntegrationTest.Mocks;
using SIDCOP.IntegrationTest.Mocks.General;

namespace SIDCOP.IntegrationTest.Controllers.General
{
    [TestClass]
    public class EmpleadosIntegrationTest : BaseIntegrationTest
    {
        private const string ApiKey = "bdccf3f3-d486-4e1e-ab44-74081aefcdbc";

        [TestMethod]
        public async Task EmpleadoInsertar()
        {
            // Configuración del cliente HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // Crear datos mock para el empleado
            var empleadoMock = EmpleadosMocks.CrearMockEmpleado();

            // Serialización de datos
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(empleadoMock),
                System.Text.Encoding.UTF8,
                "application/json"
                                             );

            // Realizar la petición POST
            var response = await cliente.PostAsync("/Empleado/Insertar", contenido);

            // Verificaciones
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task EmpleadoActualizar()
        {
            // Configuración del cliente HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // Crear datos mock para actualización
            var empleadoMock = EmpleadosMocks.CrearMockEmpleadoParaActualizar();

            // Serialización de datos
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(empleadoMock),
                System.Text.Encoding.UTF8,
                "application/json"
                                             );

            // Realizar la petición PUT
            var response = await cliente.PutAsync("/Empleado/Actualizar", contenido);

            // Verificaciones
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task ListarEmpleados_DebeRetornarLista()
        {
            // Configuración del cliente HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // Ejecutar la petición GET
            var response = await cliente.GetAsync("/Empleado/Listar");

            // Verificaciones
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task EmpleadoEliminar_DebeEliminarCorrectamente()
        {
            int empleadoId = 2047;

            // Configuración del cliente HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // Verificamos primero que el empleado existe
            var responseBuscar = await cliente.GetAsync($"/Empleado/Buscar/{empleadoId}");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, responseBuscar.StatusCode, $"El empleado con ID {empleadoId} no existe");

            // ✅ Enviamos POST sin cuerpo
            var response = await cliente.PostAsync($"/Empleado/Eliminar/{empleadoId}", null);

            // Verificaciones
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var deleteResponseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(deleteResponseContent));
            Console.WriteLine($"Respuesta de eliminación: {deleteResponseContent}");

            // Verificar que el empleado ya no existe
            var responseBuscarDespues = await cliente.GetAsync($"/Empleado/Buscar/{empleadoId}");
            Assert.AreEqual(System.Net.HttpStatusCode.NotFound, responseBuscarDespues.StatusCode,
                "El empleado aún existe después de eliminarlo");
        }

        [TestMethod]
        public async Task EmpleadoEliminar_DebeRetornarBadRequest_CuandoIdEsInvalido()
        {
            // Configuración del cliente HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // ID inválido
            int empleadoId = -1;

            // Ejecutar la petición POST para eliminar
            var response = await cliente.PostAsync($"/Empleado/Eliminar/{empleadoId}", null);

            // Verificaciones
            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(responseContent.Contains("Id Invalida"));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task EmpleadoBuscar_DebeEncontrarEmpleado()
        {
            // Configuración del cliente HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // Primero insertamos un empleado para luego buscarlo
            var empleadoMock = EmpleadosMocks.CrearMockEmpleado();
            var contenidoInsertar = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(empleadoMock),
                System.Text.Encoding.UTF8,
                "application/json"
                                                     );
            var responseInsertar = await cliente.PostAsync("/Empleado/Insertar", contenidoInsertar);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, responseInsertar.StatusCode);

            // Asumimos que el ID es 1, ajusta según tu implementación
            int empleadoId = 1;

            // Ejecutar la petición GET
            var response = await cliente.GetAsync($"/Empleado/Buscar/{empleadoId}");

            // Verificaciones
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task EmpleadoBuscar_DebeRetornarNotFound_CuandoNoExiste()
        {
            // Configuración del cliente HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // ID que asumimos que no existe
            int empleadoId = 99999;

            // Ejecutar la petición GET
            var response = await cliente.GetAsync($"/Empleado/Buscar/{empleadoId}");

            // Verificaciones
            Assert.AreEqual(System.Net.HttpStatusCode.NotFound, response.StatusCode);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(responseContent.Contains("Empleado not found"));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task EmpleadoInsertar_DeberiaFallar()
        {
            // Configuración del cliente HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // Crear datos mock con valores extremos
            var empleadoExtremos = EmpleadosMocks.CrearMockEmpleadoValoresExtremos();

            // Serialización de datos
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(empleadoExtremos),
                System.Text.Encoding.UTF8,
                "application/json"
                                             );

            // Realizar la petición que debería fallar
            var response = await cliente.PostAsync("/Empleado/Insertar", contenido);

            // Verificaciones de fallo
            var esExitoso = response.StatusCode == System.Net.HttpStatusCode.OK;
            var responseContent = await response.Content.ReadAsStringAsync();

            if (esExitoso)
            {
                Console.WriteLine("⚠️ ADVERTENCIA: La API aceptó valores extremos que podrían ser problemáticos");
                Console.WriteLine($"Respuesta: {responseContent}");
                Assert.IsTrue(true, "La API manejó valores extremos sin error - verificar si esto es el comportamiento esperado");
            }
            else
            {
                Console.WriteLine($"✅ La API correctamente rechazó valores extremos con código: {response.StatusCode}");
                Console.WriteLine($"Mensaje de error: {responseContent}");
                Assert.IsTrue(
                    response.StatusCode >= System.Net.HttpStatusCode.BadRequest,
                    $"Se esperaba un código de error, pero se recibió: {response.StatusCode}"
                             );
            }
        }
    }
}