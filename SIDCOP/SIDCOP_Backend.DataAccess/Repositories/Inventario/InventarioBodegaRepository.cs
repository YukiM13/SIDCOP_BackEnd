using Api_SIDCOP.API.Models.Reportes;
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


        public IEnumerable<IniciarJornada> InicioJornada(int Usua_Creacion, int Vend_Id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@Vend_Id", Vend_Id);
            parameters.Add("@Usua_Creacion", Usua_Creacion);

            var result = db.Query<IniciarJornada>(
                ScriptDatabase.IniciarJornadaVendedor,
                parameters,
                commandType: CommandType.StoredProcedure
            ).ToList();

            return result;
        }

        public IEnumerable<CerrarJornada> CierreJornada( int Vend_Id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@Vend_Id", Vend_Id);
        
            var result = db.Query<CerrarJornada>(
                ScriptDatabase.CerrarJornadaVendedor, parameters, commandType: CommandType.StoredProcedure
            ).ToList();

            return result;
        }

        public IEnumerable<InventarioAsignadoVendedorDTO> ObtenerInventarioAsignadoPorVendedor(int Vend_Id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@Vend_Id", Vend_Id);

            var result = db.Query<InventarioAsignadoVendedorDTO>(
                ScriptDatabase.InventarioAsgnadoPorVendedor, // Asume que tienes esta constante en ScriptDatabase
                parameters,
                commandType: CommandType.StoredProcedure
            ).ToList();

            return result;
        }



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


        public JornadaActivaDto ObtenerJornadaActiva(int Vend_Id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@Vend_Id", Vend_Id);

            var result = db.QueryFirstOrDefault<JornadaActivaDto>(
                ScriptDatabase.ObtenerJornadaActiva, // Necesitas agregar esta constante en ScriptDatabase
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result; // Retorna null si no encuentra jornada activa, o el objeto si la encuentra
        }
    }
}
