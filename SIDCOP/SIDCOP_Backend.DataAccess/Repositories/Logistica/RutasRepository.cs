using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SIDCOP_Backend.DataAccess.Context;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess.Repositories.Logistica
{
    public class RutasRepository : IRepository<tbRutas>
    {
        public int Insert(tbRutas item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Ruta_codigo", item.Ruta_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Ruta_Descripcion", item.Ruta_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Ruta_Observaciones", item.Ruta_Observaciones, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Ruta_FechaCreacion", item.Ruta_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@Ruta_Estado", item.Ruta_Estado, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Execute(ScriptDatabase.Rutas_Agregar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error base de datos" : "Exito";
            return result;
        }

        public IEnumerable<tbRutas> Listar()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbRutas>(ScriptDatabase.Rutas_listar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            return result;
        }


        public IEnumerable<tbRutas> Find2(String? item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Ruta_Codigo", item, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbRutas>(ScriptDatabase.Rutas_Filtrar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();
            return result;

        }

        public RequestStatus Update(tbRutas item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Ruta_Codigo", item.Ruta_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Ruta_Descripcion", item.Ruta_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Ruta_Observaciones", item.Ruta_Observaciones, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Ruta_FechaModificacion", item.Ruta_FechaModificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Execute(ScriptDatabase.Rutas_Editar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error base de datos" : "Exito";
            return new RequestStatus { Code_Status = result, Message_Status = mensaje };
        }


        public RequestStatus Delete2(tbRutas item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Ruta_Codigo", item.Ruta_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Execute(ScriptDatabase.Rutas_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error base de datos" : "Exito";
            return new RequestStatus { Code_Status = result, Message_Status = mensaje };
        }

        public RequestStatus Delete(tbRutas item)
        {
            throw new NotImplementedException();
        }

        public tbRutas Find(int? id)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<tbRutas> List()
        {
            throw new NotImplementedException();
        }

        RequestStatus IRepository<tbRutas>.Insert(tbRutas item)
        {
            throw new NotImplementedException();
        }
    }
}
