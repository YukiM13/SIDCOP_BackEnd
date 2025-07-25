using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess.Repositories.Inventario
{
    public class CategoriasRepository : IRepository<tbCategorias>
    {
        public RequestStatus Delete(int?  id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Cate_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            var result = db.Execute(ScriptDatabase.Categoria_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";

            return new RequestStatus { code_Status = result, message_Status = mensaje };
        }

        public tbCategorias Find(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbCategorias> FindCodigo(tbCategorias? item)
        {

            var parameter = new DynamicParameters();
            parameter.Add("@Cate_Id", item.Cate_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbCategorias>(ScriptDatabase.Categoria_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;

        }

        public IEnumerable<tbCategorias> ListarSubcategorias(tbCategorias? item)
        {

            var parameter = new DynamicParameters();
            parameter.Add("@Cate_Id", item.Cate_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbCategorias>(ScriptDatabase.Categoria_FiltrarSubcategorias, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;

        }

        public RequestStatus Insert(tbCategorias item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Cate_Descripcion", item.Cate_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Cate_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Execute(ScriptDatabase.Categoria_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";

            return new RequestStatus {code_Status = result, message_Status = mensaje };
        }

        public IEnumerable<tbCategorias> List()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbCategorias>(ScriptDatabase.Categoria_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            return result;
        }

        public RequestStatus Update(tbCategorias item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Cate_Id", item.Cate_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Cate_Descripcion", item.Cate_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Cate_FechaModificacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);


            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            var result = db.Execute(ScriptDatabase.Categoria_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";

            return new RequestStatus {code_Status = result, message_Status = mensaje };
        }
    }
}
