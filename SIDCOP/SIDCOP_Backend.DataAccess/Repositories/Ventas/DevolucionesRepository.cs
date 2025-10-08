using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess.Repositories.Ventas
{
    public class DevolucionesRepository : IRepository<tbDevoluciones>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbDevoluciones Find(int? id)
        {
            throw new NotImplementedException();
        }

        public virtual RequestStatus Insert(tbDevoluciones item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@fact_Id", item.Fact_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@devo_Fecha", item.Devo_Fecha, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@devo_Motivo", item.Devo_Motivo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@devoDetalle_XML", item.devoDetalle_XML, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@devo_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            try
            {
                var result = db.Query<RequestStatus>(ScriptDatabase.Devolucion_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);

                return result.First();
            }
            catch (Exception)
            {

                return new RequestStatus { code_Status = 0, message_Status = "Error en base de datos" };

            }

            //string mensaje = (result == 0) ? "Error en base de datos" : "Exito";

            //return new RequestStatus { code_Status = result, message_Status = mensaje };

        }

        public virtual RequestStatus Trasladar(tbDevoluciones item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos." };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@Devo_Id", item.Devo_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Devolucion_Trasladar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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

        public virtual IEnumerable<tbDevoluciones> List()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbDevoluciones>(ScriptDatabase.Devoluciones_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            return result;
        }

        public RequestStatus Update(tbDevoluciones item)
        {
            throw new NotImplementedException();
        }
    }
}
