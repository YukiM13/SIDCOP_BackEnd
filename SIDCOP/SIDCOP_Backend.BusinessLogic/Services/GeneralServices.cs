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
        private readonly ClienteRepository _clienteRepository;
        private readonly MarcaRepository _marcaRepository;

        public GeneralServices(EstadoCivilRepository estadocivilRepository, SucursalesRepository sucursalesRepository, ColoniaRepository coloniaRepository, ClienteRepository clienteRepository)
        {
            _estadocivilRepository = estadocivilRepository;
            _sucursalesRepository = sucursalesRepository;
            _coloniaRepository = coloniaRepository;
            _clienteRepository = clienteRepository;
            _marcaRepository = marcaRepository;

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

        public ServiceResult InsertEsCi(tbEstadosCiviles item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _estadocivilRepository.InsertEsCi(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarEsCi(tbEstadosCiviles item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _estadocivilRepository.ActualizarEsCi(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarEsCi(tbEstadosCiviles item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _estadocivilRepository.EliminarEsCi(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarEsCi(tbEstadosCiviles item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _estadocivilRepository.BuscarEsCi(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


        #endregion

        #region Marcas

        public IEnumerable<tbMarcas> ListMarcas()
        {
            var result = new ServiceResult();
            try
            {
                var list = _marcaRepository.List();
                return list;
            }
            catch (Exception ex)
            {

                IEnumerable<tbMarcas> marc = null;
                return marc;
            }
        }

        public ServiceResult InsertMarca(tbMarcas item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _marcaRepository.InsertMarca(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarMarca(tbMarcas item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _marcaRepository.ActualizarMarca(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarMarca(tbMarcas item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _marcaRepository.EliminarMarca(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarMarca(tbMarcas item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _marcaRepository.BuscarMarca(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion

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
                IEnumerable<tbSucursales> sucursales = null;
                return sucursales;
            }
        }

        public ServiceResult InsertarSucursal(tbSucursales sucursal)
        {
            var result = new ServiceResult();
            try
            {
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

        #region Clientes
        public ServiceResult InsertCliente(tbClientes item)
        {
            var result = new ServiceResult();
            try
            {
                var insert = _clienteRepository.Insert(item);
                return result.Ok(insert);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

    }
}
