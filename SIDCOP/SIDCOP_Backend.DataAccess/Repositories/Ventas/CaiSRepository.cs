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
    public class CaiSRepository : IRepository<tbCAIs>
    {
        public int Insert(tbCAIs item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@NCai_Codigo", item.NCai_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@NCai_Descripcion", item.NCai_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@NCai_FechaCreacion", item.NCai_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@NCai_Estado", item.NCai_Estado, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Execute(ScriptDatabase.Cai_Agregar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error base de datos" : "Exito";
            return result;
        }

        public IEnumerable<tbCAIs> Listar()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbCAIs>(ScriptDatabase.Cai_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            return result;
        }


        public IEnumerable<tbCAIs> Find2(String? item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@NCai_Codigo", item, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbCAIs>(ScriptDatabase.Cai_Filtrar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();
            return result;

        }

        public RequestStatus Update(tbCAIs item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@NCAi_Codigo", item.NCai_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@NCai_Descripcion", item.NCai_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@NCAi_FechaModificacion", item.NCai_FechaModificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Execute(ScriptDatabase.Cai_Editar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error base de datos" : "Exito";
            return new RequestStatus { Code_Status = result, Message_Status = mensaje };
        }


        public RequestStatus Delete2(tbCAIs item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@NCAi_Codigo", item.NCai_Codigo, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Execute(ScriptDatabase.Cai_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error base de datos" : "Exito";
            return new RequestStatus { Code_Status = result, Message_Status = mensaje };
        }


        public RequestStatus Delete(tbCAIs item)
        {
            throw new NotImplementedException();
        }

        public tbCAIs Find(int? id)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<tbCAIs> List()
        {
            throw new NotImplementedException();
        }

        RequestStatus IRepository<tbCAIs>.Insert(tbCAIs item)
        {
            throw new NotImplementedException();
        }
    }
}
