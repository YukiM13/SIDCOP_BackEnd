using FluentAssertions;
using Moq;
using SIDCOP_Backend.BusinessLogic;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.DataAccess.Repositories.Acceso;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace SIDCOP.UnitTest.Ventas
{
    public class RolUnitTest
    {
        //repositorio que se usara haciendolo con mock (explicacion mas abajo)
        private readonly Mock<RolRepository> _repository;
        //service que usa ese repositorio
        private readonly AccesoServices _service;

        //prepara el entorno de pruebas 
        public RolUnitTest()
        {
            //crear un mock del repositorio para no usar la bdd, aqui podemos controlar
            //que devuelve cada funcion del repositorio

            _repository = new Mock<RolRepository>();

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
            _service = new AccesoServices(null,
                                        _repository.Object,
                                        null, null
            );
        }

        //marca el metodo que le sigue como una prueba unitaria (xunit) que no toma argumentos y que representa un solo caso de prueba
        [Fact]
        //unit test del listar
        public void RolesListar()
        {
            //declaracion de un lista de la tabla que se usará (llenar datos al menos 3 para cerciorarse
            //que todo funcione bien
            var modelo = new List<tbRoles>()
            {
                new tbRoles { Role_Id = 1, Role_Descripcion = "dukii" },
                new tbRoles { Role_Id = 2, Role_Descripcion = "calmate" },
                new tbRoles { Role_Id = 3, Role_Descripcion = "brrr" }
            }.AsEnumerable();

            //el numero es según la cantidad de objetos que le hayamos puesto a la tabla de arriba dado que es el
            //"resultado esperado"
            //esto ejecuta la funcion del repositorio
            _repository.Setup(pl => pl.List())
                .Returns(modelo);

            //lo mismo aqui del "resultado esperado" ejecutando el service esta vez y guardando el result
            var result = _service.ListarRoles();

            //cantidad de objetos esperada
            result.Should().HaveCount(3);

            //un registor que contenga algo en especifico y no se repita (sirve mas que nada para las pk)
            result.Should().ContainSingle(x => x.Role_Id == 1);
        }

        //ya se explico arriba
        [Fact]

        //unit test para insertar lista precio
        public void RolInsertar()
        {
            //declaramos un elemento a insertar (que lleve algo aunque sea)
            var item = new tbRoles { Role_Id = 10 };

            //el insertar del repositorio con las cosas esperadas que devuelva
            _repository.Setup(pl => pl.Insert(item))
              .Returns(new RequestStatus { code_Status = 1, message_Status = "Rol registrado correctamente." });
            //

            //ejecuta el insert del service y guarda el result de este mismo
            var result = _service.InsertarRol(item);

            //success por como lo tenemos siempre dara true así que luego evaluamos lo del data que se manda desde
            //el sp en la base de datos
            result.Success.Should().BeTrue();

            //cosas del data del sp
            //si el code_Status es un entonces si se inserto, en caso que tire error es que no inserto nada
            ((int)result.Data.code_Status).Should().Be(1);
            //si el message_Status es el esperado entonces se cumplio que si inserto
            ((string)result.Data.message_Status).Should().Be("Rol registrado correctamente.");
            //validar que se llamo solo una vez durante la ejecucion
            _repository.Verify(r => r.Insert(item), Times.Once);

        }

        [Fact]
        public void RolActualizar()
        {
            // Arrange: creamos un objeto de prueba que será actualizado
            var item = new tbRoles
            {
                Role_Id = 1,
                Role_Descripcion = "Rol Actualizado"
            };

            // Simulamos la respuesta esperada del repositorio al actualizar
            _repository.Setup(r => r.Update(item))
                .Returns(new RequestStatus
                {
                    code_Status = 1,
                    message_Status = "Rol actualizado correctamente."
                });

            // Act: llamamos al método del servicio
            var result = _service.ActualizarRol(item);

            // Assert: validamos que el resultado sea exitoso y tenga el mensaje esperado
            result.Success.Should().BeTrue();
            ((int)result.Data.code_Status).Should().Be(1);
            ((string)result.Data.message_Status).Should().Be("Rol actualizado correctamente.");

            // Validamos que se llamó al método Update exactamente una vez
            _repository.Verify(r => r.Update(item), Times.Once);
        }

        [Fact]
        public void RolEliminar()
        {
            // Arrange: Id del rol que queremos eliminar
            int roleId = 1;

            // Simulamos la respuesta esperada del repositorio
            _repository.Setup(r => r.Delete(roleId))
                .Returns(new RequestStatus
                {
                    code_Status = 1,
                    message_Status = "Rol eliminado correctamente."
                });

            // Act: llamamos al método del servicio
            var result = _service.EliminarRol(roleId);

            // Assert: validamos que el resultado sea exitoso y tenga el mensaje esperado
            result.Success.Should().BeTrue();
            ((int)result.Data.code_Status).Should().Be(1);
            ((string)result.Data.message_Status).Should().Be("Rol eliminado correctamente.");

            // Validamos que se llamó al método Delete exactamente una vez
            _repository.Verify(r => r.Delete(roleId), Times.Once);
        }

        [Fact]
        public void PantallasListar()
        {
            // Arrange: crear lista simulada de pantallas
            var modelo = new List<tbPantallas>()
            {
                new tbPantallas { Pant_Id = 1, Pant_Descripcion = "dukii", Pant_Icon = "supuu", Pant_Ruta = "arriba" },
                new tbPantallas { Pant_Id = 2, Pant_Descripcion = "calmate", Pant_Icon = "supuu", Pant_Ruta = "arriba" },
                new tbPantallas { Pant_Id = 3, Pant_Descripcion = "brrr", Pant_Icon = "supuu", Pant_Ruta = "arriba" }
            };

            // Convertimos la lista a JSON string como lo haría el repositorio real
            var jsonResult = JsonSerializer.Serialize(modelo);

            // Mock: hacer que el repository devuelva ese JSON
            _repository.Setup(pl => pl.ListarPantallasJson())
                .Returns(jsonResult);

            // Act: llamar al método del service
            var result = _service.ListarPantallasJson(); // Este debe deserializar el JSON

            // Assert: verificar que el resultado es correcto
            //result.Should().HaveCount(3);
            //result.Should().ContainSingle(x => x.Pant_Id == 1);
        }

        [Fact]
        public void AccionesListar()
        {
            var modelo = new List<tbAccionesPorPantalla>()
            {
                new tbAccionesPorPantalla { AcPa_Id = 1, Pant_Id = 1, Acci_Id = 1 },
                new tbAccionesPorPantalla { AcPa_Id = 2, Pant_Id = 2, Acci_Id = 2 },
                new tbAccionesPorPantalla { AcPa_Id = 3, Pant_Id = 3, Acci_Id = 3 }
            }.AsEnumerable();

            //el numero es según la cantidad de objetos que le hayamos puesto a la tabla de arriba dado que es el
            //"resultado esperado"
            //esto ejecuta la funcion del repositorio
            _repository.Setup(pl => pl.ListAcciones())
                .Returns(modelo);

            //lo mismo aqui del "resultado esperado" ejecutando el service esta vez y guardando el result
            var result = _service.ListarAccionesPorPantalla();

            //cantidad de objetos esperada
            result.Should().HaveCount(3);

            //un registor que contenga algo en especifico y no se repita (sirve mas que nada para las pk)
            result.Should().ContainSingle(x => x.AcPa_Id == 1);
        }
    }
}
