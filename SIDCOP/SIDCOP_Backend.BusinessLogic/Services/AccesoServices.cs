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
        private readonly RolRepository _rolRepository;
        private readonly PermisoRepository _permisoRepository;

        public AccesoServices(UsuarioRepository usuarioRepository, RolRepository rolRepository, PermisoRepository permisoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _rolRepository = rolRepository;
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

        public LoginResponse IniciarSesion(LoginResponse item)
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

        #region Roles

        public IEnumerable<tbRoles> ListarRoles()
        {
            var result = new ServiceResult();
            try
            {
                var list = _rolRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbRoles> roles = null;
                return roles;
            }
        }

        public string ListarPantallasJson()
        {
            try
            {
                return _rolRepository.ListarPantallasJson();
            }
            catch (Exception ex)
            {
                return $"Error al listar pantallas: {ex.Message}";
            }
        }

        public IEnumerable<tbAccionesPorPantalla> ListarAccionesPorPantalla()
        {
            var result = new ServiceResult();
            try
            {
                var list = _rolRepository.ListAcciones();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbAccionesPorPantalla> acciones = null;
                return acciones;
            }
        }

        public ServiceResult InsertarRol(tbRoles item)
        {
            var result = new ServiceResult();
            try
            {
                var insert = _rolRepository.Insert(item);
                return result.Ok(insert);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarRol(tbRoles item)
        {
            var result = new ServiceResult();
            try
            {
                var update = _rolRepository.Update(item);
                return result.Ok(update);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarRol(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _rolRepository.Delete(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public tbRoles BuscarRol(int? id)
        {
            try
            {
                var rol = _rolRepository.Find(id);
                return rol;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar el rol: {ex.Message}");
            }
        }

        #endregion
    }
}
