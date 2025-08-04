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

            // Parámetros simples
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
            parameter.Add("@Fact_TotalImpuesto15", venta.Fact_TotalImpuesto15);
            parameter.Add("@Fact_TotalImpuesto18", venta.Fact_TotalImpuesto18);
            parameter.Add("@Fact_ImporteExento", venta.Fact_ImporteExento);
            parameter.Add("@Fact_ImporteGravado15", venta.Fact_ImporteGravado15);
            parameter.Add("@Fact_ImporteGravado18", venta.Fact_ImporteGravado18);
            parameter.Add("@Fact_ImporteExonerado", venta.Fact_ImporteExonerado);
            parameter.Add("@Fact_TotalDescuento", venta.Fact_TotalDescuento);
            parameter.Add("@Fact_Subtotal", venta.Fact_Subtotal);
            parameter.Add("@Fact_Total", venta.Fact_Total);
            parameter.Add("@Fact_Latitud", venta.Fact_Latitud);
            parameter.Add("@Fact_Longitud", venta.Fact_Longitud);
            parameter.Add("@Fact_Referencia", venta.Fact_Referencia ?? string.Empty);
            parameter.Add("@Fact_AutorizadoPor", venta.Fact_AutorizadoPor ?? string.Empty);
            parameter.Add("@Usua_Creacion", venta.Usua_Creacion);

            // Convertir lista de detalles a XML
            string detallesXml = venta.DetallesFactura != null && venta.DetallesFactura.Any()
                ? "<DetallesFactura>" + string.Join("", venta.DetallesFactura.Select(det =>
                    $"<Detalle Prod_Id=\"{det.Prod_Id}\" FaDe_Cantidad=\"{det.FaDe_Cantidad}\" FaDe_PrecioUnitario=\"{det.FaDe_PrecioUnitario}\" FaDe_Impuesto=\"{det.FaDe_Impuesto}\" FaDe_Descuento=\"{det.FaDe_Descuento}\" FaDe_Subtotal=\"{det.FaDe_Subtotal}\" FaDe_Total=\"{det.FaDe_Total}\" />"))
                    + "</DetallesFactura>"
                : "<DetallesFactura></DetallesFactura>";

            parameter.Add("@DetallesFactura", detallesXml, DbType.Xml);

            // Parámetro de salida
            parameter.Add("@Fact_Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                db.Execute(ScriptDatabase.Venta_Insertar, parameter, commandType: CommandType.StoredProcedure);

                var factId = parameter.Get<int>("@Fact_Id");

                return new RequestStatus
                {
                    code_Status = 1,
                    message_Status = "Venta insertada correctamente"
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
