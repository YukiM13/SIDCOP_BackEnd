using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using SIDCOP_Backend.BusinessLogic;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.DataAccess.Context;
using SIDCOP_Backend.DataAccess.Repositories.Acceso;
using SIDCOP_Backend.DataAccess.Repositories.General;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIDCOP.UnitTest.General
{
    public class ClienteVisitasHistorialUnitTest
    {
        private readonly BDD_SIDCOPContext _bddContext;
        private readonly Mock<ClientesVisitaHistorialRepository> _repository;
        private readonly GeneralServices _service;

        public ClienteVisitasHistorialUnitTest()
        {
            // Configurar un DbContext en memoria para las pruebas
            var options = new DbContextOptionsBuilder<BDD_SIDCOPContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_" + Guid.NewGuid())
                .Options;

            _bddContext = new BDD_SIDCOPContext(options);
            _repository = new Mock<ClientesVisitaHistorialRepository>(_bddContext);

            // Crear el servicio con el contexto en memoria
            _service = new GeneralServices(
                _bddContext,  // Pasar el contexto en memoria aquí
                null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null,
                null, null, _repository, null, null, null
            );

        }

        #region Listar Visitas de Clientes Por Vendedor
        [Fact]
        public void ClientesVisitasPorVendedor()
        {
            // 1️⃣ Arrange - Preparar los datos de prueba en la base de datos en memoria
            int VendId = 5;
            int VeRuId = 10;
            int RutaId = 1;
            int ClieId = 100;
            int DiClId = 200;
            int EsViId = 2;

            // Crear y agregar el vendedor
            var vendedor = new tbVendedores
            {
                Vend_Id = VendId,
                Vend_Codigo = "V001",
                Vend_Nombres = "Juan",
                Vend_Apellidos = "Pérez",
                Vend_Sexo = "M",
                Vend_DNI = "0801199012345",
                Vend_Correo = "juan.perez@email.com",
                Vend_DireccionExacta = "Col. Mangandi, al final del muro del Perla, Tortillería la Hondureñita derecha, 3 cuadras exactas",
                Vend_Tipo = "A",
                Vend_Telefono = "99887766",
                Vend_Estado = true,
                Usua_Creacion = 1,
                Vend_FechaCreacion = DateTime.Now
            };
            _bddContext.tbVendedores.Add(vendedor);

            // Crear y agregar la ruta
            var ruta = new tbRutas
            {
                Ruta_Id = RutaId,
                Ruta_Codigo = "RT-310",
                Ruta_Descripcion = "Ruta 310"
            };
            _bddContext.tbRutas.Add(ruta);

            // Crear y agregar vendedor por ruta
            var vendedorPorRuta = new tbVendedoresPorRuta
            {
                VeRu_Id = VeRuId,
                Vend_Id = VendId,
                Ruta_Id = RutaId,
                VeRu_Dias = "LMV"
            };
            _bddContext.tbVendedoresPorRuta.Add(vendedorPorRuta);

            // Crear y agregar cliente
            var cliente = new tbClientes
            {
                Clie_Id = ClieId,
                Clie_Codigo = "CLIE-RT-310-000001",
                Clie_Nombres = "Pedro",
                Clie_Apellidos = "González",
                Clie_Nacionalidad = "HN",
                Clie_ImagenDelNegocio = "Fotito.jpg",
                Clie_NombreNegocio = "Tienda El Ahorro",
                Clie_Telefono = "9856-8950",
                Clie_Sexo = "M"
            };
            _bddContext.tbClientes.Add(cliente);

            // Crear y agregar dirección del cliente
            var direccionCliente = new tbDireccionesPorCliente
            {
                DiCl_Id = DiClId,
                Clie_Id = ClieId,
                DiCl_DireccionExacta = "Colonia Tara",
                DiCl_Latitud = 15.562454m,
                DiCl_Longitud = -10.125665m
            };
            _bddContext.tbDireccionesPorCliente.Add(direccionCliente);

            // Crear y agregar estado de visita
            var estadoVisita = new tbEstadosVisita
            {
                EsVi_Id = EsViId,
                EsVi_Descripcion = "Completada"
            };
            _bddContext.tbEstadosVisita.Add(estadoVisita);

            // Crear y agregar la visita del cliente
            var visitaCliente = new tbClientesVisita
            {
                ClVi_Id = 1,
                VeRu_Id = VeRuId,
                DiCl_Id = DiClId,
                EsVi_Id = EsViId,
                ClVi_Observaciones = "Negocio cerrado",
                ClVi_Fecha = new DateTime(2025, 10, 07),
                Usua_Creacion = 1,
                ClVi_FechaCreacion = DateTime.Now
            };
            _bddContext.tbClientesVisita.Add(visitaCliente);

            // Guardar todos los cambios en la base de datos en memoria
            _bddContext.SaveChanges();

            // 2️ Act - Ejecutar el método del servicio
            var repo = new ClientesVisitaHistorialRepository(_bddContext);
            var result = repo.VisitasPorVendedor(VendId);


            // 3️ Assert - Validar los resultados
            Assert.NotNull(result);
            Assert.NotEmpty(result);

            var visitaResultante = result.FirstOrDefault();
            Assert.NotNull(visitaResultante);

            // Verificar las propiedades del DTO resultante
            Assert.Equal(1, visitaResultante.ClVi_Id);
            Assert.Equal(VendId, visitaResultante.Vend_Id);
            Assert.Equal("V001", visitaResultante.Vend_Codigo);
            Assert.Equal("Juan", visitaResultante.Vend_Nombres);
            Assert.Equal("Pérez", visitaResultante.Vend_Apellidos);
            Assert.Equal(VeRuId, visitaResultante.VeRu_Id);
            Assert.Equal(DiClId, visitaResultante.DiCl_Id);
            Assert.Equal(EsViId, visitaResultante.EsVi_Id);
            Assert.Equal("Completada", visitaResultante.EsVi_Descripcion);
            Assert.Equal("Negocio cerrado", visitaResultante.ClVi_Observaciones);
            Assert.Equal(new DateTime(2025, 10, 07), visitaResultante.ClVi_Fecha);
            Assert.Equal("Tienda El Ahorro", visitaResultante.Clie_NombreNegocio);
        }

        #endregion

        #region Insertar
        [Fact]
        public void InsertarVisita()
        {
            // Arrange
            var dto = new VisitaClientePorVendedorDTO
            {
                VeRu_Id = 1076,
                DiCl_Id = 3125,
                EsVi_Id = 3,
                ClVi_Observaciones = "Observación de prueba",
                ClVi_Fecha = DateTime.Now,
                Usua_Creacion = 1,
                ClVi_FechaCreacion = DateTime.Now
            };

            // Configura el mock para que devuelva éxito
            _repository.Setup(r => r.InsertVisita(It.IsAny<VisitaClientePorVendedorDTO>()))
                .Returns(new RequestStatus { code_Status = 1, message_Status = "Visita registrada correctamente." });

            // Act
            var result = _repository.Object.InsertVisita(dto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.code_Status);
            Assert.Equal("Visita registrada correctamente.", result.message_Status);
        }
        #endregion

        // Limpiar recursos después de cada prueba
        public void Dispose()
        {
            _bddContext?.Dispose();
        }
    }
}