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


        #region ConfiguracionFacturas
        public static string ConfiguracionFacturas_Listar       = "[Vnta].[SP_ConfiguracionFacturas_Listar]";
        public static string ConfiguracionFactura_Insertar      = "[Vnta].[SP_ConfiguracionFactura_Insertar]";
        public static string ConfiguracionFactura_Actualizar    = "[Vnta].[SP_ConfiguracionFactura_Actualizar]";
        public static string ConfiguracionFactura_Buscar        = "[Vnta].[SP_ConfiguracionFactura_Buscar]";
        public static string ConfiguracionFactura_Eliminar      = "[Vnta].[SP_ConfiguracionFactura_Eliminar]";
        #endregion


        #region Bodegas
        public static string Bodegas_Listar       = "[Logi].[SP_Bodegas_Listar]";
        public static string Bodega_Insertar      = "[Logi].[SP_Bodega_Insertar]";
        public static string Bodega_Actualizar    = "[Logi].[SP_Bodega_Actualizar]";
        public static string Bodega_Buscar        = "[Logi].[SP_Bodega_Buscar]";
        public static string Bodega_Eliminar      = "[Logi].[SP_Bodega_Eliminar]";
        #endregion
    }
}
