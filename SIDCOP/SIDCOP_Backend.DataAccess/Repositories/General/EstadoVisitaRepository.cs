using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess.Repositories.General
{

    public class EstadoVisitaRepository : IRepository<tbEstadosVisita>
    {
        //public RequestStatus Delete(tbEstadosVisita item)
        //{
        //    throw new NotImplementedException();
        //}

        public tbEstadosVisita Find(int? id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@EsVi_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            var result = db.QueryFirstOrDefault<tbEstadosVisita>(ScriptDatabase.EstadoVisita_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            if (result == null)
            {
                throw new Exception("Estado de Visita no encontrado");
            }
            return result;
        }

        public IEnumerable<tbEstadosVisita> List()
        {
            //var parameter = new DynamicParameters();

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbEstadosVisita>(ScriptDatabase.EstadosVisita_Listar, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        //public RequestStatus InsertEsCi(tbEstadosVisita item)
        //{
        //    if (item == null)
        //    {
        //        return new RequestStatus { codeStatus = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
        //    }
        //    var parameter = new DynamicParameters();
        //    parameter.Add("@EsVi_Descripcion", item.EsVi_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
        //    parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
        //    parameter.Add("@EsVi_FechaCreacion", item.EsVi_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

        //    try
        //    {
        //        using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
        //        var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.EstadoVisita_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
        //        if (result == null)
        //        {
        //            return new RequestStatus { codeStatus = 0, message_Status = "Error desconocido" };
        //        }
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new RequestStatus { codeStatus = 0, message_Status = $"Error inesperado: {ex.Message}" };
        //    }
        //}

        //public RequestStatus ActualizarEsCi(tbEstadosVisita item)
        //{
        //    var parameter = new DynamicParameters();
        //    parameter.Add("@EsVi_Id", item.EsVi_Id, DbType.Int32, ParameterDirection.Input);
        //    parameter.Add("@EsVi_Descripcion", item.EsVi_Descripcion, DbType.String, ParameterDirection.Input);
        //    parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, DbType.Int32, ParameterDirection.Input);
        //    parameter.Add("@EsVi_FechaModificacion", DateTime.Now, DbType.DateTime, ParameterDirection.Input);

        //    using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
        //    var result = db.Execute(ScriptDatabase.EstadoVisita_Actualizar, parameter, commandType: CommandType.StoredProcedure);

        //    string mensaje = (result == 0) ? "Error al actualizar el Estado Civil" : "Estado Civil actualizado correctamente";
        //    return new RequestStatus { code_Status = result, message_Status = mensaje };
        

        //public RequestStatus EliminarEsVi(int? id)
        //{
        //    var parameter = new DynamicParameters();
        //    parameter.Add("@EsVi_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
        //    try
        //    {
        //        using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
        //        var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.EstadoVisita_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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


        //public tbEstadosVisita BuscarEsCi(int? id)
        //{
        //    using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
        //    var parameter = new DynamicParameters();
        //    parameter.Add("@EsVi_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
        //    var result = db.QueryFirstOrDefault<tbEstadosVisita>(ScriptDatabase.EstadoVisita_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure);
        //    if (result == null)
        //    {
        //        throw new Exception("Estado Civil no encontrada");
        //    }
        //    return result;
        //}


        public RequestStatus Update(tbEstadosVisita item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@EsVi_Id", item.EsVi_Id, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@EsVi_Descripcion", item.EsVi_Descripcion, DbType.String, ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@EsVi_FechaModificacion", DateTime.Now, DbType.DateTime, ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Execute(ScriptDatabase.EstadoVisita_Actualizar, parameter, commandType: CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al actualizar el Estado de Visita" : "Estado de Visita actualizado correctamente";
            return new RequestStatus { code_Status = result, message_Status = mensaje };
        }

        public RequestStatus Insert(tbEstadosVisita item)
        {
            if (item == null)
            {
                return new RequestStatus { codeStatus = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@EsVi_Descripcion", item.EsVi_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@EsVi_FechaCreacion", item.EsVi_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.EstadoVisita_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    return new RequestStatus { codeStatus = 0, message_Status = "Error desconocido" };
                }
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { codeStatus = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }
        }

        public RequestStatus Delete(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@EsVi_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.EstadoVisita_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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
