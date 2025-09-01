using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess.Repositories.Ventas
{
    public class PuntoEmisionRepository : IRepository<tbPuntosEmision>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus DeleteEspecial(tbPuntosEmision item)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@PuEm_Id", item.PuEm_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameters.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@PuEm_FechaModificacion", item.PuEm_FechaModificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.PuntoEmision_Eliminar, parameters, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error desconocido" };
                }
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }
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
            parameters.Add("@Sucu_Id", item.Sucu_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameters.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@PuEm_FechaCreacion", item.PuEm_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);


            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.PuntoEmision_Insertar, parameters, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error desconocido" };
                }
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }

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
            parameters.Add("@Sucu_Id", item.Sucu_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameters.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@PuEm_FechaModificacion", item.PuEm_FechaModificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.PuntoEmision_Actualizar, parameters, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error desconocido" };
                }
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }
        }
    }
}
