using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess.Repositories.Logistica
{
    public class RecargasRepository : IRepository<tbRecargas>
    {
        public RequestStatus Delete(int? id)
        {

            throw new NotImplementedException();
        }

        public tbRecargas Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbRecargas item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbRecargas> List()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbRecargas>(ScriptDatabase.Recargas_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public RequestStatus Update(tbRecargas item)
        {
            throw new NotImplementedException();
        }
    }
}
