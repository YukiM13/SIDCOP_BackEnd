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
    // Repositorio para manejar las operaciones CRUD sobre los departamentos
    public class DepartamentoRepository : IRepository<tbDepartamentos>
    {
        // Actualiza un departamento existente en la base de datos
        public RequestStatus Update(tbDepartamentos item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            var parameter = new DynamicParameters();
            //Declaracion de parametros
            parameter.Add("@Depa_Codigo", item.Depa_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Depa_Descripcion", item.Depa_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Depa_FechaModificacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);


            try
            {
                //Se llama el ConnectionString para conectarse a la base de datos
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                //Ejecuta el procedimiento con los parametros y trae un resultado
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Departamento_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error desconocido" };
                }

                //Retorna el status del procedimiento para saber si se realizo
                return result ;
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }
        }


        // Elimina un departamento por código
        public RequestStatus DeleteConCodigo(string? id)
        {
            var parameter = new DynamicParameters();
            //Declaracion de parametros
            parameter.Add("@Depa_Codigo", id, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            try
            {
                //Se llama el ConnectionString para conectarse a la base de datos
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                //Ejecuta el procedimiento con el parametro
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Departamento_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error desconocido" };
                }
                //Retorna el status del procedimiento para saber si se realizo
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }
        }



        // Inserta un nuevo departamento en la base de datos
        public RequestStatus Insert(tbDepartamentos item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            var parameter = new DynamicParameters();
            //Declaracion de parametros
            parameter.Add("@Depa_Codigo", item.Depa_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Depa_Descripcion", item.Depa_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Depa_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                //Se llama el ConnectionString para conectarse a la base de datos
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                //Ejecuta el procedimiento con los parametros y trae lista de RequestStatus
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Departamentos_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error desconocido" };
                }
                //Retorna el status del procedimiento para saber si se realizo
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }
        }

        // Lista todos los departamentos registrados en el sistema
        public IEnumerable<tbDepartamentos> List()
        {
            var parameter = new DynamicParameters();

            //Se llama el ConnectionString para conectarse a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            //Ejecuta el procedimiento y trae una lista de departamentos
            var result = db.Query<tbDepartamentos>(ScriptDatabase.Departamentos_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            //Retorna la lista de departamentos
            return result;
        }

        // Busca un departamento por código
        public tbDepartamentos FindConCodigo(string? id)
        {
            try
            {
                //Se llama el ConnectionString para conectarse a la base de datos
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var parameter = new DynamicParameters();
                //Declaracion de parametros
                parameter.Add("@Depa_Codigo", id, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                //Ejecuta el procedimiento con el parametro y trae una lista
                var result = db.QueryFirstOrDefault<tbDepartamentos>(ScriptDatabase.Departamento_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    throw new Exception("Departamento no encontrada");
                }
                //Retorna el departamento encontrado
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
