using Moq;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.DataAccess.Repositories.Ventas;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using SIDCOP_Backend.DataAccess.Repositories.Inventario;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SIDCOP.UnitTest.Inventario
{
    public class PromocionesUnitTest
    {

        //repositorio que se usara haciendolo con mock (explicacion mas abajo)
        private readonly Mock<PromocionesRepository> _repository;
        //service que usa ese repositorio
        private readonly InventarioServices _service;

        //prepara el entorno de pruebas 
        public PromocionesUnitTest()
        {
            //crear un mock del repositorio para no usar la bdd, aqui podemos controlar
            //que devuelve cada funcion del repositorio

            _repository = new Mock<PromocionesRepository>();

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
            _service = new InventarioServices(null, null, null, null, null, null, _repository.Object, null
                                        
            );
        }

        //marca el metodo que le sigue como una prueba unitaria (xunit) que no toma argumentos y que representa un solo caso de prueba
        [Fact]
        //unit test del listar
        public void PromocionesListar()
        {
            //declaracion de un lista de la tabla que se usará (llenar datos al menos 3 para cerciorarse
            //que todo funcione bien
            var modelo = new List<tbProductos>()
        {
            new tbProductos { Prod_Id = 1, Secuencia = 1, Prod_Codigo = "", Prod_CodigoBarra = "",  Prod_Descripcion = "", Prod_DescripcionCorta = "", Prod_Imagen= "",
                                Cate_Id = 1, Subc_Id= 1, Marc_Id= 1, Prov_Id= 1, Impu_Id= 1, Prod_PrecioUnitario = 1, Prod_PagaImpuesto = "S", Marc_Descripcion = "", 
                                Cate_Descripcion= "", Subc_Descripcion= "", Prov_NombreEmpresa= "", Impu_Descripcion= ""
            },
            new tbProductos { Prod_Id = 2, Secuencia = 2, Prod_Codigo = "", Prod_CodigoBarra = "",  Prod_Descripcion = "", Prod_DescripcionCorta = "", Prod_Imagen= "",
                                Cate_Id = 1, Subc_Id= 1, Marc_Id= 1, Prov_Id= 1, Impu_Id= 1, Prod_PrecioUnitario = 1, Prod_PagaImpuesto = "S", Marc_Descripcion = "",
                                Cate_Descripcion= "", Subc_Descripcion= "", Prov_NombreEmpresa= "", Impu_Descripcion= ""
            },
            new tbProductos { Prod_Id = 3, Secuencia = 3, Prod_Codigo = "", Prod_CodigoBarra = "",  Prod_Descripcion = "", Prod_DescripcionCorta = "", Prod_Imagen= "",
                                Cate_Id = 1, Subc_Id= 1, Marc_Id= 1, Prov_Id= 1, Impu_Id= 1, Prod_PrecioUnitario = 1, Prod_PagaImpuesto = "S", Marc_Descripcion = "",
                                Cate_Descripcion= "", Subc_Descripcion= "", Prov_NombreEmpresa= "", Impu_Descripcion= ""
            },


        }.AsEnumerable();

            //el numero es según la cantidad de objetos que le hayamos puesto a la tabla de arriba dado que es el
            //"resultado esperado"
            //esto ejecuta la funcion del repositorio
            _repository.Setup(pl => pl.List())
                .Returns(modelo);

            //lo mismo aqui del "resultado esperado" ejecutando el service esta vez y guardando el result
            var result = _service.ListarPromociones();

            //cantidad de objetos esperada
            result.Should().HaveCount(3);

            //un registor que contenga algo en especifico y no se repita (sirve mas que nada para las pk)
            result.Should().ContainSingle(x => x.Prod_Id == 2);
        }

        //ya se explico arriba
        [Fact]

        //unit test para insertar lista precio
        public void PromocionesInsertar()
        {
            //declaramos un elemento a insertar (que lleve algo aunque sea)
            var item = new tbProductos{ Prod_Id = 10 };

            //el insertar del repositorio con las cosas esperadas que devuelva
            _repository.Setup(pl => pl.Insert(item))
                .Returns(new RequestStatus { code_Status = 1, message_Status = "Promocion registrada correctamente." });
            //

            //ejecuta el insert del service y guarda el result de este mismo
            var result = _service.InsertarPromocines(item);

            //success por como lo tenemos siempre dara true así que luego evaluamos lo del data que se manda desde
            //el sp en la base de datos
            result.Success.Should().BeTrue();

            //cosas del data del sp
            //si el code_Status es un entonces si se inserto, en caso que tire error es que no inserto nada
            ((int)result.Data.code_Status).Should().Be(1);
            //si el message_Status es el esperado entonces se cumplio que si inserto
            ((string)result.Data.message_Status).Should().Be("Promocion registrada correctamente.");
            //validar que se llamo solo una vez durante la ejecucion
            _repository.Verify(r => r.Insert(item), Times.Once);

        }

        [Fact]
        public void PromocionesActualizar()
        {
            //declaramos un elemento a pasar (que lleve algo aunque sea)
            var item = new tbProductos { Prod_Id = 10 };

            //el metodo del repositorio con las cosas esperadas que devuelva
            _repository.Setup(pl => pl.Update(item))
                .Returns(new RequestStatus { code_Status = 1, message_Status = "Promocion actualizada correctamente." });
            //

            //ejecuta el metodo del service y guarda el result de este mismo
            var result = _service.ActualizarPromocines(item);

            //success por como lo tenemos siempre dara true así que luego evaluamos lo del data que se manda desde
            //el sp en la base de datos
            result.Success.Should().BeTrue();

            //cosas del data del sp

            ((int)result.Data.code_Status).Should().Be(1);
            //si el message_Status es el esperado entonces se cumplio
            ((string)result.Data.message_Status).Should().Be("Promocion actualizada correctamente.");
            //validar que se llamo solo una vez durante la ejecucion
            _repository.Verify(r => r.Update(item), Times.Once);

        }

        [Fact]
        public void PromocionesEliminar()
        {

            //el metodo del repositorio con las cosas esperadas que devuelva
            _repository.Setup(pl => pl.Delete(10))
                .Returns(new RequestStatus { code_Status = 1, message_Status = "Promocion eliminada correctamente." });
            //

            //ejecuta el metodo del service y guarda el result de este mismo
            var result = _service.CambiarEstadoPromociones(10);

            //success por como lo tenemos siempre dara true así que luego evaluamos lo del data que se manda desde
            //el sp en la base de datos
            result.Success.Should().BeTrue();

            //cosas del data del sp

            ((int)result.Data.code_Status).Should().Be(1);
            //si el message_Status es el esperado entonces se cumplio
            ((string)result.Data.message_Status).Should().Be("Promocion eliminada correctamente.");
            //validar que se llamo solo una vez durante la ejecucion
            _repository.Verify(r => r.Delete(10), Times.Once);

        }

    }
}
