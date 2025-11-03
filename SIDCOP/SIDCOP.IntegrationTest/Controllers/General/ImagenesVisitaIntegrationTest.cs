using Newtonsoft.Json;
using SIDCOP.IntegrationTest.Mocks.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Controllers.General
{
    [TestClass]
    public class ImagenesVisitaIntegrationTest : BaseIntegrationTest
    {
        // Almacena la clave API para autenticación
        private const string ApiKey = "bdccf3f3-d486-4e1e-ab44-74081aefcdbc";


        [TestMethod]
        public async Task ImagenesPorVisita()
        {
            // ARRANGE
            // ARRANGE
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            int id = ImagenesVisitaMocks.ImagenId;
            string url = $"ImagenVisita/ListarPorVisita/{id}";

            // ACT
            var response = await cliente.PostAsync(url, new StringContent("", Encoding.UTF8, "application/json"));

            // ASSERT
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine($"Respuesta: {responseContent}");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Assert.IsTrue(responseContent.Contains("["), "Debería retornar un array JSON");
        }

        [TestMethod]
        public async Task InsertarImagenVisita()
        {
            // Arrange
            var visita = ImagenesVisitaMocks.InsertarImagenVisitaMock();
            var json = JsonConvert.SerializeObject(visita);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // ⚙️ Agregar ApiKey
            client.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // Act
            var response = await client.PostAsync("/ImagenVisita/Insertar", content);

            // Assert
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                Assert.Fail("❌ La API rechazó la ApiKey. Verifica que coincida con la configurada en el servidor.");

            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(responseBody.Contains("éxito")
                       || responseBody.Contains("success")
                       || responseBody.Contains("insertado"),
                       $"El resultado no indica éxito: {responseBody}");
        }
    }
}
