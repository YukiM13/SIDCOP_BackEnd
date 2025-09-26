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
    [TestClass] // Contenedora de métodos de prueba
    public class ListasDePrecioIntegrationTest : BaseIntegrationTest
    {
        // Almacena la clave API para autenticación
        private const string ApiKey = "bdccf3f3-d486-4e1e-ab44-74081aefcdbc";

        [TestMethod] // Atributo que marca este método como una prueba 
        public async Task PreciosPorProductoInsertar()
        {
            // PASO 1: CONFIGURACIÓN DEL CLIENTE HTTP
            // Crea un cliente HTTP usando la factory heredada de BaseIntegrationTest
            // Esta factory probablemente configura un servidor de pruebas en memoria
            var cliente = factory.CreateClient();

            // Añade la clave API al header de todas las peticiones de este cliente
            // Esto simula la autenticación requerida por la API
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // Crea datos mock (simulados) usando una clase helper
            // Estos datos representan una lista de precios que se va a insertar
            var preciosMock = ListaDePreciosMocks.CrearMockPreciosPorProducto();

            // PASO 3: SERIALIZACIÓN DE DATOS
            // Convierte el objeto mock a JSON para enviarlo en la petición HTTP
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(preciosMock), 
                System.Text.Encoding.UTF8,                             
                "application/json"                                      
            );

            // Hace una petición POST al endpoint para insertar la lista de precios
            var response = await cliente.PostAsync("/PreciosPorProducto/InsertarLista", contenido);

            // Verifica que la respuesta tenga código HTTP 200 (OK)
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            // Verifica que la respuesta no sea nula
            Assert.IsNotNull(response);

            // Lee el contenido de la respuesta como string
            var responseContent = await response.Content.ReadAsStringAsync();

            // Verifica que la respuesta no esté vacía
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));

            // Muestra la respuesta en consola para debugging/verificación manual
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod] // Segunda prueba para operación de actualización
        public async Task PreciosPorProductoActualizar()
        {
            // PASO 1: CONFIGURACIÓN DEL CLIENTE HTTP (igual que arriba)
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // Usa un método diferente del mock para crear datos de actualización
            var preciosMock = ListaDePreciosMocks.CrearMockPreciosPorProductoParaActualizar();

            // PASO 3: SERIALIZACIÓN (igual que arriba)
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(preciosMock),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            //  PETICIÓN A ENDPOINT DE ACTUALIZACIÓN
            var response = await cliente.PostAsync("/PreciosPorProducto/ActualizarLista", contenido);

            // VERIFICACIONES 
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }
    }
}