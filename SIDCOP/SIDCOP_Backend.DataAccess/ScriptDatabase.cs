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

        #endregion

        #region Clientes
        public const string Cliente_Insertar = "Gral.SP_Cliente_Insertar";
        public const string Cliente_Actualizar = "Gral.SP_Cliente_Actualizar";
        public const string Cliente_Buscar = "Gral.SP_Cliente_Buscar";
        public const string Cliente_CambiarEstado = "Gral.SP_Cliente_CambiarEstado";
        public const string Clientes_Listar = "Gral.SP_Clientes_Listar";
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
