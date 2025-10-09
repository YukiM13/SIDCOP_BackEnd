using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest
{
    /// Proporciona la infraestructura común necesaria para crear un servidor de prueba completo
      public class BaseIntegrationTest : IDisposable
    {
        /// Factory que crea una instancia completa de la aplicación web en memoria
        ///- simula un servidor real
        protected readonly WebApplicationFactory<Program> factory;
        /// Cliente HTTP pre-configurado para hacer peticiones al servidor de prueba
        /// Actúa como un navegador o cliente API que consume los endpoints
        protected readonly HttpClient client;
        /// Constructor que inicializa el entorno completo de pruebas de integración
        /// Se ejecuta una vez por cada clase de prueba que herede de esta base
        public BaseIntegrationTest()
        {
            // Crea una factory completa de la aplicación web usando el Program principal
            // Program es el punto de entrada de la aplicación ASP.NET Core
            factory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {

                    // Establece el entorno como "Testing"
                    // Esto permite configuraciones específicas para pruebas (appsettings.Testing.json)
                    builder.UseEnvironment("Testing");

                    // Configura la configuración de la aplicación para testing
                    builder.ConfigureAppConfiguration((context, config) =>
                    {
                        // AQUÍ SE PUEDE PERSONALIZAR LA CONFIGURACIÓN PARA PRUEBAS:

                        // Actualmente vacío - usa la configuración por defecto de la aplicación
                    });

                });

            // Crea un cliente HTTP conectado al servidor de prueba creado por la factory
            // Este cliente puede hacer peticiones reales a todos los endpoints de tu API
            client = factory.CreateClient();

            // El cliente está configurado para:
            // - Hacer peticiones HTTP reales (GET, POST, PUT, DELETE, etc.)
            // - Manejar cookies y headers automáticamente
            // - Seguir redirects si es necesario
            // - Usar la misma configuración que un cliente real
        }

        /// Implementación del patrón Dispose para liberar recursos correctamente
        /// Método virtual que permite a las clases heredadas personalizar la limpieza
        /// <param name="disposing">True si se está liberando explícitamente, false si es desde el finalizer</param>
        protected virtual void Dispose(bool disposing)
        {

            if (disposing)
            {
                // Libera el cliente HTTP para evitar memory leaks
                // Cierra conexiones TCP abiertas
                client?.Dispose();

                // Libera la factory y toda la aplicación web en memoria
                // Esto incluye: DbContext, servicios registrados, middleware, etc.
                factory?.Dispose();

                // - Cada prueba crea una instancia completa de la aplicación
                // - Sin dispose(), se acumularían en memoria
                // - Podrían causar interferencias entre pruebas
            }
        }

        public void Dispose()
        {
            // Llama al método de dispose virtual
            Dispose(true);

            // Le dice al Garbage Collector que no necesita llamar al finalizer
            // Optimización de performance
            GC.SuppressFinalize(this);
        }


    }
}

