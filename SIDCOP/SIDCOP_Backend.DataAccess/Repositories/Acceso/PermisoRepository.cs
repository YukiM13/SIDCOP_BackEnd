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
    public class PermisoRepository
    {
        public virtual IEnumerable<tbPermisos> List()
        {
            var parameter = new DynamicParameters();


            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbPermisos>(ScriptDatabase.Permisos_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();


            return result;
        }
        public virtual RequestStatus Insert(tbPermisos item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }

            var parameter = new DynamicParameters();
            parameter.Add("@Role_Id", item.Role_Id, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@AcPa_Id", item.AcPa_Id, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Perm_FechaCreacion", item.Perm_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Permiso_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);

                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error desconocido." };
                }
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }
        }

        public virtual RequestStatus Update(tbPermisos item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@Perm_Id", item.Perm_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Role_Id", item.Role_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@AcPa_Id", item.AcPa_Id, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Perm_FechaModificacion", item.Perm_FechaModificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Permiso_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);

                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error desconocido." };
                }
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }
        }

        public virtual IEnumerable<tbPermisos> FindPermission(tbPermisos? item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Role_Id", item.Role_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbPermisos>(ScriptDatabase.Permiso_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public virtual RequestStatus Delete(tbPermisos? item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }

            var parameter = new DynamicParameters();
            parameter.Add("@Perm_Id", item.Perm_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Permiso_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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
