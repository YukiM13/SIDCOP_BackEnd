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
    public class SubcategoriasRepository: IRepository<tbSubcategorias>
    {
        //Metodo que elimina una subcategoria por su id
        public RequestStatus Delete(int? id)
        {
            //Envio del parametro al procedimiento almacenado
            var parameter = new DynamicParameters();
            parameter.Add("@Subc_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            //Conexion a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            //Ejecutar el procedimiento almacenado y almacenar el resultado
            var result = db.Execute(ScriptDatabase.Subcategorias_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";

            return new RequestStatus {code_Status = result, message_Status = mensaje };
        }

        public tbSubcategorias Find(int? id)
        {
            throw new NotImplementedException();
        }

        //Metodo que busca una subcategoria por su id
        public IEnumerable<tbSubcategorias> FindCodigo(tbSubcategorias? item)
        {
            //Envio del parametro al procedimiento almacenado
            var parameter = new DynamicParameters();
            parameter.Add("@Subc_Id", item.Subc_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            //Conexion a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            //Asignacion del resultado de la consulta a una variable de tipo lista
            var result = db.Query<tbSubcategorias>(ScriptDatabase.Subcategorias_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;

        }

        //Metodo que inserta una nueva subcategoria
        public RequestStatus Insert(tbSubcategorias item)
        {
            //Envio de los parametros al procedimiento almacenado
            var parameter = new DynamicParameters();
            parameter.Add("@Subc_Descripcion", item.Subc_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Cate_Id", item.Cate_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Subc_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            //Conexion a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            //Ejecutar el procedimiento almacenado
            var result = db.Execute(ScriptDatabase.Subcategorias_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";

            return new RequestStatus {code_Status = result, message_Status = mensaje };
        }

        //Metodo que lista todos los registros de la tabla tbSubcategorias
        public IEnumerable<tbSubcategorias> List()
        {
            var parameter = new DynamicParameters();
            //Conexion a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            //Asignacion del resultado de la consulta a una variable de tipo lista
            var result = db.Query<tbSubcategorias>(ScriptDatabase.Subcategorias_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            return result;
        }

        //Metodo que actualiza una subcategoria
        public RequestStatus Update(tbSubcategorias item)
        {
            //Envio de los parametros al procedimiento almacenado
            var parameter = new DynamicParameters();
            parameter.Add("@Subc_Id", item.Subc_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Subc_Descripcion", item.Subc_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Cate_Id", item.Cate_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Subc_FechaModificacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            //Conexion a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            //Ejecutar el procedimiento almacenado
            var result = db.Execute(ScriptDatabase.Subcategorias_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";

            return new RequestStatus {code_Status = result, message_Status = mensaje };
        }
    }
}
