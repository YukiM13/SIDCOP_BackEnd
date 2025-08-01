


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

        public IEnumerable<ReportesViewModel> ReporteDeProductos()
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<ReportesViewModel>(
                ScriptDatabase.ReporteDeProductos,
                commandType: CommandType.StoredProcedure
            ).ToList();

            return result; // Retorna lista vacía si no hay datos, no lances excepción
        }

        public RequestStatus Update(ReportesViewModel item)
        {
            throw new NotImplementedException();
        }
    }

}
