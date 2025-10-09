using SIDCOP.IntegrationTest.Mocks.Logistica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Controllers.Logistica
{

    [TestClass]
    public class RecargasIntegrationTest : BaseIntegrationTest
    {

        private const string ApiKey = "bdccf3f3-d486-4e1e-ab44-74081aefcdbc";

        [TestMethod]
        public async Task RecargaListar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var response = await cliente.GetAsync("/Recargas/Listar");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]

        public async Task RecargaCrear()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var nuevoRecarga = RecargasMocks.CrearMockRecargas();
            var jsonContent = System.Text.Json.JsonSerializer.Serialize(nuevoRecarga);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("/Recargas/Insertar", contentString);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");

        }

        [TestMethod]

        public async Task RecargaActualizar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var actualizarRecarga = RecargasMocks.ActualizarMockRecargas();
            var jsonContent = System.Text.Json.JsonSerializer.Serialize(actualizarRecarga);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync("/Recargas/Actualizar", contentString);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]

        public async Task RecargaConfirmar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var actualizarRecarga = RecargasMocks.CrearMockRecargas();
            var jsonContent = System.Text.Json.JsonSerializer.Serialize(actualizarRecarga);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync("/Recargas/Confirmar", contentString);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        //ListarsPorSucursal

        [TestMethod]

        public async Task RecargaListarPorVendedor()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var VendedorId = 1;
            var response = await cliente.GetAsync($"/Recargas/ListarVendedor/{VendedorId}");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }


        [TestMethod]

        public async Task RecargaListarPorSucursal()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var Sucursal = 1;
            var EsAdmin = true;
            var response = await cliente.GetAsync($"/Recargas/ListarsPorSucursal/{Sucursal}/{EsAdmin}");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }


    }
}
