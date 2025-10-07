using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess.Repositories.Logistica
{
    public class RecargasRepository : IRepository<tbRecargas>
    {
        public RequestStatus Delete(int? id)
        {

            throw new NotImplementedException();
        }

        public tbRecargas Find(int? id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<tbRecargas> Find2(int? id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@Vend_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            var result = db.Query<tbRecargas>(ScriptDatabase.Recargas_Listar_Vendedor, parameter, commandType: System.Data.CommandType.StoredProcedure);
            if (result == null)
            {
                throw new Exception("Vendedor sin recargas no encontrada");
            }
            return result;
        }


        public IEnumerable<tbRecargas> FindSucu(int id, bool esAdmin)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@Sucu_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@EsAdmin", esAdmin, System.Data.DbType.Boolean, System.Data.ParameterDirection.Input);

            var result = db.Query<tbRecargas>(ScriptDatabase.Recargas_Listar_conParametro, parameter,
                commandType: System.Data.CommandType.StoredProcedure);

            if (result == null)
            {
                throw new Exception("No se encontraron recargas");
            }

            return result;
        }




        public RequestStatus Insert(tbRecargas item)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@Vend_Id", item.Vend_Id);
            parameter.Add("@Bode_Id", item.Bode_Id);
            parameter.Add("@Reca_Fecha", item.Reca_Fecha);
            parameter.Add("@Reca_Observaciones", item.Reca_Observaciones);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion);
            parameter.Add("@Reca_FechaCreacion", DateTime.Now);


            string detallesXml = item.Detalles != null && item.Detalles.Any()
            ? "<Detalles>" + string.Join("", item.Detalles.Select(d =>
                $"<Deta><Prod_Id>{d.Prod_Id}</Prod_Id><ReDe_Cantidad>{d.ReDe_Cantidad}</ReDe_Cantidad><ReDe_Observaciones>{System.Security.SecurityElement.Escape(d.ReDe_Observaciones ?? "")}</ReDe_Observaciones></Deta>"))
                + "</Detalles>"
            : "<Detalles></Detalles>";

            parameter.Add("@Detalles", detallesXml, DbType.Xml);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Recarga_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error desconocido" };
                }
                return result;
            }
            catch(Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }

        }

        public virtual IEnumerable<tbRecargas> List()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbRecargas>(ScriptDatabase.Recargas_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public RequestStatus Update(tbRecargas item)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@Reca_Id", item.Reca_Id);
            parameter.Add("@Vend_Id", item.Vend_Id);
            parameter.Add("@Bode_Id", item.Bode_Id);
            parameter.Add("@Reca_Fecha", item.Reca_Fecha);
            parameter.Add("@Reca_Observaciones", item.Reca_Observaciones);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion);
            parameter.Add("@Reca_FechaModificacion", item.Reca_FechaModificacion);


            string detallesXml = item.Detalles != null && item.Detalles.Any()
            ? "<Detalles>" + string.Join("", item.Detalles.Select(d =>
                $"<Deta><Prod_Id>{d.Prod_Id}</Prod_Id><ReDe_Cantidad>{d.ReDe_Cantidad}</ReDe_Cantidad><ReDe_Observaciones>{System.Security.SecurityElement.Escape(d.ReDe_Observaciones ?? "")}</ReDe_Observaciones></Deta>"))
                + "</Detalles>"
            : "<Detalles></Detalles>";

            parameter.Add("@Detalles", detallesXml, DbType.Xml);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Recarga_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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

        public RequestStatus RecargasConfirm(tbRecargas item)
        {

            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@Reca_Id", item.Reca_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Reca_Confirmacion", item.Reca_Confirmacion, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            parameter.Add("@Reca_Observaciones", item.Reca_Observaciones, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Confirmacion", item.Usua_Confirmacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Reca_FechaModificacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Recarga_Confirmacion, parameter, commandType: System.Data.CommandType.StoredProcedure);
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
