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

        #region Municipios
        public const string Municipios_Insertar = "[Gral].[SP_Municipio_Insertar]";
        public const string Municipios_Actualizar = "[Gral].[SP_Municipio_Actualizar]";
        public const string Municipios_Listar = "[Gral].[SP_Municipio_Listar]";
        public const string Municipios_Buscar = "[Gral].[SP_Municipio_Buscar]";
        public static string Municipios_Eliminar = "[Gral].[SP_Municipio_Eliminar]"; 
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
        public static string Colonias_Listar = "[Gral].[SP_Colonias_Listar]";
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

        #region Clientes
        public const string Cliente_Insertar = "Gral.SP_Cliente_Insertar";
        public const string Cliente_Actualizar = "Gral.SP_Cliente_Actualizar";
        public const string Cliente_Buscar = "Gral.SP_Cliente_Buscar";
        public const string Cliente_CambiarEstado = "Gral.SP_Cliente_CambiarEstado";
        public const string Clientes_Listar = "Gral.SP_Clientes_Listar";
        #endregion



        #region Marcas
        public static string Marcas_Listar = "[Gral].[SP_Marcas_Listar]";
        public static string Marca_Insertar = "[Gral].[SP_Marca_Insertar]";
        public static string Marca_Actualizar = "[Gral].[SP_Marca_Actualizar]";
        public static string Marca_Eliminar = "[Gral].[SP_Marca_Eliminar]";
        public static string Marca_Buscar = "[Gral].[SP_Marca_Buscar]";

        #endregion





        #region Empleados
        public static string Empleados_Listar       = "[Gral].[SP_Empleados_Listar]";
        public static string Empleados_Buscar       = "[Gral].[SP_Empleado_Buscar]";
        public static string Empleados_Eliminar     = "[Gral].[SP_Empleado_Eliminar]";
        public static string Empleados_Insertar     = "[Gral].[SP_Empleado_Insertar]";
        public static string Empleados_Actualizar   = "[Gral].[SP_Empleado_Actualizar]";

        #endregion


        #region Rutas
        public static string Rutas_Agregar = "[Logi].[SP_Ruta_Insertar]";
        public static string Rutas_listar = "[Logi].[SP_Rutas_Listar]";
        public static string Rutas_Filtrar = "[Logi].[SP_Ruta_Buscar]";
        public static string Rutas_Eliminar = "[Logi].[SP_Ruta_Eliminar]";
        public static string Rutas_Editar = "[Logi].[SP_Ruta_Actualizar]";
        #endregion

        #region Cais
        public static string Cai_Agregar = "[Vnta].[SP_CAI_Insertar]";
        public static string Cai_Listar = "[Vnta].[SP_CAIs_Listar]";
        public static string Cai_Eliminar = "[Vnta].[]";
        public static string Cai_Filtrar = "[Vnta].[SP_CAI_Buscar]";
        #endregion

        #region Canales
            public static string Canales_Listar     = "[Gral].[SP_Canales_Listar]";
            public static string Canales_Insertar   = "[Gral].[SP_Canal_Insertar]";
            public static string Canales_Actualizar = "[Gral].[SP_Canal_Actualizar]";
            public static string Canales_Eliminar   = "[Gral].[SP_Canal_Eliminar]";
            public static string Canales_Buscar     = "[Gral].[SP_Canal_Buscar]";
        #endregion



        #region RegistrosCaiS
        public static string RegistrosCaiSInsertar = "[Vnta].[SP_RegistroCAI_Insertar]";
        public static string RegistrosCaiSListar = "[Vnta].[SP_RegistrosCAI_Listar]";
        public static string RegistrosCaiSFiltrar = "[Vnta].[SP_RegistrosCAI_Buscar]";
        public static string RegistrosCaiSEditar = "[Vnta].[SP_RegistroCAI_Actualizar]";
        public static string RegistrosCaiSEliminar = "[Vnta].[]";
        #endregion

    }
}
