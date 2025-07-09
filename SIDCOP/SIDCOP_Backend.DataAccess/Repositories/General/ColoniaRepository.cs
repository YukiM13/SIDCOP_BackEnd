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
    public class ColoniaRepository : IRepository<tbColonias>
    {
        public RequestStatus Delete(tbColonias item)
        {
            throw new NotImplementedException();
        }

        public tbColonias Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbColonias item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbColonias> List()
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbColonias>(ScriptDatabase.Colonias_Listar, commandType: System.Data.CommandType.StoredProcedure);
             return result;
        }

        public RequestStatus Update(tbColonias item)
        {
            throw new NotImplementedException();
        }
    }
}
