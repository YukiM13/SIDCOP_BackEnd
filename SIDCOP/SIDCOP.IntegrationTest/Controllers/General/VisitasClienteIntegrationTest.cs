using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Management.Smo.Wmi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SIDCOP.IntegrationTest.Mocks.General;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.DataAccess.Context;
using SIDCOP_Backend.DataAccess.Repositories.General;
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

        private readonly BDD_SIDCOPContext _context;
        private readonly GeneralServices _service;
        private readonly ClientesVisitaHistorialRepository _repository;

        #region Listar Por Vendedor
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
        #endregion


        #region Insertar
        [TestMethod]
        public async Task InsertarVisita()
        {
            // Arrange
            var visita = VisitasClienteMocks.InsertarVisitaMock();
            var json = JsonConvert.SerializeObject(visita);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // ⚙️ Agregar ApiKey
            client.DefaultRequestHeaders.Add("X-API-Key", ApiKey);

            // Act
            var response = await client.PostAsync("/ClientesVisitaHistorial/Insertar", content);

            // Assert
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                Assert.Fail("❌ La API rechazó la ApiKey. Verifica que coincida con la configurada en el servidor.");

            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(responseBody.Contains("éxito")
                       || responseBody.Contains("success")
                       || responseBody.Contains("insertado"),
                       $"El resultado no indica éxito: {responseBody}");
        }
        #endregion

    }

}
