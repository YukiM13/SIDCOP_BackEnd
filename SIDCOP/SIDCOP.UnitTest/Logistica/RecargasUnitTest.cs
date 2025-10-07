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



    }
}
