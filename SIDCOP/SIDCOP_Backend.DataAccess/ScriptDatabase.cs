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

        #region Productos

        public const string Productos_Listar = "Inve.SP_Productos_Listar";

        public const string Producto_Insertar = "Inve.SP_Producto_Insertar";

        public const string Producto_Actualizar = "Inve.SP_Producto_Actualizar";

        public const string Producto_Eliminar = "Inve.SP_Producto_Eliminar";

        public const string Producto_Buscar = "Inve.SP_Producto_Buscar";

        #endregion

        #region Sucursales

        public const string Sucursales_Listar = "Gral.SP_Sucursales_Listar";

        public const string Sucursal_Insertar = "Gral.SP_Sucursal_Insertar";

        public const string Sucursal_Actualizar = "Gral.SP_Sucursal_Actualizar";

        public const string Sucursal_Eliminar = "Gral.SP_Sucursal_Eliminar";

        public const string Sucursal_Buscar = "Gral.SP_Sucursal_Buscar";

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
        public static string Marca_Actualizar = "[Gral].[SP_Marca_Actualizar]";
        public static string Marca_Eliminar = "[Gral].[SP_Marca_Eliminar]";
        public static string Marca_Buscar = "[Gral].[SP_Marca_Buscar]";
           public static string EstadosCiviles_Listar =  "[Gral].[SP_EstadosCiviles_Listar]";

        #endregion

        #region Clientes
        public const string Cliente_Insertar = "Gral.SP_Cliente_Insertar";
        public const string Cliente_Actualizar = "Gral.SP_Cliente_Actualizar";
        #endregion
    }
}
