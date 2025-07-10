using System;
using System.Collections.Generic;
using System.Globalization;
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

        #region Clientes
        public const string Cliente_Insertar = "Gral.SP_Cliente_Insertar";
        public const string Cliente_Actualizar = "Gral.SP_Cliente_Actualizar";
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
        public static string EstadoCivil_Insertar = "[Gral].[SP_EstadoCivil_Insertar]";
        public static string EstadoCivil_Actualizar = "[Gral].[SP_EstadoCivil_Actualizar]";
        public static string EstadoCivil_Buscar = "[Gral].[SP_EstadoCivil_Buscar]";
        public static string EstadoCivil_Eliminar = "[Gral].[SP_EstadoCivil_Eliminar]";
        #endregion



        #region Marcas
        public static string Marcas_Listar = "[Gral].[SP_Marcas_Listar]";
        public static string Marca_Insertar = "[Gral].[SP_Marca_Insertar]";
        #endregion
    }
}
