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

        //Metodo que elimina un proveedor
        public virtual RequestStatus Delete(int? id)
        {
            //Envio del parametro al procedimiento almacenado
            var parameter = new DynamicParameters();
            parameter.Add("@Prov_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            try
            {
                //Conexion a la base de datos
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Proveedores_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error desconocido" };
                }
                //Retorno del resultado de la operacion en formato RequestStatus
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }
        }


        public virtual tbProveedores Find(int? id)
        {
            throw new NotImplementedException();
        }

        //Metodo que busca un proveedor por su id
        public IEnumerable<tbProveedores> FindCodigo(tbProveedores? item)
        {
            //Envio del parametro al procedimiento almacenado
            var parameter = new DynamicParameters();
            parameter.Add("@Prov_Id", item.Prov_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            //Conexion a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbProveedores>(ScriptDatabase.Proveedores_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            // Retorno del resultado de la operacion en formato de lista tbProveedores
            return result;

        }


        //Metodo que inserta un nuevo proveedor
        public virtual RequestStatus Insert(tbProveedores item)
        {
            //Envio de los parámetros al procedimiento almacenado
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

            //Conexion a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            //Ejecutar el procedimiento almacenado
            var result = db.Execute(ScriptDatabase.Proveedores_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";

            //Retorno del resultado de la operacion
            return new RequestStatus {code_Status = result, message_Status = mensaje };
        }

        //Metodo que lista todos los registros de la tabla tbProveedores
        public virtual IEnumerable<tbProveedores> List()
        {
            var parameter = new DynamicParameters();

            //Conexion a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            //Asignacion del resultado de la consulta a una variable de tipo lista
            var result = db.Query<tbProveedores>(ScriptDatabase.Proveedores_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            // Retorno del resultado de la operacion en formato de lista tbProveedores
            return result;
        }

        //Metodo que actualiza un proveedor
        public virtual RequestStatus Update(tbProveedores item)
        {
            //Envio de los parámetros al procedimiento almacenado
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

            //Ejecutar el procedimiento almacenado
            var result = db.Execute(ScriptDatabase.Proveedores_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";

            //Retorno del resultado de la operacion
            return new RequestStatus {code_Status = result, message_Status = mensaje };
        }
    }
}
