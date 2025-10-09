using FluentAssertions;
using Moq;

using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.DataAccess.Repositories.Acceso;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.UnitTest.General
{
    public class UsuarioUnitTest
    {
        private readonly Mock<UsuarioRepository> _repository;
        private readonly AccesoServices _service;

        public UsuarioUnitTest()
        {
            _repository = new Mock<UsuarioRepository>();
            _service = new AccesoServices(_repository.Object, null, null, null);
        }

        #region Listar
        [Fact]
        //Prueba Unitaria de listar.
        public void UsuarioListar()
        {
            //Declaracion de una lista de la tabla que se usará (llenar al menos 3 registros para cerciorarse que todo funcione bien).
            var modelo = new List<tbUsuarios>()
            {
                new tbUsuarios { Usua_Id = 1, Usua_Usuario = "sloshy", Usua_Clave = "hola", Usua_Imagen = "imagen.jpg",
                                 Usua_EsAdmin = true, Usua_TienePermisos = true, Role_Id = 25, Usua_IdPersona = 20},

                new tbUsuarios { Usua_Id = 2, Usua_Usuario = "wilcrack", Usua_Clave = "chilly_willy", Usua_Imagen = "imagen.jpg",
                                 Usua_EsAdmin = false, Usua_TienePermisos = true, Role_Id = 5, Usua_IdPersona = 31},

                new tbUsuarios { Usua_Id = 3, Usua_Usuario = "deyby", Usua_Clave = "tuttopassa", Usua_Imagen = "imagen.jpg",
                                 Usua_EsAdmin = true, Usua_TienePermisos = false, Role_Id = 18, Usua_IdPersona = 8},
            }.AsEnumerable();

            //Esto ejecuta la funcion del repositorio.
            _repository.Setup(pl => pl.List())
                .Returns(modelo);

            //Lo mismo aqui, ejecutando el service esta vez y guardando el result.
            var result = _service.ListUsuarios();

            //Cantidad de objetos esperada
            result.Should().HaveCount(3);

            //Un registro que contenga algo en especifico y no se repita (sirve mas que nada para las pk).
            result.Should().ContainSingle(x => x.Usua_Id == 3);
        }
        #endregion

        #region Insertar
        [Fact]
        public void UsuarioInsertar()
        {
            //Declaramos un elemento a insertar (que lleve algo aunque sea).
            var item = new tbUsuarios
            {
                Usua_Usuario = "Poncho",
                Usua_Clave = "poncho123",
                Role_Id = 2,
                Usua_IdPersona = 12,
                Usua_EsVendedor = true,
                Usua_EsAdmin = true,
                Usua_Imagen = "ImagenUsuario.jpg",
                Usua_TienePermisos = true
                //Agregar los demas campos si es necesario.
            };

            //El insertar del repositorio con las cosas esperadas que devuelva.
            _repository.Setup(pl => pl.Insert(item))
              .Returns(new RequestStatus { code_Status = 1, message_Status = "Usuario registrado correctamente." });
            //

            //Ejecuta el insertar del service y guarda el result de este mismo.
            var result = _service.InsertUsuario(item);

            //Success por como lo tenemos siempre dara true así que luego evaluamos lo del data que se manda desde.
            //El sp en la base de datos.
            result.Success.Should().BeTrue();

            //Cosas del data del sp.
            //Si el code_Status es un entonces si se insertó, en caso que tire error es que no insertó nada.
            ((int)result.Data.code_Status).Should().Be(1);
            //Si el message_Status es el esperado entonces se cumplio que si insertó.
            ((string)result.Data.message_Status).Should().Be("Usuario registrado correctamente.");
            //Validar que se llamo solo una vez durante la ejecucion.
            _repository.Verify(r => r.Insert(item), Times.Once);
        }
        #endregion

        #region Editar
        [Fact]
        public void UsuarioEditar()
        {
            //Declaramos un elemento a editar (que lleve algo aunque sea).
            var item = new tbUsuarios
            {
                Usua_Id = 1,
                Usua_Usuario = "Poncho",
                Usua_Clave = "poncho123",
                Role_Id = 2,
                Usua_IdPersona = 12,
                Usua_EsVendedor = true,
                Usua_EsAdmin = true,
                Usua_Imagen = "ImagenUsuario.jpg",
                Usua_TienePermisos = true
                //Agregar los demas campos si es necesario.
            };

            //El insertar del repositorio con las cosas esperadas que devuelva.
            _repository.Setup(pl => pl.Update(item))
              .Returns(new RequestStatus { code_Status = 1, message_Status = "Usuario actualizado correctamente." });
            //

            //Ejecuta el insertar del service y guarda el result de este mismo.
            var result = _service.UpdateUsuario(item);

            //Success por como lo tenemos siempre dara true así que luego evaluamos lo del data que se manda desde.
            //El sp en la base de datos.
            result.Success.Should().BeTrue();

            //Cosas del data del sp.
            //Si el code_Status es un entonces si se insertó, en caso que tire error es que no insertó nada.
            ((int)result.Data.code_Status).Should().Be(1);
            //Si el message_Status es el esperado entonces se cumplio que si insertó.
            ((string)result.Data.message_Status).Should().Be("Usuario actualizado correctamente.");
            //Validar que se llamo solo una vez durante la ejecucion.
            _repository.Verify(r => r.Update(item), Times.Once);
        }
        #endregion

        #region Iniciar Sesión
        [Fact]
        public void IniciarSesion()
        {
            var item = new LoginResponse
            {
                Usua_Usuario = "Poncho",
                Usua_Clave = "poncho123",
            };

            // Usa It.IsAny para que coincida con cualquier LoginResponse
            _repository.Setup(pl => pl.Login(It.IsAny<LoginResponse>()))
              .Returns(new LoginResponse
              {
                  code_Status = 1,
                  message_Status = "Sesión iniciada correctamente."
              });

            var result = _service.IniciarSesion(item);

            result.Success.Should().BeTrue();
            ((int)result.Data.code_Status).Should().Be(1);
            ((string)result.Data.message_Status).Should().Be("Sesión iniciada correctamente.");

            _repository.Verify(r => r.Login(It.IsAny<LoginResponse>()), Times.Once);
        }
        #endregion 

        #region Buscar
        [Fact]
        public void BuscarUsuario()
        {
            //Declaramos un elemento a buscar (que lleve algo aunque sea).
            var item = new tbUsuarios
            {
                Usua_Id = 5
                //Agregar los demas campos si es necesario.
            };

            //Crear una lista de usuarios simulada que retornará FindUser
            var usuariosEncontrados = new List<tbUsuarios>
            {
                new tbUsuarios
                {
                    Usua_Id = 5
                    //Agregar otros campos según tu entidad
                }
            };

            //El buscar del repositorio retorna IEnumerable<tbUsuarios>
            _repository.Setup(pl => pl.FindUser(item))
                .Returns(usuariosEncontrados);

            //Ejecuta el buscar del service y guarda el result de este mismo.
            var result = _service.BuscarUsuario(item);

            //Verificar que el resultado no sea nulo
            result.Should().NotBeNull();

            //Verificar que se encontró al menos un usuario
            result.Should().HaveCount(1);

            //Verificar que el usuario encontrado tiene el Id correcto
            result.First().Usua_Id.Should().Be(5);

            //Validar que se llamo solo una vez durante la ejecucion.
            _repository.Verify(r => r.FindUser(item), Times.Once);
        }
        #endregion

        #region Cambiar Estado
        [Fact]
        public void UsuarioCambiarEstado()
        {
            //Declaramos un elemento a insertar (que lleve algo aunque sea).
            var item = new tbUsuarios
            {
                Usua_Id = 2
                //Agregar los demas campos si es necesario.
            };

            //El insertar del repositorio con las cosas esperadas que devuelva.
            _repository.Setup(pl => pl.ChangeUserState(item))
              .Returns(new RequestStatus { code_Status = 1, message_Status = "Estado de usuario cambiado correctamente." });
            //

            //Ejecuta el insertar del service y guarda el result de este mismo.
            var result = _service.CambiarEstadoUsuario(item);

            //Success por como lo tenemos siempre dara true así que luego evaluamos lo del data que se manda desde.
            //El sp en la base de datos.
            result.Success.Should().BeTrue();

            //Cosas del data del sp.
            //Si el code_Status es un entonces si se insertó, en caso que tire error es que no insertó nada.
            ((int)result.Data.code_Status).Should().Be(1);
            //Si el message_Status es el esperado entonces se cumplio que si insertó.
            ((string)result.Data.message_Status).Should().Be("Estado de usuario cambiado correctamente.");
            //Validar que se llamo solo una vez durante la ejecucion.
            _repository.Verify(r => r.ChangeUserState(item), Times.Once);
        }
        #endregion

        #region Mostrar Contraseña
        [Fact]
        public void UsuarioMostrarContrasena()
        {
            // Parámetros de entrada
            int usuaId = 5;
            string claveSeguridad = "hola";

            // El mock del repositorio debe retornar RequestStatus
            var expectedResponse = new RequestStatus
            {
                code_Status = 1,
                message_Status = "Contraseña obtenida correctamente.",
                data = "ContraseñaDesencriptada123" // La contraseña que retorna el SP
            };

            // Setup del repositorio con los parámetros correctos
            _repository.Setup(pl => pl.ShowPassword(usuaId, claveSeguridad))
                .Returns(expectedResponse);

            // Ejecuta el método del service
            var result = _service.MostrarContrasena(usuaId, claveSeguridad);

            // Verificar que el resultado no sea nulo
            result.Should().NotBeNull();

            // Verificar que la operación fue exitosa
            result.Success.Should().BeTrue();

            // Verificar el code_Status
            ((int)result.Data.code_Status).Should().Be(1);

            // Verificar el message_Status
            ((string)result.Data.message_Status).Should().Be("Contraseña obtenida correctamente.");

            // Verificar que se obtuvo la contraseña
            ((string)result.Data.data).Should().Be("ContraseñaDesencriptada123");

            // Validar que se llamó solo una vez durante la ejecución
            _repository.Verify(r => r.ShowPassword(usuaId, claveSeguridad), Times.Once);
        }
        #endregion

        #region Restablecer Contraseña
        [Fact]
        public void UsuarioRestablecerContrasena()
        {
            //Declaramos un elemento a insertar (que lleve algo aunque sea).
            var item = new tbUsuarios
            {
                Usua_Id = 3,
                Usua_Clave = "hola"
                //Agregar los demas campos si es necesario.
            };

            //El insertar del repositorio con las cosas esperadas que devuelva.
            _repository.Setup(pl => pl.RestorePassword(item))
              .Returns(new RequestStatus { code_Status = 1, message_Status = "Contraseña restablecida correctamente." });
            //

            //Ejecuta el insertar del service y guarda el result de este mismo.
            var result = _service.RestablecerContrasena(item);

            //Success por como lo tenemos siempre dara true así que luego evaluamos lo del data que se manda desde.
            //El sp en la base de datos.
            result.Success.Should().BeTrue();

            //Cosas del data del sp.
            //Si el code_Status es un entonces si se insertó, en caso que tire error es que no insertó nada.
            ((int)result.Data.code_Status).Should().Be(1);
            //Si el message_Status es el esperado entonces se cumplio que si insertó.
            ((string)result.Data.message_Status).Should().Be("Contraseña restablecida correctamente.");
            //Validar que se llamo solo una vez durante la ejecucion.
            _repository.Verify(r => r.RestorePassword(item), Times.Once);
        }
        #endregion
    }
}
