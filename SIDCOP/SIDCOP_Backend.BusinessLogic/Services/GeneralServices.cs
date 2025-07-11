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
        private readonly MunicipioRepository _municipioRepository;
        private readonly DepartamentoRepository _departamentoRepository;
        private readonly MarcaVehiculoRepository _marcaVehiculoRepository;
        private readonly EstadoCivilRepository _estadocivilRepository;
        private readonly SucursalesRepository _sucursalesRepository;
        private readonly ColoniaRepository _coloniaRepository;
        private readonly ClienteRepository _clienteRepository;
        private readonly CanalRepository _canalRepository;
        private readonly MarcaRepository _marcaRepository;
        private readonly EmpleadoRepository _empleadoRepository;

        public GeneralServices(EstadoCivilRepository estadocivilRepository, SucursalesRepository sucursalesRepository,
        ColoniaRepository coloniaRepository, ClienteRepository clienteRepository, CanalRepository canalRepository,
        EmpleadoRepository empleadoRepository, MarcaRepository marcaRepository,
        DepartamentoRepository departamentoRepository, MarcaVehiculoRepository marcaVehiculoRepository, MunicipioRepository municipioRepository)
        {
            _estadocivilRepository = estadocivilRepository;
            _sucursalesRepository = sucursalesRepository;
            _coloniaRepository = coloniaRepository;

            _marcaRepository = marcaRepository;
            _clienteRepository = clienteRepository;
            _municipioRepository = municipioRepository;
            _canalRepository = canalRepository;

            _empleadoRepository = empleadoRepository;
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

        #endregion Departamentos

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

        #endregion MarcasVehiculos

        #region Empleados

        public IEnumerable<tbEmpleados> ListarEmpleado()
        {
            var result = new ServiceResult();
            try
            {
                var list = _empleadoRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbEmpleados> empleados = null;
                return empleados;
            }
        }

        public ServiceResult InsertarEmpleados(tbEmpleados item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _empleadoRepository.Insert(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdateEmpleados(tbEmpleados empleados)
        {
            var result = new ServiceResult();
            try
            {
                var response = _empleadoRepository.Update(empleados);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult DeleteEmpleado(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var deleteResult = _empleadoRepository.Delete(id);
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
                return result.Error($"Error al eliminar: {ex.Message}");
            }
        }

        public tbEmpleados FindEmpleados(int? id)
        {
            try
            {
                var sucursal = _empleadoRepository.Find(id);
                return sucursal;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar : {ex.Message}");
            }
        }

        #endregion Empleados

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

        public ServiceResult InsertarColonia(tbColonias item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _coloniaRepository.Insert(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdateColonia(tbColonias colonia)
        {
            var result = new ServiceResult();
            try
            {
                var response = _coloniaRepository.Update(colonia);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult DeleteColonia(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var deleteResult = _coloniaRepository.Delete(id);
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
                return result.Error($"Error al eliminar : {ex.Message}");
            }
        }

        public tbColonias BuscarColonia(int? id)
        {
            try
            {
                var colonia = _coloniaRepository.Find(id);
                return colonia;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar : {ex.Message}");
            }
        }

        #endregion Colonias

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

        public ServiceResult EliminarEsCi(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var deleteResult = _estadocivilRepository.EliminarEsCi(id);
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
                return result.Error($"Error al eliminar el Estado Civil: {ex.Message}");
            }
        }

        public tbEstadosCiviles BuscarEsCi(int? id)
        {
            try
            {
                var EsCi = _estadocivilRepository.BuscarEsCi(id);
                return EsCi;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar el Estado Civil: {ex.Message}");
            }
        }

        #endregion Estados Civiles

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

        public ServiceResult EliminarMarca(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var deleteResult = _marcaRepository.EliminarMarca(id);
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
                return result.Error($"Error al eliminar la Marca: {ex.Message}");
            }
        }

        public tbMarcas BuscarMarca(int? id)
        {
            try
            {
                var marca = _marcaRepository.BuscarMarca(id);
                return marca;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar marca: {ex.Message}");
            }
        }

        #endregion Marcas

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

        #endregion Sucursales

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

        public ServiceResult UpdateCliente(tbClientes item)
        {
            var result = new ServiceResult();
            try
            {
                var insert = _clienteRepository.Update(item);
                return result.Ok(insert);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public tbClientes BuscarCliente(int? id)
        {
            try
            {
                var cliente = _clienteRepository.Find(id);
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar cliente: {ex.Message}");
            }
        }

        public ServiceResult CambioEstadoCliente(int? id, DateTime? fecha)
        {
            var result = new ServiceResult();
            try
            {
                var deleteResult = _clienteRepository.ChangeState(id, fecha);
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

        public IEnumerable<tbClientes> ListClientes()
        {
            var result = new ServiceResult();
            try
            {
                var list = _clienteRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbClientes> clientes = null;
                return clientes;
            }
        }

        #endregion Clientes

        #region Canales

        public IEnumerable<tbCanales> ListarCanales()
        {
            var result = new ServiceResult();
            try
            {
                var list = _canalRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbCanales> canales = null;
                return canales;
            }
        }

        public ServiceResult InsertarCanal(tbCanales item)
        {
            var result = new ServiceResult();
            try
            {
                var insert = _canalRepository.Insert(item);
                return result.Ok(insert);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarCanal(tbCanales item)
        {
            var result = new ServiceResult();
            try
            {
                var update = _canalRepository.Update(item);
                return result.Ok(update);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarCanal(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var delete = _canalRepository.Delete(id);
                if (delete.code_Status == 1)
                {
                    return result.Ok(delete.message_Status);
                }
                else
                {
                    return result.Error(delete.message_Status);
                }
            }
            catch (Exception ex)
            {
                return result.Error($"Error al eliminar sucursal: {ex.Message}");
            }
        }

        public tbCanales BuscarCanal(int? id)
        {
            try
            {
                var canal = _canalRepository.Find(id);
                return canal;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar canal: {ex.Message}");
            }
        }

        #endregion Canales

        #region Municipios

        public ServiceResult InsertarMunicipios(tbMunicipios item)
        {
            var result = new ServiceResult();
            try
            {
                var muni = _municipioRepository.Insert(item);
                if (muni.code_Status == 1)
                {
                    return result.Ok(muni.message_Status);
                }
                else
                {
                    return result.Error(muni.message_Status);

                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarMunicipios(tbMunicipios item)
        {
            var result = new ServiceResult();
            try
            {
                var muni = _municipioRepository.Update(item);
                if (muni.code_Status == 1)
                {
                    return result.Ok(muni.message_Status);

                }
                else
                {
                    return result.Error(muni.message_Status);

                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public IEnumerable<tbMunicipios> ListarMunicipios()
        {
            var result = new ServiceResult();
            try
            {
                var list = _municipioRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbMunicipios> muni = null;
                return muni;
            }
        }

        public ServiceResult EliminarMunicipio(string id)
        {
            var result = new ServiceResult();
            try
            {
              
                    var list = _municipioRepository.DeleteConCodigo(id);
                if (list.code_Status == 1)
                {
                    return result.Ok(list.message_Status);

                }
                else
                {
                    return result.Error(list.message_Status);

                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public tbMunicipios BuscarMunicipio(string id)
        {
            //  var result = new ServiceResult();
            try
            {
                var list = _municipioRepository.FindConCodigo(id);
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar departamento: {ex.Message}");
            }
        }

        #endregion Municipios
    }
}