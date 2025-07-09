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
    public class SucursalesRepository : IRepository<tbSucursales>
    {
        public RequestStatus Delete(tbSucursales item)
        {
            throw new NotImplementedException();
        }

        public tbSucursales Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbSucursales item)
        {
            if (item == null)
            {
                return new RequestStatus { CodeStatus = 0, MessageStatus = "Los datos llegaron vacios o datos erroneos" };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@Sucu_Descripcion", item.Sucu_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Colo_Id", item.Colo_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Sucu_DireccionExacta", item.Sucu_DireccionExacta, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Sucu_Telefono1", item.Sucu_Telefono1, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Sucu_Telefono2", item.Sucu_Telefono2, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Sucu_Correo", item.Sucu_Correo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Sucu_FechaCreacion", item.Sucu_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Sucursal_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    return new RequestStatus { CodeStatus = 0, MessageStatus = "Error desconocido" };
                }
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { CodeStatus = 0, MessageStatus = $"Error inesperado: {ex.Message}" };
            }
        }

        public IEnumerable<tbSucursales> List()
        {
            var parameter = new DynamicParameters();


            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbSucursales>(ScriptDatabase.Sucursales_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();


            return result;
        }

        public RequestStatus Update(tbSucursales item)
        {
            throw new NotImplementedException();
        }
    }
}
