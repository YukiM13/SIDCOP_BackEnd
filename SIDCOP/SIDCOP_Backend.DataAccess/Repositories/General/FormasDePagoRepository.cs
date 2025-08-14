using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;
using SIDCOP_Backend.Entities.Entities;

namespace SIDCOP_Backend.DataAccess.Repositories.General
{
    public class FormasDePagoRepository: IRepository<tbFormasDePago>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbFormasDePago Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbFormasDePago item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbFormasDePago> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbFormasDePago> ListarFormasDePago()
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbFormasDePago>(ScriptDatabase.FormasDePago_Listar, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public RequestStatus Update(tbFormasDePago item)
        {
            throw new NotImplementedException();
        }
    }
}
