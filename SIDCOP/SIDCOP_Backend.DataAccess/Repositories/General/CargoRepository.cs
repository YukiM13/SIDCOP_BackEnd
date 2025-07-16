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
    public class CargoRepository : IRepository<tbCargos>
    {
        //public RequestStatus Delete(int? id)
        //{
        //    var parameter = new DynamicParameters();
        //    parameter.Add("@Carg_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

        //    try
        //    {
        //        using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
        //        var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Cargos_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);
        //        if (result == null)
        //        {
        //            return new RequestStatus { code_Status = 0, message_Status = "Error desconocido" };
        //        }
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
        //    }
        //}


        public RequestStatus Delete(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Carg_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            var result = db.Execute(ScriptDatabase.Cargos_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje;

            switch (result)
            {
                case 1:
                    mensaje = "Cargo eliminado correctamente.";
                    break;
                case -1:
                    mensaje = "El cargo está siendo utilizado.";
                    break;
                default:
                    mensaje = "Error al eliminar el cargo.";
                    break;
            }

            return new RequestStatus { code_Status = result, message_Status = mensaje };
        }


        public tbCargos Find(int? id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@Carg_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            var result = db.QueryFirstOrDefault<tbCargos>(ScriptDatabase.Cargos_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            if (result == null)
            {
                throw new KeyNotFoundException("Cargo no encontrado.");
            }
            return result;
        }

        public RequestStatus Insert(tbCargos item)
        {
            if(item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos." };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@Carg_Descripcion", item.Carg_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Carg_FechaCreacion", item.Carg_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Cargos_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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

        public IEnumerable<tbCargos> List()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbCargos>(ScriptDatabase.Cargos_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            return result;
        }

        public RequestStatus Update(tbCargos item)
        {
            if(item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos." };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@Carg_Id", item.Carg_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Carg_Descripcion", item.Carg_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Carg_FechaModificacion", item.Carg_FechaModificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Cargos_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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
