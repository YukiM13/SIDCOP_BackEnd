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


        public AccesoServices(UsuarioRepository usuarioRepository, RolRepository rolRepository)
        {
            _usuarioRepository = usuarioRepository;
            _rolRepository = rolRepository;
        }

        #region Usuarios 

        public IEnumerable<tbUsuarios> ListUsuario()
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
                var delete = _rolRepository.Delete(id);
                if (delete.code_Status == 1)
                {
                    return result.Ok(delete.message_Status);
                }
                else
                {
                    return result.Error(delete.message_Status);
                }
            }
            catch (Exception ex)
            {
                return result.Error($"Error al eliminar el rol: {ex.Message}");
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
