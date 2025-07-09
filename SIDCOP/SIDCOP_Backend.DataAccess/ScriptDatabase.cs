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

        #region Colonias
        public static string Colonias_Listar = "[Gral].[SP_Colonia_Listar]";
        public static string Colonias_Buscar = "[Gral].[SP_Colonia_Buscar]";
        public static string Colonias_Eliminar = "[Gral].[SP_Colonia_Eliminar]";
        public static string Colonias_Insertar= "[Gral].[SP_Colonia_Insertar]";
        public static string Colonias_Actualizar = "[Gral].[SP_Colonia_Actualizar]";

        #endregion



        #region EstadosCiviles
           public static string EstadosCiviles_Listar =  "[Gral].[SP_EstadosCiviles_Listar]";
        #endregion
    }
}
