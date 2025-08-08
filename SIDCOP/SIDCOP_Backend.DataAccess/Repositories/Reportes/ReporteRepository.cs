


using Api_SIDCOP.API.Models.Reportes;
using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.DataAccess.Repositories.General;
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


        #region ReporteClientes
        //public tbClientes ClientePorFecha(DateTime? fechaCreacion)
        //{
        //    using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
        //    var parameter = new DynamicParameters();
        //    parameter.Add("@FechaCreacion", fechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

        //    var result = db.QueryFirstOrDefault<tbClientes>(
        //        ScriptDatabase.Clientes_ListarPorFecha,
        //        parameter,
        //        commandType: System.Data.CommandType.StoredProcedure);

        //    if (result == null)
        //    {
        //        throw new Exception("Cliente no encontrado");
        //    }

        //    return result;
        //}


        public IEnumerable<ReportesViewModel> ClientePorFecha(DateTime? id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@FechaCreacion", id, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            var result = db.Query<ReportesViewModel>(ScriptDatabase.Clientes_ListarPorFecha, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList() ;
            if (result == null)
            {
                throw new Exception("Cliente no encontrado");
            }
            return result;
        }
        #endregion

        public RequestStatus Update(ReportesViewModel item)
        {
            throw new NotImplementedException();
        }
    }

}
