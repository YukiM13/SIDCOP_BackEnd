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

    private readonly DepartamentoRepository _departamentoRepository;
        private readonly MarcaVehiculoRepository _marcaVehiculoRepository;
        private readonly ColoniaRepository _coloniaRepository;
        private readonly EstadoCivilRepository _estadocivilRepository; 
        private readonly MarcaRepository _marcaRepository;
        private readonly ClienteRepository _clienteRepository;
        private readonly EmpleadoRepository _empleadoRepository;
        private readonly SucursalesRepository _sucursalesRepository;


        public GeneralServices(ColoniaRepository coloniaRepository, EstadoCivilRepository estadoCivilRepository,
            MarcaRepository marcaRepository, ClienteRepository clienteRepository,
             EmpleadoRepository empleadoRepository, SucursalesRepository sucursalesRepository,
             DepartamentoRepository departamentoRepository, MarcaVehiculoRepository marcaVehiculoRepository)
        {
            _estadocivilRepository = estadoCivilRepository;
            _sucursalesRepository = sucursalesRepository;
            _coloniaRepository = coloniaRepository;

            _marcaRepository = marcaRepository;
            _clienteRepository = clienteRepository;
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


        #endregion


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
        #endregion

    }
}
