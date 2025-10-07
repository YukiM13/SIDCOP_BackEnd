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
    public class PagoCuentaPorCobrarUnitTest
    {
        private readonly Mock<PagosCuentasPorCobrarRepository> _repository;

        private readonly VentaServices _service;

        public PagoCuentaPorCobrarUnitTest()
        {
            _repository = new Mock<PagosCuentasPorCobrarRepository>();

            _service = new VentaServices(null, null, null, null, null, null, null, null, null, null,
                                        _repository.Object,
                                        null, null, null
            );
        }

        [Fact]
        public void PagoCuentaPorCobrar_Insertar()
        {
            var item = new tbPagosCuentasPorCobrar { CPCo_Id = 1, Pago_Fecha = DateTime.Now, Pago_Monto = 100, Pago_NumeroReferencia = "123", Pago_Observaciones = "N/A" };

            // Simula que el SP devuelve 1 (éxito)
            _repository.Setup(pl => pl.InsertarPago(item)).Returns(1);

            var result = _service.InsertarPagoCuentaPorCobrar(item);

            result.Success.Should().BeTrue();

            // Verifica que el resultado sea 1 (éxito)
            ((int)result.Data).Should().Be(1);

            _repository.Verify(r => r.InsertarPago(item), Times.Once);
        }

        [Fact]
        public void PagoCuentaPorCobrar_ListarPorCuentaPorCobrar()
        {
            // Arrange
            var pagos = new List<tbPagosCuentasPorCobrar>
        {
            new tbPagosCuentasPorCobrar { Pago_Id = 1, CPCo_Id = 10, Pago_Monto = 100 },
            new tbPagosCuentasPorCobrar { Pago_Id = 2, CPCo_Id = 10, Pago_Monto = 200 }
        }.AsEnumerable();

            _repository.Setup(r => r.ListarPorCuentaPorCobrar(10)).Returns(pagos);

            // Act
            var result = _service.ListarPagosPorCuentaPorCobrar(10);

            // Assert
            result.Success.Should().BeTrue();
            var lista = result.Data as IEnumerable<tbPagosCuentasPorCobrar>;
            lista.Should().NotBeNull();
            lista.Should().HaveCount(2);
            lista.Should().Contain(x => x.Pago_Id == 1 && x.Pago_Monto == 100);
        }

        [Fact]
        public void PagoCuentaPorCobrar_ListarCuentasPorCobrar()
        {
            // Arrange
            var cuentas = new List<dynamic>
        {
            new { CPCo_Id = 1, Clie_Id = 1, Saldo = 100 },
            new { CPCo_Id = 2, Clie_Id = 2, Saldo = 200 }
        }.AsEnumerable();

            _repository.Setup(r => r.ListarCuentasPorCobrar(1, true, false)).Returns(cuentas);

            // Act
            var result = _service.ListarCuentasPorCobrar(1, true, false);

            // Assert
            result.Success.Should().BeTrue();
            var lista = result.Data as IEnumerable<dynamic>;
            lista.Should().NotBeNull();
            lista.Should().HaveCount(2);
            //lista.First().CPCo_Id.Should().Be(1);
        }

        [Fact]
        public void PagoCuentaPorCobrar_AnularPago()
        {
            // Arrange
            var status = new RequestStatus { code_Status = 1, message_Status = "Pago anulado exitosamente" };

            _repository.Setup(r => r.AnularPago(5, 99, "Motivo de prueba")).Returns(status);

            // Act
            var result = _service.AnularPagoCuentaPorCobrar(5, 99, "Motivo de prueba");

            // Assert
            result.Success.Should().BeTrue();
            ((int)result.Data.code_Status).Should().Be(1);
            ((string)result.Data.message_Status).Should().Be("Pago anulado exitosamente");
            _repository.Verify(r => r.AnularPago(5, 99, "Motivo de prueba"), Times.Once);
        }
    }
}
