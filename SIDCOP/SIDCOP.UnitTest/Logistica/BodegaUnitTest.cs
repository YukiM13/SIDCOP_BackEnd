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

namespace SIDCOP.UnitTest.Logistica
{
    public class BodegaUnitTest
    {
        //Repositorio que se usara haciendolo con mock (explicacion mas abajo).
        private readonly Mock<BodegaRepository> _repository;
        //Service que usa ese repositorio.
        private readonly LogisticaServices _service;

        //Prepara el entorno de pruebas.
        public BodegaUnitTest()
        {
            //Crear un mock del repositorio para no usar la bdd, aqui podemos controlar que devuelve cada funcion del repositorio.
            _repository = new Mock<BodegaRepository>();

            //Service con lo que se explica abajo usando el repo declarado arriba.
            //Los null se ponen segun la cantidad de repositorios que hayan antes y despues del que estamos utilizando.
            _service = new LogisticaServices(null, _repository.Object, null, null);
        }

        //Marca el metodo que le sigue como una prueba unitaria (xunit) que no toma argumentos y que representa un solo caso de prueba.
        [Fact]
        //Prueba Unitaria de listar.
        public void BodegasListar()
        {
            //Declaracion de una lista de la tabla que se usará (llenar al menos 3 registros para cerciorarse que todo funcione bien).
            var modelo = new List<tbBodegas>()
            {
                new tbBodegas { Bode_Id = 1, Bode_Descripcion = "Bodega Preventista", Sucu_Id = 1, RegC_Id = 19, Vend_Id = 2, Mode_Id = 25,
                                Bode_VIN  = "4S1EHDBF85DGZJ121", Bode_Placa = "PDZ-5980", Bode_Capacidad = 200.55M, Bode_TipoCamion = "M" },

                new tbBodegas { Bode_Id = 2, Bode_Descripcion = "Bodega de QA", Sucu_Id = 2, RegC_Id = 22, Vend_Id = 12, Mode_Id = 27,
                                Bode_VIN  = "1HGCM82633A123456", Bode_Placa = "HDR-8812", Bode_Capacidad = 500.00M, Bode_TipoCamion = "G" },

                new tbBodegas { Bode_Id = 3, Bode_Descripcion = "Camión Choloma 2", Sucu_Id = 6, RegC_Id = 24, Vend_Id = 13, Mode_Id = 28,
                                Bode_VIN  = "W2RS34GGR3AD135R1", Bode_Placa = "HNS-2930", Bode_Capacidad = 100.50M, Bode_TipoCamion = "P" }
            }.AsEnumerable();

            //Esto ejecuta la funcion del repositorio.
            _repository.Setup(pl => pl.List())
                .Returns(modelo);

            //Lo mismo aqui, ejecutando el service esta vez y guardando el result.
            var result = _service.ListBodegas();

            //Cantidad de objetos esperada
            result.Should().HaveCount(3);

            //Un registro que contenga algo en especifico y no se repita (sirve mas que nada para las pk).
            result.Should().ContainSingle(x => x.Bode_Id == 2);
        }

        //Ya se explico arriba.
        [Fact]
        //Prueba Unitaria para insertar.
        public void BodegaInsertar()
        {
            //Declaramos un elemento a insertar (que lleve algo aunque sea)
            var item = new tbBodegas
            {
                Bode_Descripcion = "Camión de Choluteca",
                Sucu_Id = 15,
                RegC_Id = 22,
                Vend_Id = 30,
                Mode_Id = 14,
                Bode_VIN = "4S1EHDBF85DGZJ121",
                Bode_Placa = "PDZ-5980",
                Bode_Capacidad = 500.00M,
                Bode_TipoCamion = "G"
                //Agregar los demas campos si es necesario.
            };

            //El insertar del repositorio con las cosas esperadas que devuelva
            _repository.Setup(pl => pl.Insert(item))
              .Returns(new RequestStatus { code_Status = 1, message_Status = "Bodega registrada correctamente." });
            //

            //Ejecuta el insert del service y guarda el result de este mismo
            var result = _service.InsertBodega(item);

            //success por como lo tenemos siempre dara true así que luego evaluamos lo del data que se manda desde
            //el sp en la base de datos
            result.Success.Should().BeTrue();

            //cosas del data del sp
            //si el code_Status es un entonces si se inserto, en caso que tire error es que no inserto nada
            ((int)result.Data.code_Status).Should().Be(1);
            //si el message_Status es el esperado entonces se cumplio que si inserto
            ((string)result.Data.message_Status).Should().Be("Bodega registrada correctamente.");
            //validar que se llamo solo una vez durante la ejecucion
            _repository.Verify(r => r.Insert(item), Times.Once);
        }
    }
}
