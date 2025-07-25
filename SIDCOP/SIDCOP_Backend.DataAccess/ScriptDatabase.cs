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
        public const string Usuario_Insertar = "Acce.SP_Usuario_Insertar";
        public const string Usuario_Actualizar = "Acce.SP_Usuario_Actualizar";
        public const string Usuario_CambiarEstado = "Acce.SP_Usuario_Estado";
        public const string Usuario_Buscar = "Acce.SP_Usuario_Buscar";
        public const string Usuarios_Listar = "Acce.SP_Usuarios_Listar";
        public const string Usuario_IniciarSesion = "Acce.SP_Usuario_IniciarSesion";
        public const string Usuario_MostrarContrasena = "Acce.SP_Usuario_MostrarContrasena";
        public const string Usuario_RestablecerContrasena = "Acce.SP_Usuario_RestablecerClave";
        public const string Usuario_VerificarUsuarioExistente = "[Acce].[SP_Usuario_VerificarUsuarioExistente]";
        #endregion

        #region Roles

            public static string Roles_Listar = "Acce.SP_Roles_Listar";
            public static string Rol_Insertar = "Acce.SP_Rol_Insertar";
            public static string Rol_Actualizar = "Acce.SP_Rol_Actualizar";
            public static string Rol_Eliminar = "Acce.SP_Rol_Eliminar";
            public static string Rol_Buscar = "Acce.SP_Rol_Buscar";

            //PARA LAS PANTALLAS CON SUS ACCIONES
            public static string Pantallas_Listar = "Acce.SP_Pantallas_Listar";

        #endregion

        #region Municipios

        public const string Municipios_Insertar = "[Gral].[SP_Municipio_Insertar]";
        public const string Municipios_Actualizar = "[Gral].[SP_Municipio_Actualizar]";
        public const string Municipios_Listar = "[Gral].[SP_Municipios_Listar]";
        public const string Municipios_Buscar = "[Gral].[SP_Municipio_Buscar]";
        public static string Municipios_Eliminar = "[Gral].[SP_Municipio_Eliminar]";
        public static string Municipio_ListarSucursales = "[Gral].[SP_Municipio_ListarSucursales]";

        #endregion Municipios

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
        public const string MarcasVehiculos_ListarModelos = "[Gral].[SP_MarcaVehiculo_ListarModelos]";

        #endregion Marcas Vehiculos

        #region Permisos
        public const string Permiso_Insertar = "Acce.SP_Permiso_Insertar";
        public const string Permiso_Actualizar = "Acce.SP_Permiso_Actualizar";
        public const string Permiso_Eliminar = "Acce.SP_Permiso_Eliminar";
        public const string Permiso_Buscar = "Acce.SP_Permiso_Buscar";
        public const string Permisos_Listar = "Acce.SP_Permisos_Listar";
        #endregion

        
        #region Productos

        public const string Productos_Listar = "Inve.SP_Productos_Listar";

        public const string Producto_Insertar = "Inve.SP_Producto_Insertar";

        public const string Producto_Actualizar = "Inve.SP_Producto_Actualizar";

        public const string Producto_Eliminar = "Inve.SP_Producto_Eliminar";

        public const string Producto_Buscar = "Inve.SP_Producto_Buscar";

        #endregion Productos

        #region Sucursales

        public const string Sucursales_Listar = "Gral.SP_Sucursales_Listar";

        public const string Sucursal_Insertar = "Gral.SP_Sucursal_Insertar";

        public const string Sucursal_Actualizar = "Gral.SP_Sucursal_Actualizar";

        public const string Sucursal_Eliminar = "Gral.SP_Sucursal_Eliminar";

        public const string Sucursal_Buscar = "Gral.SP_Sucursal_Buscar";

        #endregion Sucursales

        #region Colonias

        public static string Colonias_Listar = "[Gral].[SP_Colonias_Listar]";
        public static string Colonias_Buscar = "[Gral].[SP_Colonia_Buscar]";
        public static string Colonias_Eliminar = "[Gral].[SP_Colonia_Eliminar]";
        public static string Colonias_Insertar = "[Gral].[SP_Colonia_Insertar]";
        public static string Colonias_Actualizar = "[Gral].[SP_Colonia_Actualizar]";

        #endregion Colonias

        #region Avales

        public static string Avales_Listar = "[Gral].[SP_Avales_Listar]";
        public static string Avales_Insertar = "[Gral].[SP_Aval_Insertar]";
        public static string Avales_Actualizar = "[Gral].[SP_Aval_Actualizar]";
        public static string Avales_Eliminar = "[Gral].[SP_Aval_Eliminar]";

        #endregion Avales

        #region EstadosCiviles
        public static string EstadosCiviles_Listar =  "[Gral].[SP_EstadosCiviles_Listar]";

        public static string EstadoCivil_Insertar = "[Gral].[SP_EstadoCivil_Insertar]";
        public static string EstadoCivil_Actualizar = "[Gral].[SP_EstadoCivil_Actualizar]";
        public static string EstadoCivil_Buscar = "[Gral].[SP_EstadoCivil_Buscar]";
        public static string EstadoCivil_Eliminar = "[Gral].[SP_EstadoCivil_Eliminar]";
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

        
        #region Categorias
        public const string Categoria_Listar = "[Inve].[SP_Categorias_Listar]";
        public const string Categoria_Insertar = "[Inve].[SP_Categoria_Insertar]";
        public const string Categoria_Eliminar = "[Inve].[SP_Categoria_Eliminar]";
        public const string Categoria_Actualizar = "[Inve].[SP_Categoria_Actualizar]";
        public const string Categoria_Buscar = "[Inve].[SP_Categoria_Buscar]";
        public const string Categoria_FiltrarSubcategorias = "[Inve].[SP_Categoria_ListarSubcategorias]";
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

        #region  Impuestos 
        public const string Impuestos_Actualizar = "[Vnta].[SP_Impuesto_Actualizar]";
        public const string  Impuestos_Listar= "[Vnta].[SP_Impuestos_Listar]";
        
        

        #endregion EstadosCiviles

        #region Clientes

        public const string Cliente_Insertar = "Gral.SP_Cliente_Insertar";
        public const string Cliente_Actualizar = "Gral.SP_Cliente_Actualizar";
        public const string Cliente_Buscar = "Gral.SP_Cliente_Buscar";
        public const string Cliente_CambiarEstado = "Gral.SP_Cliente_CambiarEstado";
        public const string Clientes_ListarConfirmados = "Gral.SP_Clientes_ListarConfirmados";
        public const string Clientes_ListarSinConfirmacion = "Gral.SP_Clientes_ListarSinConfirmacion";

        #endregion Clientes

        #region Marcas

        public static string Marcas_Listar = "[Gral].[SP_Marcas_Listar]";
        public static string Marca_Insertar = "[Gral].[SP_Marca_Insertar]";
        public static string Marca_Actualizar = "[Gral].[SP_Marca_Actualizar]";
        public static string Marca_Eliminar = "[Gral].[SP_Marca_Eliminar]";
        public static string Marca_Buscar = "[Gral].[SP_Marca_Buscar]";

        #endregion Marcas

        #region Empleados

        public static string Empleados_Listar = "[Gral].[SP_Empleados_Listar]";
        public static string Empleados_Buscar = "[Gral].[SP_Empleado_Buscar]";
        public static string Empleados_Eliminar = "[Gral].[SP_Empleado_Eliminar]";
        public static string Empleados_Insertar = "[Gral].[SP_Empleado_Insertar]";
        public static string Empleados_Actualizar = "[Gral].[SP_Empleado_Actualizar]";

        #endregion Empleados

        #region Rutas

        public static string Rutas_Agregar = "[Logi].[SP_Ruta_Insertar]";
        public static string Rutas_listar = "[Logi].[SP_Rutas_Listar]";
        public static string Rutas_Filtrar = "[Logi].[SP_Ruta_Buscar]";
        public static string Rutas_Eliminar = "[Logi].[SP_Ruta_Eliminar]";
        public static string Rutas_Editar = "[Logi].[SP_Ruta_Actualizar]";

        #endregion Rutas

        #region Cais

        public static string Cai_Agregar = "[Vnta].[SP_CAI_Insertar]";
        public static string Cai_Listar = "[Vnta].[SP_CAIs_Listar]";
        public static string Cai_Eliminar = "[Vnta].[SP_CAI_CambiarEstado]";
        public static string Cai_Filtrar = "[Vnta].[SP_CAI_Buscar]";

        #endregion Cais

        #region Canales

        public static string Canales_Listar = "[Gral].[SP_Canales_Listar]";
        public static string Canales_Insertar = "[Gral].[SP_Canal_Insertar]";
        public static string Canales_Actualizar = "[Gral].[SP_Canal_Actualizar]";
        public static string Canales_Eliminar = "[Gral].[SP_Canal_Eliminar]";
        public static string Canales_Buscar = "[Gral].[SP_Canal_Buscar]";
        
         #endregion Canales

        #region Cargos
        public static string Cargos_Listar = "[Gral].[SP_Cargos_Listar]";
        public static string Cargos_Insertar    = "[Gral].[SP_Cargo_Insertar]";
        public static string Cargos_Actualizar  = "[Gral].[SP_Cargo_Actualizar]";
        public static string Cargos_Eliminar    = "[Gral].[SP_Cargo_Eliminar]";
        public static string Cargos_Buscar      = "[Gral].[SP_Cargo_Buscar]";
        #endregion

       

        #region RegistrosCaiS
        public static string RegistrosCaiSInsertar = "[Vnta].[SP_RegistroCAI_Insertar]";
        public static string RegistrosCaiSListar = "[Vnta].[SP_RegistrosCAI_Listar]";
        public static string RegistrosCaiSFiltrar = "[Vnta].[SP_RegistrosCAI_Buscar]";
        public static string RegistrosCaiSEditar = "[Vnta].[SP_RegistroCAI_Actualizar]";
        public static string RegistrosCaiSEliminar = "[Vnta].[SP_RegistroCAI_CambiarEstado]";
        #endregion

        
        
        #region Vendedores
        public static string Vendedores_Listar = "[Vnta].[SP_Vendedores_Listar]";
        public static string Vendedor_Buscar = "[Vnta].[SP_Vendedor_Buscar]";
        public static string Vendedor_Eliminar = "[Vnta].[SP_Vendedor_Eliminar]";
        public static string Vendedor_Insertar = "[Vnta].[SP_Vendedor_Insertar]";
        public static string Vendedor_Actualizar = "[Vnta].[SP_Vendedor_Actualizar]";

        #endregion Vendedores

        #region CuentasPorCobrar
        
               public static string CuentasPorCobrar_Listar = "[Vnta].[SP_CuentasPorCobrar_Listar]";
        #endregion

        #region PuntosEmision
        public static string PuntosEmision_Listar     = "[Vnta].[SP_PuntosEmisiones_Listar]";
        public static string PuntoEmision_Insertar    = "[Vnta].[SP_PuntoEmision_Insertar]";
        public static string PuntoEmision_Actualizar  = "[Vnta].[SP_PuntoEmision_Actualizar]";
        public static string PuntoEmision_Buscar      = "[Vnta].[SP_PuntoEmision_Buscar]";
        public static string PuntoEmision_Eliminar    = "[Vnta].[SP_PuntoEmision_Eliminar]";
        #endregion


        #region DireccionesPorCliente
        public static string DireccionPorCliente_Insertar = "[Gral].[SP_DireccionPorCliente_Insertar]";
        public static string DireccionPorCliente_Modificar = "[Gral].[SP_DireccionPorCliente_Actualizar]";
        public static string DireccionesPorCliente_Listar = "[Gral].[SP_DireccionesPorCliente_Listar]";
        public static string DireccionesPorCliente_ListarPorCliente = "[Gral].[SP_DireccionesPorCliente_ListarPorCliente]";
        public static string DireccionPorCliente_Eliminar = "[Gral].[SP_DireccionPorCliente_Eliminar]";
        #endregion

        #region Recargas
        public static string Recargas_Listar = "Logi.SP_Recargas_Listar";
        public static string Recarga_Insertar = "Logi.SP_Recarga_Insertar";
        public static string Recargas_Listar_Vendedor = "[Logi].[SP_Recargas_Listar_Vendedor]";
        //public static string DireccionesPorCliente_ListarPorCliente = "[Gral].[SP_DireccionesPorCliente_ListarPorCliente]";
        //public static string DireccionPorCliente_Eliminar = "[Gral].[SP_DireccionPorCliente_Eliminar]";
        #endregion


        #region Descuentos
        public static string Descuentos_Listar = "Inve.SP_Descuentos_Listar";
        public static string Descuentos_Insertar = "[Inve].[SP_Descuento_Insertar]";
        public static string DescuentosDetalle_Insertar = "[Inve].[SP_DescuentoDetalle_Insertar]";
        public static string DescuentosPorEscala_Insertar = "[Inve].[SP_DescuentoPorEscala_Insertar]";
        public static string DescuentosPorCliente_Insertar = "[Inve].[SP_DescuentoPorCliente_Insertar]";
        public static string Descuento_Actualizar = "Inve.SP_Descuento_Actualizar";
        public static string Descuento_Eliminar = "Inve.SP_Descuento_Eliminar";
        #endregion

        #region Traslados

        public static string Traslados_Listar = "[Logi].[SP_Traslados_Listar]";
        public static string Traslado_Insertar = "Logi.SP_Traslado_Insertar";
        public static string Traslado_Buscar = "Logi.SP_Traslado_Buscar";
        public static string Traslado_Eliminar = "Logi.SP_Traslado_Eliminar";
        public static string TrasladoDetalle_Insertar = "Logi.SP_TrasladoDetalle_Insertar";

        #endregion

        #region Pedidos y Pedidos Detalles

        public static string Pedidos_Listar = "[Vnta].[SP_Pedidos_Listar]";
        public static string Pedidos_Insertar = "[Vnta].[SP_Pedido_Insertar]";
        public static string Pedidos_Actualizar = "[Vnta].[SP_Pedido_Actualizar]";
        public static string Pedidos_Eliminar = "[Vnta].[SP_Pedido_Eliminar]";

        #endregion


        #region Inventario

        public static string InventarioSucursal_Listar      = "";
        public static string InventarioSucursal_Insertar    = "";
        public static string InventarioSucursal_Actualizar  = ""; 
        public static string InventarioSucursal_Eliminar    = "";
        public static string InventarioSucursal_Buscar      = "";

        
        public static string InventarioBodega_Listar        = "";
        public static string InventarioBodega_Insertar      = "";
        public static string InventarioBodega_Actualizar    = ""; 
        public static string InventarioBodega_Eliminar      = "";
        public static string InventarioAsgnadoPorVendedor   = "Inve.SP_InventarioAsignadoPorVendedor_Listar ";

        #endregion


        #region Paises

        public const string Paises_Listar = "Gral.SP_Paises_Listar";
        public const string Paises_ListarDepartamentos = "Gral.SP_Paises_ListarDepartamentos";
        #endregion


        #region TipiosDeVivienda
        public const string TiposDeVivienda_Listar = "Gral.SP_TiposDeVivienda_Listar";
        #endregion


    }
}