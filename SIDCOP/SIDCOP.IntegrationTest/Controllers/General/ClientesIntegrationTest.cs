using SIDCOP.IntegrationTest.Mocks;
using SIDCOP.IntegrationTest.Mocks.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Controllers.General
{
    [TestClass]
    public class ClientesIntegrationTest: BaseIntegrationTest
    {
        private const string ApiKey = "bdccf3f3-d486-4e1e-ab44-74081aefcdbc";

        [TestMethod]
        public async Task Clientes_Listar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var response = await cliente.GetAsync("/Cliente/Listar");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }


        [TestMethod] // Atributo que marca este método como una prueba 
        public async Task Cliente_Insertar()
        {

            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var ClienteMock = ClientesMocks.CrearMockClienteInsertar();
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(ClienteMock),
                System.Text.Encoding.UTF8,
                "application/json"
            );
            var response = await cliente.PostAsync("/Cliente/Insertar", contenido);

            // Verifica que la respuesta tenga código HTTP 200 (OK)
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            // Verifica que la respuesta no sea nula
            Assert.IsNotNull(response);

            // Lee el contenido de la respuesta como string
            var responseContent = await response.Content.ReadAsStringAsync();

            // Verifica que la respuesta no esté vacía
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));

            // Muestra la respuesta en consola para debugging/verificación manual
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task Cliente_Buscar()
        {
            // PASO 1: CONFIGURACIÓN DEL CLIENTE HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            // Usa un método diferente del mock para crear datos de búsqueda
            var ClienteMock = ClientesMocks.CrearMockClienteBuscar();
            // PASO 3: SERIALIZACIÓN 
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(ClienteMock),
                System.Text.Encoding.UTF8,
                "application/json"
            );
            //  PETICIÓN A ENDPOINT DE BÚSQUEDA
            var response = await cliente.GetAsync($"/Cliente/Buscar/{ClienteMock.Clie_Id}");
            // VERIFICACIONES 
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }
    }
}
