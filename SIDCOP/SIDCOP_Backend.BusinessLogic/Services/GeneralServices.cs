using SIDCOP_Backend.DataAccess.Repositories.Acceso;
using SIDCOP_Backend.DataAccess.Repositories.General;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIDCOP_Backend.DataAccess;

namespace SIDCOP_Backend.BusinessLogic.Services
{
    public class GeneralServices
    {
        private readonly EstadoCivilRepository _estadocivilRepository;
        private readonly SucursalesRepository _sucursalesRepository;
        private readonly ColoniaRepository _coloniaRepository;
        private readonly EstadoCivilRepository _estadocivilRepository;
        private readonly ModeloRepository _modeloRepository;
        private readonly ProveedoresRepository _proveedoresRepository;

        public GeneralServices(ColoniaRepository coloniaRepository, EstadoCivilRepository estadoCivilRepository, ModeloRepository modeloRepository, ProveedoresRepository proveedoresRepository)
        private readonly ClienteRepository _clienteRepository;

        public GeneralServices(EstadoCivilRepository estadocivilRepository, SucursalesRepository sucursalesRepository, ColoniaRepository coloniaRepository, ClienteRepository clienteRepository)
        {
            _estadocivilRepository = estadocivilRepository;
            _sucursalesRepository = sucursalesRepository;
            _coloniaRepository = coloniaRepository;
            _estadocivilRepository = estadoCivilRepository;
            _modeloRepository = modeloRepository;
            _proveedoresRepository = proveedoresRepository;
            _clienteRepository = clienteRepository;

        }


        #region Colonias 

        public IEnumerable<tbColonias> ListarColonia()
        {
            var result = new ServiceResult();
            try
            {
                var list = _coloniaRepository.List();
                return list;
            }
            catch (Exception ex)
            {

                IEnumerable<tbColonias> colonia = null;
                return colonia;
            }
        }
        #endregion


        #region Estados Civiles
        public IEnumerable<tbEstadosCiviles> ListEsCi()
        {
            var result = new ServiceResult();
            try
            {
                var list = _estadocivilRepository.List();
                return list;
            }
            catch (Exception ex)
            {

                IEnumerable<tbEstadosCiviles> esci = null;
                return esci;
            }
        }
        #endregion

        #region Modelos

        public IEnumerable<tbModelos> ListModelos()
        {
            try
            {
                var list = _modeloRepository.List();
        #region Sucursales

        public IEnumerable<tbSucursales> ListSucursales()
        {
            var result = new ServiceResult();
            try
            {
                var list = _sucursalesRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                List<tbModelos> lista = null;
                return lista;
            }
        }

        public ServiceResult InsertarModelo(tbModelos item)
                IEnumerable<tbSucursales> sucursales = null;
                return sucursales;
            }
        }

        public ServiceResult InsertarSucursal(tbSucursales sucursal)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _modeloRepository.Insert(item);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarModelo(tbModelos item)
                var insertResult = _sucursalesRepository.Insert(sucursal);

                if (insertResult.code_Status == 1)
                {
                    //result.Ok = true;
                    //result.Message = ;
                    return result.Ok(insertResult.message_Status);
                    //return result.Ok(insertResult.message_Status);
                }
                else
                {
                    //result.IsSuccess = false;
                    //result.Message = insertResult.message_Status;
                    //return result.Error(insertResult.message_Status);
                    return result.Error(insertResult.message_Status);
                }

            }
            catch (Exception ex)
            {
                //return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
                //return result.Error($"Error al insertar carro: {ex.Message}");
                return result.Error($"Error al insertar sucursal: {ex.Message}");
            }
        }

        public ServiceResult ActualizarSucursal(tbSucursales sucursal)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _modeloRepository.Update(item);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarModelo(tbModelos item)
                var updateResult = _sucursalesRepository.Update(sucursal);
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
                return result.Error($"Error al actualizar sucursal: {ex.Message}");
            }
        }

        public ServiceResult EliminarSucursal(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _modeloRepository.Delete(item);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarModelo(tbModelos item)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _modeloRepository.FindCodigo(item);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
                var deleteResult = _sucursalesRepository.Delete(id);
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

        public tbSucursales BuscarSucursal(int? id)
        {
            try
            {
                var sucursal = _sucursalesRepository.Find(id);
                return sucursal;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar sucursal: {ex.Message}");
            }
        }

        #endregion

        #region Proveedores

        public IEnumerable<tbProveedores> ListProveedores()
        {
            try
            {
                var list = _proveedoresRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                List<tbProveedores> lista = null;
                return lista;
            }
        }

        public ServiceResult InsertarProveedor(tbProveedores item)
        #region Clientes
        public ServiceResult InsertCliente(tbClientes item)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _proveedoresRepository.Insert(item);
                return result.Ok(resultado);
                var insert = _clienteRepository.Insert(item);
                return result.Ok(insert);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarProveedor(tbProveedores item)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _proveedoresRepository.Update(item);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarProveedor(tbProveedores item)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _proveedoresRepository.Delete(item);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarProveedor(tbProveedores item)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _proveedoresRepository.FindCodigo(item);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion
        #endregion

    }
}
