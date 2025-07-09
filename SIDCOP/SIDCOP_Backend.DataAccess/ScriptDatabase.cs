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


        #region EstadosCiviles
           public static string EstadosCiviles_Listar =  "[Gral].[SP_EstadosCiviles_Listar]";
        #endregion


        #region Rutas
        public static string Rutas_Agregar = "[].[]";
        public static string Rutas_listar = "[].[]";
        public static string Rutas_Filtrar = "[].[]";
        public static string Rutas_Eliminar = "[].[]";
        public static string Rutas_Editar = "[].[]";
        #endregion

        #region Cais
        public static string Cai_Agregar = "[].[]";
        public static string Cai_Listar = "[].[]";
        public static string Cai_Eliminar = "[].[]";
        public static string Cai_Editar = "[].[]";
        public static string Cai_Filtrar = "[].[]";
        #endregion
    }
}
