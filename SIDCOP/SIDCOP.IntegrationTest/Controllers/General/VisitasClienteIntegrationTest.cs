using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIDCOP.IntegrationTest.Mocks.General;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Controllers.General
{
    [TestClass]
    public class VisitasClienteIntegrationTest : BaseIntegrationTest 
    {
        // Almacena la clave API para autenticación
        private const string ApiKey = "bdccf3f3-d486-4e1e-ab44-74081aefcdbc";

        [TestMethod]
        public async Task VisitasPorVendedor()
        {
            // ARRANGE
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            int vendedorId = VisitasClienteMocks.VendId; // Usar constante del mock

            string url = $"ClientesVisitaHistorial/ListarVisitasPorVendedor?vend_Id={vendedorId}";

            // ACT
            var response = await cliente.GetAsync(url);

            // ASSERT
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine($"Respuesta: {responseContent}");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));

            // Opcional: Verificar que retorna un array
            Assert.IsTrue(responseContent.Contains("["), "Debería retornar un array JSON");
        }

        //[TestMethod]
        //public async Task InsertVisita()
        //{
        //    var cliente = factory.CreateClient();
        //    cliente.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

        //    // ✅ Ahora crear la visita con el ID válido
        //    var visitaMock = VisitasClienteMocks.ObtenerVisitaValida();
        //    // Usar el ID que acabamos de crear o uno que sabemos que existe
        //    visitaMock.VeRu_Id = 20; // ID válido

        //    var contenido = new StringContent(
        //        System.Text.Json.JsonSerializer.Serialize(visitaMock),
        //        System.Text.Encoding.UTF8,
        //        "application/json"
        //    );

        //    var response = await cliente.PostAsync("/VisitasClienteHistorial/Insertar", contenido);
        //    var responseContent = await response.Content.ReadAsStringAsync();

        //    Console.WriteLine($"Respuesta: {responseContent}");

        //    var apiResponse = System.Text.Json.JsonSerializer.Deserialize<ApiResponse<VisitaResponseData>>(
        //        responseContent,
        //        new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        //    );

        //    Assert.IsNotNull(apiResponse);
        //    Assert.IsTrue(apiResponse.success);
        //    Assert.AreEqual(0, apiResponse.data.code_Status,
        //        $"Error en BD: {apiResponse.data.message_Status}");
        //}
    }

    // Clases para deserializar la respuesta
    public class ApiResponse<T>
    {
        public int code { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }

    public class VisitaResponseData
    {
        public int code_Status { get; set; }
        public string message_Status { get; set; }
        public object data { get; set; }
        public string tras_Id { get; set; }
    }

}
