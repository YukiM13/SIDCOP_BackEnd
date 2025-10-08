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
        //Metodo que elimina una categoria por su id
        public RequestStatus Delete(int?  id)
        {
            //Envio del parametro al procedimiento almacenado
            var parameter = new DynamicParameters();
            parameter.Add("@Cate_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            //Conexion a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            //Ejecutar el procedimiento almacenado
            var result = db.Execute(ScriptDatabase.Categoria_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";

            //Retorno del resultado de la operacion en formato RequestStatus
            return new RequestStatus { code_Status = result, message_Status = mensaje };
        }

        public tbCategorias Find(int? id)
        {
            throw new NotImplementedException();
        }

        //Metodo que busca una categoria por su id
        public IEnumerable<tbCategorias> FindCodigo(tbCategorias? item)
        {

            //Envio del parametro al procedimiento almacenado
            var parameter = new DynamicParameters();
            parameter.Add("@Cate_Id", item.Cate_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            //Conexion a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            //Asignacion del resultado de la consulta a una variable de tipo lista
            var result = db.Query<tbCategorias>(ScriptDatabase.Categoria_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            // Retorno del resultado de la operacion en formato de lista tbCategorias
            return result;

        }

        //Metodo que lista las subcategorias de una categoria
        public IEnumerable<tbCategorias> ListarSubcategorias(tbCategorias? item)
        {
            //Envio del parametro al procedimiento almacenado
            var parameter = new DynamicParameters();
            parameter.Add("@Cate_Id", item.Cate_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            //Conexion a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            //Asignacion del resultado de la consulta a una variable de tipo lista
            var result = db.Query<tbCategorias>(ScriptDatabase.Categoria_FiltrarSubcategorias, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            // Retorno del resultado de la operacion en formato de lista tbCategorias
            return result;

        }

        //Metodo que inserta una nueva categoria
        public RequestStatus Insert(tbCategorias item)
        {
            //Validacion de que el objeto no venga nulo
            var parameter = new DynamicParameters();
            parameter.Add("@Cate_Descripcion", item.Cate_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Cate_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            //Conexion a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            //Ejecutar el procedimiento almacenado
            var result = db.Execute(ScriptDatabase.Categoria_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";

            //Retorno del resultado de la operacion en formato RequestStatus
            return new RequestStatus {code_Status = result, message_Status = mensaje };
        }

        //Metodo que lista todas las categorias
        public IEnumerable<tbCategorias> List()
        {
            var parameter = new DynamicParameters();
            //Conexion a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            //Asignacion del resultado de la consulta a una variable de tipo lista
            var result = db.Query<tbCategorias>(ScriptDatabase.Categoria_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            //  Retorno del resultado de la operacion en formato de lista tbCategorias
            return result;
        }

        //Metodo que actualiza una categoria
        public RequestStatus Update(tbCategorias item)
        {
            //Validacion de que el objeto no venga nulo
            var parameter = new DynamicParameters();
            parameter.Add("@Cate_Id", item.Cate_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Cate_Descripcion", item.Cate_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Cate_FechaModificacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            //Conexion a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            //Ejecutar el procedimiento almacenado
            var result = db.Execute(ScriptDatabase.Categoria_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";

            //Retorno del resultado de la operacion en formato RequestStatus
            return new RequestStatus {code_Status = result, message_Status = mensaje };
        }
    }
}
