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
using System.Text.Json;

namespace SIDCOP.UnitTest.Ventas
{
    public class CuentaPorCobrarUnitTest
    {
        private readonly Mock<CuentasPorCobrarRepository> _repository;

        private readonly VentaServices _service;

        public CuentaPorCobrarUnitTest()
        {
            _repository = new Mock<CuentasPorCobrarRepository>();

            _service = new VentaServices(null, null, null, null, null, null,
                                        _repository.Object,
                                        null, null, null, null, null, null, null
            );
        }

        [Fact]
        public void CuentasPorCobrar_Listar()
        {
            var modelo = new List<tbCuentasPorCobrar>()
            {
                new tbCuentasPorCobrar { CPCo_Id = 1, Clie_Id = 1, Fact_Id = 1, CPCo_FechaEmision = DateTime.Now, CPCo_FechaVencimiento = DateTime.Now, CPCo_Valor = 100,
                                         CPCo_Saldo = 200, CPCo_Observaciones = "N/A"},
                new tbCuentasPorCobrar { CPCo_Id = 2, Clie_Id = 2, Fact_Id = 2, CPCo_FechaEmision = DateTime.Now, CPCo_FechaVencimiento = DateTime.Now, CPCo_Valor = 200,
                                        CPCo_Saldo = 500, CPCo_Observaciones = "N/A"},
                new tbCuentasPorCobrar { CPCo_Id = 3, Clie_Id = 3, Fact_Id = 3, CPCo_FechaEmision = DateTime.Now, CPCo_FechaVencimiento = DateTime.Now, CPCo_Valor = 300,
                                        CPCo_Saldo = 1000, CPCo_Observaciones = "N/A"}
            }.AsEnumerable();

            _repository.Setup(pl => pl.List())
                .Returns(modelo);

            var result = _service.ListCuentasPorCobrar();

            //result.Should().HaveCount();

            //result.Should().ContainSingle(x => x.CPCo_Id == 1);
        }

        [Fact]
        public void CuentaPorCobrar_GetDetalle()
        {
            // Arrange: crea un objeto de prueba
            var detalle = new tbCuentasPorCobrar
            {
                CPCo_Id = 1,
                Clie_Id = 2,
                Fact_Id = 1,
                CPCo_FechaEmision = DateTime.Now,
                CPCo_FechaVencimiento = DateTime.Now.AddDays(30),
                CPCo_Valor = 500,
                CPCo_Saldo = 250,
                CPCo_Observaciones = "Detalle de prueba"
            };

            // Configura el mock para devolver el objeto cuando se llama GetDetalle
            _repository.Setup(r => r.GetDetalle(1)).Returns(detalle);

            // Act: llama al método del servicio
            var result = _service.ObtenerDetalleCuentaPorCobrar(1);

            //cantidad de objetos esperada
            //result.Should().HaveCount(1);

            ////un registor que contenga algo en especifico y no se repita (sirve mas que nada para las pk)
            //result.Should().ContainSingle(x => x.CPCo_Id == 1);
        }

        [Fact]
        public void CuentasPorCobrar_ResumenAntiguedad()
        {
            var modelo = new List<tbCuentasPorCobrar>()
            {
                new tbCuentasPorCobrar { CPCo_Id = 1, Clie_Id = 1, Fact_Id = 1, CPCo_FechaEmision = DateTime.Now, CPCo_FechaVencimiento = DateTime.Now, CPCo_Valor = 100,
                                         CPCo_Saldo = 200, CPCo_Observaciones = "N/A"},
                new tbCuentasPorCobrar { CPCo_Id = 2, Clie_Id = 2, Fact_Id = 2, CPCo_FechaEmision = DateTime.Now, CPCo_FechaVencimiento = DateTime.Now, CPCo_Valor = 200,
                                        CPCo_Saldo = 500, CPCo_Observaciones = "N/A"},
                new tbCuentasPorCobrar { CPCo_Id = 3, Clie_Id = 3, Fact_Id = 3, CPCo_FechaEmision = DateTime.Now, CPCo_FechaVencimiento = DateTime.Now, CPCo_Valor = 300,
                                        CPCo_Saldo = 1000, CPCo_Observaciones = "N/A"}
            }.AsEnumerable();

            _repository.Setup(pl => pl.ResumenAntiguedad())
                .Returns(modelo);

            var result = _service.ResumenAntiguedad();

            //result.Should().HaveCount();

            //result.Should().ContainSingle(x => x.CPCo_Id == 1);
        }

        [Fact]
        public void CuentasPorCobrar_ResumenCliente()
        {
            var modelo = new List<tbCuentasPorCobrar>()
            {
                new tbCuentasPorCobrar { CPCo_Id = 1, Clie_Id = 1, Fact_Id = 1, CPCo_FechaEmision = DateTime.Now, CPCo_FechaVencimiento = DateTime.Now, CPCo_Valor = 100,
                                         CPCo_Saldo = 200, CPCo_Observaciones = "N/A"},
                new tbCuentasPorCobrar { CPCo_Id = 2, Clie_Id = 2, Fact_Id = 2, CPCo_FechaEmision = DateTime.Now, CPCo_FechaVencimiento = DateTime.Now, CPCo_Valor = 200,
                                        CPCo_Saldo = 500, CPCo_Observaciones = "N/A"},
                new tbCuentasPorCobrar { CPCo_Id = 3, Clie_Id = 3, Fact_Id = 3, CPCo_FechaEmision = DateTime.Now, CPCo_FechaVencimiento = DateTime.Now, CPCo_Valor = 300,
                                        CPCo_Saldo = 1000, CPCo_Observaciones = "N/A"}
            }.AsEnumerable();

            _repository.Setup(pl => pl.ResumenCliente())
                .Returns(modelo);

            var result = _service.ResumenCliente();

            //result.Should().HaveCount();

            //result.Should().ContainSingle(x => x.CPCo_Id == 1);
        }

        [Fact]
        public void CuentaPorCobrar_timeLineCliente()
        {
            // Arrange: crea una lista de prueba
            var modelo = new List<tbCuentasPorCobrar>
            {
                new tbCuentasPorCobrar { CPCo_Id = 1, Clie_Id = 5, Fact_Id = 1, CPCo_Valor = 100, CPCo_Saldo = 50, CPCo_FechaVencimiento = DateTime.Now, CPCo_Observaciones = "Pago parcial" },
                new tbCuentasPorCobrar { CPCo_Id = 2, Clie_Id = 5, Fact_Id = 2, CPCo_Valor = 200, CPCo_Saldo = 0, CPCo_FechaVencimiento = DateTime.Now, CPCo_Observaciones = "Pagado" }
            }.AsEnumerable();

            // Configura el mock para devolver la lista cuando se llama timeLineCliente
            _repository.Setup(r => r.timeLineCliente(5)).Returns(modelo);

            // Act: llama al método del servicio
            var result = _service.timeLineCliente(5);

            // Assert: verifica el resultado
            result.Success.Should().BeTrue();
            var lista = result.Data as IEnumerable<tbCuentasPorCobrar>;
            lista.Should().NotBeNull();
            lista.Should().HaveCount(2);
            lista.Should().Contain(x => x.CPCo_Id == 1 && x.Clie_Id == 5);
            lista.Should().Contain(x => x.CPCo_Id == 2 && x.Clie_Id == 5);
        }
    }
}
