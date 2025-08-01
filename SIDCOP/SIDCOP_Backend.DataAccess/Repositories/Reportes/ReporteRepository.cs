


using Api_SIDCOP.API.Models.Reportes;
using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;

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

            var result = db.Query<ReportesViewModel>(ScriptDatabase.ReporteDeProductos, commandType: System.Data.CommandType.StoredProcedure).ToList();

            //Retorna la lista de bodegas
            return result;
        }
        public RequestStatus Update(ReportesViewModel item)
        {
            throw new NotImplementedException();
        }
    }

}
