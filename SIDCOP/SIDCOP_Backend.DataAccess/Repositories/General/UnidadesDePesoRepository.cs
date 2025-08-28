using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;

namespace SIDCOP_Backend.DataAccess.Repositories.General
{
    public class UnidadesDePesoRepository : IRepository<tbUnidadesDePeso>
    {
        public RequestStatus Delete(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@UnPe_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.UnPeso_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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

        public tbUnidadesDePeso Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbUnidadesDePeso item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@UnPe_Descripcion", item.UnPe_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@UnPe_Abreviatura", item.UnPe_Abreviatura, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@UnPe_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.UnPeso_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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

        public IEnumerable<tbUnidadesDePeso> List()
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbUnidadesDePeso>(ScriptDatabase.UnPeso_Listar, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public RequestStatus Update(tbUnidadesDePeso item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@UnPe_Id", item.UnPe_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@UnPe_Descripcion", item.UnPe_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@UnPe_Abreviatura", item.UnPe_Abreviatura, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@UnPe_FechaModificacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.UnPeso_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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
