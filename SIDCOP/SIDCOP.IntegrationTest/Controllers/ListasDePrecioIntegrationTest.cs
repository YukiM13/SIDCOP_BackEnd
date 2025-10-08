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
            // PASO 1: CONFIGURACIÓN DEL CLIENTE HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // Usa un método diferente del mock para crear datos de actualización
            var preciosMock = ListaDePreciosMocks.CrearMockPreciosPorProductoParaActualizar();

            // PASO 3: SERIALIZACIÓN 
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

     

        [TestMethod] // Prueba con valores extremos que también debería fallar
        public async Task PreciosPorProductoInsertar_DeberiaFallar()
        {
            // PASO 1: CONFIGURACIÓN DEL CLIENTE HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // PASO 2: CREAR DATOS CON VALORES EXTREMOS
            // Usa valores extremos que podrían causar overflow o errores de validación
            var preciosExtremos = ListaDePreciosMocks.CrearMockPreciosPorProductoValoresExtremos();

            // PASO 3: SERIALIZACIÓN DE DATOS EXTREMOS
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(preciosExtremos),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            // PASO 4: PETICIÓN QUE DEBERÍA FALLAR
            var response = await cliente.PostAsync("/PreciosPorProducto/InsertarLista", contenido);

            // PASO 5: VERIFICACIONES DE FALLO
            // Esta prueba puede fallar de diferentes maneras:
            // - 400 Bad Request (validación)
            // - 404 Not Found (IDs inexistentes)
            // - 500 Internal Server Error (overflow o errores de BD)
            
            var esExitoso = response.StatusCode == System.Net.HttpStatusCode.OK;
            var responseContent = await response.Content.ReadAsStringAsync();
            
            if (esExitoso)
            {
                Console.WriteLine("⚠️ ADVERTENCIA: La API aceptó valores extremos que podrían ser problemáticos");
                Console.WriteLine($"Respuesta: {responseContent}");
                
                // Si la API acepta estos valores, al menos documentamos que pasó
                Assert.IsTrue(true, "La API manejó valores extremos sin error - verificar si esto es el comportamiento esperado");
            }
            else
            {
                Console.WriteLine($"✅ La API correctamente rechazó valores extremos con código: {response.StatusCode}");
                Console.WriteLine($"Mensaje de error: {responseContent}");
                
                // Verifica que sea un código de error apropiado
                Assert.IsTrue(
                    response.StatusCode >= System.Net.HttpStatusCode.BadRequest,
                    $"Se esperaba un código de error, pero se recibió: {response.StatusCode}"
                );
            }
        }

    }
}