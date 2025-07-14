using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess.Repositories.Logistica
{
    public class BodegaRepository : IRepository<tbBodegas>
    {

        public RequestStatus Delete(int? id)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@Bode_Id", id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Execute(ScriptDatabase.Bodega_Eliminar, parameters, commandType: System.Data.CommandType.StoredProcedure);

            var status = new RequestStatus();
            status.code_Status = result;

            return status;
        }

        public tbBodegas Find(int? id)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@Bode_Id", id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbBodegas>(ScriptDatabase.Bodega_Buscar, parameters, commandType: System.Data.CommandType.StoredProcedure);

            return result.First();
        }

        public RequestStatus Insert(tbBodegas item)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@Bode_Descripcion", item.Bode_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@Sucu_Id", item.Sucu_Id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@RegC_Id", item.RegC_Id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@Vend_Id", item.Vend_Id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@Mode_Id", item.Mode_Id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@Bode_VIN", item.Bode_VIN, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@Bode_Placa", item.Bode_Placa, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@Bode_Capacidad", item.Bode_Capacidad, System.Data.DbType.Decimal, System.Data.ParameterDirection.Input);
            parameters.Add("@Bode_TipoCamion", item.Bode_TipoCamion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@Bode_FechaCreacion", item.Bode_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<RequestStatus>(ScriptDatabase.Bodega_Insertar, parameters, commandType: System.Data.CommandType.StoredProcedure);

            var status = new RequestStatus();
            status = result.First();
            

            return status;
        }

        public IEnumerable<tbBodegas> List()
        {

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbBodegas>(ScriptDatabase.Bodegas_Listar, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public RequestStatus Update(tbBodegas item)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@Bode_Id", item.Bode_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameters.Add("@Bode_Descripcion", item.Bode_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@Sucu_Id", item.Sucu_Id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@RegC_Id", item.RegC_Id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@Vend_Id", item.Vend_Id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@Mode_Id", item.Mode_Id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@Bode_VIN", item.Bode_VIN, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@Bode_Placa", item.Bode_Placa, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@Bode_Capacidad", item.Bode_Capacidad, System.Data.DbType.Decimal, System.Data.ParameterDirection.Input);
            parameters.Add("@Bode_TipoCamion", item.Bode_TipoCamion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@Usua_Creacion", item.Usua_Modificacion, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@Bode_FechaCreacion", item.Bode_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Execute(ScriptDatabase.Bodega_Actualizar, parameters, commandType: System.Data.CommandType.StoredProcedure);

            var status = new RequestStatus();
            status.code_Status = result;

            return status;
        }


    }
}
