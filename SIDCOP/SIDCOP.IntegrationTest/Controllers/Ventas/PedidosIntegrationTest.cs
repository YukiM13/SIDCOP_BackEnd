using SIDCOP.IntegrationTest.Mocks.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Controllers.Ventas
{
    [TestClass]
    public class PedidosIntegrationTest : BaseIntegrationTest
    {

        private const string ApiKey = "bdccf3f3-d486-4e1e-ab44-74081aefcdbc";

        [TestMethod]
        public async Task PedidosListar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
     

            var response = await cliente.GetAsync("/Pedido/Listar");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }


        [TestMethod]
        public async Task PedidosInsertar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var pedidoMock = PedidosMocks.CrearPedidoMock();
            var contenido = new StringContent(
                 System.Text.Json.JsonSerializer.Serialize(pedidoMock),
                 System.Text.Encoding.UTF8,
                 "application/json"
             );

            var response = await cliente.PostAsync("/Pedido/Insertar", contenido);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task PedidosActualizar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            var pedidoMock = PedidosMocks.ActualizarPedidoMock();

            var contenido = new StringContent(
                 System.Text.Json.JsonSerializer.Serialize(pedidoMock),
                 System.Text.Encoding.UTF8,
                 "application/json"
             );

            var response = await cliente.PutAsync("/Pedido/Actualizar", contenido);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task PedidosEliminar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            var pedidoMock = PedidosMocks.EliminarPedido();

            var response = await cliente.PostAsync($"Pedido/Eliminar/{pedidoMock}", null);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }


        [TestMethod]
        public async Task PedidosInsertarDeberiaFallar()
        {
           var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var pedidoMock = PedidosMocks.CrearPedidosMockValoresInvalidos();
            var contenido = new StringContent(
                 System.Text.Json.JsonSerializer.Serialize(pedidoMock),
                 System.Text.Encoding.UTF8,
                 "application/json"
             );
            var response = await cliente.PostAsync("/Pedido/Insertar", contenido);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
           

            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }


        [TestMethod]
        public async Task PedidosEditarDeberiaFallar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var pedidoMock = PedidosMocks.ActualizarPedidoMockValoresInvalidos();

            var contenido = new StringContent(
                 System.Text.Json.JsonSerializer.Serialize(pedidoMock),
                 System.Text.Encoding.UTF8,
                 "application/json"
             );
            var response = await cliente.PutAsync("/Pedido/Actualizar", contenido);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();


            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }


        [TestMethod]
        public async Task PedidosEliminarDeberiaFallar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            var pedidoMock = PedidosMocks.EliminarPedidoValoresInvalidos; // ID que no existe

            var response = await cliente.PostAsync($"Pedido/Eliminar/{pedidoMock}", null);
            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }



    }
}
