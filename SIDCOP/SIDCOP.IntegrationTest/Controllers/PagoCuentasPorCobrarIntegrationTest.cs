using Org.BouncyCastle.Asn1;
using SIDCOP.IntegrationTest.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Controllers
{
    [TestClass]
    public class PagoCuentasPorCobrarIntegrationTest : BaseIntegrationTest
    {
        private const string ApiKey = "bdccf3f3-d486-4e1e-ab44-74081aefcdbc";

        [TestMethod]
        public async Task PagosCuentasPorCobrar_Insertar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            var pagoMock = PagoCuentaPorCobrarMocks.CrearMockPagoCuentaPorCobrarInsertar();

            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(pagoMock),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            var response = await cliente.PostAsync("/PagosCuentasPorCobrar/Insertar", contenido);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task PagosCuentasPorCobrar_ListarPorCuentaPorCobrar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var pagoMock = PagoCuentaPorCobrarMocks.CrearMockPagoCuentaPorCobrarListarCuentaPorCobrar();
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(pagoMock),
                System.Text.Encoding.UTF8,
                "application/json"
            );
            var response = await cliente.GetAsync($"/PagosCuentasPorCobrar/ListarPorCuentaPorCobrar/{pagoMock.CPCo_Id}");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task PagosCuentasPorCobrar_Anular()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            var pagoMock = PagoCuentaPorCobrarMocks.CrearMockPagoCuentaPorCobrarAnular();

            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(pagoMock),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            var response = await cliente.PostAsync("/PagosCuentasPorCobrar/Anular", contenido);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }
    }
}
