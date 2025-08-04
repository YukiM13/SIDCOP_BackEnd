using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SIDCOP_Backend.DataAccess.Context;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace SIDCOP_Backend.DataAccess.Repositories.Logistica
{
    public class RutasRepository : IRepository<tbRutas>
    {
        public RequestStatus Insert(tbRutas item)
        {
            if(item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@Ruta_codigo", item.Ruta_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Ruta_Descripcion", item.Ruta_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Ruta_Observaciones", item.Ruta_Observaciones, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Ruta_FechaCreacion", item.Ruta_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Rutas_Agregar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error Desconocido" };
                }
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }
       
        }

        public IEnumerable<tbRutas> List()
        {
            
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbRutas>(ScriptDatabase.Rutas_listar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            return result;
        }

        public tbRutas Find(int? id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@Ruta_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            var result = db.QueryFirstOrDefault<tbRutas>(ScriptDatabase.Rutas_Filtrar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            if (result == null)
            {
                throw new Exception("Ruta no encontrada");
            }
            return result;
        }

        public RequestStatus Update(tbRutas item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@Ruta_Id", item.Ruta_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Ruta_Codigo", item.Ruta_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Ruta_Descripcion", item.Ruta_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Ruta_Observaciones", item.Ruta_Observaciones, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Ruta_FechaModificacion", item.Ruta_FechaModificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Rutas_Editar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error Desconocido" };
                }
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }
        }

        public RequestStatus Delete(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Ruta_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Rutas_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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
