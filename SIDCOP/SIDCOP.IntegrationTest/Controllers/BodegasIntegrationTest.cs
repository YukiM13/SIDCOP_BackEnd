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
    public class BodegasIntegrationTest : BaseIntegrationTest
    {
        // Almacena la clave API para autenticación
        private const string ApiKey = "bdccf3f3-d486-4e1e-ab44-74081aefcdbc";

        [TestMethod] // Atributo que marca este método como una prueba 
        public async Task BodegaInsertar()
        {
            // PASO 1: CONFIGURACIÓN DEL CLIENTE HTTP
            // Crea un cliente HTTP usando la factory heredada de BaseIntegrationTest
            // Esta factory configura un servidor de pruebas en memoria
            var cliente = factory.CreateClient();

            // Añadimos la clave API al header de todas las peticiones de este cliente
            // Esto simula la autenticación requerida por la API
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // PASO 2: CREAR DATOS MOCKS (SIMULADOS)
            // Estos datos representan una bodega que se va a insertar
            var bodegaMock = BodegasMocks.MockBodegaInsertar();

            // PASO 3: SERIALIZACIÓN DE DATOS
            // Convierte el objeto mock a JSON para enviarlo en la petición HTTP
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(bodegaMock),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            // Hace una petición POST al endpoint para insertar la bodega
            var response = await cliente.PostAsync("/Bodega/Insertar", contenido);

            // PASO 4: VERIFICACIONES
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
        public async Task BodegaActualizar()
        {
            // PASO 1: CONFIGURACIÓN DEL CLIENTE HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // PASO 2: CREAR DATOS MOCKS (SIMULADOS)
            // Usa un método diferente del mock para crear datos de la actualización
            var bodegaMock = BodegasMocks.MockBodegaActualizar();

            // PASO 3: SERIALIZACIÓN DE DATOS
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(bodegaMock),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            //  PETICIÓN A ENDPOINT DE ACTUALIZACIÓN
            var response = await cliente.PutAsync("/Bodega/Actualizar", contenido);
            
            // PASO 4: VERIFICACIONES
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod] // Tercera prueba para operación de listar
        public async Task BodegasListar()
        {
            // PASO 1: CONFIGURACIÓN DEL CLIENTE HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // PASO 2: PETICIÓN A ENDPOINT DE LISTAR
            var response = await cliente.GetAsync("/Bodega/Listar");

            // PASO 3: VERIFICACIONES
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }

        [TestMethod] // Cuarta prueba para operación de actualización
        public async Task BodegaEliminar()
        {
            // PASO 1: CONFIGURACIÓN DEL CLIENTE HTTP
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // PASO 2: CREAR DATOS MOCKS (SIMULADOS)
            // Usa un método diferente del mock para crear el id a eliminar
            var bodegaMock = BodegasMocks.MockBodegaEliminar();

            // PASO 3: SERIALIZACIÓN DE DATOS
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(bodegaMock),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            //  PETICIÓN A ENDPOINT DE ACTUALIZACIÓN
            var response = await cliente.PostAsync("/Bodega/Eliminar/{id}", contenido);

            // PASO 4: VERIFICACIONES
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
            Console.WriteLine($"Respuesta del servidor: {responseContent}");
        }
    }
}
