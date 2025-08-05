using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess.Repositories.Ventas
{
    public class DevolucionesRepository : IRepository<tbDevoluciones>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbDevoluciones Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbDevoluciones item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbDevoluciones> List()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbDevoluciones>(ScriptDatabase.Devoluciones_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            return result;
        }

        public RequestStatus Update(tbDevoluciones item)
        {
            throw new NotImplementedException();
        }
    }
}
