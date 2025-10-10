using FluentAssertions;
using Moq;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.DataAccess.Repositories.Inventario;
using SIDCOP_Backend.Entities.Entities;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIDCOP.UnitTest.Inventario
{
    public class ProductosUnitTest
    {
        //Repositorio que se usa con Mock.
        private readonly Mock<ProductosRepository> _repository;
        //Servicio que usa ese repositorio.
        private readonly InventarioServices _service;

        //Prepara el entorno de pruebas.
        public ProductosUnitTest()
        {
            //Crear un mock del repositorio, no usara la base real.
            _repository = new Mock<ProductosRepository>();

            //Servicio con el repositorio declarado arriba.
            //3 posición del ProductosRepository en el constructor de InventarioServices
            /*
            si el service esta
            CategoriasRepository {...}
            SubcategoriasRepository {...}
            ProductosRepository {...}
            InventarioSucursalRepository {...}
            InventarioBodegaRepository {...}
            DescuentosRepository {...}
            PromocionesRepository {...}
            HistorialInventarioSucursalesRepository {...}
            tendrían que ir 2 null antes de ponerlo y 5 despues
            */
            _service = new InventarioServices(null, null, _repository.Object, null, null, null, null, null);
        }

        [Fact]
        public void Productos_Listar()
        {
            var modelo = new List<tbProductos>()
            {
                new tbProductos { Prod_Id = 1, Prod_Descripcion = "Producto A", Prod_Estado = true },
                new tbProductos { Prod_Id = 2, Prod_Descripcion = "Producto B", Prod_Estado = true },
                new tbProductos { Prod_Id = 3, Prod_Descripcion = "Producto C", Prod_Estado = true },
            }.AsEnumerable();

            _repository.Setup(pl => pl.List()).Returns(modelo);

            var result = _service.ListarProductos();

            result.Should().HaveCount(3);
            result.Should().ContainSingle(x => x.Prod_Id == 2);
            result.Should().OnlyContain(x => x.Prod_Estado == true);
        }

        [Fact]
        public void Productos_BuscarPorId()
        {
            var modelo = new tbProductos { Prod_Id = 1, Prod_Descripcion = "Producto Test", Prod_Estado = true };

            _repository.Setup(pl => pl.Find(1)).Returns(modelo);

            var result = _service.BuscarProducto(1);

            result.Should().NotBeNull();
            result.Prod_Id.Should().Be(1);
            result.Prod_Descripcion.Should().Be("Producto Test");
        }

        [Fact]
        public void Productos_Insertar()
        {
            var producto = new tbProductos 
            { 
                Prod_Descripcion = "Nuevo Producto", 
                Prod_Estado = true,
                Usua_Creacion = 1,
                Prod_FechaCreacion = DateTime.Now
            };
            var resultadoEsperado = new RequestStatus { code_Status = 1, message_Status = "Producto insertado correctamente" };

            _repository.Setup(pl => pl.Insert(producto)).Returns(resultadoEsperado);

            var result = _service.InsertarProducto(producto);

            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Message.Should().Contain("exitosamente");
        }

        [Fact]
        public void Productos_Actualizar()
        {
            var producto = new tbProductos 
            { 
                Prod_Id = 1,
                Prod_Descripcion = "Producto Actualizado", 
                Prod_Estado = true,
                Usua_Modificacion = 1,
                Prod_FechaModificacion = DateTime.Now
            };
            var resultadoEsperado = new RequestStatus { code_Status = 1, message_Status = "Producto actualizado correctamente" };

            _repository.Setup(pl => pl.Update(producto)).Returns(resultadoEsperado);

            var result = _service.ActualizarProducto(producto);

            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Message.Should().Contain("exitosamente");
        }

        [Fact]
        public void Productos_Eliminar()
        {
            var resultadoEsperado = new RequestStatus { code_Status = 1, message_Status = "Producto eliminado correctamente" };

            _repository.Setup(pl => pl.Delete(1)).Returns(resultadoEsperado);

            var result = _service.EliminarProducto(1);

            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Message.Should().Contain("exitosamente");
        }

        [Fact]
        public void Productos_ListaPrecioClientes()
        {
            var modelo = new List<tbProductos>()
            {
                new tbProductos { Prod_Id = 1, Prod_Descripcion = "Producto A", Prod_Estado = true },
                new tbProductos { Prod_Id = 2, Prod_Descripcion = "Producto B", Prod_Estado = true },
                new tbProductos { Prod_Id = 3, Prod_Descripcion = "Producto C", Prod_Estado = true },
            }.AsEnumerable();

            _repository.Setup(pl => pl.ListaPrecio(1)).Returns(modelo);

            var result = _service.ListaPrecioClientes(1);

            result.Should().HaveCount(3);
            result.Should().NotBeNull();
        }

        [Fact]
        public void Productos_BuscarPorFactura()
        {
            var modelo = new List<tbProductos>()
            {
                new tbProductos { Prod_Id = 1, Prod_Descripcion = "Producto A", Prod_Estado = true },
                new tbProductos { Prod_Id = 2, Prod_Descripcion = "Producto B", Prod_Estado = true },
            }.AsEnumerable();

            _repository.Setup(pl => pl.FindFactura(100)).Returns(modelo);

            var result = _service.BuscarProductoPorFactura(100);

            result.Should().HaveCount(2);
            result.Should().NotBeNull();
            result.Should().OnlyContain(x => x.Prod_Estado == true);
        }
    }
}
