


using Api_SIDCOP.API.Models.Reportes;
using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.DataAccess.Repositories.Dashboards;
using SIDCOP_Backend.Entities.Entities;
using System.Data;
using System.Reflection.Metadata;

namespace SIDCOP_Backend.DataAccess.Repositories.Reportes
{
    public class DashboardsRepository : IRepository<DashboardsViewModel>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public DashboardsViewModel Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(DashboardsViewModel item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DashboardsViewModel> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<dynamic> VentasPorMes()
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            var parameters = new DynamicParameters();

            var result = db.Query(
                ScriptDatabase.VentasPorMes,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }


        public IEnumerable<dynamic> VentasPorMesProductos(DashboardsViewModel item)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@Cate_Id", item.cate_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameters.Add("@Anio", item.Anio, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameters.Add("@Mes", item.Mes, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            var result = db.Query(
                ScriptDatabase.VentasPorMesProductos, parameters,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public IEnumerable<dynamic> VentasPorMesCategorias(DashboardsViewModel item)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@Anio", item.Anio, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameters.Add("@Mes", item.Mes, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            var result = db.Query(
                ScriptDatabase.VentasPorMesCategorias, parameters,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public IEnumerable<dynamic> Top5ProductosCategoria(DashboardsViewModel item)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@Cate_Id", item.cate_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            var result = db.Query(
                ScriptDatabase.Top5ProductosCategoria, parameters,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public IEnumerable<dynamic> Top5VendedoresPorMes(DashboardsViewModel item)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@Mes", item.Mes, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            var result = db.Query(
                ScriptDatabase.Top5VendedoresPorMes, parameters,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public IEnumerable<DashboardMarcasMasVendidas> Top5MarcasMasVendidas(
            DateTime? fechaInicio = null,
            DateTime? fechaFin = null)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@FechaInicio", fechaInicio);
            parameters.Add("@FechaFin", fechaFin);

            var result = db.Query<DashboardMarcasMasVendidas>(
                ScriptDatabase.Top5MarcasMasVendidas,
                parameters,
                commandType: CommandType.StoredProcedure
            ).ToList();

            return result;
        }

        public IEnumerable<DashboardMarcasMasVendidas> DashboardProductosPorMarcas(
            int marcaId,
            DateTime? fechaInicio = null,
            DateTime? fechaFin = null)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@FechaInicio", fechaInicio);
            parameters.Add("@FechaFin", fechaFin);
            parameters.Add("@Marc_Id", marcaId);

            var result = db.Query<DashboardMarcasMasVendidas>(
                ScriptDatabase.DashboardPorMarcasVendidas,
                parameters,
                commandType: CommandType.StoredProcedure
            ).ToList();

            return result;
        }

        public RequestStatus Update(DashboardsViewModel item)
        {
            throw new NotImplementedException();
        }
    }

}
