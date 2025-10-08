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

        [Fact]
        public void UsuarioEditar()
        {
            //Declaramos un elemento a insertar (que lleve algo aunque sea).
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
    }
}
