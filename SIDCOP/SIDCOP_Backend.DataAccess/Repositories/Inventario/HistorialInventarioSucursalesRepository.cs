using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess.Repositories.Inventario
{
    public class HistorialInventarioSucursalesRepository : IRepository<tbInventarioSucursalesHistorial>
    {


        public IEnumerable<tbInventarioSucursalesHistorial> ListHistorialInve(int id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@Sucu_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            var result = db.Query<tbInventarioSucursalesHistorial>(
                ScriptDatabase.HistorialInventarioSucursal_ListarPorSucursal,
                parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbInventarioSucursalesHistorial Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbInventarioSucursalesHistorial item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbInventarioSucursalesHistorial> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbInventarioSucursalesHistorial item)
        {
            throw new NotImplementedException();
        }
    }
}
