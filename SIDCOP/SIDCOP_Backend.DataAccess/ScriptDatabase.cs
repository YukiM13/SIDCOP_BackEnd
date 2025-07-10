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


        #region Departamentos
            public const string Departamentos_Listar = "[Gral].[SP_Departamentos_Listar]";
            public const string Departamentos_Insertar = "[Gral].[SP_Departamento_Insertar]";
            public const string Departamento_Actualizar = "[Gral].[SP_Departamento_Actualizar]";
            public const string Departamento_Eliminar = "[Gral].[SP_Departamento_Eliminar]";
            public const string Departamento_Buscar = "[Gral].[SP_Departamento_Buscar]";
        #endregion

        #region Marcas Vehiculos
            public const string MarcasVehiculos_Listar = "[Gral].[SP_MarcasVehiculos_Listar]";
            public const string MarcasVehiculos_Insertar = "[Gral].[SP_MarcaVehiculo_Insertar]";
            public const string MarcasVehiculos_Actualizar = "[Gral].[SP_MarcaVehiculo_Actualizar]";
            public const string MarcasVehiculos_Eliminar = "[Gral].[SP_MarcaVehiculo_Eliminar]";
            public const string MarcasVehiculos_Buscar = "[Gral].[SP_MarcaVehiculo_Buscar]";
        #endregion
    }
}
