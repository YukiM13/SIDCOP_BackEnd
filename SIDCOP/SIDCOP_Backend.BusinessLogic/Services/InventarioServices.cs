using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.DataAccess.Repositories.General;
using SIDCOP_Backend.DataAccess.Repositories.Inventario;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.BusinessLogic.Services
{
    public class InventarioServices
    {
        private readonly ProductosRepository _productosRepository;
        public InventarioServices(ProductosRepository productosRepository)
        {
            _productosRepository = productosRepository;
        }

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

    }
}
