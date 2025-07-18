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
    public class DireccionesPorClienteRepository : IRepository<tbDireccionesPorCliente>
    {
        public RequestStatus Insert(tbDireccionesPorCliente item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos." };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@Clie_Id", item.Clie_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Colo_Id", item.Colo_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);    
            parameter.Add("@DiCl_DireccionExacta", item.DiCl_DireccionExacta, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@DiCl_Observaciones", item.DiCl_Observaciones, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@DiCl_Latitud", item.DiCl_Latitud, System.Data.DbType.Decimal, System.Data.ParameterDirection.Input);
            parameter.Add("@DiCl_Longitud", item.DiCl_Longitud, System.Data.DbType.Decimal, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@DiCl_FechaCreacion", item.DiCl_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.DireccionPorCliente_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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


        public RequestStatus Update(tbDireccionesPorCliente item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos." };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@DiCl_Id", item.DiCl_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Id", item.Clie_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Colo_Id", item.Colo_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@DiCl_DireccionExacta", item.DiCl_DireccionExacta, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@DiCl_Observaciones", item.DiCl_Observaciones, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@DiCl_Latitud", item.DiCl_Latitud, System.Data.DbType.Decimal, System.Data.ParameterDirection.Input);
            parameter.Add("@DiCl_Longitud", item.DiCl_Longitud, System.Data.DbType.Decimal, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@DiCl_FechaModificacion", item.DiCl_FechaModificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.DireccionPorCliente_Modificar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbDireccionesPorCliente Find(int? id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<tbDireccionesPorCliente> List()
        {
            throw new NotImplementedException();
        }

    }
}
