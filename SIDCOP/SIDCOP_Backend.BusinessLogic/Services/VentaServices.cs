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
using SIDCOP_Backend.DataAccess.Repositories.Inventario;
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
        private readonly DevolucionesRepository _devolucionesRepository;
        private readonly CuentasPorCobrarRepository _cuentasporcobrarRepository;
        private readonly PagosCuentasPorCobrarRepository _pagosCuentasPorCobrarRepository;
        private readonly PedidoRepository _pedidoRepository;
        private readonly PreciosPorProductoRepository _preciosPorProductoRepository;
        private readonly FacturasRepository _facturasRepository;
        private readonly DevolucionesDetallesRepository _devolucionesDetallesRepository;
        private readonly MetaRepository _metaRepository;

        public VentaServices(
            CaiSRepository caiSrepository, RegistrosCaiSRepository registrosCaiSRepository,
            VendedorRepository vendedorRepository, ImpuestosRepository impuestosRepository,
            ConfiguracionFacturaRepository configuracionFacturaRepository, PuntoEmisionRepository puntoEmisionRepository,
            CuentasPorCobrarRepository cuentaporcobrarRepository, PedidoRepository pedidoRepository,
            FacturasRepository facturasRepository,

            PreciosPorProductoRepository preciosPorProductoRepository,

            PagosCuentasPorCobrarRepository pagosCuentasPorCobrarRepository, DevolucionesRepository devolucionesRepository,
            DevolucionesDetallesRepository devolucionesDetallesRepository,
            MetaRepository metaRepository
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
            _facturasRepository = facturasRepository;
            _devolucionesRepository = devolucionesRepository;
            _devolucionesDetallesRepository = devolucionesDetallesRepository;
            _metaRepository = metaRepository;
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
                // Retorna null en lugar de lista vacía para indicar error
                List<tbCAIs> lista = null;
                return lista;
            }
        }

        public ServiceResult CrearCai(tbCAIs item)
        {
            var result = new ServiceResult();

            try
            {
                // Insert retorna RequestStatus, no una lista
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

        public ServiceResult CrearRegistroCAi(tbRegistrosCAI item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _registrosCaiSRepository.Insert(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
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

        public IEnumerable<tbVendedoresPorRuta> ListarVendedoresPorRuta()
        {
            try
            {
                var list = _vendedorRepository.ListVeRu();
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

        public IEnumerable<VendedorConVisitasDTO> ListarVendedoresConVisita()
        {
            try
            {
                var list = _vendedorRepository.ListarVendedoresConVisitas();
                return list;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                //throw new Exception("Error al listar vendedores: " + ex.Message);
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

        public ServiceResult ResumenAntiguedad()
        {
            var result = new ServiceResult();
            try
            {
                var response = _cuentasporcobrarRepository.ResumenAntiguedad();
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ResumenCliente()
        {
            var result = new ServiceResult();
            try
            {
                var response = _cuentasporcobrarRepository.ResumenCliente();
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult timeLineCliente(int clie_Id)
        {
            var result = new ServiceResult();
            try
            {
                var response = _cuentasporcobrarRepository.timeLineCliente(clie_Id);
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

        #endregion PreciosPorProducto

        #region Ventas

        public ServiceResult InsertVentas(VentaInsertarDTO item)
        {
            var result = new ServiceResult();

            try
            {
                // Validaciones básicas antes de llamar al repository
                if (item == null)
                {
                    return result.Error("Los datos de la venta son requeridos");
                }

                if (string.IsNullOrWhiteSpace(item.Fact_Numero))
                {
                    return result.Error("El número de factura es requerido");
                }

                if (item.DetallesFacturaInput == null || !item.DetallesFacturaInput.Any())
                {
                    return result.Error("Debe incluir al menos un producto en la venta");
                }

                // Validar que todos los detalles tengan datos válidos
                var detallesInvalidos = item.DetallesFacturaInput
                    .Where(d => d.Prod_Id <= 0 || d.FaDe_Cantidad <= 0)
                    .ToList();

                if (detallesInvalidos.Any())
                {
                    return result.Error("Todos los productos deben tener ID válido y cantidad mayor a 0");
                }

                // Llamar al repository para insertar la venta
                var response = _facturasRepository.InsertarVenta(item);

                if (response.code_Status == 1)
                {
                    return result.Ok(response);
                }
                else
                {
                    return result.Error(response);
                }
            }
            catch (Exception ex)
            {
                // Log del error para debugging (si tienes un logger)
                // _logger.LogError(ex, "Error al insertar venta para factura {FacturaNumero}", item?.Fact_Numero);

                return result.Error($"Error inesperado al insertar venta: {ex.Message}");
            }
        }

        public ServiceResult InsertVentasSucursal(VentaInsertarDTO item)
        {
            var result = new ServiceResult();

            try
            {
                // Validaciones básicas
                if (item == null)
                {
                    return result.Error("Los datos de la venta son requeridos");
                }

                // ✅ Validar DiCl_Id en lugar de Clie_Id
                if (item.DiCl_Id <= 0)
                {
                    return result.Error("La dirección del cliente (DiCl_Id) es requerida y debe ser válida");
                }

                // ❌ Eliminado: Validación de Fact_Numero (ahora lo genera el SP)

                if (item.RegC_Id <= 0)
                {
                    return result.Error("El registro CAI (RegC_Id) es requerido");
                }

                if (item.Vend_Id <= 0)
                {
                    return result.Error("El vendedor (Vend_Id) es requerido");
                }

                if (string.IsNullOrWhiteSpace(item.Fact_TipoVenta))
                {
                    return result.Error("El tipo de venta (CONTADO/CREDITO) es requerido");
                }

                if (item.Fact_FechaEmision == default)
                {
                    return result.Error("La fecha de emisión es requerida");
                }

                if (item.DetallesFacturaInput == null || !item.DetallesFacturaInput.Any())
                {
                    return result.Error("Debe incluir al menos un producto en la venta");
                }

                // Validar que todos los detalles tengan datos válidos
                var detallesInvalidos = item.DetallesFacturaInput
                    .Where(d => d.Prod_Id <= 0 || d.FaDe_Cantidad <= 0)
                    .ToList();

                if (detallesInvalidos.Any())
                {
                    return result.Error("Todos los productos deben tener ID válido y cantidad mayor a 0");
                }

                // Llamar al repository para insertar la venta
                var response = _facturasRepository.InsertarVentaEnSucursal(item);

                if (response.code_Status == 1)
                {
                    // ✅ El mensaje de éxito ya incluye el Fact_Numero generado
                    return result.Ok(response);
                }
                else
                {
                    return result.Error(response.message_Status);
                }
            }
            catch (Exception ex)
            {
                return result.Error($"Error inesperado al insertar venta: {ex.Message}");
            }
        }

        // Método adicional opcional para validar una venta antes de insertarla
        public ServiceResult ValidarVenta(VentaInsertarDTO item)
        {
            var result = new ServiceResult();

            try
            {
                // Validaciones de negocio más específicas
                var errores = new List<string>();

                // Validar fechas
                if (item.Fact_FechaEmision > DateTime.Now.AddDays(1))
                {
                    errores.Add("La fecha de emisión no puede ser futura");
                }
                // Validar tipo de venta
                if (!new[] { "CONTADO", "CREDITO" }.Contains(item.Fact_TipoVenta?.ToUpper()))
                {
                    errores.Add("El tipo de venta debe ser CONTADO o CREDITO");
                }

                // Validar coordenadas geográficas
                if (item.Fact_Latitud < -90 || item.Fact_Latitud > 90)
                {
                    errores.Add("La latitud debe estar entre -90 y 90 grados");
                }

                if (item.Fact_Longitud < -180 || item.Fact_Longitud > 180)
                {
                    errores.Add("La longitud debe estar entre -180 y 180 grados");
                }

                if (errores.Any())
                {
                    return result.Error($"Errores de validación: {string.Join(", ", errores)}");
                }

                return result.Ok("Validación exitosa");
            }
            catch (Exception ex)
            {
                return result.Error($"Error al validar venta: {ex.Message}");
            }
        }

        public ServiceResult ObtenerFacturaCompleta(int factId)
        {
            var result = new ServiceResult();
            try
            {
                // Validaciones básicas antes de llamar al repository
                if (factId <= 0)
                {
                    return result.Error("El ID de la factura debe ser mayor a 0");
                }

                // Llamar al repository para obtener la factura completa
                var facturaCompleta = _facturasRepository.ObtenerFacturaCompleta(factId);

                if (!facturaCompleta.Exitoso)
                {
                    return result.Error(facturaCompleta.Mensaje);
                }

                // Validaciones adicionales de negocio si es necesario
                if (facturaCompleta.Fact_Id == 0)
                {
                    return result.Error("No se encontró la factura especificada");
                }

                return result.Ok(facturaCompleta);
            }
            catch (Exception ex)
            {
                // Log del error para debugging (si tienes un logger)
                // *logger.LogError(ex, "Error al obtener factura completa ID: {FactId}", factId);
                return result.Error($"Error inesperado al obtener la factura: {ex.Message}");
            }
        }

        public ServiceResult ListarFacturasPorVendedor(int vendId)
        {
            var result = new ServiceResult();

            try
            {
                // Validaciones básicas antes de llamar al repository
                if (vendId <= 0)
                {
                    return result.Error("El ID del vendedor debe ser mayor a 0");
                }

                // Llamar al repository para obtener las facturas del vendedor
                var facturas = _facturasRepository.ListarFacturasPorVendedor(vendId);

                // Verificar si hubo error en el repository
                if (facturas.Any() && !facturas.First().Exitoso)
                {
                    return result.Error(facturas.First().Mensaje);
                }

                // Validaciones adicionales de negocio si es necesario
                if (!facturas.Any())
                {
                    return result.Ok("No se encontraron facturas para el vendedor especificado");
                }

                return result.Ok(facturas);
            }
            catch (Exception ex)
            {
                // Log del error para debugging (si tienes un logger)
                // _logger.LogError(ex, "Error al listar facturas para vendedor ID: {VendId}", vendId);

                return result.Error($"Error inesperado al obtener las facturas del vendedor: {ex.Message}");
            }
        }

        public ServiceResult ListFacturas()
        {
            var result = new ServiceResult();
            try
            {
                var response = _facturasRepository.List();
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ListFacturasDevoLimite()
        {
            var result = new ServiceResult();
            try
            {
                var response = _facturasRepository.ListPorDevoLimite();
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult AnularFactura(tbFacturas item)
        {
            var result = new ServiceResult();
            try
            {
                var response = _facturasRepository.AnularFactura(item);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion Ventas

        #region Devoluciones

        public IEnumerable<tbDevoluciones> DevolucionesListar()
        {
            try
            {
                var list = _devolucionesRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                List<tbDevoluciones> lista = null;
                return lista;
            }
        }

        public ServiceResult DevolucionTrasladar(tbDevoluciones item)
        {
            var result = new ServiceResult();
            try
            {
                var insert = _devolucionesRepository.Trasladar(item);
                return result.Ok(insert);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertarDevolucion(tbDevoluciones item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _devolucionesRepository.Insert(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion Devoluciones

        #region DevolucionesDetalles

        public IEnumerable<tbDevolucionesDetalle> BuscarDevolucionDetalle(int? id)
        {
            try
            {
                var devolucionesDetalle = _devolucionesDetallesRepository.FindDetalle(id);
                return devolucionesDetalle;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion DevolucionesDetalles


        #region Metas

        public IEnumerable<tbMetas> ListMetasCompleto()
        {
            //var result = new ServiceResult();
            try
            {
                var list = _metaRepository.ListCompleto();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbMetas> result = null;
                return result;
            }
        }

        public IEnumerable<dynamic> ListarPorVendedor(int? id)
        {
            //var result = new ServiceResult();
            try
            {
                var list = _metaRepository.ListarPorVendedor(id);
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<dynamic> result = null;
                return result;
            }
        }

        public ServiceResult EliminarMeta(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _metaRepository.Delete(id);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertMetasCompleto(tbMetas item)
        {
            var result = new ServiceResult();
            try
            {
                var response = _metaRepository.InsertCompleto(item);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdateMetasCompleto(tbMetas item)
        {
            var result = new ServiceResult();
            try
            {
                var response = _metaRepository.UpdateCompleto(item);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarProgreso(tbMetas item)
        {
            var result = new ServiceResult();
            try
            {
                var response = _metaRepository.ActualizarProgreso(item);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        ////public ServiceResult DeletePreciosPorProductoLista(tbPreciosPorProducto item)
        ////{
        ////    var result = new ServiceResult();
        ////    try
        ////    {
        ////        var response = _preciosPorProductoRepository.DeleteLista(item);
        ////        return result.Ok(response);
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        return result.Error(ex.Message);
        ////    }
        ////}


        #endregion
    }
}