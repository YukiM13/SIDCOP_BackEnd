using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIDCOP.IntegrationTest.Mocks.Logistica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Controllers.Inventario
{
    [TestClass]
    public class InventarioSucursalesIntegrationTest : BaseIntegrationTest
    {
        private const string ApiKey = "bdccf3f3-d486-4e1e-ab44-74081aefcdbc";

        [TestMethod]
        public async Task Buscar_InventarioPorId()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            var response = await cliente.GetAsync("/InventarioSucursales/Buscar/1");

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var content = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(content));
            Console.WriteLine(content);
        }

        [TestMethod]
        public async Task Historial_InventarioPorId()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            var response = await cliente.GetAsync("/InventarioSucursales/Historial/1");

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(content));
            Console.WriteLine(content);
        }

        [TestMethod]
        public async Task ListarPorSucursal_DeberiaRetornarLista()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            var response = await cliente.GetAsync("/InventarioSucursales/ListarPorSucursal/1");

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(content));
            Console.WriteLine(content);
        }

        [TestMethod]
        public async Task ActualizarInventario_DeberiaEjecutarse()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            var response = await cliente.PostAsync("/InventarioSucursales/ActualizarInventario/2/1", null);

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(content));
            Console.WriteLine(content);
        }

        [TestMethod]
        public async Task ActualizarCantidades_DeberiaAceptarLista()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            var lista = InventarioSucursalesMocks.CrearMockListaParaActualizarCantidades();
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(lista),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            // fecha de modificacion: ahora
            var fecha = DateTime.Now.ToString("o"); // ISO 8601

            var response = await cliente.PutAsync($"/InventarioSucursales/ActualizarCantidades/5/{fecha}", contenido);

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(content));
            Console.WriteLine(content);
        }
    }
}
