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

        public RequestStatus Insert(tbRecargas item)
        {
            var parameter = new DynamicParameters();

           // parameter.Add("@Empl_Id", item.Empl_Id);
            parameter.Add("@Bode_Id", item.Bode_Id);
            parameter.Add("@Reca_Fecha", item.Reca_Fecha);
            parameter.Add("@Reca_Observaciones", item.Reca_Observaciones);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion);
            parameter.Add("@Reca_FechaCreacion", item.Reca_FechaCreacion);


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


            throw new NotImplementedException();
        }

        public IEnumerable<tbRecargas> List()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbRecargas>(ScriptDatabase.Recargas_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public RequestStatus Update(tbRecargas item)
        {
            throw new NotImplementedException();
        }
    }
}
