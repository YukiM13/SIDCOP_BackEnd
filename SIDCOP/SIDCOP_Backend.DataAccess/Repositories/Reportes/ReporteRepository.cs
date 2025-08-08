


using Api_SIDCOP.API.Models.Reportes;
using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;
using System.Data;

namespace SIDCOP_Backend.DataAccess.Repositories.Reportes
{
    public class ReporteRepository : IRepository<ReportesViewModel>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public ReportesViewModel Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(ReportesViewModel item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReportesViewModel> List()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<ReportesViewModel> ReporteDeProductos(
            DateTime? fechaInicio = null,
            DateTime? fechaFin = null,
            int? marcaId = null,
            int? categoriaId = null)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@FechaInicio", fechaInicio);
            parameters.Add("@FechaFin", fechaFin);
            parameters.Add("@MarcaId", marcaId);
            parameters.Add("@CategoriaId", categoriaId);

            var result = db.Query<ReportesViewModel>(
                ScriptDatabase.ReporteDeProductos,
                parameters,
                commandType: CommandType.StoredProcedure
            ).ToList();

            return result;
        }

        public IEnumerable<ReporteProductosVendidosRuta> ReporteProductosVendidosRutas(int? rutaId = null)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@Ruta_Id", rutaId);

            var result = db.Query<ReporteProductosVendidosRuta>(
                ScriptDatabase.ReporteProductosVendidosRutas,
                parameters,
                commandType: CommandType.StoredProcedure
            ).ToList();

            return result;
        }

        public IEnumerable<ReportesViewModel> ReporteClientesMasFacturados(DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@FechaInicio", fechaInicio);
            parameters.Add("@FechaFin", fechaFin);
            var result = db.Query<ReportesViewModel>(ScriptDatabase.ReporteDeClientesMasFacturados, parameters,commandType: CommandType.StoredProcedure).ToList();

            return result;
        }

        public RequestStatus Update(ReportesViewModel item)
        {
            throw new NotImplementedException();
        }
    }

}
