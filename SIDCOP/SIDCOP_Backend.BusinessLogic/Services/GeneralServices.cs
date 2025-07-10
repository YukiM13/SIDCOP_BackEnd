using SIDCOP_Backend.DataAccess.Repositories.Acceso;
using SIDCOP_Backend.DataAccess.Repositories.General;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.BusinessLogic.Services
{
    public class GeneralServices
    {
        private readonly DepartamentoRepository _departamentoRepository;
        private readonly MarcaVehiculoRepository _marcaVehiculoRepository;

        public GeneralServices(DepartamentoRepository departamentoRepository, MarcaVehiculoRepository marcaVehiculoRepository)
        {
            _departamentoRepository = departamentoRepository;
            _marcaVehiculoRepository = marcaVehiculoRepository;
        }

        #region Departamentos
        public ServiceResult InsertarDepartamento(tbDepartamentos item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _departamentoRepository.Insert(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EditarDepartamento(tbDepartamentos item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _departamentoRepository.Update(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarDepartamento(string id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _departamentoRepository.DeleteConCodigo(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


        public tbDepartamentos BuscarDepartamento(string id)
        {
          //  var result = new ServiceResult();
            try
            {
                var list = _departamentoRepository.FindConCodigo(id);
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar departamento: {ex.Message}");
            }
        }

        public IEnumerable<tbDepartamentos> ListarDepartamentos()
        {
            var result = new ServiceResult();
            try
            {
                var list = _departamentoRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbDepartamentos> usua = null;
                return usua;
            }
        }
        #endregion

        #region MarcasVehiculos
        public ServiceResult InsertarMarcaVehiculo(tbMarcasVehiculos item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _marcaVehiculoRepository.Insert(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EditarMarcaVehiculo(tbMarcasVehiculos item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _marcaVehiculoRepository.Update(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarMarcavehiculo(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var deleteResult = _marcaVehiculoRepository.Delete(id);
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


        public tbMarcasVehiculos BuscarMarcaVehiculo(int id)
        {
            try
            {
                var marcavehiculo = _marcaVehiculoRepository.Find(id);
                return marcavehiculo;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar marca del vehiculo: {ex.Message}");
            }
        }

        public IEnumerable<tbMarcasVehiculos> ListarMarcaVehiculo()
        {
            var result = new ServiceResult();
            try
            {
                var list = _marcaVehiculoRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbMarcasVehiculos> usua = null;
                return usua;
            }
        }
        #endregion

    }
}
