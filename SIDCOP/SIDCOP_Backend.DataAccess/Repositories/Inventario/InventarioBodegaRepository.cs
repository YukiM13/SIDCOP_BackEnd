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
    public class InventarioBodegaRepository : IRepository<tbInventarioBodegas>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbInventarioBodegas> Listprodvend(int id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@Vend_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            var result = db.Query<tbInventarioBodegas>(
                ScriptDatabase.InventarioAsgnadoPorVendedor,
                parameter,
                commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public tbInventarioBodegas Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbInventarioBodegas item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbInventarioBodegas> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbInventarioBodegas item)
        {
            throw new NotImplementedException();
        }
    }
}
