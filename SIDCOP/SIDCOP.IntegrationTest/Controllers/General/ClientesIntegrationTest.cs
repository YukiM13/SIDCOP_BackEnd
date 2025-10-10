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
    }
}
