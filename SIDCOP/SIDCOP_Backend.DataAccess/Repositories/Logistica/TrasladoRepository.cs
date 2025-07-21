using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;

namespace SIDCOP_Backend.DataAccess.Repositories.Logistica
{
    public class TrasladoRepository : IRepository<tbTraslados>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbTraslados> ListTraslados()
        {
            var parameter = new DynamicParameters();


            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbTraslados>(ScriptDatabase.Traslados_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();


            return result;
        }

        public tbTraslados Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbTraslados item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbTraslados> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbTraslados item)
        {
            throw new NotImplementedException();
        }
    }
}
