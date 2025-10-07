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
    public class DevolucionesUnitTest
    {
        //repositorio que se usara haciendolo con mock
        private readonly Mock<DevolucionesRepository> _repository;
        //service que usa ese repositorio
        private readonly VentaServices _service;

        //prepara el entorno de pruebas 
        public DevolucionesUnitTest()
        {
            //crear un mock del repositorio para no usar la bdd
            _repository = new Mock<DevolucionesRepository>();

            //service con el repositorio mockeado en la posición correcta
            _service = new VentaServices(null, null, null, null, null, null, null, null, null, null, null, 
                                        _repository.Object, null, null);
        }

        //marca el metodo que le sigue como una prueba unitaria (xunit)
        [Fact]
        //unit test del listar devoluciones
        public void DevolucionesListar()
        {
            //declaracion de una lista de devoluciones que se usará
            var modelo = new List<tbDevoluciones>()
            {
                new tbDevoluciones { Devo_Id = 1, Fact_Id = 100, Devo_Motivo = "Producto defectuoso", 
                                   Devo_Estado = true, Devo_EnSucursal = false },
                new tbDevoluciones { Devo_Id = 2, Fact_Id = 101, Devo_Motivo = "Cliente insatisfecho", 
                                   Devo_Estado = true, Devo_EnSucursal = true },
                new tbDevoluciones { Devo_Id = 3, Fact_Id = 102, Devo_Motivo = "Cambio de opinión", 
                                   Devo_Estado = true, Devo_EnSucursal = false }
            }.AsEnumerable();

            //esto ejecuta la funcion del repositorio
            _repository.Setup(d => d.List())
                .Returns(modelo);

            //ejecutando el service y guardando el result
            var result = _service.DevolucionesListar();

            //cantidad de objetos esperada
            result.Should().HaveCount(3);

            //un registro que contenga algo en especifico
            result.Should().ContainSingle(x => x.Devo_Id == 2);
        }

        //ya se explico arriba
        [Fact]
        //unit test para insertar devolucion
        public void DevolucionInsertar()
        {
            //declaramos un elemento a insertar
            var item = new tbDevoluciones { Fact_Id = 10, Devo_Motivo = "Prueba unitaria" };

            //el insertar del repositorio con las cosas esperadas que devuelva
            _repository.Setup(d => d.Insert(item))
              .Returns(new RequestStatus { code_Status = 1, message_Status = "Devolución registrada correctamente." });

            //ejecuta el insert del service y guarda el result de este mismo
            var result = _service.InsertarDevolucion(item);

            //success por como lo tenemos siempre dara true
            result.Success.Should().BeTrue();

            //cosas del message del ServiceResult (mensaje genérico que devuelve el service)
            result.Message.Should().Be("Operación completada exitosamente.");
            
            //validar que se llamo solo una vez durante la ejecucion
            _repository.Verify(r => r.Insert(item), Times.Once);
        }

        //ya se explico arriba  
        [Fact]
        //unit test para trasladar devolucion
        public void DevolucionTrasladar()
        {
            //declaramos un elemento a trasladar
            var item = new tbDevoluciones { Devo_Id = 5, Fact_Id = 15, Devo_Motivo = "Traslado de prueba" };

            //el trasladar del repositorio con las cosas esperadas que devuelva
            _repository.Setup(d => d.Trasladar(item))
              .Returns(new RequestStatus { code_Status = 1, message_Status = "Devolución trasladada correctamente." });

            //ejecuta el traslado del service y guarda el result
            var result = _service.DevolucionTrasladar(item);

            //success debe ser true
            result.Success.Should().BeTrue();

            //verificar el message del ServiceResult (mensaje genérico que devuelve el service)
            result.Message.Should().Be("Operación completada exitosamente.");
            
            //validar que se llamo solo una vez durante la ejecucion
            _repository.Verify(r => r.Trasladar(item), Times.Once);
        }
    }
}
