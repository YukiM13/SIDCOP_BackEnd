using Dapper;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess.Repositories.Inventario
{
    public class DescuentosRepository : IRepository<tbDescuentos>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbDescuentos Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbDescuentos item)
        {

            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }

            var parameter = new DynamicParameters();

            parameter.Add("@desc_Descripcion", item.Desc_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@desc_Tipo", item.Desc_Tipo, System.Data.DbType.Boolean, System.Data.ParameterDirection.Input);
            parameter.Add("@desc_Aplicar", item.Desc_Aplicar, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@desc_FechaInicio", item.Desc_FechaInicio, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@desc_FechaFin", item.Desc_FechaFin, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@desc_Observaciones", item.Desc_Observaciones, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@desc_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Descuentos_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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

        public RequestStatus InsertDetails(tbDescuentosDetalle item)
        {

            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }

            var jsonIds = JsonConvert.SerializeObject(item.IdReferencias);
            var parameter = new DynamicParameters();

            parameter.Add("@desc_Id", item.Desc_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@id_ReferenciaJSON", jsonIds, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@desD_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.DescuentosDetalle_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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


        public RequestStatus InsertDetailsClientes(tbDescuentoPorClientes item)
        {

            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }

            var jsonIds = JsonConvert.SerializeObject(item.IdClientes);
            var parameter = new DynamicParameters();

            parameter.Add("@desc_Id", item.Desc_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@clie_IdJSON", jsonIds, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@deEs_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.DescuentosPorCliente_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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

        public RequestStatus InsertDetallesEscala(tbDescuentosPorEscala item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            var parameters = new DynamicParameters();

            parameters.Add("@desc_Id", item.Desc_Id, DbType.Int32);
            parameters.Add("@escala_JSON", item.Escala_JSON, DbType.String);
            parameters.Add("@usua_Creacion", item.Usua_Creacion, DbType.Int32);
            parameters.Add("@deEs_FechaCreacion", item.DeEs_FechaCreacion, DbType.DateTime);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.DescuentosPorEscala_Insertar, parameters, commandType: System.Data.CommandType.StoredProcedure);
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

        public IEnumerable<tbDescuentos> List()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbDescuentos>(ScriptDatabase.Descuentos_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public RequestStatus Update(tbDescuentos item)
        {
            throw new NotImplementedException();
        }
    }
}
