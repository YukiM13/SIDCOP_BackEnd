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
    public class DevolucionesDetallesRepository : IRepository<tbDevolucionesDetalle>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<tbDevolucionesDetalle> FindDetalle(int? id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@Devo_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            var result = db.Query<tbDevolucionesDetalle>(ScriptDatabase.DevolucionDetalle_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            if (result == null)
            {
                throw new Exception("Detalle no encontrado");
            }
            return result;
        }

        public tbDevolucionesDetalle Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbDevolucionesDetalle item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbDevolucionesDetalle> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbDevolucionesDetalle item)
        {
            throw new NotImplementedException();
        }
    }
}
