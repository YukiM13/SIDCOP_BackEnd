using FluentAssertions;
using Moq;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.DataAccess.Repositories.Ventas;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.UnitTest.Ventas
{
    public class PedidoUnitTest
    {

        private readonly Mock<PedidoRepository> _repository;
        private readonly VentaServices _service;

        //prepara el entorno de pruebas 
        public PedidoUnitTest()
        {

            _repository = new Mock<PedidoRepository>();
        
            _service = new VentaServices(null, null, null, null, null, null, null, _repository.Object, null,
                                        null,
                                        null, null, null, null
            );
        }


        [Fact]
        public void PedidoListar()
        {
           
            var modelo = new List<tbPedidos>()
            {
                new tbPedidos { Pedi_Id = 1, Pedi_Codigo = "PED001", DiCl_Id = 1,
                                           Vend_Id = 1, Pedi_FechaPedido = DateTime.Now,
                                           Usua_Creacion = 1, Pedi_FechaCreacion = DateTime.Now,
                                           Pedi_Estado = true },
                new tbPedidos { Pedi_Id = 2, Pedi_Codigo = "PED002", DiCl_Id = 2,
                                           Vend_Id = 1, Pedi_FechaPedido = DateTime.Now,
                                           Usua_Creacion = 1, Pedi_FechaCreacion = DateTime.Now,
                                           Pedi_Estado = true },
                new tbPedidos { Pedi_Id = 3, Pedi_Codigo = "PED003", DiCl_Id = 3,
                                             Vend_Id = 2, Pedi_FechaPedido = DateTime.Now,
                                             Usua_Creacion = 1, Pedi_FechaCreacion = DateTime.Now,
                                             Pedi_Estado = true },
            }.AsEnumerable();

       
            _repository.Setup(pl => pl.List())
                .Returns(modelo);

           
            var result = _service.ListarPedidos();
            result.Should().HaveCount(3);
            result.Should().ContainSingle(x => x.Pedi_Id == 2);
        }

        [Fact]
        public void PedidoInsertar()
        {
            _repository.Setup(pl => pl.Insert(It.IsAny<tbPedidos>()))
              .Returns(new RequestStatus { code_Status = 1, message_Status = "Pedido registrada correctamente." });

            var result = _service.InsertarPedido(It.IsAny<tbPedidos>());

            result.Success.Should().BeTrue();

            ((int)result.Data.code_Status).Should().Be(1);
            ((string)result.Data.message_Status).Should().Be("Pedido registrada correctamente.");
            _repository.Verify(r => r.Insert(It.IsAny<tbPedidos>()), Times.Once);

        }

        [Fact]
        public void PedidoEditar()
        {
            _repository.Setup(pl => pl.Update(It.IsAny<tbPedidos>()))
              .Returns(new RequestStatus { code_Status = 1, message_Status = "Pedido editado correctamente." });

            var result = _service.EditarPedido(It.IsAny<tbPedidos>());

            result.Success.Should().BeTrue();

            ((int)result.Data.code_Status).Should().Be(1);
            ((string)result.Data.message_Status).Should().Be("Pedido editado correctamente.");
            _repository.Verify(r => r.Update(It.IsAny<tbPedidos>()), Times.Once);

        }

        [Fact]
        public void PedidoEliminar()
        {
            _repository.Setup(pl => pl.Delete(1))
              .Returns(new RequestStatus { code_Status = 1, message_Status = "Pedido eliminado correctamente." });

            var result = _service.EliminarPedido(1);

            result.Success.Should().BeTrue();

            ((int)result.Data.code_Status).Should().Be(1);
            ((string)result.Data.message_Status).Should().Be("Pedido eliminado correctamente.");
            _repository.Verify(r => r.Delete(1), Times.Once);

        }

    }
}
