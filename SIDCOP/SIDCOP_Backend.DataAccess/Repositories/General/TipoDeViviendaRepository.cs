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
    public class TipoDeViviendaRepository : IRepository<tbTiposDeVivienda>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbTiposDeVivienda Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbTiposDeVivienda item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbTiposDeVivienda> List()
        {
            var parameter = new DynamicParameters();


            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbTiposDeVivienda>(ScriptDatabase.TiposDeVivienda_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();


            return result;
        }

        public RequestStatus Update(tbTiposDeVivienda item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbTiposDeVivienda> IRepository<tbTiposDeVivienda>.List()
        {
            throw new NotImplementedException();
        }
    }
}
