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
        

        public AccesoServices(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;

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

        
    }
}
