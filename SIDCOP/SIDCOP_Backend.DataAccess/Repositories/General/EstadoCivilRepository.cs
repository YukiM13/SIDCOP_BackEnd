using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.DataAccess.Context;
using SIDCOP_Backend.Entities.Entities;

namespace SIDCOP_Backend.DataAccess.Repositories.General
{
    public class EstadoCivilRepository : IRepository<tbEstadosCiviles>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbEstadosCiviles Find(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbEstadosCiviles> List()
        {
            var parameter = new DynamicParameters();


            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbEstadosCiviles>(ScriptDatabase.EstadosCiviles_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();


            return result;
        }

        public int InsertEsCi(tbEstadosCiviles item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@EsCv_Descripcion", item.EsCv_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@EsCv_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.QueryFirstOrDefault<int>(
                ScriptDatabase.EstadoCivil_Insertar,
                parameter,
                commandType: System.Data.CommandType.StoredProcedure
            );

            return result; // Puede ser 1 (éxito), -1 (DNI duplicado), o 0 (error interno)
        }

        public RequestStatus ActualizarEsCi(tbEstadosCiviles item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@EsCv_Id", item.EsCv_Id, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@EsCv_Descripcion", item.EsCv_Descripcion, DbType.String, ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@EsCv_FechaModificacion", DateTime.Now, DbType.DateTime, ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Execute(ScriptDatabase.EstadoCivil_Actualizar, parameter, commandType: CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al actualizar el Estado Civil" : "Estado Civil actualizado correctamente";
            return new RequestStatus { code_Status = result, message_Status = mensaje };
        }

        public RequestStatus EliminarEsCi(tbEstadosCiviles item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@EsCv_Id", item.EsCv_Id, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Execute(ScriptDatabase.EstadoCivil_Eliminar, parameters, commandType: CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al eliminar el Estado Civil" : "Estado Civil correctamente";
            return new RequestStatus { code_Status = result, message_Status = mensaje };
        }

        public tbEstadosCiviles BuscarEsCi(tbEstadosCiviles item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@EsCv_Id", item.EsCv_Id, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.QueryFirstOrDefault<tbEstadosCiviles>(ScriptDatabase.EstadoCivil_Buscar, parameter, commandType: CommandType.StoredProcedure);

            return result;
        }

        public RequestStatus Update(tbEstadosCiviles item)
        {
            throw new NotImplementedException();
        }

        RequestStatus IRepository<tbEstadosCiviles>.Insert(tbEstadosCiviles item)
        {
            throw new NotImplementedException();
        }
    }
}
