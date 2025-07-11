using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using SIDCOP_Backend.DataAccess.Context;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess.Repositories.General
{
    public class DepartamentoRepository : IRepository<tbDepartamentos>
    {
        public RequestStatus Update(tbDepartamentos item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@Depa_Codigo", item.Depa_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Depa_Descripcion", item.Depa_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Depa_FechaModificacion", item.Depa_FechaModificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);


            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Departamento_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error desconocido" };
                }

                return result ;
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }
        }


        public RequestStatus DeleteConCodigo(string? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Depa_Codigo", id, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Departamento_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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



        public RequestStatus Insert(tbDepartamentos item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@Depa_Codigo", item.Depa_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Depa_Descripcion", item.Depa_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Depa_FechaCreacion", item.Depa_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Departamentos_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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

        public IEnumerable<tbDepartamentos> List()
        {
            var parameter = new DynamicParameters();


            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbDepartamentos>(ScriptDatabase.Departamentos_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();


            return result;
        }

        public tbDepartamentos FindConCodigo(string? id)
        {
            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var parameter = new DynamicParameters();
                parameter.Add("@Depa_Codigo", id, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                var result = db.QueryFirstOrDefault<tbDepartamentos>(ScriptDatabase.Departamento_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    throw new Exception("Departamento no encontrada");
                }
                return result;
            }
            catch (Exception)
            {

                throw new Exception("Error");
            }
          
        }

        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbDepartamentos Find(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
