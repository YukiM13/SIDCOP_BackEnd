using Api_SIDCOP.API.Models.Acceso;
using Api_SIDCOP.API.Models.Ventas;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Mocks
{
    public class UsuarioMocks
    {
        public static UsuarioViewModel ListarUsuariosMock()
        {
            return new UsuarioViewModel
            {
                Usua_Id = 74,
                Usua_Usuario = "heuceda",
                Usua_Clave = "euceda123@",
                Usua_Imagen = "heuceda.jpg",
                Role_Id = 3,
                Role_Descripcion = "Supervisor(a)",
                Usua_IdPersona = 33,
                Usua_EsAdmin = true,
                Usua_EsVendedor = false,
                Usua_TienePermisos = true,
                Usua_Creacion = 35,
                Usua_FechaCreacion = DateTime.Now,
                Usua_Modificacion = 1,
                Usua_FechaModificacion = DateTime.Now,
                Usua_Estado = true,
            };
        }

        public static UsuarioViewModel CrearMockUsuario()
        {
            return new UsuarioViewModel
            {
                Usua_Usuario = "heuceda",
                Usua_Clave = "euceda123+",
                Usua_Imagen = "heuceda.jpg",
                Role_Id = 3,
                Role_Descripcion = "Supervisor(a)",
                Usua_IdPersona = 33,
                Usua_EsAdmin = true,
                Usua_EsVendedor = false,
                Usua_TienePermisos = false,
                Usua_Creacion = 1,
                Usua_FechaCreacion = DateTime.Now,
            
            };
        }

        public static UsuarioViewModel ActualizarMockUsuario()
        {
            return new UsuarioViewModel
            {
                Usua_Id = 74,
                Usua_Usuario = "heuceda",
                Usua_Clave = "euceda123@",
                Usua_Imagen = "heuceda.jpg",
                Role_Id = 3,
                Role_Descripcion = "Supervisor(a)",
                Usua_IdPersona = 33,
                Usua_EsAdmin = true,
                Usua_EsVendedor = false,
                Usua_TienePermisos = true,
                Usua_Creacion = 35,
                Usua_FechaCreacion = DateTime.Now,
                Usua_Modificacion = 1,
                Usua_FechaModificacion = DateTime.Now,
                Usua_Estado = true,
            };
        }

        public static UsuarioViewModel CambiarEstadoUsuarioMock()
        {
            return new UsuarioViewModel
            {
                Usua_Id = 74,
                Usua_Usuario = "heuceda",
                Usua_Clave = "euceda123+",
                Usua_Imagen = "heuceda.jpg",
                Role_Id = 3,
                Role_Descripcion = "Supervisor(a)",
                Usua_IdPersona = 33,
                Usua_EsAdmin = true,
                Usua_EsVendedor = false,
                Usua_TienePermisos = false,
                Usua_Creacion = 1,
                Usua_FechaCreacion = DateTime.Now,
                Usua_Estado = false,
            };
        }

        public static UsuarioViewModel BuscarUsuarioMock()
        {
            return new UsuarioViewModel
            {
                Usua_Id = 74,
                Usua_Usuario = "heuceda",
                Usua_Clave = "euceda123+",
                Usua_Imagen = "heuceda.jpg",
                Role_Id = 3,
                Role_Descripcion = "Supervisor(a)",
                Usua_IdPersona = 33,
                Usua_EsAdmin = true,
                Usua_EsVendedor = false,
                Usua_TienePermisos = false,
                Usua_Creacion = 1,
                Usua_FechaCreacion = DateTime.Now,
                Usua_Estado = false,
            };
        }

        public static UsuarioViewModel MostrarMontrasenaMock()
        {
            return new UsuarioViewModel
            {
                Usua_Id = 74,
                Usua_Usuario = "heuceda",
                Usua_Clave = "euceda123@",
                Usua_Imagen = "heuceda.jpg",
                Role_Id = 3,
                Role_Descripcion = "Supervisor(a)",
                Usua_IdPersona = 33,
                Usua_EsAdmin = true,
                Usua_EsVendedor = false,
                Usua_TienePermisos = false,
                Usua_Creacion = 1,
                Usua_FechaCreacion = DateTime.Now,
                Usua_Estado = false,
            };
        }

        public static LoginResponse IniciarSesionMock()
        {
            return new LoginResponse
            {
                Usua_Usuario = "heuceda",
                Usua_Clave = "euceda123@",
            };
        }

        public static UsuarioViewModel RestablecerContrasenaMock()
        {
            return new UsuarioViewModel
            {
                Usua_Id = 74,
                Usua_Usuario = "heuceda",
                Usua_Clave = "euceda10@",
                Usua_Imagen = "heuceda.jpg",
                Role_Id = 3,
                Role_Descripcion = "Supervisor(a)",
                Usua_IdPersona = 33,
                Usua_EsAdmin = true,
                Usua_EsVendedor = false,
                Usua_TienePermisos = false,
                Usua_Creacion = 1,
                Usua_FechaCreacion = DateTime.Now,
                Usua_Estado = false,
            };
        }

        public static tbUsuarios VerificarUsuarioExistenteMock()
        {
            return new tbUsuarios
            {
                Usua_Id = 74,
                Usua_Usuario = "heuceda",
                Usua_Clave = "euceda123@",
                Usua_Imagen = "heuceda.jpg",
                Role_Id = 3,
                Role_Descripcion = "Supervisor(a)",
                Usua_EsAdmin = true,
                Usua_Estado = true,
                Usua_Creacion = 1,
                Usua_FechaCreacion = DateTime.Now
            };
        }
    }
}

