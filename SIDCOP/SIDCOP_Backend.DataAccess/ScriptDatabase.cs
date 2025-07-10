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
        public const string Usuario_Insertar = "Acce.SP_Usuario_Insertar";
        public const string Usuario_Actualizar = "Acce.SP_Usuario_Actualizar";
        public const string Usuario_CambiarEstado = "Acce.SP_Usuario_Estado";
        public const string Usuario_Buscar = "Acce.SP_Usuario_Buscar";
        public const string Usuarios_Listar = "Acce.SP_Usuarios_Listar";
        public const string Usuario_IniciarSesion = "Acce.SP_Usuario_Login";
        public const string Usuario_MostrarContrasena = "Acce.SP_Usuario_MostrarContrasena";
        public const string Usuario_RestablecerContrasena = "Acce.SP_Usuario_RestablecerContrasena";
        public const string Usuario_VerificarUsuarioExistente = "Acce.SP_Usuario_VerificarUsuarioExistente";

        #endregion

        #region Permisos
        public const string Permiso_Insertar = "Acce.SP_Permiso_Insertar";
        public const string Permiso_Actualizar = "Acce.SP_Permiso_Actualizar";
        public const string Permiso_Eliminar = "Acce.SP_Permiso_Eliminar";
        public const string Permiso_Buscar = "Acce.SP_Permiso_Buscar";
        public const string Permisos_Listar = "Acce.SP_Permisos_Listar";
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
