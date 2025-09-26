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
    public class BaseIntegrationTest : IDisposable
    {
        protected readonly WebApplicationFactory<Program> factory;
        protected readonly HttpClient client;

        public BaseIntegrationTest()
        {
            factory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.UseEnvironment("Testing");
                    // Configurar para usar configuración de pruebas si es necesario
                    builder.ConfigureAppConfiguration((context, config) =>
                    {
                        // Aquí puedes agregar configuración específica para pruebas
                    });
                });

            client = factory.CreateClient();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                client?.Dispose();
                factory?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
