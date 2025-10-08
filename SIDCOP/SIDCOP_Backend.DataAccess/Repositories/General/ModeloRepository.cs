using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess.Repositories.General
{
    public class ModeloRepository : IRepository<tbModelos>
    {


        //Metodo que elimina un registro de la tabla tbModelos
        public RequestStatus Delete(int? id)
        {
            //Envio del parametro al procedimiento almacenado
            var parameter = new DynamicParameters();
            parameter.Add("@Mode_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            try
            {
                //Conexion a la base de datos
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Modelos_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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

        public tbModelos Find(int? id)
        {
            throw new NotImplementedException();
        }

        //Metodo que busca un modelo por su codigo
        public IEnumerable<tbModelos> FindCodigo(tbModelos? item)
        {
            //Envio del parametro al procedimiento almacenado
            var parameter = new DynamicParameters();
            parameter.Add("@Mode_Id", item.Mode_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            //Conexion a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            //Asignacion del resultado de la consulta a una variable de tipo lista
            var result = db.Query<tbModelos>(ScriptDatabase.Modelos_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;

        }

        //Metodo que inserta un modelo 
        public RequestStatus Insert(tbModelos item)
        {
            {
                //Envio de parametros al procedimiento almacenado
                var parameter = new DynamicParameters();
                parameter.Add("@MaVe_Id", item.MaVe_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Mode_Descripcion", item.Mode_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Mode_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

                //Conexion a la base de datos
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.Execute(ScriptDatabase.Modelos_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                string mensaje = (result == 0) ? "Error en base de datos" : "Exito";

                //Retorno del resultado de la operacion
                return new RequestStatus { code_Status = result, message_Status = mensaje };
            }
        }


        //Metodo que lista todos los registros de la tabla tbModelos
        public IEnumerable<tbModelos> List()
        {
            var parameter = new DynamicParameters();

            //Conexion a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbModelos>(ScriptDatabase.Modelos_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            //Retorno del resultado de la operacion
            return result;
        }


        //Metodo que actualiza un modelo
        public RequestStatus Update(tbModelos item)
        {
            //Envio de parametros al procedimiento almacenado
            var parameter = new DynamicParameters();
            parameter.Add("@Mode_Id", item.Mode_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@MaVe_Id", item.MaVe_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Mode_Descripcion", item.Mode_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Mode_FechaModificacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            //Conexion a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            var result = db.Execute(ScriptDatabase.Modelos_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";

            return new RequestStatus {code_Status = result, message_Status = mensaje };
        }




    }
}
