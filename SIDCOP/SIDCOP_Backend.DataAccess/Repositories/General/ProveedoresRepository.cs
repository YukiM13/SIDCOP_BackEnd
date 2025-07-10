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
    public class ProveedoresRepository : IRepository<tbProveedores>
    {
        public RequestStatus Delete(tbProveedores item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Prov_Id", item.Prov_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            var result = db.Execute(ScriptDatabase.Proveedores_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

        public tbProveedores Find(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbProveedores> FindCodigo(tbProveedores? item)
        {

            var parameter = new DynamicParameters();
            parameter.Add("@Prov_Id", item.Prov_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbProveedores>(ScriptDatabase.Proveedores_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;

        }


        public RequestStatus Insert(tbProveedores item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Prov_Codigo", item.Prov_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prov_NombreEmpresa", item.Prov_NombreEmpresa, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prov_NombreContacto", item.Prov_NombreContacto, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Colo_Id", item.Colo_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prov_DireccionExacta", item.Prov_DireccionExacta, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prov_Telefono", item.Prov_Telefono, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prov_Correo", item.Prov_Correo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prov_Observaciones", item.Prov_Observaciones, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prov_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Execute(ScriptDatabase.Proveedores_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

        public IEnumerable<tbProveedores> List()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbProveedores>(ScriptDatabase.Proveedores_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            return result;
        }

        public RequestStatus Update(tbProveedores item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Prov_Id", item.Prov_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prov_Codigo", item.Prov_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prov_NombreEmpresa", item.Prov_NombreEmpresa, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prov_NombreContacto", item.Prov_NombreContacto, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Colo_Id", item.Colo_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prov_DireccionExacta", item.Prov_DireccionExacta, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prov_Telefono", item.Prov_Telefono, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prov_Correo", item.Prov_Correo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prov_Observaciones", item.Prov_Observaciones, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prov_FechaModificacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);


            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            var result = db.Execute(ScriptDatabase.Proveedores_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }
    }
}
