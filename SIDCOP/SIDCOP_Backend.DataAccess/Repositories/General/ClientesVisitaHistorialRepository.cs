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
    public class ClientesVisitaHistorialRepository : IRepository<tbClientesVisitaHistorial>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbClientesVisitaHistorial Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbClientesVisitaHistorial item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@VeRu_Id", item.VeRu_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Id", item.Clie_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@HCVi_Foto", item.HCVi_Foto, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@HCVi_Observaciones", item.HCVi_Observaciones, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@HCVi_Fecha", item.HCVi_Fecha, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@HCVi_Latitud", item.HCVi_Latitud, System.Data.DbType.Decimal, System.Data.ParameterDirection.Input);
            parameter.Add("@HCVi_Longitud", item.HCVi_Longitud, System.Data.DbType.Decimal, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@HCVi_FechaCreacion", item.HCVi_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.ClientesVisitasHistorial_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error Desconocido" };
                }
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }

        }

        public IEnumerable<tbClientesVisitaHistorial> List()
        {

            var parameter = new DynamicParameters();

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbClientesVisitaHistorial>(ScriptDatabase.ClientesVisitasHistorial_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            return result;
        }

        public RequestStatus Update(tbClientesVisitaHistorial item)
        {
            throw new NotImplementedException();
        }
    }
}
