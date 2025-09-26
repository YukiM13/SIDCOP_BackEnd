using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIDCOP.IntegrationTest.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Controllers
{
    [TestClass]
    public class ListasDePrecioIntegrationTest : BaseIntegrationTest
    {
        // ApiKey - usando la misma que está configurada en appsettings.json
        private const string ApiKey = "bdccf3f3-d486-4e1e-ab44-74081aefcdbc";

        [TestMethod]
        public async Task PreciosPorProductoInsertar()
        {
            // Creamos el cliente
            var cliente = factory.CreateClient();

            // Añadimos la apikey al header
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // Creamos el mock de datos
            var preciosMock = ListaDePreciosMocks.CrearMockPreciosPorProducto();

            // Serializa el objeto a JSON para enviarlo en el cuerpo de la petición
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(preciosMock), 
                System.Text.Encoding.UTF8, 
                "application/json"
            );

            // Aquí hace la petición a la URL tipo Post
            var response = await cliente.PostAsync("/PreciosPorProducto/InsertarLista", contenido);
            
            // Aserciones
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            // Lee el contenido de la respuesta 
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));

            // Opcional: Verificar que la respuesta contiene información de éxito
            // Puedes deserializar la respuesta si conoces el formato del RequestStatus
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod]
        public async Task PreciosPorProductoActualizar()
        {
            // Creamos el cliente
            var cliente = factory.CreateClient();

            // Añadimos la apikey al header
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // Creamos el mock de datos para actualizar
            var preciosMock = ListaDePreciosMocks.CrearMockPreciosPorProductoParaActualizar();

            // Serializa el objeto a JSON para enviarlo en el cuerpo de la petición
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(preciosMock), 
                System.Text.Encoding.UTF8, 
                "application/json"
            );

            // Aquí hace la petición a la URL tipo Post para actualizar
            var response = await cliente.PostAsync("/PreciosPorProducto/ActualizarLista", contenido);
            
            // Aserciones
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            // Lee el contenido de la respuesta 
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));

            // Opcional: Verificar que la respuesta contiene información de éxito
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }


    }
}
