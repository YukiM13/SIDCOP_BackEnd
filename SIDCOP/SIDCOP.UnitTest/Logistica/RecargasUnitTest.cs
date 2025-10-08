using FluentAssertions;
using Moq;
using SIDCOP_Backend.BusinessLogic;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.DataAccess.Repositories.Logistica;
using SIDCOP_Backend.DataAccess.Repositories.Ventas;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.UnitTest.logistica
{
    public class RecargaUnitTest
    {

        private readonly Mock<RecargasRepository> _repository;
        //service que usa ese repositorio
        private readonly LogisticaServices _service;

        //prepara el entorno de pruebas 
        public RecargaUnitTest()
        {
            //crear un mock del repositorio para no usar la bdd, aqui podemos controlar
            //que devuelve cada funcion del repositorio

            _repository = new Mock<RecargasRepository>();

            //service con lo que se explica abajo usando el repo declarado arriba
            //9, 4 tiene que ir segun el lugar esta en el service 
            /*
            si el serivce esta
            cais {...}
            ventas {...}
            precioproductos {...}
            pedidos {...}
            tendrían que ir 2 null antes de ponerlo y 1 despues
            */
            _service = new LogisticaServices(null, null, null, _repository.Object
            );
        }

        //marca el metodo que le sigue como una prueba unitaria (xunit) que no toma argumentos y que representa un solo caso de prueba
        [Fact]
        //unit test del listar
        public void RecargaListar()
        {
            //declaracion de un lista de la tabla que se usará (llenar datos al menos 3 para cerciorarse
            //que todo funcione bien
            var modelo = new List<tbRecargas>()
            {
                    new tbRecargas
                    {
                        Reca_Id = 1,
                        Recarga = "Recarga 1",
                        Vend_Id = 10,
                        Bode_Id = 100,
                        Reca_Fecha = DateTime.Now,
                        Reca_Observaciones = "Observación 1"
                    },
                    new tbRecargas
                    {
                        Reca_Id = 2,
                        Recarga = "Recarga 2",
                        Vend_Id = 11,
                        Bode_Id = 101,
                        Reca_Fecha = DateTime.Now,
                        Reca_Observaciones = "Observación 2"
                    },
                    new tbRecargas
                    {
                        Reca_Id = 3,
                        Recarga = "Recarga 3",
                        Vend_Id = 12,
                        Bode_Id = 102,
                        Reca_Fecha = DateTime.Now,
                        Reca_Observaciones = "Observación 3"
                    },
            }.AsEnumerable();

            //el numero es según la cantidad de objetos que le hayamos puesto a la tabla de arriba dado que es el
            //"resultado esperado"
            //esto ejecuta la funcion del repositorio
            _repository.Setup(pl => pl.List())
                .Returns(modelo);

            //lo mismo aqui del "resultado esperado" ejecutando el service esta vez y guardando el result
            var result = _service.ListRecargas();

            //cantidad de objetos esperada
            result.Should().HaveCount(3);

        }


        [Fact]
        public void RecargaFind2Listar()
        {
            // Arrange: preparamos una lista de recargas simulada
            var modelo = new List<tbRecargas>()
    {
        new tbRecargas
        {
            Reca_Id = 1,
            Recarga = "Recarga 1",
            Vend_Id = 10,
            Bode_Id = 100,
            Reca_Fecha = DateTime.Now,
            Reca_Observaciones = "Observación 1"
        },
        new tbRecargas
        {
            Reca_Id = 2,
            Recarga = "Recarga 2",
            Vend_Id = 10,
            Bode_Id = 101,
            Reca_Fecha = DateTime.Now,
            Reca_Observaciones = "Observación 2"
        },
        new tbRecargas
        {
            Reca_Id = 3,
            Recarga = "Recarga 3",
            Vend_Id = 10,
            Bode_Id = 102,
            Reca_Fecha = DateTime.Now,
            Reca_Observaciones = "Observación 3"
        },
    }.AsEnumerable();

            // Act: configuramos el mock para que devuelva la lista cuando se llame Find2 con el id 10
            _repository.Setup(pl => pl.Find2(10)).Returns(modelo);

            // Llamada al método a probar
            var result = _repository.Object.Find2(10);

            // Assert: verificamos que la cantidad de elementos sea la esperada
            result.Should().HaveCount(3);

            // Verificamos que exista un registro con Reca_Id = 2
            result.Should().ContainSingle(x => x.Reca_Id == 2);
        }


        [Fact]
        //unit test para insertar devolucion
        public void RecargaInsertar()
        {
            //declaramos un elemento a insertar
            var item = new tbRecargas
            {
                Recarga = "Recarga 1",
                Vend_Id = 10,
                Bode_Id = 100,
                Reca_Fecha = DateTime.Now,
                Reca_Observaciones = "Observación 1",
                Usua_Creacion = 1,
                Reca_FechaCreacion = DateTime.Now

                //parameter.Add("@Vend_Id", item.Vend_Id);
                //parameter.Add("@Bode_Id", item.Bode_Id);
                //parameter.Add("@Reca_Fecha", item.Reca_Fecha);
                //parameter.Add("@Reca_Observaciones", item.Reca_Observaciones);
                //parameter.Add("@Usua_Creacion", item.Usua_Creacion);
                //parameter.Add("@Reca_FechaCreacion", DateTime.Now);
            };

            //el insertar del repositorio con las cosas esperadas que devuelva
            _repository.Setup(d => d.Insert(item))
              .Returns(new RequestStatus { code_Status = 1, message_Status = "Recarga registrada correctamente." });

            //ejecuta el insert del service y guarda el result de este mismo
            var result = _service.InsertRecargas(item);

            //success por como lo tenemos siempre dara true
            result.Success.Should().BeTrue();

            //cosas del message del ServiceResult (mensaje genérico que devuelve el service)
            result.Message.Should().Be("Operación completada exitosamente.");

            //validar que se llamo solo una vez durante la ejecucion
            _repository.Verify(r => r.Insert(item), Times.Once);
        }


        [Fact]
        public void Recarga_Actualizar()
        {
            // Arrange: creamos un objeto de prueba que será actualizado
            var item = new tbRecargas
            {

                Recarga = "Recarga 1",
                Vend_Id = 10,
                Bode_Id = 100,
                Reca_Fecha = DateTime.Now,
                Reca_Observaciones = "Observación 1",
                Usua_Creacion = 1,
                Reca_FechaCreacion = DateTime.Now
            };

            // Simulamos la respuesta esperada del repositorio al actualizar
            _repository.Setup(r => r.Update(item))
                .Returns(new RequestStatus
                {
                    code_Status = 1,
                    message_Status = "Rol actualizado correctamente."
                });

            // Act: llamamos al método del servicio
            var result = _service.UpdateRecargas(item);

            // Assert: validamos que el resultado sea exitoso y tenga el mensaje esperado
            result.Success.Should().BeTrue();
            ((int)result.Data.code_Status).Should().Be(1);
            ((string)result.Data.message_Status).Should().Be("Rol actualizado correctamente.");

            // Validamos que se llamó al método Update exactamente una vez
            _repository.Verify(r => r.Update(item), Times.Once);
        }

        [Fact]
        //unit test del buscar devoluciones detalle
        public void FindSucu()
        {
            //declaracion de una lista de devoluciones detalle que se usará
            var modelo = new List<tbRecargas>()
            {
                new tbRecargas { Bode_Id = 1, Bode_Descripcion = "Test" },
                new tbRecargas { Bode_Id = 2, Bode_Descripcion = "Test" },
                new tbRecargas { Bode_Id = 3, Bode_Descripcion = "Test" },

            }.AsEnumerable();

            //esto ejecuta la funcion del repositorio
            // Act: configuramos el mock para que devuelva la lista cuando se llame Find2 con el id 10
            _repository.Setup(pl => pl.FindSucu(10, true)).Returns(modelo);

            // Llamada al método a probar
            var result = _repository.Object.FindSucu(10, true);

            // Assert: verificamos que la cantidad de elementos sea la esperada
            result.Should().HaveCount(3);

            // Verificamos que exista un registro con Reca_Id = 2
            result.Should().ContainSingle(x => x.Bode_Id == 2);
        }

        [Fact]
        public void Recarga_Confirmar()
        {
            // Arrange: creamos un objeto de prueba para confirmar
            var item = new tbRecargas
            {
                Reca_Id = 1,
                Reca_Confirmacion = "CONFIRMADO",
                Reca_Observaciones = "Observación de confirmación",
                Usua_Confirmacion = 2,
                Usua_Modificacion = 2
            };

            var expectedStatus = new RequestStatus
            {
                code_Status = 1,
                message_Status = "Recarga confirmada correctamente"
            };

            // Simulamos la respuesta esperada del repositorio al confirmar
            _repository.Setup(r => r.RecargasConfirm(item))
                .Returns(expectedStatus);

            // Act: llamamos al método a probar
            var result = _repository.Object.RecargasConfirm(item);

            // Assert: validamos que el resultado sea exitoso y tenga el mensaje esperado
            result.code_Status.Should().Be(1);
            result.message_Status.Should().Be("Recarga confirmada correctamente");

            // Validamos que se llamó al método RecargasConfirm exactamente una vez
            _repository.Verify(r => r.RecargasConfirm(item), Times.Once);
        }


    }
}
