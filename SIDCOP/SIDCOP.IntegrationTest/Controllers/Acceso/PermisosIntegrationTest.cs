using SIDCOP.IntegrationTest.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Controllers
{
    [TestClass]
    public class PermisosIntegrationTest : BaseIntegrationTest
    {
        private const string ApiKey = "bdccf3f3-d486-4e1e-ab44-74081aefcdbc";

        [TestMethod]
        public async Task Permisos_Listar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var response = await cliente.GetAsync("/Listar");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task Permisos_Insertar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var mockPermiso = PermisosMocks.CrearMockPermisoInsertar();
            var jsonContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(mockPermiso), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("/Insertar", jsonContent);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task Permisos_Actualizar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var mockPermiso = PermisosMocks.CrearMockPermisoActualizar();
            var jsonContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(mockPermiso), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync("/Actualizar", jsonContent);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task Permisos_Eliminar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var mockPermiso = PermisosMocks.CrearMockPermisoEliminar();
            var jsonContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(mockPermiso), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("/Eliminar", jsonContent);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task Permisos_Buscar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var mockPermiso = PermisosMocks.CrearMockPermisoBuscar();
            var jsonContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(mockPermiso), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("/Buscar", jsonContent);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }
    }
}
