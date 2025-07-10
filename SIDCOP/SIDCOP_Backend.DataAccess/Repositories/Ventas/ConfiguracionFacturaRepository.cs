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
    public class ConfiguracionFacturaRepository : IRepository<tbConfiguracionFacturas>
    {
        public RequestStatus Delete(tbConfiguracionFacturas item)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@CoFa_Id", item.CoFa_Id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Execute(ScriptDatabase.ConfiguracionFactura_Eliminar, parameters, commandType: System.Data.CommandType.StoredProcedure);

            var status = new RequestStatus();
            status.CodeStatus = result;

            return status;
        }

        public tbConfiguracionFacturas Find(int? id)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@CoFa_Id", id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);           

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbConfiguracionFacturas>(ScriptDatabase.ConfiguracionFactura_Buscar, parameters, commandType: System.Data.CommandType.StoredProcedure);

            return result.First();
        }

        public RequestStatus Insert(tbConfiguracionFacturas item)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@CoFa_NombreEmpresa", item.CoFa_NombreEmpresa, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@CoFa_DireccionEmpresa", item.CoFa_DireccionEmpresa, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@CoFa_RTN", item.CoFa_RTN, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@CoFa_Correo", item.CoFa_Correo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@CoFa_Telefono1", item.CoFa_Telefono1, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@CoFa_Telefono2", item.CoFa_Telefono2, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@CoFa_Logo", item.CoFa_Logo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@Colo_Id", item.Colo_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameters.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameters.Add("@CoFa_FechaCreacion", item.CoFa_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Execute(ScriptDatabase.ConfiguracionFactura_Insertar, parameters, commandType: System.Data.CommandType.StoredProcedure);

            var status = new RequestStatus();
            status.CodeStatus = result;

            return status;
        }

        public IEnumerable<tbConfiguracionFacturas> List()
        {

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbConfiguracionFacturas>(ScriptDatabase.ConfiguracionFacturas_Listar, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public RequestStatus Update(tbConfiguracionFacturas item)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@CoFa_Id", item.CoFa_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameters.Add("@CoFa_NombreEmpresa", item.CoFa_NombreEmpresa, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@CoFa_DireccionEmpresa", item.CoFa_DireccionEmpresa, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@CoFa_RTN", item.CoFa_RTN, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@CoFa_Correo", item.CoFa_Correo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@CoFa_Telefono1", item.CoFa_Telefono1, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@CoFa_Telefono2", item.CoFa_Telefono2, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@CoFa_Logo", item.CoFa_Logo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@Colo_Id", item.Colo_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameters.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameters.Add("@CoFa_FechaModificacion", item.CoFa_FechaModificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Execute(ScriptDatabase.ConfiguracionFactura_Actualizar, parameters, commandType: System.Data.CommandType.StoredProcedure);

            var status = new RequestStatus();
            status.CodeStatus = result;

            return status;
        }
    }
}
