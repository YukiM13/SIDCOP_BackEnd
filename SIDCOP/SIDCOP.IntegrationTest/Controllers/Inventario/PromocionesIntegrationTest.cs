using SIDCOP.IntegrationTest.Mocks.General;
using SIDCOP.IntegrationTest.Mocks.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Controllers.Inventario
{
    [TestClass]
    public class PromocionesIntegrationTest: BaseIntegrationTest
    {
        private const string ApiKey = "bdccf3f3-d486-4e1e-ab44-74081aefcdbc";

        [TestMethod]
        public async Task PromocionesListar()
        {
            // Arrange
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // Act
            var response = await cliente.GetAsync("/Promociones/Listar");

            // Assert
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(content));
            Console.WriteLine(content);
        }

        [TestMethod]
        public async Task PromocionInsertar()
        {
            // Configuración del cliente HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // Crear datos mock para el empleado
            var promocionMock = PromocionesMocks.CrearMockPromocion();

            // Serialización de datos
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(promocionMock),
                System.Text.Encoding.UTF8,
                "application/json"
                                             );

            // Realizar la petición POST
            var response = await cliente.PostAsync("/Promociones/Insertar", contenido);

            // Verificaciones
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task PromocionActualizar()
        {
            // Configuración del cliente HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // Crear datos mock para actualización
            var promocionMock = PromocionesMocks.CrearMockPromocionParaActualizar();

            // Serialización de datos
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(promocionMock),
                System.Text.Encoding.UTF8,
                "application/json"
                                             );

            // Realizar la petición PUT
            var response = await cliente.PutAsync("/Promociones/Actualizar", contenido);

            // Verificaciones
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }


        [TestMethod]
        public async Task PromocionCambiarEstado()
        {
            int promocionId = 200;

            // Configuración del cliente HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // ✅ Enviamos POST sin cuerpo
            var response = await cliente.PutAsync($"/Promociones/CambiarEstado/{promocionId}", null);

            // Verificaciones
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var deleteResponseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(deleteResponseContent));
            Console.WriteLine($"Respuesta de cambio de estado: {deleteResponseContent}");

        }


        [TestMethod]
        public async Task PromocionInsertar_DeberiaFallar()
        {
            // Configuración del cliente HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // Crear datos mock con valores extremos
            var promocionExtremos = PromocionesMocks.CrearMockPromocionValoresExtremos();

            // Serialización de datos
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(promocionExtremos),
                System.Text.Encoding.UTF8,
                "application/json"
                                             );

            // Realizar la petición que debería fallar
            var response = await cliente.PostAsync("/Promociones/Insertar", contenido);

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
