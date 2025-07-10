using SIDCOP_Backend.DataAccess.Repositories.General;
using SIDCOP_Backend.DataAccess.Repositories.Ventas;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.BusinessLogic.Services
{
    public class VentaServices
    {
        private readonly VendedorRepository _vendedorRepository;
        public VentaServices(VendedorRepository vendedorRepository)
        {
            _vendedorRepository = vendedorRepository;
        }

        #region Vendedores

        public IEnumerable<tbVendedores> ListarVendedores()
        {
            try
            {
                var list = _vendedorRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("Error al listar vendedores: " + ex.Message);
            }
        }

        public ServiceResult InsertarVendedor(tbVendedores vendedores)
        {
            var result = new ServiceResult();
            try
            {
                var insertResult = _vendedorRepository.Insert(vendedores);

                if (insertResult.code_Status == 1)
                {
                    return result.Ok(insertResult.message_Status);;
                }
                else
                {
                    return result.Error(insertResult.message_Status);
                }

            }
            catch (Exception ex)
            {
                return result.Error($"Error al insertar sucursal: {ex.Message}");
            }
        }

        public ServiceResult ActualizarVendedor(tbVendedores vendedor)
        {
            var result = new ServiceResult();
            try
            {
                var updateResult = _vendedorRepository.Update(vendedor);
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
                return result.Error($"Error al actualizar vendedor: {ex.Message}");
            }
        }

        public ServiceResult EliminarVendedor(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var deleteResult = _vendedorRepository.Delete(id);
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

        public tbVendedores BuscarVendedor(int? id)
        {
            try
            {
                var vendedor = _vendedorRepository.Find(id);
                return vendedor;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar sucursal: {ex.Message}");
            }
        }


        #endregion

    }
}
