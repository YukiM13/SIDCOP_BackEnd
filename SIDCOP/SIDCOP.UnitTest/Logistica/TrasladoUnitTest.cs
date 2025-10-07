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
            _service = new LogisticaServices(null, null, null, _repository.Object, null, null);

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
        public void TrasladoEditar()
        {
            _repository.Setup(r => r.Update(It.IsAny<tbTraslados>()))
                .Returns(new RequestStatus { code_Status = 1, message_Status = "Traslado editado correctamente." });

            var traslado = new tbTraslados { Tras_Id = 1, Tras_Origen = 1, Tras_Destino = 2, Tras_Fecha = DateTime.Now };
            var result = _service.UpdateTraslado(traslado);

            result.Success.Should().BeTrue();
            ((int)result.Data.code_Status).Should().Be(1);
            ((string)result.Data.message_Status).Should().Be("Traslado editado correctamente.");
            _repository.Verify(r => r.Update(It.IsAny<tbTraslados>()), Times.Once);
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
