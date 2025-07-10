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

        #region Categorias
        public const string Categoria_Listar = "[Inve].[SP_Categorias_Listar]";
        public const string Categoria_Insertar = "[Inve].[SP_Categoria_Insertar]";
        public const string Categoria_Eliminar = "[Inve].[SP_Categoria_Eliminar]";
        public const string Categoria_Actualizar = "[Inve].[SP_Categoria_Actualizar]";
        public const string Categoria_Buscar = "[Inve].[SP_Categoria_Buscar]";
        #endregion

        #region Modelos
        public const string Modelos_Listar = "[Gral].[SP_Modelos_Listar]";
        public const string Modelos_Insertar = "[Gral].[SP_Modelo_Insertar]";
        public const string Modelos_Eliminar = "[Gral].[SP_Modelo_Eliminar]";
        public const string Modelos_Actualizar = "[Gral].[SP_Modelo_Actualizar]";
        public const string Modelos_Buscar = "[Gral].[SP_Modelo_Buscar]";
        #endregion

        #region Subcategorias

        public const string Subcategorias_Listar = "[Inve].[SP_Subcategoria_Listar]";
        public const string Subcategorias_Insertar = "[Inve].[SP_Subcategoria_Insertar]";
        public const string Subcategorias_Eliminar = "[Inve].[SP_Subcategoria_Eliminar]";
        public const string Subcategorias_Buscar = "[Inve].[SP_Subcategoria_Buscar]";
        public const string Subcategorias_Actualizar = "[Inve].[SP_Subcategoria_Actualizar]";
        #endregion

        #region Proveedores
        public const string Proveedores_Listar = "[Gral].[SP_Proveedores_Listar]";
        public const string Proveedores_Insertar = "[Gral].[SP_Proveedor_Insertar]";
        public const string Proveedores_Actualizar = "[Gral].[SP_Proveedor_Actualizar]";
        public const string Proveedores_Buscar = "[Gral].[SP_Proveedor_Buscar]";
        public const string Proveedores_Eliminar = "[Gral].[SP_Proveedor_Eliminar]";
        #endregion
    }
}
