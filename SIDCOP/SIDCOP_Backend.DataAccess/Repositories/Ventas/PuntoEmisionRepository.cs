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
    public class PuntoEmisionRepository : IRepository<tbPuntosEmision>
    {

        public RequestStatus Delete(int? id)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@PuEm_Id", id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Execute(ScriptDatabase.PuntoEmision_Eliminar, parameters, commandType: System.Data.CommandType.StoredProcedure);

            var status = new RequestStatus();
            status.code_Status = result;

            return status;
        }

        public tbPuntosEmision Find(int? id)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@PuEm_Id", id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbPuntosEmision>(ScriptDatabase.PuntoEmision_Buscar, parameters, commandType: System.Data.CommandType.StoredProcedure);

            return result.First();
        }

        public RequestStatus Insert(tbPuntosEmision item)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@PuEm_Codigo", item.PuEm_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@PuEm_Descripcion", item.PuEm_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@PuEm_FechaCreacion", item.PuEm_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<RequestStatus>(ScriptDatabase.PuntoEmision_Insertar, parameters, commandType: System.Data.CommandType.StoredProcedure);

            var status = new RequestStatus();
            status = result.First();


            return status;
        }

        public IEnumerable<tbPuntosEmision> List()
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbPuntosEmision>(ScriptDatabase.PuntosEmision_Listar, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public RequestStatus Update(tbPuntosEmision item)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@PuEm_Id", item.PuEm_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameters.Add("@PuEm_Codigo", item.PuEm_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@PuEm_Descripcion", item.PuEm_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@PuEm_FechaModificacion", item.PuEm_FechaModificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Execute(ScriptDatabase.PuntoEmision_Actualizar, parameters, commandType: System.Data.CommandType.StoredProcedure);

            var status = new RequestStatus();
            status.code_Status = result;

            return status;
        }
    }
}
