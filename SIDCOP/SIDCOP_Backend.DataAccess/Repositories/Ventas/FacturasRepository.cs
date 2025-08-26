using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Dapper;
using SIDCOP_Backend.Entities.Entities;

namespace SIDCOP_Backend.DataAccess.Repositories.Ventas
{
    public class FacturasRepository
    {
        public RequestStatus InsertarVenta(VentaInsertarDTO venta)
        {
            var parameter = new DynamicParameters();

            // Parámetros de entrada principales
            parameter.Add("@Fact_Numero", venta.Fact_Numero);
            parameter.Add("@Fact_TipoDeDocumento", venta.Fact_TipoDeDocumento);
            parameter.Add("@RegC_Id", venta.RegC_Id);
            parameter.Add("@DiCl_Id", venta.DiCl_Id);
            parameter.Add("@Vend_Id", venta.Vend_Id);
            parameter.Add("@Fact_TipoVenta", venta.Fact_TipoVenta);
            parameter.Add("@Fact_FechaEmision", venta.Fact_FechaEmision);
            parameter.Add("@Fact_Latitud", venta.Fact_Latitud);
            parameter.Add("@Fact_Longitud", venta.Fact_Longitud);
            parameter.Add("@Fact_Referencia", venta.Fact_Referencia ?? string.Empty);
            parameter.Add("@Fact_AutorizadoPor", venta.Fact_AutorizadoPor ?? string.Empty);
            parameter.Add("@Usua_Creacion", venta.Usua_Creacion);

            // Convertir lista de detalles a XML (solo productos y cantidades)
            string detallesXml = venta.DetallesFacturaInput != null && venta.DetallesFacturaInput.Any()
                ? "<DetallesFactura>" + string.Join("", venta.DetallesFacturaInput.Select(det =>
                    $"<Detalle Prod_Id=\"{det.Prod_Id}\" FaDe_Cantidad=\"{det.FaDe_Cantidad}\" />"))
                    + "</DetallesFactura>"
                : "<DetallesFactura></DetallesFactura>";

            parameter.Add("@DetallesFacturaInput", detallesXml, DbType.Xml);

            // Parámetros de salida
            parameter.Add("@Fact_Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameter.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
            parameter.Add("@Exitoso", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                db.Execute(ScriptDatabase.Venta_Insertar, parameter, commandType: CommandType.StoredProcedure);

                // Obtener valores de salida
                var factId = parameter.Get<int>("@Fact_Id");
                var mensaje = parameter.Get<string>("@Mensaje");
                var exitoso = parameter.Get<bool>("@Exitoso");

                return new RequestStatus
                {
                    code_Status = exitoso ? 1 : 0,
                    message_Status = exitoso ? $"Venta insertada correctamente. ID: {factId}. {mensaje}" : mensaje
                };
            }
            catch (Exception ex)
            {
                return new RequestStatus
                {
                    code_Status = 0,
                    message_Status = $"Error inesperado: {ex.Message}"
                };
            }
        }

        public RequestStatus InsertarVentaEnSucursal(VentaInsertarDTO venta)
        {
            var parameter = new DynamicParameters();

            // Parámetros de entrada principales (actualizados)
            parameter.Add("@Fact_TipoDeDocumento", venta.Fact_TipoDeDocumento);
            parameter.Add("@RegC_Id", venta.RegC_Id);
            parameter.Add("@DiCl_Id", venta.DiCl_Id);
            parameter.Add("@Vend_Id", venta.Vend_Id);
            parameter.Add("@Fact_TipoVenta", venta.Fact_TipoVenta);
            parameter.Add("@Fact_FechaEmision", venta.Fact_FechaEmision);

            parameter.Add("@Fact_Latitud", venta.Fact_Latitud);
            parameter.Add("@Fact_Longitud", venta.Fact_Longitud);
            parameter.Add("@Fact_Referencia", venta.Fact_Referencia ?? string.Empty);
            parameter.Add("@Fact_AutorizadoPor", venta.Fact_AutorizadoPor ?? string.Empty);
            parameter.Add("@Usua_Creacion", venta.Usua_Creacion);

            // Convertir lista de detalles a XML (solo productos y cantidades)
            string detallesXml = venta.DetallesFacturaInput != null && venta.DetallesFacturaInput.Any()
                ? "<DetallesFactura>" + string.Join("", venta.DetallesFacturaInput.Select(det =>
                    $"<Detalle Prod_Id=\"{det.Prod_Id}\" FaDe_Cantidad=\"{det.FaDe_Cantidad}\" />"))
                    + "</DetallesFactura>"
                : "<DetallesFactura></DetallesFactura>";

            parameter.Add("@DetallesFacturaInput", detallesXml, DbType.Xml);

            // Parámetros de salida
            parameter.Add("@Fact_Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameter.Add("@Fact_Numero", dbType: DbType.String, direction: ParameterDirection.Output, size: 20); // ✅ Nuevo: @Fact_Numero como salida
            parameter.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
            parameter.Add("@Exitoso", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                // ✅ Usar el nuevo SP
                db.Execute(ScriptDatabase.Venta_InsertarEnSucursal, parameter, commandType: CommandType.StoredProcedure);

                // Obtener valores de salida
                var factId = parameter.Get<int>("@Fact_Id");
                var factNumero = parameter.Get<string>("@Fact_Numero");
                var mensaje = parameter.Get<string>("@Mensaje");
                var exitoso = parameter.Get<bool>("@Exitoso");

                return new RequestStatus
                {
                    code_Status = exitoso ? 1 : 0,
                    message_Status = exitoso
                        ? $"Venta insertada correctamente. Número: {factNumero}, ID: {factId}. {mensaje}"
                        : mensaje
                };
            }
            catch (Exception ex)
            {
                return new RequestStatus
                {
                    code_Status = 0,
                    message_Status = $"Error inesperado: {ex.Message}"
                };
            }
        }

        public FacturaCompletaDTO ObtenerFacturaCompleta(int factId)
        {
            var parameter = new DynamicParameters();

            // Parámetros de entrada
            parameter.Add("@Fact_Id", factId);

            // Parámetros de salida
            parameter.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
            parameter.Add("@Exitoso", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

                // Ejecutar el SP que retorna múltiples result sets
                using var multi = db.QueryMultiple("[Vnta].[SP_Factura_ObtenerCompleta]", parameter, commandType: CommandType.StoredProcedure);

                var facturaCompleta = new FacturaCompletaDTO();

                // 1. Leer configuración de facturas (primer result set)
                var configuracion = multi.ReadFirstOrDefault();
                if (configuracion != null)
                {
                    facturaCompleta.CoFa_NombreEmpresa = configuracion.CoFa_NombreEmpresa;
                    facturaCompleta.CoFa_DireccionEmpresa = configuracion.CoFa_DireccionEmpresa;
                    facturaCompleta.CoFa_RTN = configuracion.CoFa_RTN;
                    facturaCompleta.CoFa_Correo = configuracion.CoFa_Correo;
                    facturaCompleta.CoFa_Telefono1 = configuracion.CoFa_Telefono1;
                    facturaCompleta.CoFa_Telefono2 = configuracion.CoFa_Telefono2;
                    facturaCompleta.CoFa_Logo = configuracion.CoFa_Logo;
                }

                // 2. Leer datos principales de la factura (segundo result set)
                var datosFactura = multi.ReadFirstOrDefault();
                if (datosFactura != null)
                {
                    // Datos de la factura
                    facturaCompleta.Fact_Id = datosFactura.Fact_Id;
                    facturaCompleta.Fact_Numero = datosFactura.Fact_Numero;
                    facturaCompleta.Fact_TipoDeDocumento = datosFactura.Fact_TipoDeDocumento;
                    facturaCompleta.Fact_TipoVenta = datosFactura.Fact_TipoVenta;
                    facturaCompleta.Fact_FechaEmision = datosFactura.Fact_FechaEmision;
                    facturaCompleta.Fact_FechaLimiteEmision = datosFactura.Fact_FechaLimiteEmision;
                    facturaCompleta.Fact_RangoInicialAutorizado = datosFactura.Fact_RangoInicialAutorizado;
                    facturaCompleta.Fact_RangoFinalAutorizado = datosFactura.Fact_RangoFinalAutorizado;
                    facturaCompleta.Fact_Referencia = datosFactura.Fact_Referencia;
                    facturaCompleta.Fact_AutorizadoPor = datosFactura.Fact_AutorizadoPor;
                    facturaCompleta.Fact_Latitud = datosFactura.Fact_Latitud;
                    facturaCompleta.Fact_Longitud = datosFactura.Fact_Longitud;

                    // Datos del cliente
                    facturaCompleta.Clie_Id = datosFactura.Clie_Id;
                    facturaCompleta.Cliente = datosFactura.Cliente;
                    facturaCompleta.Clie_RTN = datosFactura.Clie_RTN;
                    facturaCompleta.Clie_Telefono = datosFactura.Clie_Telefono;
                    facturaCompleta.DiCl_DireccionExacta = datosFactura.DiCl_DireccionExacta;

                    // Datos del vendedor
                    facturaCompleta.Vend_Id = datosFactura.Vend_Id;
                    facturaCompleta.Vendedor = datosFactura.Vendedor;
                    facturaCompleta.Vend_Telefono = datosFactura.Vend_Telefono;

                    // Datos de la sucursal
                    facturaCompleta.Sucu_Id = datosFactura.Sucu_Id;
                    facturaCompleta.Sucu_Descripcion = datosFactura.Sucu_Descripcion;
                    facturaCompleta.Sucu_DireccionExacta = datosFactura.Sucu_DireccionExacta;

                    // Datos del registro CAI
                    facturaCompleta.RegC_Descripcion = datosFactura.RegC_Descripcion;
                    facturaCompleta.RegC_FechaInicialEmision = datosFactura.RegC_FechaInicialEmision;
                    facturaCompleta.RegC_FechaFinalEmision = datosFactura.RegC_FechaFinalEmision;
                    facturaCompleta.RegC_RangoInicial = datosFactura.RegC_RangoInicial;
                    facturaCompleta.RegC_RangoFinal = datosFactura.RegC_RangoFinal;

                    // Totales de la factura
                    facturaCompleta.Fact_TotalImpuesto15 = datosFactura.Fact_TotalImpuesto15;
                    facturaCompleta.Fact_TotalImpuesto18 = datosFactura.Fact_TotalImpuesto18;
                    facturaCompleta.Fact_ImporteExento = datosFactura.Fact_ImporteExento;
                    facturaCompleta.Fact_ImporteGravado15 = datosFactura.Fact_ImporteGravado15;
                    facturaCompleta.Fact_ImporteGravado18 = datosFactura.Fact_ImporteGravado18;
                    facturaCompleta.Fact_ImporteExonerado = datosFactura.Fact_ImporteExonerado;
                    facturaCompleta.Fact_TotalDescuento = datosFactura.Fact_TotalDescuento;
                    facturaCompleta.Fact_Subtotal = datosFactura.Fact_Subtotal;
                    facturaCompleta.Fact_Total = datosFactura.Fact_Total;
                }

                // 3. Leer detalle de la factura (tercer result set)
                var detalles = multi.Read();
                facturaCompleta.DetalleFactura = detalles.Select(det => new FacturaCompletaDTO.DetalleItem
                {
                    // Datos del detalle
                    FaDe_Id = det.FaDe_Id,
                    Prod_Id = det.Prod_Id,
                    FaDe_Cantidad = det.FaDe_Cantidad,
                    FaDe_PrecioUnitario = det.FaDe_PrecioUnitario,
                    FaDe_Subtotal = det.FaDe_Subtotal,
                    FaDe_Descuento = det.FaDe_Descuento,
                    FaDe_Impuesto = det.FaDe_Impuesto,
                    FaDe_Total = det.FaDe_Total,

                    // Datos del producto
                    Prod_Descripcion = det.Prod_Descripcion,
                    Prod_CodigoBarra = det.Prod_CodigoBarra,
                    Prod_PagaImpuesto = det.Prod_PagaImpuesto,
                    Prod_Imagen = det.Prod_Imagen,

                    // Datos del impuesto
                    Impu_Id = det.Impu_Id,
                    Impu_Descripcion = det.Impu_Descripcion,
                    PorcentajeImpuesto = det.PorcentajeImpuesto,

                    // Cálculos adicionales
                    DescuentoUnitario = det.DescuentoUnitario,
                    PorcentajeDescuento = det.PorcentajeDescuento
                }).ToList();

                // 4. Leer cuentas por cobrar (cuarto result set - condicional)
                if (!multi.IsConsumed)
                {
                    var cuentasPorCobrar = multi.Read();
                    facturaCompleta.CuentasPorCobrar = cuentasPorCobrar.Select(cpc => new FacturaCompletaDTO.CuentaPorCobrarItem
                    {
                        CPCo_Id = cpc.CPCo_Id,
                        CPCo_FechaEmision = cpc.CPCo_FechaEmision,
                        CPCo_FechaVencimiento = cpc.CPCo_FechaVencimiento,
                        CPCo_Valor = cpc.CPCo_Valor,
                        CPCo_Saldo = cpc.CPCo_Saldo,
                        CPCo_Observaciones = cpc.CPCo_Observaciones,
                        CPCo_Saldada = cpc.CPCo_Saldada,
                        DiasParaVencimiento = cpc.DiasParaVencimiento,
                        EstadoCuenta = cpc.EstadoCuenta
                    }).ToList();
                }

                // Obtener valores de salida del SP
                var mensaje = parameter.Get<string>("@Mensaje");
                var exitoso = parameter.Get<bool>("@Exitoso");

                facturaCompleta.Mensaje = mensaje;
                facturaCompleta.Exitoso = exitoso;

                return facturaCompleta;
            }
            catch (Exception ex)
            {
                return new FacturaCompletaDTO
                {
                    Mensaje = $"Error inesperado: {ex.Message}",
                    Exitoso = false
                };
            }
        }

        // Método para agregar en FacturasRepository
        public List<FacturaVendedorDTO> ListarFacturasPorVendedor(int vendId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Vend_Id", vendId);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

                var facturas = db.Query<FacturaVendedorDTO>(
                    "[Vnta].[SP_ListarFacturasPorVendedor]",
                    parameter,
                    commandType: CommandType.StoredProcedure
                                                           ).ToList();

                // Agregar información de éxito a cada factura (siguiendo el patrón de FacturaCompletaDTO)
                foreach (var factura in facturas)
                {
                    factura.Mensaje = $"Facturas obtenidas correctamente.";
                    factura.Exitoso = true;
                }

                return facturas;
            }
            catch (Exception ex)
            {
                // Retornar una lista con un elemento que contenga el error
                return new List<FacturaVendedorDTO>
        {
            new FacturaVendedorDTO
            {
                Mensaje = $"Error al obtener facturas del vendedor: {ex.Message}",
                Exitoso = false
            }
        };
            }
        }

        public IEnumerable<tbFacturas> List()
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbFacturas>(ScriptDatabase.Facturas_Listar, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public RequestStatus AnularFactura(tbFacturas anular)
        {
            var parameter = new DynamicParameters();

            // Parámetros de entrada principales
            parameter.Add("@Fact_Id", anular.Fact_Id);
            parameter.Add("@Usua_Modificacion", anular.Usua_Modificacion);
            parameter.Add("@Motivo", anular.Motivo);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            try
            {
                var result = db.Execute(ScriptDatabase.Anular_Factura, parameter, commandType: CommandType.StoredProcedure);
                return new RequestStatus
                {
                    code_Status = 1,
                    message_Status = $"Factura anulada correctamente {result}"
                };
            }
            catch (Exception ex)
            {
                return new RequestStatus
                {
                    code_Status = 0,
                    message_Status = $"Error inesperado: {ex.Message}"
                };
            }
        }
    }
}