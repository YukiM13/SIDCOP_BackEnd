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
    public class AvalRepository : IRepository<tbAvales>
    {
        public RequestStatus Delete(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Aval_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Avales_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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

        public tbAvales Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbAvales item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos." };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@Clie_Id", item.Clie_Id, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Aval_Nombres", item.Aval_Nombres, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Aval_Apellidos", item.Aval_Apellidos, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            //parameter.Add("@Aval_ParentescoConCliente", item.Aval_ParentescoConCliente, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Aval_DNI", item.Aval_DNI, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Aval_Telefono", item.Aval_Telefono, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@TiVi_Id", item.TiVi_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Aval_DireccionExacta", item.Aval_DireccionExacta, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Colo_Id", item.Colo_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Aval_FechaNacimiento", item.Aval_FechaNacimiento, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@EsCv_Id", item.EsCv_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Aval_Sexo", item.Aval_Sexo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Aval_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Avales_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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

        public IEnumerable<tbAvales> List()
        {
            var parameter = new DynamicParameters();
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbAvales>(ScriptDatabase.Avales_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();
            return result;
        }

        public RequestStatus Update(tbAvales item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos." };
            }
            var parameter = new DynamicParameters();
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            parameter.Add("@Aval_Id", item.Aval_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Id", item.Clie_Id, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Aval_Nombres", item.Aval_Nombres, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Aval_Apellidos", item.Aval_Apellidos, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            //parameter.Add("@Aval_ParentescoConCliente", item.Aval_ParentescoConCliente, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Aval_DNI", item.Aval_DNI, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Aval_Telefono", item.Aval_Telefono, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@TiVi_Id", item.TiVi_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Aval_DireccionExacta", item.Aval_DireccionExacta, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Colo_Id", item.Colo_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Aval_FechaNacimiento", item.Aval_FechaNacimiento, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@EsCv_Id", item.EsCv_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Aval_Sexo", item.Aval_Sexo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Aval_FechaModificacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Avales_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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
