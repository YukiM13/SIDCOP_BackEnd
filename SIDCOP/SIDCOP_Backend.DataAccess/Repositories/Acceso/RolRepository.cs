using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess.Repositories.Acceso
{
    public class RolRepository : IRepository<tbRoles>
    {
        public virtual RequestStatus Delete(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Role_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Rol_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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

        public virtual tbRoles Find(int? id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@Role_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            var result = db.QueryFirstOrDefault<tbRoles>(ScriptDatabase.Rol_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            if (result == null)
            {
                throw new KeyNotFoundException("Rol no encontrado.");
            }
            return result;
        }

        public virtual RequestStatus Insert(tbRoles item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos." };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@Role_Descripcion", item.Role_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Role_FechaCreacion", item.Role_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Rol_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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

        public virtual IEnumerable<tbRoles> List()
        {
            var parameter = new DynamicParameters();
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbRoles>(ScriptDatabase.Roles_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            return result.ToList();
        }

        public virtual string ListarPantallasJson()
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.QueryFirstOrDefault<string>("Acce.SP_Pantallas_Listar", commandType: CommandType.StoredProcedure);
            return result;
        }

        public virtual IEnumerable<tbAccionesPorPantalla> ListAcciones()
        {
            var parameter = new DynamicParameters();
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbAccionesPorPantalla>(ScriptDatabase.AccionesPorPantalla_Listar, parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public virtual RequestStatus Update(tbRoles item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos." };
            }
            var parameter = new DynamicParameters();
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            parameter.Add("@Role_Id", item.Role_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Role_Descripcion", item.Role_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Role_FechaModificacion", item.Role_FechaModificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Rol_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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
