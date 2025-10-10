using SIDCOP.IntegrationTest.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Controllers
{
    [TestClass]
    public class CuentasPorCobrarIntegrationTest : BaseIntegrationTest
    {
        private const string ApiKey = "bdccf3f3-d486-4e1e-ab44-74081aefcdbc";

        [TestMethod]
        public async Task CuentasPorCobrar_Listar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var response = await cliente.GetAsync("/CuentasPorCobrar/Listar");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task CuentasPorCobrar_ListarConFiltro()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // Usa el mock para obtener el cliente ID
            var mockCuentaPorCobrar = CuentasPorCobrarMocks.CrearMockCuentaPorCobrarListarConFiltro();
            int? clienteId = mockCuentaPorCobrar.Clie_Id; // Obtén el ID del cliente del mock
            bool soloActivas = true;
            bool soloVencidas = false;

            // Construye la URL con los parámetros de consulta
            var url = $"/CuentasPorCobrar/ListarConFiltro?clienteId={clienteId}&soloActivas={soloActivas}&soloVencidas={soloVencidas}";

            // Realiza la solicitud GET
            var response = await cliente.GetAsync(url);

            // Verifica la respuesta
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            // Lee y valida el contenido de la respuesta
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task CuentasPorCobrar_Detalle()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var mockCuentaPorCobrar = CuentasPorCobrarMocks.CrearMockCuentaPorCobrarDetalle();
            var response = await cliente.GetAsync($"/CuentasPorCobrar/Detalle/{mockCuentaPorCobrar.CPCo_Id}");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task CuentasPorCobrar_ResumenAntiguedad()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var response = await cliente.GetAsync("/CuentasPorCobrar/ResumenAntiguedad");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task CuentasPorCobrar_ResumenCliente()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var response = await cliente.GetAsync("/CuentasPorCobrar/ResumenCliente");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task CuentasPorCobrar_timeLineCliente()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var mockCuentaPorCobrar = CuentasPorCobrarMocks.CrearMockCuentaPorCobrartimeLine();
            var response = await cliente.GetAsync($"/CuentasPorCobrar/timeLineCliente/{mockCuentaPorCobrar.Clie_Id}");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }
    }
}
