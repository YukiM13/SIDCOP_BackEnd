using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess.Repositories.Inventario
{
    public class InventarioBodegaRepository 
    {
        public ReporteJornadaDto ObtenerReporteJornadaDetallado(int vendId, DateTime? fecha = null)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Vend_Id", vendId);
            parameter.Add("@Fecha", fecha);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

                using var multi = db.QueryMultiple(
                    ScriptDatabase.ReporteJornada,
                    parameter,
                    commandType: CommandType.StoredProcedure
                );

                // 🔹 Primer result set → Header
                var header = multi.ReadFirstOrDefault<ReporteJornadaHeaderDto>();

                // 🔹 Segundo result set → Detalle
                var detalle = multi.Read<ReporteJornadaDetalleDto>().ToList();

                // 🔹 Retornar objeto combinado
                return new ReporteJornadaDto
                {
                    Header = header ?? new ReporteJornadaHeaderDto(),
                    Detalle = detalle
                };
            }
            catch (Exception ex)
            {
                // En caso de error devolvemos objeto con mensaje
                return new ReporteJornadaDto
                {
                    Header = new ReporteJornadaHeaderDto
                    {
                        RutaDescripcion = string.Empty,
                        Vendedor = string.Empty
                    },
                    Detalle = new List<ReporteJornadaDetalleDto>
                    {
                        new ReporteJornadaDetalleDto
                        {
                            Producto = $"Error: {ex.Message}",
                            Codigo = "",
                            Inicial = 0,
                            Final = 0,
                            Vendido = 0,
                            SubTotal = 0
                        }
                    }
                };
            }
        }
    }
}
