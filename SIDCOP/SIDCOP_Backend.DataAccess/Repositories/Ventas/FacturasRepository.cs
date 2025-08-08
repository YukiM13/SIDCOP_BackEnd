using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            parameter.Add("@Clie_Id", venta.Clie_Id);
            parameter.Add("@Vend_Id", venta.Vend_Id);
            parameter.Add("@Fact_TipoVenta", venta.Fact_TipoVenta);
            parameter.Add("@Fact_FechaEmision", venta.Fact_FechaEmision);
            parameter.Add("@Fact_FechaLimiteEmision", venta.Fact_FechaLimiteEmision);
            parameter.Add("@Fact_RangoInicialAutorizado", venta.Fact_RangoInicialAutorizado);
            parameter.Add("@Fact_RangoFinalAutorizado", venta.Fact_RangoFinalAutorizado);
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

    }
}
