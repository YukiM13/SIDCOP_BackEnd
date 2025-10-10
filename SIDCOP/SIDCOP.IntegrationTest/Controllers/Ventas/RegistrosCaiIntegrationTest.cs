using SIDCOP.IntegrationTest.Mocks.General;
using SIDCOP.IntegrationTest.Mocks.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Controllers.Ventas
{
    [TestClass]
    public class RegistroCaiIntegrationTest : BaseIntegrationTest
    {
        private const string ApiKey = "bdccf3f3-d486-4e1e-ab44-74081aefcdbc";

        [TestMethod]
        public async Task RegistroCaiListar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            var response = await cliente.GetAsync("/RegistrosCaiS/Listar");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task RegistroCaiCrear()
        {
            // Configuración del cliente HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // Crear datos mock para el empleado
            var nuevoRegistroCai = RegistrosCaiMocks.MockRegistroCai();

            // Serialización de datos
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(nuevoRegistroCai),
                System.Text.Encoding.UTF8,
                "application/json"
                                             );

            // Realizar la petición POST
            var response = await cliente.PostAsync("/RegistrosCaiS/Crear", contenido);

            // Verificaciones
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task RegistroCaiActualizar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            var actualizarRegistroCai = RegistrosCaiMocks.MockRegistroCai();
            var response = await cliente.PutAsJsonAsync("/RegistrosCaiS/Modificar", actualizarRegistroCai);

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task RegistroCaiEliminar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            var eliminarRegistroCai = RegistrosCaiMocks.MockRegistroCai();
            var response = await cliente.PutAsJsonAsync("/RegistrosCaiS/Eliminar", eliminarRegistroCai);

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }
    }
}