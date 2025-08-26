using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess.Repositories.Acceso
{
    public class MigracionRepository : IRepository<tbControlMigraciones>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbControlMigraciones Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbControlMigraciones item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbControlMigraciones> List()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbControlMigraciones>(ScriptDatabase.Migracion_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public RequestStatus Update(tbControlMigraciones item)
        {
            throw new NotImplementedException();
        }
    }
}
