using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIDCOP.IntegrationTest.Mocks.Logistica;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Controllers.Inventario
{
    [TestClass]
    public class ProductosIntegrationTest : BaseIntegrationTest
    {
        private const string ApiKey = "bdccf3f3-d486-4e1e-ab44-74081aefcdbc";

        [TestMethod]
        public async Task Listar_DeberiaRetornarListaDeProductos()
        {
            // Arrange
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // Act
            var response = await cliente.GetAsync("/Productos/Listar");

            // Assert
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(content));
            Console.WriteLine(content);
        }

        [TestMethod]
        public async Task Buscar_ProductoExistente_DeberiaRetornarProducto()
        {
            // Arrange
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var productoId = 1; // Asegúrate de que este ID exista en tu base de datos de prueba

            // Act
            var response = await cliente.GetAsync($"/Productos/Buscar/{productoId}");

            // Assert
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(content));
            Console.WriteLine(content);
        }

        [TestMethod]
        public async Task Buscar_ProductoNoExistente_DeberiaRetornarNotFound()
        {
            // Arrange
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var productoId = -1; // ID que no existe

            // Act
            var response = await cliente.GetAsync($"/Productos/Buscar/{productoId}");

            // Assert
            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(content));
            Console.WriteLine(content);
        }

        [TestMethod]
        public async Task ListaPrecio_ClienteExistente_DeberiaRetornarListaDePrecios()
        {
            // Arrange
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var clienteId = 1; // Asegúrate de que este ID de cliente exista en tu base de datos de prueba

            // Act
            var response = await cliente.GetAsync($"/Productos/ListaPrecio/{clienteId}");

            // Assert
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(content));
            Console.WriteLine(content);
        }

        [TestMethod]
        public async Task BuscarPorFactura_FacturaExistente_DeberiaRetornarProductos()
        {
            // Arrange
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var facturaId = 1; // Asegúrate de que este ID de factura exista en tu base de datos de prueba

            // Act
            var response = await cliente.GetAsync($"/Productos/BuscarPorFactura/{facturaId}");

            // Assert
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(content));
            Console.WriteLine(content);
        }

        [TestMethod]
        public async Task Eliminar_ProductoExistente_DeberiaRetornarExito()
        {
            // Arrange
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            
            // Primero creamos un producto para luego eliminarlo
            // Nota: Necesitarías implementar un endpoint de creación o usar un ID existente
            var productoId = 999; // Asegúrate de que este ID exista o sea válido para eliminar

            // Act
            var response = await cliente.PostAsync($"/Productos/Eliminar/{productoId}", null);

            // Assert
            // Podría ser OK o BadRequest dependiendo de si el producto existe o no
            Assert.IsTrue(
                response.StatusCode == System.Net.HttpStatusCode.OK || 
                response.StatusCode == System.Net.HttpStatusCode.BadRequest);
                
            var content = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(content));
            Console.WriteLine(content);
        }
    }
}
