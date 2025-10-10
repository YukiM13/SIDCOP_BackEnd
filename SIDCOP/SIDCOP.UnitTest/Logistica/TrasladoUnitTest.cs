using FluentAssertions;
using Moq;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.DataAccess.Repositories.Logistica;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SIDCOP.UnitTest.Logistica
{
    public class TrasladoUnitTest
    {
        private readonly Mock<TrasladoRepository> _repository;
        private readonly LogisticaServices _service;

        public TrasladoUnitTest()
        {
            _repository = new Mock<TrasladoRepository>();

            _service = new LogisticaServices(
                null,
                null,
                _repository.Object,
                null
            );
        }

        [Fact]
        public void TrasladoListar()
        {
            var modelo = new List<tbTraslados>
            {
                new tbTraslados { Tras_Id = 1, Tras_Origen = 1, Tras_Destino = 2, Tras_Fecha = DateTime.Now },
                new tbTraslados { Tras_Id = 2, Tras_Origen = 2, Tras_Destino = 3, Tras_Fecha = DateTime.Now }
            }.AsEnumerable();

            _repository.Setup(r => r.ListTraslados()).Returns(modelo);

            var result = _service.ListTraslados();
            result.Should().HaveCount(2);
            result.Should().ContainSingle(x => x.Tras_Id == 2);
        }

        [Fact]
        public void TrasladoInsertar()
        {
            _repository.Setup(r => r.InsertTraslado(It.IsAny<tbTraslados>()))
                .Returns(new RequestStatus { code_Status = 1, message_Status = "Traslado registrado correctamente." });

            var traslado = new tbTraslados { Tras_Origen = 1, Tras_Destino = 2, Tras_Fecha = DateTime.Now };
            var result = _service.InsertTraslado(traslado);

            result.Success.Should().BeTrue();
            ((int)result.Data.code_Status).Should().Be(1);
            ((string)result.Data.message_Status).Should().Be("Traslado registrado correctamente.");
            _repository.Verify(r => r.InsertTraslado(It.IsAny<tbTraslados>()), Times.Once);
        }

        [Fact]
        public void TrasladoInsertarDetalle()
        {
            var detalle = new tbTrasladosDetalle
            {
                TrDe_Id = 1,
                Tras_Id = 1,
                Prod_Id = 10,
                TrDe_Cantidad = 5,
                TrDe_Observaciones = "Obs",
                Usua_Creacion = 1
            };

            _repository.Setup(r => r.InsertTrasladoDetalle(It.IsAny<tbTrasladosDetalle>()))
                .Returns(new RequestStatus { code_Status = 1, message_Status = "Detalle insertado correctamente." });

            var result = _service.InsertTrasladoDetalle(detalle);

            result.Success.Should().BeTrue();
            ((int)result.Data.code_Status).Should().Be(1);
            ((string)result.Data.message_Status).Should().Be("Detalle insertado correctamente.");
            _repository.Verify(r => r.InsertTrasladoDetalle(It.IsAny<tbTrasladosDetalle>()), Times.Once);
        }

        [Fact]
        public void TrasladoBuscar()
        {
            var traslado = new tbTraslados
            {
                Tras_Id = 1,
                Tras_Origen = 1,
                Tras_Destino = 2,
                Tras_Fecha = DateTime.Now
            };

            _repository.Setup(r => r.BuscarTraslado(1)).Returns(traslado);

            var result = _service.BuscarTraslado(1);

            result.Success.Should().BeTrue();
            ((tbTraslados)result.Data).Tras_Id.Should().Be(1);
            _repository.Verify(r => r.BuscarTraslado(1), Times.Once);
        }

        [Fact]
        public void TrasladoBuscarDetalle()
        {
            var detalles = new List<tbTrasladosDetalle>
            {
                new tbTrasladosDetalle { TrDe_Id = 1, Tras_Id = 1, Prod_Id = 10, TrDe_Cantidad = 5, TrDe_Observaciones = "Obs", Usua_Creacion = 1 }
            }.AsEnumerable();

            _repository.Setup(r => r.BuscarTrasladoDetalle(1)).Returns(detalles);

            var result = _service.BuscarTrasladoDetalle(1);

            result.Success.Should().BeTrue();
            ((IEnumerable<tbTrasladosDetalle>)result.Data).Should().HaveCount(1);
            _repository.Verify(r => r.BuscarTrasladoDetalle(1), Times.Once);
        }

        [Fact]
        public void TrasladoEliminar()
        {
            _repository.Setup(r => r.EliminarTraslado(1))
                .Returns(new RequestStatus { code_Status = 1, message_Status = "Traslado eliminado correctamente." });

            var result = _service.EliminarTraslado(1);

            result.Success.Should().BeTrue();
            ((int)result.Data.code_Status).Should().Be(1);
            ((string)result.Data.message_Status).Should().Be("Traslado eliminado correctamente.");
            _repository.Verify(r => r.EliminarTraslado(1), Times.Once);
        }
    }
}
