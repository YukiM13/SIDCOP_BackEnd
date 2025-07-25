using SIDCOP_Backend.Entities.Entities;
using SIDCOP_Backend.DataAccess.Repositories.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public InventarioServices(CategoriasRepository categoriasRepository, SubcategoriasRepository subcategoriasRepository,
       ProductosRepository productosRepository, InventarioSucursalRepository inventarioSucursalRepository,
       InventarioBodegaRepository inventarioBodegaRepository, DescuentosRepository descuentosRepository)
       {
           _categoriasRepository = categoriasRepository;
           _subcategoriasRepository = subcategoriasRepository;
           _productosRepository = productosRepository;
           _inventarioSucursalRepository = inventarioSucursalRepository;
           _inventarioBodegaRepository = inventarioBodegaRepository;
           _descuentosRepository = descuentosRepository;
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
                var deleteResult = _productosRepository.Delete(id);
                if (deleteResult.code_Status == 1)
                {
                    return result.Ok(deleteResult.message_Status);
                }
                else
                {
                    return result.Error(deleteResult.message_Status);
                }
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

        public ServiceResult InsertarProducto(tbProductos producto)
        {
            var result = new ServiceResult();
            try
            {
                var insertResult = _productosRepository.Insert(producto);
                if (insertResult.code_Status == 1)
                {
                    return result.Ok(insertResult.message_Status);
                }
                else
                {
                    return result.Error(insertResult.message_Status);
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
                    return result.Ok(updateResult.message_Status);
                }
                else
                {
                    return result.Error(updateResult.message_Status);
                }
            }
            catch (Exception ex)
            {
                return result.Error($"Error al actualizar producto: {ex.Message}");
            }
        }
        #endregion


        #region Inventario Bodega

 
        public IEnumerable<tbInventarioBodegas>BuscarInventarioPorVendedor(int id)
        {
            try
            {
                var list = _inventarioBodegaRepository.Listprodvend(id);
                return list;
            }
            catch (Exception)
            {
                IEnumerable<tbInventarioBodegas> resultado = null;
                return resultado;
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
        public ServiceResult InsertarDescuentoDetalle(tbDescuentosDetalle descuento)
        {
            var result = new ServiceResult();
            try
            {
                var insertResult = _descuentosRepository.InsertDetails(descuento);
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


        public ServiceResult InsertarDescuentoPorCliente(tbDescuentoPorClientes descuento)
        {
            var result = new ServiceResult();
            try
            {
                var insertResult = _descuentosRepository.InsertDetailsClientes(descuento);
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

        public ServiceResult InsertarDescuentoPorEscala(tbDescuentosPorEscala descuento)
        {
            var result = new ServiceResult();
            try
            {
                var insertResult = _descuentosRepository.InsertDetallesEscala(descuento);
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
        #endregion
    }
}
