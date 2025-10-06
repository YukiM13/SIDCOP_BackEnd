using SIDCOP_Backend.Entities.Entities;
using SIDCOP_Backend.DataAccess.Repositories.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIDCOP_Backend.DataAccess.Repositories.Ventas;
using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.DataAccess.Repositories.Reportes;

namespace SIDCOP_Backend.BusinessLogic.Services
{
    public class InventarioServices
    {
        private readonly CategoriasRepository _categoriasRepository;
        private readonly SubcategoriasRepository _subcategoriasRepository;
        private readonly ProductosRepository _productosRepository;
        private readonly InventarioBodegaRepository _inventarioBodegaRepository;
        private readonly InventarioSucursalRepository _inventarioSucursalRepository;
        private readonly DescuentosRepository _descuentosRepository;
        private readonly PromocionesRepository _promocionesRepository;
        private readonly HistorialInventarioSucursalesRepository _historialInventarioSucursalesRepository;
    
        public InventarioServices(CategoriasRepository categoriasRepository, SubcategoriasRepository subcategoriasRepository,
       ProductosRepository productosRepository, InventarioSucursalRepository inventarioSucursalRepository,
       InventarioBodegaRepository inventarioBodegaRepository, DescuentosRepository descuentosRepository, PromocionesRepository promocionesRepository, 
       HistorialInventarioSucursalesRepository historialInventarioSucursalesRepository)
        {
            _categoriasRepository = categoriasRepository;
            _subcategoriasRepository = subcategoriasRepository;
            _productosRepository = productosRepository;
            _inventarioSucursalRepository = inventarioSucursalRepository;
            _inventarioBodegaRepository = inventarioBodegaRepository;
            _descuentosRepository = descuentosRepository;
            _promocionesRepository = promocionesRepository;
            _historialInventarioSucursalesRepository = historialInventarioSucursalesRepository;
        }

        #region Categorias

        public IEnumerable<tbCategorias> ListarCategorias()
        {
            try
            {
                var list = _categoriasRepository.List();
                return list;
            }
            catch (Exception)
            {
                IEnumerable<tbCategorias> categorias = null;
                return categorias;
            }
        }

        public ServiceResult InsertarCategoria(tbCategorias item)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _categoriasRepository.Insert(item);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarCategoria(tbCategorias item)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _categoriasRepository.Update(item);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarCategoria(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _categoriasRepository.Delete(id);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarCategoria(tbCategorias item)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _categoriasRepository.FindCodigo(item);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult FiltrarSubcategorias(tbCategorias item)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _categoriasRepository.ListarSubcategorias(item);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion

        #region Subcategorias
        public IEnumerable<tbSubcategorias> ListarSubCategorias()
        {
            try
            {
                var list = _subcategoriasRepository.List();
                return list;
            }
            catch (Exception)
            {
                IEnumerable<tbSubcategorias> subcategorias = null;
                return subcategorias;
            }
        }

        public ServiceResult InsertarSubCategoria(tbSubcategorias item)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _subcategoriasRepository.Insert(item);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarSubCategoria(tbSubcategorias item)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _subcategoriasRepository.Update(item);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarSubCategoria(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _subcategoriasRepository.Delete(id);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarSubCategoria(tbSubcategorias item)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _subcategoriasRepository.FindCodigo(item);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion


        #region Productos

        public IEnumerable<tbProductos> ListarProductos()
        {
            try
            {
                var list = _productosRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<tbProductos>();
            }
        }
        public ServiceResult EliminarProducto(int? id)
        {
            var result = new ServiceResult();
            try
            {
                //var deleteResult = _productosRepository.Delete(id);
                //if (deleteResult.code_Status == 1)
                //{
                //    return result.Ok(deleteResult);
                //}
                //else
                //{
                //    return result.Error(deleteResult);
                //}
                var list = _productosRepository.Delete(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error($"Error al eliminar sucursal: {ex.Message}");
            }
        }
        public tbProductos BuscarProducto(int? id)
        {
            try
            {
                var producto = _productosRepository.Find(id);
                return producto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<tbProductos> ListaPrecioClientes(int? id)
        {
            try
            {
                var producto = _productosRepository.ListaPrecio(id);
                return producto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public IEnumerable<tbProductos> BuscarProductoPorFactura(int? id)
        {
            try
            {
                var producto = _productosRepository.FindFactura(id);
                return producto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ServiceResult InsertarProducto(tbProductos producto)
        {
            var result = new ServiceResult();
            try
            {
                var insertResult = _productosRepository.Insert(producto);
                if (insertResult.code_Status == 1)
                {
                    return result.Ok(insertResult);
                }
                else
                {
                    return result.Error(insertResult);
                }
            }
            catch (Exception ex)
            {
                return result.Error($"Error al insertar producto: {ex.Message}");
            }
        }

        public ServiceResult ActualizarProducto(tbProductos producto)
        {
            var result = new ServiceResult();
            try
            {
                var updateResult = _productosRepository.Update(producto);
                if (updateResult.code_Status == 1)
                {
                    return result.Ok(updateResult);
                }
                else
                {
                    return result.Error(updateResult);
                }
            }
            catch (Exception ex)
            {
                return result.Error($"Error al actualizar producto: {ex.Message}");
            }
        }


        public async Task<IEnumerable<ListasPreciosVendedor>> ObtenerProductosDescuentoPrecioPorClienteVendedorAsync(int clieId, int vendId)
        {
            try
            {
                var productos = await _productosRepository.ObtenerProductosDescuentoPrecioPorClienteVendedorAsync(clieId, vendId);
                return productos;
            }
            catch (Exception ex)
            {
                // Loguear la excepción si tienes un sistema de logging
                // _logger.LogError(ex, "Error al obtener productos con descuento por cliente y vendedor");
                return Enumerable.Empty<ListasPreciosVendedor>();
            }
        }
        #endregion


        #region Inventario Bodega

        public IEnumerable<IniciarJornada> IniciarJornada(int Usua_Creacion, int Vend_Id)
        {
            try
            {
                var list = _inventarioBodegaRepository.InicioJornada( Usua_Creacion, Vend_Id);
                return list;
            }
            catch (Exception)
            {
                IEnumerable<IniciarJornada> resultado = null;
                return resultado;
            }
        }

        public IEnumerable<CerrarJornada> CierreJornada(int Vend_Id)
        {
            try
            {
                var list = _inventarioBodegaRepository.CierreJornada(Vend_Id);
                return list;
            }
            catch (Exception)
            {
                IEnumerable<CerrarJornada> resultado = null;
                return resultado;
            }
        }


        public ServiceResult ObtenerReporteJornadaDetallado(int vendId, DateTime? fecha = null)
        {
            var result = new ServiceResult();

            try
            {
                // 🔹 Validación básica
                if (vendId <= 0)
                {
                    return result.Error("El ID del vendedor debe ser mayor a 0");
                }

                // 🔹 Llamar al repository
                var reporte = _inventarioBodegaRepository.ObtenerReporteJornadaDetallado(vendId, fecha);

                // 🔹 Verificar si hay error (en este caso lo detectamos por si en el detalle viene un "Error: ...")
                if (reporte.Detalle.Any() && reporte.Detalle.First().Producto.StartsWith("Error:"))
                {
                    return result.Error(reporte.Detalle.First().Producto);
                }

                // 🔹 Validación adicional: si no hay datos en el detalle
                if (!reporte.Detalle.Any())
                {
                    return result.Ok("No se encontraron registros de jornada para el vendedor especificado.");
                }

                // 🔹 Respuesta exitosa
                return result.Ok(reporte);
            }
            catch (Exception ex)
            {
                return result.Error($"Error inesperado al obtener el reporte de jornada: {ex.Message}");
            }
        }



        public IEnumerable<InventarioAsignadoVendedorDTO> ObtenerInventarioAsignadoPorVendedor(int Vend_Id)
        {
            try
            {
                var list = _inventarioBodegaRepository.ObtenerInventarioAsignadoPorVendedor(Vend_Id);
                return list;
            }
            catch (Exception)
            {
                IEnumerable<InventarioAsignadoVendedorDTO> resultado = null;
                return resultado;
            }
        }


        public ServiceResult ObtenerJornadaActiva(int Vend_Id)
        {
            var result = new ServiceResult();
            try
            {
                // Validación básica
                if (Vend_Id <= 0)
                {
                    return result.Error("El ID del vendedor debe ser mayor a 0");
                }

                var jornadaActiva = _inventarioBodegaRepository.ObtenerJornadaActiva(Vend_Id);

                if (jornadaActiva == null)
                {
                    return result.Ok("No se encontró jornada activa para el vendedor especificado.");
                }

                return result.Ok(jornadaActiva);
            }
            catch (Exception ex)
            {
                return result.Error($"Error inesperado al obtener la jornada activa: {ex.Message}");
            }
        }


        #endregion

        #region Descuentos


        public IEnumerable<tbDescuentos> ListarDescuentos()
        {
            try
            {
                var list = _descuentosRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<tbDescuentos>();
            }
        }
        public ServiceResult Insertar(tbDescuentos descuento)
        {
            var result = new ServiceResult();
            try
            {
                var insertResult = _descuentosRepository.Insert(descuento);
                if (insertResult.code_Status > 0)
                {
                    return result.Ok(insertResult);
                }
                else
                {
                    return result.Error(insertResult);
                }
            }
            catch (Exception ex)
            {
                return result.Error($"Error al insertar producto: {ex.Message}");
            }
        }
        

        public ServiceResult ActualizarDescuentos(tbDescuentos descuento)
        {
            var result = new ServiceResult();
            try
            {
                var insertResult = _descuentosRepository.Update(descuento);
                if (insertResult.code_Status > 0)
                {
                    return result.Ok(insertResult);
                }
                else
                {
                    return result.Error(insertResult);
                }
            }
            catch (Exception ex)
            {
                return result.Error($"Error al actualizar descuento: {ex.Message}");
            }
        }


        public ServiceResult EliminarDescuento(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var deleteResult = _descuentosRepository.Delete(id);
                if (deleteResult.code_Status > 0)
                {
                    return result.Ok(deleteResult);
                }
                else
                {
                    return result.Error(deleteResult);
                }
            }
            catch (Exception ex)
            {
                return result.Error($"Error al eliminar descuento: {ex.Message}");
            }
        }
        #endregion

        #region Inventario Sucursal

        public IEnumerable<tbInventarioSucursales> ListInve(int id)
        {
            try
            {
                var list = _inventarioSucursalRepository.ListInve(id);
                return list;
            }
            catch (Exception)
            {
                IEnumerable<tbInventarioSucursales> resultado = null;
                return resultado;
            }
        }
        public IEnumerable<tbInventarioSucursalesHistorial> ListHistorialInve(int id)
        {
            try
            {
                var list = _historialInventarioSucursalesRepository.ListHistorialInve(id);
                return list;
            }
            catch (Exception)
            {
                IEnumerable<tbInventarioSucursalesHistorial> resultado = null;
                return resultado;
            }
        }

        public IEnumerable<tbInventarioSucursales>ListarPorSucursal(int id)
        {
            try
            {
                var list = _inventarioSucursalRepository.ListadoPorSucursal(id);
                return list;
            }
            catch (Exception)
            {
                IEnumerable<tbInventarioSucursales> resultado = null;
                return resultado;
            }
        }

        public IEnumerable<tbInventarioSucursales> ActualizarInventario(int sucu_id, int usua_id)
        {
            try
            {
                var list = _inventarioSucursalRepository.ActulizarInventario(sucu_id, usua_id);
                return list;
            }
            catch (Exception)
            {
                IEnumerable<tbInventarioSucursales> resultado = null;
                return resultado;
            }
        }

        public IEnumerable<tbInventarioSucursales> ActualizarCantidadesInventario(int usua_id, DateTime inSu_FechaModificacion, string xmlData)
        {
            try
            {
                var list = _inventarioSucursalRepository.ActualizarCantidadesInventario(usua_id, inSu_FechaModificacion, xmlData);
                return list;
            }
            catch (Exception)
            {
                IEnumerable<tbInventarioSucursales> resultado = null;
                return resultado;
            }
        }


        #endregion


        #region Promociones

        public IEnumerable<tbProductos> ListarPromociones()
        {
            try
            {
                var list = _promocionesRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<tbProductos>();
            }
        }
        public ServiceResult InsertarPromocines(tbProductos producto)
        {
            var result = new ServiceResult();
            try
            {
                var insertResult = _promocionesRepository.Insert(producto);
       
                
                    return result.Ok(insertResult);
                
            }
            catch (Exception ex)
            {
                return result.Error($"Error al insertar producto: {ex.Message}");
            }
        }

        public ServiceResult ActualizarPromocines(tbProductos producto)
        {
            var result = new ServiceResult();
            try
            {
                var insertResult = _promocionesRepository.Update(producto);


                return result.Ok(insertResult);

            }
            catch (Exception ex)
            {
                return result.Error($"Error al insertar producto: {ex.Message}");
            }
        }

        public ServiceResult CambiarEstadoPromociones(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var deleteResult = _promocionesRepository.Delete(id);
                if (deleteResult.code_Status > 0)
                {
                    return result.Ok(deleteResult);
                }
                else
                {
                    return result.Error(deleteResult);
                }
            }
            catch (Exception ex)
            {
                return result.Error($"Error al eliminar descuento: {ex.Message}");
            }
        }
        #endregion Promociones
    }
}
