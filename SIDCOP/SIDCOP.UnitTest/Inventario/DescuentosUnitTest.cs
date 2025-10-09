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
    public class DescuentosUnitTest
    {
        //repositorio que se usara haciendolo con mock (explicacion mas abajo)
        private readonly Mock<DescuentosRepository> _repository;
        //service que usa ese repositorio
        private readonly InventarioServices _service;

        //prepara el entorno de pruebas 
        public DescuentosUnitTest()
        {
            //crear un mock del repositorio para no usar la bdd, aqui podemos controlar
            //que devuelve cada funcion del repositorio

            _repository = new Mock<DescuentosRepository>();

            //service con lo que se explica abajo usando el repo declarado arriba
            //6 posición del DescuentosRepository en el constructor de InventarioServices
            /*
            si el serivce esta
            CategoriasRepository {...}
            SubcategoriasRepository {...}
            ProductosRepository {...}
            InventarioSucursalRepository {...}
            InventarioBodegaRepository {...}
            DescuentosRepository {...}
            PromocionesRepository {...}
            HistorialInventarioSucursalesRepository {...}
            tendrían que ir 5 null antes de ponerlo y 2 despues
            */
            _service = new InventarioServices(null, null, null, null, null,
                                            _repository.Object,
                                            null, null
            );
        }

        //marca el metodo que le sigue como una prueba unitaria (xunit) que no toma argumentos y que representa un solo caso de prueba
        [Fact]
        //unit test del listar
        public void Descuentos_Listar()
        {
            //declaracion de un lista de la tabla que se usará (llenar datos al menos 3 para cerciorarse
            //que todo funcione bien
            var modelo = new List<tbDescuentos>()
            {
                new tbDescuentos { 
                    Desc_Id = 1, 
                    Desc_Descripcion = "Descuento Cliente VIP", 
                    Desc_Tipo = true,
                    Desc_Aplicar = "Cliente",
                    Desc_TipoFactura = "Contado",
                    Desc_FechaInicio = DateTime.Now,
                    Desc_FechaFin = DateTime.Now.AddDays(30),
                    Desc_Observaciones = "Descuento para clientes VIP",
                    Usua_Creacion = 1,
                    Desc_Estado = true
                },
                new tbDescuentos { 
                    Desc_Id = 2, 
                    Desc_Descripcion = "Descuento Por Volumen", 
                    Desc_Tipo = false,
                    Desc_Aplicar = "Producto",
                    Desc_TipoFactura = "Credito",
                    Desc_FechaInicio = DateTime.Now,
                    Desc_FechaFin = DateTime.Now.AddDays(60),
                    Desc_Observaciones = "Descuento por compra en volumen",
                    Usua_Creacion = 1,
                    Desc_Estado = true
                },
                new tbDescuentos { 
                    Desc_Id = 3, 
                    Desc_Descripcion = "Descuento Promocional", 
                    Desc_Tipo = true,
                    Desc_Aplicar = "General",
                    Desc_TipoFactura = "Ambos",
                    Desc_FechaInicio = DateTime.Now,
                    Desc_FechaFin = DateTime.Now.AddDays(15),
                    Desc_Observaciones = "Descuento promocional temporal",
                    Usua_Creacion = 2,
                    Desc_Estado = true
                },
            }.AsEnumerable();

            //el numero es según la cantidad de objetos que le hayamos puesto a la tabla de arriba dado que es el
            //"resultado esperado"
            //esto ejecuta la funcion del repositorio
            _repository.Setup(d => d.List())
                .Returns(modelo);

            //lo mismo aqui del "resultado esperado" ejecutando el service esta vez y guardando el result
            var result = _service.ListarDescuentos();

            //cantidad de objetos esperada
            result.Should().HaveCount(3);

            //un registor que contenga algo en especifico y no se repita (sirve mas que nada para las pk)
            result.Should().ContainSingle(x => x.Desc_Id == 2);
        }

        //ya se explico arriba
        [Fact]
        //unit test para insertar descuento
        public void Descuentos_Insertar()
        {
            //declaramos un elemento a insertar (que lleve algo aunque sea)
            var item = new tbDescuentos { 
                Desc_Descripcion = "Nuevo Descuento Test",
                Desc_Tipo = true,
                Desc_Aplicar = "Cliente",
                Usua_Creacion = 1
            };

            //el insertar del repositorio con las cosas esperadas que devuelva
            _repository.Setup(d => d.Insert(item))
              .Returns(new RequestStatus { code_Status = 1, message_Status = "Operación completada exitosamente." });

            //ejecuta el insert del service y guarda el result de este mismo
            var result = _service.Insertar(item);

            //success por como lo tenemos siempre dara true así que luego evaluamos lo del data que se manda desde
            //el sp en la base de datos
            result.Success.Should().BeTrue();

            //cosas del data del sp
            //si el code_Status es un entonces si se inserto, en caso que tire error es que no inserto nada
            ((int)result.Data.code_Status).Should().Be(1);
            //si el message_Status es el esperado entonces se cumplio que si inserto
            ((string)result.Data.message_Status).Should().Be("Operación completada exitosamente.");
            //validar que se llamo solo una vez durante la ejecucion
            _repository.Verify(r => r.Insert(item), Times.Once);
        }

        [Fact]
        //unit test para actualizar descuento
        public void Descuentos_Actualizar()
        {
            //declaramos un elemento a actualizar
            var item = new tbDescuentos { 
                Desc_Id = 1,
                Desc_Descripcion = "Descuento Actualizado Test",
                Desc_Tipo = false,
                Desc_Aplicar = "Producto",
                Usua_Modificacion = 1
            };

            //el actualizar del repositorio con las cosas esperadas que devuelva
            _repository.Setup(d => d.Update(item))
              .Returns(new RequestStatus { code_Status = 1, message_Status = "Operación completada exitosamente." });

            //ejecuta el update del service y guarda el result de este mismo
            var result = _service.ActualizarDescuentos(item);

            //success por como lo tenemos siempre dara true así que luego evaluamos lo del data que se manda desde
            //el sp en la base de datos
            result.Success.Should().BeTrue();

            //cosas del data del sp
            //si el code_Status es un entonces si se actualizo, en caso que tire error es que no actualizo nada
            ((int)result.Data.code_Status).Should().Be(1);
            //si el message_Status es el esperado entonces se cumplio que si actualizo
            ((string)result.Data.message_Status).Should().Be("Operación completada exitosamente.");
            //validar que se llamo solo una vez durante la ejecucion
            _repository.Verify(r => r.Update(item), Times.Once);
        }

        [Fact]
        //unit test para eliminar descuento
        public void Descuentos_Eliminar()
        {
            //declaramos el id a eliminar
            int id = 1;

            //el eliminar del repositorio con las cosas esperadas que devuelva
            _repository.Setup(d => d.Delete(id))
              .Returns(new RequestStatus { code_Status = 1, message_Status = "Operación completada exitosamente." });

            //ejecuta el delete del service y guarda el result de este mismo
            var result = _service.EliminarDescuento(id);

            //success por como lo tenemos siempre dara true así que luego evaluamos lo del data que se manda desde
            //el sp en la base de datos
            result.Success.Should().BeTrue();

            //cosas del data del sp
            //si el code_Status es un entonces si se elimino, en caso que tire error es que no elimino nada
            ((int)result.Data.code_Status).Should().Be(1);
            //si el message_Status es el esperado entonces se cumplio que si elimino
            ((string)result.Data.message_Status).Should().Be("Operación completada exitosamente.");
            //validar que se llamo solo una vez durante la ejecucion
            _repository.Verify(r => r.Delete(id), Times.Once);
        }
    }
}
