using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIDCOP.IntegrationTest.Mocks.Logistica;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Controllers.Logistica
{
    [TestClass]
    public class TrasladosIntegrationTest : BaseIntegrationTest
    {
        private const string ApiKey = "bdccf3f3-d486-4e1e-ab44-74081aefcdbc";

        [TestMethod]
        public async Task TrasladoListar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var response = await cliente.GetAsync("/Traslado/Listar");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task TrasladoCrear()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var nuevoTraslado = TrasladosMocks.CrearMockTraslado();
            var jsonContent = System.Text.Json.JsonSerializer.Serialize(nuevoTraslado);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("/Traslado/Insertar", contentString);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task TrasladoInsertarDetalle()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var nuevoTrasladoDetalle = TrasladosMocks.CrearMockTrasladoDetalle();
            var jsonContent = System.Text.Json.JsonSerializer.Serialize(nuevoTrasladoDetalle);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("/Traslado/InsertarDetalle", contentString);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task TrasladoBuscar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var trasladoId = TrasladosMocks.ObtenerIdTrasladoExistente();
            var response = await cliente.GetAsync($"/Traslado/Buscar/{trasladoId}");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task TrasladoBuscarDetalle()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var trasladoId = TrasladosMocks.ObtenerIdTrasladoConDetalles();
            var response = await cliente.GetAsync($"/Traslado/BuscarDetalle/{trasladoId}");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task TrasladoEliminar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var trasladoId = TrasladosMocks.ObtenerIdTrasladoParaEliminar();
            var response = await cliente.PostAsync($"/Traslado/Eliminar/{trasladoId}", null);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }
    }
}
