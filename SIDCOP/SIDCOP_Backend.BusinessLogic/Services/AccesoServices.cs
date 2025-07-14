using SIDCOP_Backend.DataAccess.Repositories.Acceso;
using SIDCOP_Backend.DataAccess.Repositories.General;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.BusinessLogic.Services
{
    public class AccesoServices
    {
        private readonly UsuarioRepository _usuarioRepository;
        private readonly PermisoRepository _permisoRepository;


        public AccesoServices(UsuarioRepository usuarioRepository, PermisoRepository permisoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _permisoRepository = permisoRepository;
        }

        #region Usuarios 

        public IEnumerable<tbUsuarios> ListUsuarios()
        {
            var result = new ServiceResult();
            try
            {
                var list = _usuarioRepository.List();
                return list;
            }
            catch (Exception ex)
            {

                IEnumerable<tbUsuarios> usua = null;
                return usua;
            }
        }

        public ServiceResult InsertUsuario(tbUsuarios item)
        {
            var result = new ServiceResult();
            try
            {
                var insert = _usuarioRepository.Insert(item);
                return result.Ok(insert);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdateUsuario(tbUsuarios item)
        {
            var result = new ServiceResult();
            try
            {
                var update = _usuarioRepository.Update(item);
                return result.Ok(update);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult CambiarEstadoUsuario(tbUsuarios item)
        {
            var result = new ServiceResult();
            try
            {
                var respuesta = _usuarioRepository.ChangeUserState(item);
                return result.Ok(respuesta);
            }
            catch (Exception ex)
            {
                return result.Error("Error al cambiar el estado del usuario: " + ex.Message);
            }
        }

        public IEnumerable<tbUsuarios> BuscarUsuario(tbUsuarios item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _usuarioRepository.FindUser(item);
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbUsuarios> usua = null;
                return usua;
            }
        }

        public ServiceResult VerificarUsuarioExistente(tbUsuarios item)
        {
            var result = new ServiceResult();
            try
            {
                var respuesta = _usuarioRepository.VerificateExistingUser(item);
                return result.Ok(respuesta);
            }
            catch (Exception ex)
            {
                return result.Error("Error al verificar el usuario: " + ex.Message);
            }
        }


        //public IEnumerable<tbUsuarios> IniciarSesion(tbUsuarios item)
        //{
        //    var result = new ServiceResult();
        //    try
        //    {
        //        var list = _usuarioRepository.Login(item);
        //        return list;
        //    }
        //    catch (Exception ex)
        //    {

        //        IEnumerable<tbUsuarios> usua = null;
        //        return usua;
        //    }
        //}

        public LoginResponse IniciarSesion(tbUsuarios item)
        {
            try
            {
                return _usuarioRepository.Login(item);
            }
            catch
            {
                return new LoginResponse
                {
                    code_Status = 0,
                    message_Status = "Error al iniciar sesión"
                };
            }
        }



        public ServiceResult MostrarContrasena(int usuaId, string claveSeguridad)
        {
            var result = new ServiceResult();
            try
            {
                var respuesta = _usuarioRepository.ShowPassword(usuaId, claveSeguridad);
                return result.Ok(respuesta);
            }
            catch (Exception ex)
            {
                return result.Error("Error al mostrar la contraseña: " + ex.Message);
            }
        }


        public ServiceResult RestablecerContrasena(tbUsuarios item)
        {
            var result = new ServiceResult();
            try
            {
                var restore = _usuarioRepository.RestorePassword(item);
                return result.Ok(restore);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion


        #region Permisos
        public IEnumerable<tbPermisos> ListPermisos()
        {
            var result = new ServiceResult();
            try
            {
                var list = _permisoRepository.List();
                return list;
            }
            catch (Exception ex)
            {

                IEnumerable<tbPermisos> usua = null;
                return usua;
            }
        }

        public ServiceResult InsertPermiso(tbPermisos item)
        {
            var result = new ServiceResult();
            try
            {
                var insert = _permisoRepository.Insert(item);
                return result.Ok(insert);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdatePermiso(tbPermisos item)
        {
            var result = new ServiceResult();
            try
            {
                var update = _permisoRepository.Update(item);
                return result.Ok(update);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public IEnumerable<tbPermisos> BuscarPermiso(tbPermisos item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _permisoRepository.FindPermission(item);
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbPermisos> usua = null;
                return usua;
            }
        }

        public ServiceResult EliminarPermiso(tbPermisos item)
        {
            var result = new ServiceResult();
            try
            {
                var respuesta = _permisoRepository.Delete(item);
                return result.Ok(respuesta);
            }
            catch (Exception ex)
            {
                return result.Error("Error al eliminar el permiso: " + ex.Message);
            }
        }
        #endregion
    }
}
