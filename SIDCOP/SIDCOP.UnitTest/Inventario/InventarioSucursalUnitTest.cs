using FluentAssertions;
using Moq;
using SIDCOP_Backend.BusinessLogic;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.DataAccess.Repositories.Inventario;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.UnitTest.Inventario
{
    public class InventarioSucursalUnitTest
    {
        //Repositorio que se usa con Mock.
        private readonly Mock<InventarioSucursalRepository> _repository;
        //Servicio que usa ese repositorio.
        private readonly InventarioServices _service;

        //Prepara el entorno de pruebas.
        public InventarioSucursalUnitTest()
        {
            //Crear un mock del repositorio, no usara la base real.
            _repository = new Mock<InventarioSucursalRepository>();

            //Servicio con el repositorio declarado arriba.
            _service = new InventarioServices(null, null, null, _repository.Object, null, null, null, null);
        }

        [Fact]
        public void InventarioSucursal_Listar()
        {
            var modelo = new List<tbInventarioSucursales>()
            {
                new tbInventarioSucursales { InSu_Id = 1, Sucu_Id = 1, Prod_Id = 10, InSu_Cantidad = 15 },
                new tbInventarioSucursales { InSu_Id = 2, Sucu_Id = 1, Prod_Id = 11, InSu_Cantidad = 25 },
                new tbInventarioSucursales { InSu_Id = 3, Sucu_Id = 1, Prod_Id = 12, InSu_Cantidad = 30 },
            }.AsEnumerable();

            _repository.Setup(pl => pl.ListInve(1)).Returns(modelo);

            var result = _service.ListInve(1);

            result.Should().HaveCount(3);
            result.Should().ContainSingle(x => x.InSu_Id == 3);
            result.Should().OnlyContain(x => x.Sucu_Id == 1);
        }

        [Fact]
        public void InventarioSucursal_ListadoPorSucursal()
        {
            var modelo = new List<tbInventarioSucursales>()
            {
                new tbInventarioSucursales { InSu_Id = 1, Sucu_Id = 1, Prod_Id = 10, InSu_Cantidad = 15 },
                new tbInventarioSucursales { InSu_Id = 2, Sucu_Id = 1, Prod_Id = 11, InSu_Cantidad = 25 },
                new tbInventarioSucursales { InSu_Id = 3, Sucu_Id = 1, Prod_Id = 12, InSu_Cantidad = 30 },
            }.AsEnumerable();

            _repository.Setup(pl => pl.ListadoPorSucursal(1)).Returns(modelo);

            var result = _service.ListarPorSucursal(1);

            result.Should().HaveCount(3);
            result.Should().ContainSingle(x => x.Prod_Id == 12);
            result.Should().OnlyContain(x => x.Sucu_Id == 1);
        }

        [Fact]
        public void InventarioSucursal_ActualizarInventario()
        {
            var modelo = new List<tbInventarioSucursales>()
            {
                new tbInventarioSucursales { InSu_Id = 1, Sucu_Id = 2, Prod_Id = 5, InSu_Cantidad = 40 },
                new tbInventarioSucursales { InSu_Id = 2, Sucu_Id = 2, Prod_Id = 6, InSu_Cantidad = 55 },
                new tbInventarioSucursales { InSu_Id = 3, Sucu_Id = 2, Prod_Id = 7, InSu_Cantidad = 70 },
            }.AsEnumerable();

            _repository.Setup(pl => pl.ActulizarInventario(2, 10)).Returns(modelo);
            
            var result = _service.ActualizarInventario(2, 10);

            result.Should().HaveCount(3);
            result.Should().Contain(x => x.InSu_Cantidad > 50);
            result.Should().OnlyContain(x => x.Sucu_Id == 2);
        }

        [Fact]
        public void InventarioSucursal_ActualizarCantidades()
        {
            var modelo = new List<tbInventarioSucursales>()
            {
                new tbInventarioSucursales { InSu_Id = 1, Prod_Id = 8, InSu_Cantidad = 100 },
                new tbInventarioSucursales { InSu_Id = 2, Prod_Id = 9, InSu_Cantidad = 200 },
                new tbInventarioSucursales { InSu_Id = 3, Prod_Id = 10, InSu_Cantidad = 300 },
            }.AsEnumerable();

            int usuarioId = 5;
            DateTime fecha = DateTime.Now;
            string xml = "<Inventario><Item Id='1' Cantidad='100'/></Inventario>";

            _repository.Setup(pl => pl.ActualizarCantidadesInventario(usuarioId, fecha, xml)).Returns(modelo);

            var result = _service.ActualizarCantidadesInventario(usuarioId, fecha, xml);

            result.Should().HaveCount(3);
            result.Should().ContainSingle(x => x.InSu_Id == 2);
            result.Should().OnlyContain(x => x.InSu_Cantidad > 0);
        }
    }
}
