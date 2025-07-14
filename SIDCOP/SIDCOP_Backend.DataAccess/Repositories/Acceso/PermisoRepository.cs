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
        public IEnumerable<tbPermisos> List()
        {
            var parameter = new DynamicParameters();


            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbPermisos>(ScriptDatabase.Permisos_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();


            return result;
        }
        public RequestStatus Insert(tbPermisos item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Role_Id", item.Role_Id, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Pant_Id", item.Pant_Id, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Acci_Id", item.Acci_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Perm_FechaCreacion", item.Perm_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Execute(ScriptDatabase.Permiso_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al insertar" : "Insertado correctamente";

            return new RequestStatus { code_Status = result, message_Status = mensaje };
        }

        public RequestStatus Update(tbPermisos item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Perm_Id", item.Perm_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Role_Id", item.Role_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Pant_Id", item.Pant_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Acci_Id", item.Acci_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Perm_FechaModificacion", item.Perm_FechaModificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Execute(ScriptDatabase.Permiso_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al actualizar" : "Actualizado correctamente";

            return new RequestStatus { code_Status = result, message_Status = mensaje };
        }

        public IEnumerable<tbPermisos> FindPermission(tbPermisos? item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Role_Id", item.Role_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbPermisos>(ScriptDatabase.Permiso_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public RequestStatus Delete(tbPermisos? item)
        {
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
