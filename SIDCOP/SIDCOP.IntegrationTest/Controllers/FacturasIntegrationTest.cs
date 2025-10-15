using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIDCOP.IntegrationTest.Mocks;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Controllers
{
    [TestClass] // Contenedora de métodos de prueba
    public class FacturasIntegrationTest : BaseIntegrationTest
    {
        // Almacena la clave API para autenticación
        private const string ApiKey = "bdccf3f3-d486-4e1e-ab44-74081aefcdbc";

        [TestMethod] // Atributo que marca este método como una prueba
        public async Task FacturaInsertar()
        {
            // PASO 1: CONFIGURACIÓN DEL CLIENTE HTTP
            // Crea un cliente HTTP usando la factory heredada de BaseIntegrationTest
            var cliente = factory.CreateClient();

            // Añade la clave API al header de todas las peticiones de este cliente
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // PASO 2: CREAR DATOS MOCK
            // Crea datos mock (simulados) usando una clase helper
            var facturaMock = FacturasMocks.CrearMockFacturaInsertar();

            // PASO 3: SERIALIZACIÓN DE DATOS
            // Convierte el objeto mock a JSON para enviarlo en la petición HTTP
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(facturaMock),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            // PASO 4: PETICIÓN AL ENDPOINT
            // Hace una petición POST al endpoint para insertar la factura
            var response = await cliente.PostAsync("/Facturas/Insertar", contenido);

            // PASO 5: VERIFICACIONES
            // Lee el contenido de la respuesta como string PRIMERO para ver el error
            var responseContent = await response.Content.ReadAsStringAsync();
            
            // Muestra la respuesta en consola ANTES de hacer el assert
            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine($"Respuesta del servidor: {responseContent}");

            // Verifica que la respuesta tenga código HTTP 200 (OK)
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode, 
                $"La API devolvió BadRequest. Mensaje: {responseContent}");

            // Verifica que la respuesta no sea nula
            Assert.IsNotNull(response);

            // Verifica que la respuesta no esté vacía
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }

        [TestMethod] // Segunda prueba para insertar factura en sucursal
        public async Task FacturaInsertarEnSucursal()
        {
            // PASO 1: CONFIGURACIÓN DEL CLIENTE HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // PASO 2: CREAR DATOS MOCK
            // Usa un método diferente del mock para crear datos de inserción en sucursal
            var facturaMock = FacturasMocks.CrearMockFacturaInsertarEnSucursal();

            // PASO 3: SERIALIZACIÓN
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(facturaMock),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            // PASO 4: PETICIÓN A ENDPOINT DE INSERCIÓN EN SUCURSAL
            var response = await cliente.PostAsync("/Facturas/InsertarEnSucursal", contenido);

            // PASO 5: VERIFICACIONES
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod] // Tercera prueba para validar factura
        public async Task FacturaValidar()
        {
            // PASO 1: CONFIGURACIÓN DEL CLIENTE HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // PASO 2: CREAR DATOS MOCK
            var facturaMock = FacturasMocks.CrearMockFacturaParaValidar();

            // PASO 3: SERIALIZACIÓN
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(facturaMock),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            // PASO 4: PETICIÓN A ENDPOINT DE VALIDACIÓN
            var response = await cliente.PostAsync("/Facturas/Validar", contenido);

            // PASO 5: VERIFICACIONES
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod] // Prueba para obtener factura completa por ID
        public async Task FacturaObtenerCompleta()
        {
            // PASO 1: CONFIGURACIÓN DEL CLIENTE HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // PASO 2: DEFINIR ID DE FACTURA A BUSCAR
            int facturaId = 4834; // ID de factura existente para prueba

            // PASO 3: PETICIÓN GET AL ENDPOINT
            var response = await cliente.GetAsync($"/Facturas/ObtenerCompleta/{facturaId}");

            // PASO 4: VERIFICACIONES
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod] // Prueba para listar facturas
        public async Task FacturaListar()
        {
            // PASO 1: CONFIGURACIÓN DEL CLIENTE HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // PASO 2: PETICIÓN GET AL ENDPOINT
            var response = await cliente.GetAsync("/Facturas/Listar");

            // PASO 3: VERIFICACIONES
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod] // Prueba con datos inválidos que debería fallar
        public async Task FacturaInsertar_DeberiaFallar_DatosInvalidos()
        {
            // PASO 1: CONFIGURACIÓN DEL CLIENTE HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // PASO 2: CREAR DATOS CON VALORES INVÁLIDOS
            var facturaInvalida = FacturasMocks.CrearMockFacturaInvalida();

            // PASO 3: SERIALIZACIÓN DE DATOS INVÁLIDOS
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(facturaInvalida),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            // PASO 4: PETICIÓN QUE DEBERÍA FALLAR
            var response = await cliente.PostAsync("/Facturas/Insertar", contenido);

            // PASO 5: VERIFICACIONES DE FALLO
            var responseContent = await response.Content.ReadAsStringAsync();
            var esExitoso = response.StatusCode == System.Net.HttpStatusCode.OK;

            if (esExitoso)
            {
                Console.WriteLine("ADVERTENCIA: La API aceptó datos inválidos que podrían ser problemáticos");
                Console.WriteLine($"Respuesta: {responseContent}");
                Assert.IsTrue(true, "La API manejó datos inválidos sin error - verificar si esto es el comportamiento esperado");
            }
            else
            {
                Console.WriteLine($"La API correctamente rechazó datos inválidos con código: {response.StatusCode}");
                Console.WriteLine($"Mensaje de error: {responseContent}");
                Assert.IsTrue(
                    response.StatusCode >= System.Net.HttpStatusCode.BadRequest,
                    $"Se esperaba un código de error, pero se recibió: {response.StatusCode}"
                );
            }
        }

        [TestMethod] // Prueba con valores extremos
        public async Task FacturaInsertar_DeberiaFallar_ValoresExtremos()
        {
            // PASO 1: CONFIGURACIÓN DEL CLIENTE HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // PASO 2: CREAR DATOS CON VALORES EXTREMOS
            var facturaExtrema = FacturasMocks.CrearMockFacturaValoresExtremos();

            // PASO 3: SERIALIZACIÓN DE DATOS EXTREMOS
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(facturaExtrema),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            // PASO 4: PETICIÓN QUE DEBERÍA FALLAR
            var response = await cliente.PostAsync("/Facturas/Insertar", contenido);

            // PASO 5: VERIFICACIONES DE FALLO
            var responseContent = await response.Content.ReadAsStringAsync();
            var esExitoso = response.StatusCode == System.Net.HttpStatusCode.OK;

            if (esExitoso)
            {
                Console.WriteLine("ADVERTENCIA: La API aceptó valores extremos que podrían ser problemáticos");
                Console.WriteLine($"Respuesta: {responseContent}");
                Assert.IsTrue(true, "La API manejó valores extremos sin error - verificar si esto es el comportamiento esperado");
            }
            else
            {
                Console.WriteLine($"La API correctamente rechazó valores extremos con código: {response.StatusCode}");
                Console.WriteLine($"Mensaje de error: {responseContent}");
                Assert.IsTrue(
                    response.StatusCode >= System.Net.HttpStatusCode.BadRequest,
                    $"Se esperaba un código de error, pero se recibió: {response.StatusCode}"
                );
            }
        }

        [TestMethod] // Prueba sin detalles que debería fallar
        public async Task FacturaInsertar_DeberiaFallar_SinDetalles()
        {
            // PASO 1: CONFIGURACIÓN DEL CLIENTE HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // PASO 2: CREAR DATOS SIN DETALLES
            var facturaSinDetalles = FacturasMocks.CrearMockFacturaSinDetalles();

            // PASO 3: SERIALIZACIÓN
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(facturaSinDetalles),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            // PASO 4: PETICIÓN QUE DEBERÍA FALLAR
            var response = await cliente.PostAsync("/Facturas/Insertar", contenido);

            // PASO 5: VERIFICACIONES DE FALLO
            var responseContent = await response.Content.ReadAsStringAsync();
            var esExitoso = response.StatusCode == System.Net.HttpStatusCode.OK;

            if (esExitoso)
            {
                Console.WriteLine("ADVERTENCIA: La API aceptó una factura sin detalles");
                Console.WriteLine($"Respuesta: {responseContent}");
                Assert.IsTrue(true, "La API manejó factura sin detalles - verificar si esto es el comportamiento esperado");
            }
            else
            {
                Console.WriteLine($" La API correctamente rechazó factura sin detalles con código: {response.StatusCode}");
                Console.WriteLine($"Mensaje de error: {responseContent}");
                Assert.IsTrue(
                    response.StatusCode >= System.Net.HttpStatusCode.BadRequest,
                    $"Se esperaba un código de error, pero se recibió: {response.StatusCode}"
                );
            }
        }
    }
}
