using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess.Repositories.General
{
    public class PaisRepository : IRepository<tbPaises>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbPaises Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbPaises item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbPaises> List()
        {
            var parameter = new DynamicParameters();


            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbPaises>(ScriptDatabase.Paises_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();


            return result;
        }

        public RequestStatus Update(tbPaises item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbPaises> IRepository<tbPaises>.List()
        {
            throw new NotImplementedException();
        }
    }
}
