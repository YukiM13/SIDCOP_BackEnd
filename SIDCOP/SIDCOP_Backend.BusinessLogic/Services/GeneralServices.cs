using SIDCOP_Backend.DataAccess.Repositories.Acceso;
using SIDCOP_Backend.DataAccess.Repositories.General;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIDCOP_Backend.DataAccess.Repositories.Ventas;
using SIDCOP_Backend.DataAccess.Repositories.Inventario;

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
        private readonly ModeloRepository _modeloRepository;
        private readonly ProveedoresRepository _proveedoresRepository;
        private readonly CargoRepository _cargoRepository;
        private readonly DireccionesPorClienteRepository _direccionesPorClienteRepository;
        private readonly PaisRepository _paisRepository;
        private readonly TipoDeViviendaRepository _tipoDeViviendaRepository;
        private readonly AvalRepository _avalRepository;
        private readonly ParentescoRepository _parentescoRepository;
        private readonly ClientesVisitaHistorialRepository _clientesVisitaHistorialRepository;
        private readonly EstadoVisitaRepository _estadoVisitaRepository;
        private readonly ImagenVisitaRepository _imagenVisitaRepository;
        private readonly FormasDePagoRepository _formasDePagoRepository;

        public GeneralServices(EstadoCivilRepository estadocivilRepository, SucursalesRepository sucursalesRepository,
        ColoniaRepository coloniaRepository, ClienteRepository clienteRepository, CanalRepository canalRepository,
        EmpleadoRepository empleadoRepository, MarcaRepository marcaRepository, CargoRepository cargoRepository,
        DepartamentoRepository departamentoRepository, MarcaVehiculoRepository marcaVehiculoRepository,
        ModeloRepository modeloRepository, ProveedoresRepository proveedoresRepository,
        MunicipioRepository municipioRepository, DireccionesPorClienteRepository direccionesPorClienteRepository,
        PaisRepository paisRepository, TipoDeViviendaRepository tipoDeViviendaRepository, AvalRepository avalRepository,
        ParentescoRepository parentescoRepository, ClientesVisitaHistorialRepository clientesVisitaHistorialRepository,
        EstadoVisitaRepository estadoVisitaRepository,
        ImagenVisitaRepository imagenVisitaRepository,
        FormasDePagoRepository formasDePagoRepository
        )
        {
            _direccionesPorClienteRepository = direccionesPorClienteRepository;
            _coloniaRepository = coloniaRepository;

            _marcaRepository = marcaRepository;
            _clienteRepository = clienteRepository;
            _municipioRepository = municipioRepository;
            _canalRepository = canalRepository;
            _sucursalesRepository = sucursalesRepository;
            _estadocivilRepository = estadocivilRepository;

            _empleadoRepository = empleadoRepository;
            _departamentoRepository = departamentoRepository;
            _marcaVehiculoRepository = marcaVehiculoRepository;
            _modeloRepository = modeloRepository;
            _proveedoresRepository = proveedoresRepository;
            _sucursalesRepository = sucursalesRepository;
            _avalRepository = avalRepository;

            _clienteRepository = clienteRepository;
            _marcaRepository = marcaRepository;
            _empleadoRepository = empleadoRepository;
            _cargoRepository = cargoRepository;

            _paisRepository = paisRepository;
            _tipoDeViviendaRepository = tipoDeViviendaRepository;
            _parentescoRepository = parentescoRepository;
            _clientesVisitaHistorialRepository = clientesVisitaHistorialRepository;
            _estadoVisitaRepository = estadoVisitaRepository;
            _imagenVisitaRepository = imagenVisitaRepository;
            _formasDePagoRepository = formasDePagoRepository;
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
                return null;
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
                    return result.Ok(deleteResult);
                }
                else
                {
                    return result.Error(deleteResult);
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
                return null;
            }
        }

        public tbMarcasVehiculos BuscarModeloDeMarca(int id)
        {
            try
            {
                var marcavehiculo = _marcaVehiculoRepository.Modelos(id);
                return marcavehiculo;
            }
            catch (Exception ex)
            {
                return null;
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
                return null;
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

        public IEnumerable<tbColonias> ListarMunicipiosyDepartamentos()
        {
            var result = new ServiceResult();
            try
            {
                var list = _coloniaRepository.ListMunicipiosyDepartamentos();
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
                return result.Ok(deleteResult);
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
                return null;
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
                var list = _estadocivilRepository.EliminarEsCi(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
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
                return null;
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
                var list = _marcaRepository.EliminarMarca(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
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
                return null;
            }
        }

        #endregion Marcas

        #region Modelos

        public IEnumerable<tbModelos> ListModelos()
        {
            try
            {
                var list = _modeloRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                List<tbModelos> lista = null;
                return lista;
            }
        }

        public ServiceResult InsertarModelo(tbModelos item)
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

        public ServiceResult EliminarModelo(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _modeloRepository.Delete(id);
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
                return null;
                //return result.Error($"Error al eliminar sucursal: {ex.Message}");BuscarClientePorVendedor
            }
        }

        public IEnumerable<tbClientes> BuscarClientePorRuta(int? id)
        {
            try
            {
                var cliente = _clienteRepository.FindPorVendedor(id);
                return cliente;
            }
            catch (Exception ex)
            {
                return null;
                //return result.Error($"Error al eliminar sucursal: {ex.Message}");
            }
        }


        public IEnumerable<ClientesPorVendedorDTO> BuscarClientePorVendedor(int id)
        {
            try
            {
                var cliente = _clienteRepository.ListarVendedorPorCliente(id);
                return cliente;
            }
            catch (Exception ex)
            {
                return null;
                //return result.Error($"Error al eliminar sucursal: {ex.Message}");BuscarClientePorVendedor
            }
        }

        public tbClientes BuscarVendedor(int? id)
        {
            try
            {
                var cliente = _clienteRepository.Find(id);
                return cliente;
            }
            catch (Exception ex)
            {
                return null;
                //return result.Error($"Error al eliminar sucursal: {ex.Message}");
            }
        }



        public IEnumerable<ClientesPorVendedorDTO> BuscarVendedor(int vend_Id)
        {
            try
            {
                var cliente = _clienteRepository.ListarVendedorPorCliente(vend_Id);
                return cliente;
            }
            catch (Exception ex)
            {
                return null;
                //return result.Error($"Error al eliminar sucursal: {ex.Message}");
            }
        }

        public ClienteCambiarEstadoDTO CambiarEstadoCliente(int clie_Id, DateTime fechaActual)
        {
            return _clienteRepository.ChangeState(clie_Id, fechaActual);
        }

        public IEnumerable<tbClientes> ListClientesConfirmados()
        {
            var result = new ServiceResult();
            try
            {
                var list = _clienteRepository.ListConfirmados().OrderByDescending(x => x.Clie_Estado);
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbClientes> clientes = null;
                return clientes;
            }
        }

        public IEnumerable<tbClientes> ListClientesSinConfirmacion()
        {
            var result = new ServiceResult();
            try
            {
                var list = _clienteRepository.ListSinConfirmacion();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbClientes> clientes = null;
                return clientes;
            }
        }
        #endregion Clientes

        #region ClientesVisitaHistorial
        public ServiceResult InsertVisitaCliente(VisitaClientePorVendedorDTO item)
        {
            var result = new ServiceResult();
            try
            {
                var insert = _clientesVisitaHistorialRepository.InsertVisita(item);
                return result.Ok(insert);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        //public IEnumerable<tbClientesVisita> ListVisitasClientes()
        //{
        //    var result = new ServiceResult();
        //    try
        //    {
        //        return _clientesVisitaHistorialRepository.List();
        //    }
        //    catch (Exception ex)
        //    {
        //        IEnumerable<tbClientesVisita> visitas = null;
        //        return visitas;
        //    }
        //}

        public IEnumerable<tbClientesVisita> ListVisitasClientes()
        {
            var result = new ServiceResult();
            try
            {
                var list = _clientesVisitaHistorialRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbClientesVisita> clvi = null;
                return clvi;
            }
        }

        public IEnumerable<VisitaClientePorVendedorDTO> VisitasPorVendedor(int vend_Id)
        {
            var result = new ServiceResult();
            try
            {
                var lista = _clientesVisitaHistorialRepository.VisitasPorVendedor(vend_Id);
                return lista;
            }
            catch (Exception ex)
            {
                IEnumerable<VisitaClientePorVendedorDTO> visitas = null;
                return visitas;
            }
        }

        public tbClientesVisita BuscarVisitaPorVendedor(int? id)
        {
            try
            {
                var cliente = _clientesVisitaHistorialRepository.FindByVendedor(id);
                return cliente;
            }
            catch (Exception ex)
            {
                return null;
                //return result.Error($"Error al eliminar sucursal: {ex.Message}");
            }
        }

        #endregion ClientesVisitaHistorial

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
                return result.Ok(delete);

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
                return null;
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
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _proveedoresRepository.Insert(item);
                return result.Ok(resultado);
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

        public ServiceResult EliminarProveedor(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _proveedoresRepository.Delete(id);
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

        #region Avales

        public IEnumerable<tbAvales> ListarAvales()
        {
            var result = new ServiceResult();
            try
            {
                var list = _avalRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbAvales> aval = null;
                return aval;
            }
        }
        public ServiceResult InsertarAval(tbAvales item)
        {
            var result = new ServiceResult();
            try
            {
                var insert = _avalRepository.Insert(item);
                return result.Ok(insert);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarAval(tbAvales item)
        {
            var result = new ServiceResult();
            try
            {
                var update = _avalRepository.Update(item);
                return result.Ok(update);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarAval(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _avalRepository.Delete(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion Avales

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
                    return result.Ok(insertResult);
                }
                else
                {
                    return result.Error(insertResult);
                }

            }
            catch (Exception ex)
            {
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
                    return result.Ok(updateResult);
                }
                else
                {
                    return result.Error(updateResult);
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
                var list = _sucursalesRepository.Delete(id);
                return result.Ok(list);
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

        #region Cargos
        public IEnumerable<tbCargos> ListarCargos()
        {
            var result = new ServiceResult();
            try
            {
                var list = _cargoRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbCargos> cargos = null;
                return cargos;
            }
        }

        public ServiceResult InsertarCargo(tbCargos item)
        {
            var result = new ServiceResult();
            try
            {
                var insert = _cargoRepository.Insert(item);
                return result.Ok(insert);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarCargo(tbCargos item)
        {
            var result = new ServiceResult();
            try
            {
                var update = _cargoRepository.Update(item);
                return result.Ok(update);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult EliminarCargo(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _cargoRepository.Delete(id);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //public ServiceResult EliminarCargo(int? id)
        //{
        //    var result = new ServiceResult();
        //    try
        //    {
        //        var delete = _cargoRepository.Delete(id);
        //        if (delete.code_Status == 1)
        //        {
        //            return result.Ok(delete.message_Status);
        //        }
        //        else
        //        {
        //            return result.Error(delete.message_Status);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return result.Error($"Error al eliminar cargo: {ex.Message}");
        //    }
        //}

        public tbCargos BuscarCargo(int? id)
        {
            try
            {
                var cargo = _cargoRepository.Find(id);
                return cargo;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar cargo: {ex.Message}");
            }
        }
        #endregion

        #region Municipios

        public ServiceResult InsertarMunicipios(tbMunicipios item)
        {
            var result = new ServiceResult();
            try
            {
                var muni = _municipioRepository.Insert(item);

                return result.Ok(muni);

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

                return result.Ok(muni);



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

                return result.Ok(list);



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

        public IEnumerable<tbSucursales> Municipio_ListarSucursales(string id)
        {
            //  var result = new ServiceResult();
            try
            {
                var list = _municipioRepository.SucursalesPorMunicipio(id);
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbSucursales> muni = null;
                return muni;
            }
        }

        #endregion Municipios

        #region DireccionesPorCliente


        public ServiceResult InsertarDireccionPorCliente(tbDireccionesPorCliente item)
        {
            var result = new ServiceResult();
            try
            {
                var insert = _direccionesPorClienteRepository.Insert(item);
                return result.Ok(insert);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarDireccionPorCliente(tbDireccionesPorCliente item)
        {
            var result = new ServiceResult();
            try
            {
                var update = _direccionesPorClienteRepository.Update(item);
                return result.Ok(update);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public IEnumerable<tbDireccionesPorCliente> DireccionesPorCliente_Buscar(int? id)
        {
            try
            {
                var direccionesPorCliente = _direccionesPorClienteRepository.Find(id);
                return direccionesPorCliente;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar cargo: {ex.Message}");
            }
        }
        public IEnumerable<tbDireccionesPorCliente> ListarDireccionesPorCliente()
        {
            var result = new ServiceResult();
            try
            {
                var list = _direccionesPorClienteRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbDireccionesPorCliente> direccionesPorCliente = null;
                return direccionesPorCliente;
            }
        }


        public ServiceResult EliminarDireccionesPorCliente(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _direccionesPorClienteRepository.Delete(id);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion


        #region Paises

        public IEnumerable<tbPaises> ListarPaises()
        {
            var result = new ServiceResult();
            try
            {
                var list = _paisRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbPaises> pais = null;
                return pais;
            }
        }


        //public IEnumerable<tbSucursales> Pais_ListarDepartamentos(string codigo)
        //{
        //    //  var result = new ServiceResult();
        //    try
        //    {
        //        var list = _municipioRepository.SucursalesPorMunicipio(codigo);
        //        return list;
        //    }
        //    catch (Exception ex)
        //    {
        //        IEnumerable<tbSucursales> muni = null;
        //        return muni;
        //    }
        //}

        #endregion Paises

        #region TiposDeVivienda
        public IEnumerable<tbTiposDeVivienda> ListarTiposDeVivienda()
        {
            var result = new ServiceResult();
            try
            {
                var list = _tipoDeViviendaRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbTiposDeVivienda> pais = null;
                return pais;
            }
        }
        #endregion TiposDeVivienda

        #region Parentescos
        public IEnumerable<tbParentescos> ListarParentescos()
        {
            var result = new ServiceResult();
            try
            {
                var list = _parentescoRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbParentescos> parentesco = null;
                return parentesco;
            }
        }
        #endregion

        #region ImagenesVisita

        public IEnumerable<tbImagenesVisita> ListImVi()
        {
            var result = new ServiceResult();
            try
            {
                var list = _imagenVisitaRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbImagenesVisita> imvi = null;
                return imvi;
            }
        }

        public IEnumerable<tbImagenesVisita> ListPorVisita(int id)
        {
            try
            {
                var list = _imagenVisitaRepository.ListPorVisita(id);
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbImagenesVisita> imvi = null;
                return imvi;
            }
        }

        public ServiceResult InsertImVi(tbImagenesVisita item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _imagenVisitaRepository.Insert(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion


        #region EstadosVisita

        public IEnumerable<tbEstadosVisita> ListarEstadosVisita()
        {
            var result = new ServiceResult();
            try
            {
                var list = _estadoVisitaRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbEstadosVisita> esci = new List<tbEstadosVisita>();
                return esci;
            }
        }

        public ServiceResult InsertarEstadoVisita(tbEstadosVisita item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _estadoVisitaRepository.Insert(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarEstadoVisita(tbEstadosVisita item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _estadoVisitaRepository.Update(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarEstadoVisita(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _estadoVisitaRepository.Delete(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


        public tbEstadosVisita BuscarEstadoVisita(int? id)
        {
            try
            {
                var EsCi = _estadoVisitaRepository.Find(id);
                return EsCi;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        #endregion

        #region FormasDePago
        public IEnumerable<tbFormasDePago> ListarFormasDePago()
        {
            var result = new ServiceResult();
            try
            {
                var list = _formasDePagoRepository.ListarFormasDePago();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbFormasDePago> FoPa = null;
                return FoPa;
            }
        }
        #endregion
    }
}