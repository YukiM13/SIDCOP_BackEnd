using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess
{
    public static class ScriptDatabase
    {
        #region Usuarios
        public const string Usuarios_Listar = "Acce.SP_Usuarios_Listar";

        #endregion

        #region Municipios
        public const string Municipios_Insertar = "[Gral].[SP_Municipio_Insertar]";
        public const string Municipios_Actualizar = "[Gral].[SP_Municipio_Actualizar]";
        public const string Municipios_Listar = "[Gral].[SP_Municipio_Listar]";
        
        #endregion
    }
}
