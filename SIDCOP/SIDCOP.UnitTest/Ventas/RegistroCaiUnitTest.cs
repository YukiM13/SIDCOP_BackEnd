using FluentAssertions;
using Moq;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.DataAccess.Repositories.Ventas;
using SIDCOP_Backend.Entities.Entities;
using SIDCOP_Backend.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIDCOP.UnitTest.Ventas
{
    public class RegistroCaiUnitTest
    {
        // Repositorio que se usará haciéndolo con mock
        private readonly Mock<RegistrosCaiSRepository> _repository;
        // Service que usa ese repositorio
        private readonly VentaServices _service;

        // Prepara el entorno de pruebas
        public RegistroCaiUnitTest()
        {
            // Crear un mock del repositorio para no usar la bdd
            // Necesitamos CallBase = true para que funcione con clases concretas
            _repository = new Mock<RegistrosCaiSRepository>() { CallBase = false };

            // Service con el repositorio mockeado en la posición correcta (2da posición)
            _service = new VentaServices(null, _repository.Object, null, null, null, null, null, null, null, 
                                        null, null, null, null, null);
        }

        // Marca el método que le sigue como una prueba unitaria (xunit)
        [Fact]
        // Unit test del listar registros CAI
        public void RegistrosCaiListar()
        {
            // Declaración de una lista de registros CAI que se usará
            var modelo = new List<tbRegistrosCAI>()
            {
                new tbRegistrosCAI 
                { 
                    RegC_Id = 1, 
                    RegC_Descripcion = "Registro CAI Test 1",
                    Sucu_Id = 1,
                    PuEm_Id = 1,
                    NCai_Id = 100,
                    RegC_RangoInicial = "001-001-01-00000001",
                    RegC_RangoFinal = "001-001-01-00001000",
                    RegC_FechaInicialEmision = DateTime.Now.AddDays(-30),
                    RegC_FechaFinalEmision = DateTime.Now.AddDays(30),
                    RegC_Estado = true 
                },
                new tbRegistrosCAI 
                { 
                    RegC_Id = 2, 
                    RegC_Descripcion = "Registro CAI Test 2",
                    Sucu_Id = 1,
                    PuEm_Id = 2,
                    NCai_Id = 101,
                    RegC_RangoInicial = "001-002-01-00000001",
                    RegC_RangoFinal = "001-002-01-00001000",
                    RegC_FechaInicialEmision = DateTime.Now.AddDays(-60),
                    RegC_FechaFinalEmision = DateTime.Now.AddDays(60),
                    RegC_Estado = true 
                },
                new tbRegistrosCAI 
                { 
                    RegC_Id = 3, 
                    RegC_Descripcion = "Registro CAI Test 3",
                    Sucu_Id = 2,
                    PuEm_Id = 1,
                    NCai_Id = 102,
                    RegC_RangoInicial = "002-001-01-00000001",
                    RegC_RangoFinal = "002-001-01-00001000",
                    RegC_FechaInicialEmision = DateTime.Now.AddDays(-15),
                    RegC_FechaFinalEmision = DateTime.Now.AddDays(15),
                    RegC_Estado = true 
                }
            }.AsEnumerable();

            // Esto ejecuta la función del repositorio
            _repository.Setup(r => r.List())
                .Returns(modelo);

            // Ejecutando el service y guardando el resultado
            var result = _service.ListarRegistrosCaiS();

            // Cantidad de objetos esperada
            result.Should().HaveCount(3);

            // Un registro que contenga algo específico
            result.Should().ContainSingle(x => x.RegC_Id == 2);
            result.Should().ContainSingle(x => x.RegC_Descripcion == "Registro CAI Test 1");
        }

        // Ya se explicó arriba
        [Fact]
        // Unit test para insertar registro CAI
        public void RegistroCaiInsertar()
        {
            // Declaramos un elemento a insertar
            var item = new tbRegistrosCAI 
            { 
                RegC_Descripcion = "Nuevo Registro CAI Test",
                Sucu_Id = 1,
                PuEm_Id = 1,
                NCai_Id = 200,
                RegC_RangoInicial = "001-001-01-00002001",
                RegC_RangoFinal = "001-001-01-00003000",
                RegC_FechaInicialEmision = DateTime.Now,
                RegC_FechaFinalEmision = DateTime.Now.AddDays(90),
                Usua_Creacion = 1,
                RegC_FechaCreacion = DateTime.Now
            };

            // El insertar del repositorio con las cosas esperadas que devuelva
            _repository.Setup(r => r.Insert(item))
              .Returns(new RequestStatus { code_Status = 1, message_Status = "Registro CAI creado correctamente." });

            // Ejecuta el insert del service y guarda el result de este mismo
            var result = _service.CrearRegistroCAi(item);

            // Success por como lo tenemos siempre dará true
            result.Success.Should().BeTrue();

            // Cosas del message del ServiceResult (mensaje genérico que devuelve el service)
            result.Message.Should().Be("Operación completada exitosamente.");
            
            // Validar que se llamó solo una vez durante la ejecución
            _repository.Verify(r => r.Insert(item), Times.Once);
        }

        // Ya se explicó arriba  
        [Fact]
        // Unit test para modificar registro CAI
        public void RegistroCaiModificar()
        {
            // Declaramos un elemento a modificar
            var item = new tbRegistrosCAI 
            { 
                RegC_Id = 5,
                RegC_Descripcion = "Registro CAI Modificado",
                Sucu_Id = 1,
                PuEm_Id = 1,
                NCai_Id = 200,
                RegC_RangoInicial = "001-001-01-00002001",
                RegC_RangoFinal = "001-001-01-00003000",
                RegC_FechaInicialEmision = DateTime.Now.AddDays(-10),
                RegC_FechaFinalEmision = DateTime.Now.AddDays(80),
                Usua_Modificacion = 1,
                RegC_FechaModificacion = DateTime.Now
            };

            // El modificar del repositorio con las cosas esperadas que devuelva
            _repository.Setup(r => r.Update(item))
              .Returns(new RequestStatus { code_Status = 1, message_Status = "Registro CAI modificado correctamente." });

            // Ejecuta el update del service y guarda el result
            var result = _service.ModificarRegistroCai(item);

            // Success por como lo tenemos siempre dará true
            result.Success.Should().BeTrue();

            // Cosas del message del ServiceResult (mensaje genérico que devuelve el service)
            result.Message.Should().Be("Operación completada exitosamente.");

            // Validar que se llamó solo una vez durante la ejecución
            _repository.Verify(r => r.Update(item), Times.Once);
        }

        // Ya se explicó arriba
        [Fact]
        // Unit test para eliminar registro CAI
        public void RegistroCaiEliminar()
        {
            // Declaramos un elemento a eliminar
            var item = new tbRegistrosCAI 
            { 
                RegC_Id = 10,
                Usua_Modificacion = 1,
                RegC_FechaModificacion = DateTime.Now
            };

            // El eliminar del repositorio con las cosas esperadas que devuelva
            _repository.Setup(r => r.Delete(item))
              .Returns(new RequestStatus { code_Status = 1, message_Status = "Registro CAI eliminado correctamente." });

            // Ejecuta el delete del service y guarda el result
            var result = _service.EliminarRegistroCai(item);

            // Success por como lo tenemos siempre dará true
            result.Success.Should().BeTrue();

            // Cosas del message del ServiceResult (mensaje genérico que devuelve el service)
            result.Message.Should().Be("Operación completada exitosamente.");

            // Validar que se llamó solo una vez durante la ejecución
            _repository.Verify(r => r.Delete(item), Times.Once);
        }


    }
}