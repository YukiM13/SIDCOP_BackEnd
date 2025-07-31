using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Dapper;
using Org.BouncyCastle.Crypto.Utilities;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.DataAccess.Repositories.General;
using SIDCOP_Backend.DataAccess.Repositories.Logistica;
using SIDCOP_Backend.DataAccess.Repositories.Ventas;
using SIDCOP_Backend.Entities.Entities;

namespace SIDCOP_Backend.BusinessLogic.Services
{
    public class VentaServices
    {
        private readonly ImpuestosRepository _impuestosRepository;
        private readonly CaiSRepository _caiSRepository;
        private readonly RegistrosCaiSRepository _registrosCaiSRepository;
        private readonly VendedorRepository _vendedorRepository;
        private readonly ConfiguracionFacturaRepository _configuracionFacturaRepository;
        private readonly PuntoEmisionRepository _puntoEmisionRepository;

        private readonly CuentasPorCobrarRepository _cuentasporcobrarRepository;
        private readonly PagosCuentasPorCobrarRepository _pagosCuentasPorCobrarRepository;
        private readonly PedidoRepository _pedidoRepository;
        private readonly PreciosPorProductoRepository _preciosPorProductoRepository;

        public VentaServices(
            CaiSRepository caiSrepository, RegistrosCaiSRepository registrosCaiSRepository,
            VendedorRepository vendedorRepository, ImpuestosRepository impuestosRepository,
            ConfiguracionFacturaRepository configuracionFacturaRepository, PuntoEmisionRepository puntoEmisionRepository,
            CuentasPorCobrarRepository cuentaporcobrarRepository, PedidoRepository pedidoRepository,

            PreciosPorProductoRepository preciosPorProductoRepository,


            PagosCuentasPorCobrarRepository pagosCuentasPorCobrarRepository
                            )

        {
            _impuestosRepository = impuestosRepository;
            _caiSRepository = caiSrepository;
            _registrosCaiSRepository = registrosCaiSRepository;
            _vendedorRepository = vendedorRepository;
            _configuracionFacturaRepository = configuracionFacturaRepository;
            _puntoEmisionRepository = puntoEmisionRepository;
            _cuentasporcobrarRepository = cuentaporcobrarRepository;
            _pagosCuentasPorCobrarRepository = pagosCuentasPorCobrarRepository;
            _pedidoRepository = pedidoRepository;
            _preciosPorProductoRepository = preciosPorProductoRepository;
        }

        #region Pedidos

        public ServiceResult InsertarPedido(tbPedidos item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _pedidoRepository.Insert(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EditarPedido(tbPedidos item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _pedidoRepository.Update(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarPedido(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var deleteResult = _pedidoRepository.Delete(id);
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

        public IEnumerable<tbPedidos> ListarPedidos()
        {
            var result = new ServiceResult();
            try
            {
                var list = _pedidoRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbPedidos> usua = null;
                return usua;
            }
        }

        #endregion Pedidos

        #region CaiS



        public IEnumerable<tbCAIs> ListarCaiS()
        {
            try
            {
                var list = _caiSRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                List<tbCAIs> lista = null;
                return lista;
            }
        }

        public ServiceResult CrearCai(tbCAIs item)
        {
            var result = new ServiceResult();

            try
            {
                var list = _caiSRepository.Insert(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarCai(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _caiSRepository.EliminarCai(id);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarCai(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _caiSRepository.BuscarCai(id);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion CaiS

        #region RegistroCais

        public tbRegistrosCAI BuscarRegistroCaiS(int? id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@RegC_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            var result = db.QueryFirstOrDefault<tbRegistrosCAI>(ScriptDatabase.RegistrosCaiSFiltrar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public IEnumerable<tbRegistrosCAI> ListarRegistrosCaiS()
        {
            try
            {
                var list = _registrosCaiSRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                List<tbRegistrosCAI> lista = null;
                return lista;
            }
        }

        public int CrearRegistroCAi(tbRegistrosCAI item)
        {
            try
            {
                var list = _registrosCaiSRepository.Insert(item);
                return list.code_Status;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public ServiceResult ModificarRegistroCai(tbRegistrosCAI item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _registrosCaiSRepository.Update(item);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarRegistroCai(tbRegistrosCAI item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _registrosCaiSRepository.Delete(item);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //public ServiceResult EliminarRegistroCai(int? id)
        //{
        //    var result = new ServiceResult();
        //    try
        //    {
        //        var deleteResult = _registrosCaiSRepository.Delete(id);
        //        if (deleteResult.code_Status == 1)
        //        {
        //            return result.Ok(deleteResult.message_Status);
        //        }
        //        else
        //        {
        //            return result.Error(deleteResult.message_Status);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return result.Error($"Error al eliminar Registro Cai: {ex.Message}");
        //    }
        //}

        #endregion RegistroCais

        #region Impuestos

        public IEnumerable<tbImpuestos> ListImpuestos()
        {
            try
            {
                var list = _impuestosRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                List<tbImpuestos> lista = null;
                return lista;
            }
        }

        public ServiceResult ActualizarImpuestos(tbImpuestos item)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _impuestosRepository.Update(item);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion Impuestos

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
                //throw new Exception("Error al listar vendedores: " + ex.Message);
                return null;
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
                    return result.Ok(insertResult.message_Status); ;
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
               
            
                    return result.Ok(deleteResult);
              
            
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
                return null;
            }
        }

        #endregion Vendedores

        #region ConfiguracionFacturas

        public IEnumerable<tbConfiguracionFacturas> ListConfiguracionFactura()
        {
            //var result = new ServiceResult();
            try
            {
                var list = _configuracionFacturaRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbConfiguracionFacturas> result = null;
                return result;
            }
        }

        public ServiceResult InsertConfiguracionFactura(tbConfiguracionFacturas item)
        {
            var result = new ServiceResult();
            try
            {
                var response = _configuracionFacturaRepository.Insert(item);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdateConfiguracionFactura(tbConfiguracionFacturas item)
        {
            var result = new ServiceResult();
            try
            {
                var response = _configuracionFacturaRepository.Update(item);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult DeleteConfiguracionFactura(int id)
        {
            var result = new ServiceResult();
            try
            {
                var response = _configuracionFacturaRepository.Delete(id);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult FindConfiguracionFactura(int id)
        {
            var result = new ServiceResult();
            try
            {
                var response = _configuracionFacturaRepository.Find(id);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion ConfiguracionFacturas

        #region puntosEmision

        public IEnumerable<tbPuntosEmision> ListPuntosEmision()
        {
            //var result = new ServiceResult();
            try
            {
                var list = _puntoEmisionRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbPuntosEmision> result = null;
                return result;
            }
        }

        public ServiceResult InsertPuntoEmision(tbPuntosEmision item)
        {
            var result = new ServiceResult();
            try
            {
                var response = _puntoEmisionRepository.Insert(item);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdatePuntoEmision(tbPuntosEmision item)
        {
            var result = new ServiceResult();
            try
            {
                var response = _puntoEmisionRepository.Update(item);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult DeletePuntoEmision(tbPuntosEmision item)
        {
            var result = new ServiceResult();
            try
            {
                var response = _puntoEmisionRepository.DeleteEspecial(item);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult FindPuntoEmision(int id)
        {
            var result = new ServiceResult();
            try
            {
                var response = _puntoEmisionRepository.Find(id);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion puntosEmision

        #region PagosCuentasPorCobrar

        public ServiceResult InsertarPagoCuentaPorCobrar(tbPagosCuentasPorCobrar item)
        {
            var result = new ServiceResult();
            try
            {
                var response = _pagosCuentasPorCobrarRepository.InsertarPago(item);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ListarPagosPorCuentaPorCobrar(int cuentaPorCobrarId)
        {
            var result = new ServiceResult();
            try
            {
                var response = _pagosCuentasPorCobrarRepository.ListarPorCuentaPorCobrar(cuentaPorCobrarId);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ListarCuentasPorCobrar(int? clienteId = null, bool soloActivas = true, bool soloVencidas = false)
        {
            var result = new ServiceResult();
            try
            {
                var response = _pagosCuentasPorCobrarRepository.ListarCuentasPorCobrar(clienteId, soloActivas, soloVencidas);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult AnularPagoCuentaPorCobrar(int pagoId, int usuarioId, string motivo)
        {
            var result = new ServiceResult();
            try
            {
                var response = _pagosCuentasPorCobrarRepository.AnularPago(pagoId, usuarioId, motivo);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion PagosCuentasPorCobrar

        #region CuentasPorCobrar

        public ServiceResult ObtenerDetalleCuentaPorCobrar(int cuentaPorCobrarId)
        {
            var result = new ServiceResult();
            try
            {
                var response = _cuentasporcobrarRepository.GetDetalle(cuentaPorCobrarId);
                if (response == null)
                    return result.Error("No se encontró la cuenta por cobrar especificada.");
                    
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        
        public ServiceResult ListCuentasPorCobrar()
        {
            var result = new ServiceResult();
            try
            {
                var response = _cuentasporcobrarRepository.List();
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion CuentasPorCobrar

        #region PreciosPorProducto

        public IEnumerable<tbPreciosPorProducto> ListPreciosPorProducto_PorProducto(int? id)
        {
            //var result = new ServiceResult();
            try
            {
                var list = _preciosPorProductoRepository.ListPorProducto(id);
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbPreciosPorProducto> result = null;
                return result;
            }
        }

        public ServiceResult InsertPreciosPorProductoLista(tbPreciosPorProducto item)
        {
            var result = new ServiceResult();
            try
            {
                var response = _preciosPorProductoRepository.InsertLista(item);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult UpdatePreciosPorProductoLista(tbPreciosPorProducto item)
        {
            var result = new ServiceResult();
            try
            {
                var response = _preciosPorProductoRepository.UpdateLista(item);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult DeletePreciosPorProductoLista(tbPreciosPorProducto item)
        {
            var result = new ServiceResult();
            try
            {
                var response = _preciosPorProductoRepository.DeleteLista(item);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion ConfiguracionFacturas
    }
}