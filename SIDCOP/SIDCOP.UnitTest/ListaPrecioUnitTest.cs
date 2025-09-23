using FluentAssertions;
using Moq;
using SIDCOP_Backend.BusinessLogic;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.DataAccess.Repositories.Ventas;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.UnitTest
{
    public class ListaPrecioUnitTest
    {
        //repositorio que se usara haciendolo con mock (explicacion mas abajo)
        private readonly Mock<PreciosPorProductoRepository> _repository;
        //service que usa ese repositorio
        private readonly VentaServices _service;

        //prepara el entorno de pruebas 
        public ListaPrecioUnitTest()
        {
            //crear un mock del repositorio para no usar la bdd, aqui podemos controlar
            //que devuelve cada funcion del repositorio

            _repository = new Mock<PreciosPorProductoRepository>();

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
            _service = new VentaServices( null, null, null, null, null, null, null, null, null,
                                        _repository.Object,
                                        null, null, null, null
            );
        }

        //marca el metodo que le sigue como una prueba unitaria (xunit) que no toma argumentos y que representa un solo caso de prueba
        [Fact]
        //unit test del listar
        public void ListaPrecioListar()
        {
            //declaracion de un lista de la tabla que se usará (llenar datos al menos 3 para cerciorarse
            //que todo funcione bien
            var modelo = new List<tbPreciosPorProducto>()
            {
                new tbPreciosPorProducto { PreP_Id = 1, Prod_Id = 1, Clie_Id = 1,
                                           PreP_PrecioContado = 100, PreP_PrecioCredito = 105,
                                           PreP_InicioEscala = 1, PreP_FinEscala = 10, PreP_ListaPrecios = 1},
                new tbPreciosPorProducto { PreP_Id = 2, Prod_Id = 1, Clie_Id = 1,
                                           PreP_PrecioContado = 80, PreP_PrecioCredito = 85,
                                           PreP_InicioEscala = 11, PreP_FinEscala = 20, PreP_ListaPrecios = 2},
                new tbPreciosPorProducto { PreP_Id = 3, Prod_Id = 2, Clie_Id = 1,
                                           PreP_PrecioContado = 100, PreP_PrecioCredito = 105,
                                           PreP_InicioEscala = 1, PreP_FinEscala = 10, PreP_ListaPrecios = 1},
            }.AsEnumerable();

            //el numero es según la cantidad de objetos que le hayamos puesto a la tabla de arriba dado que es el
            //"resultado esperado"
            //esto ejecuta la funcion del repositorio
            _repository.Setup(pl => pl.ListPorProducto(3))
                .Returns(modelo);

            //lo mismo aqui del "resultado esperado" ejecutando el service esta vez y guardando el result
            var result = _service.ListPreciosPorProducto_PorProducto(3);

            //cantidad de objetos esperada
            result.Should().HaveCount(3);

            //un registor que contenga algo en especifico y no se repita (sirve mas que nada para las pk)
            result.Should().ContainSingle(x => x.Prod_Id == 2);
        }

        //ya se explico arriba
        [Fact]

        //unit test para insertar lista precio
        public void ListaPrecioInsertar()
        {
            //declaramos un elemento a insertar (que lleve algo aunque sea)
            var item = new tbPreciosPorProducto { Prod_Id = 10 };

            //el insertar del repositorio con las cosas esperadas que devuelva
            _repository.Setup(pl => pl.InsertLista(item))
              .Returns(new RequestStatus { code_Status = 1, message_Status = "Precios registrados correctamente." });
            //

            //ejecuta el insert del service y guarda el result de este mismo
            var result = _service.InsertPreciosPorProductoLista(item);

            //success por como lo tenemos siempre dara true así que luego evaluamos lo del data que se manda desde
            //el sp en la base de datos
            result.Success.Should().BeTrue();

            //cosas del data del sp
            //si el code_Status es un entonces si se inserto, en caso que tire error es que no inserto nada
            ((int)result.Data.code_Status).Should().Be(1);
            //si el message_Status es el esperado entonces se cumplio que si inserto
            ((string)result.Data.message_Status).Should().Be("Precios registrados correctamente.");
            //validar que se llamo solo una vez durante la ejecucion
            _repository.Verify(r => r.InsertLista(item), Times.Once);

        }

    }
}
