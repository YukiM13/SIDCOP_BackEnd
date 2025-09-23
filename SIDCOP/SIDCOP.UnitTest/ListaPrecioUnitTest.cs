using FluentAssertions;
using Moq;
using SIDCOP_Backend.BusinessLogic;
using SIDCOP_Backend.BusinessLogic.Services;
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
        //repositorio que se usara
        private readonly Mock<PreciosPorProductoRepository> _repository;
        //service que usa ese repositorio
        private readonly VentaServices _service;

        //no se muy bien como funca ya investigo pero es para las funciones del repositorio y service
        public ListaPrecioUnitTest()
        {
            //definir el repo respecto al de arriva
            _repository = new Mock<PreciosPorProductoRepository>();

            //service con lo que se explica abajo usando el repo declarado arriba
            //9, 4 tiene que ir segun el lugar esta en el service 
            /*
            si el serivce esta
            cais {...}
            ventas {...}
            precioproductos {...}
            pedidos {...}
            tendrían que ir 3 null antes de ponerlo y 1 despues
            */
            _service = new VentaServices( null, null, null, null, null, null, null, null, null,
                                        _repository.Object,
                                        null, null, null, null
            );
        }

        //no se, ya investigo
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
            _repository.Setup(pl => pl.ListPorProducto(3))
                .Returns(modelo);

            //lo mismo aqui del "resultado esperado"
            var result = _service.ListPreciosPorProducto_PorProducto(3);

            //cantidad de objetos, sin mas eso
            result.Should().HaveCount(3);

            //un registor que contenga algo en especifico y no se repita (sirve mas que nada para las pk)
            result.Should().ContainSingle(x => x.Prod_Id == 2);
        }

        public void ListaPrecioInsertar()
        {

        }

    }
}
