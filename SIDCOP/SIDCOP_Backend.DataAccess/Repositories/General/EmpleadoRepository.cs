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
    public class EmpleadoRepository : IRepository<tbEmpleados>
    {
        public RequestStatus Delete(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Empl_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Empleados_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error desconocido" };
                }
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }
        }



        public tbEmpleados Find(int? id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@Empl_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            var result = db.QueryFirstOrDefault<tbEmpleados>(ScriptDatabase.Empleados_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            if (result == null)
            {
                throw new Exception("Empleado no encontrada");
            }
            return result;
        }


        public RequestStatus Insert(tbEmpleados item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@Empl_DNI", item.Empl_DNI, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_Codigo", item.Empl_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_Nombres", item.Empl_Nombres, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_Apellidos", item.Empl_Apellidos, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_Sexo", item.Empl_Sexo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_FechaNacimiento", item.Empl_FechaNacimiento, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_Correo", item.Empl_Correo, System.Data.DbType.String, System.Data.ParameterDirection.Input); 
            parameter.Add("@Empl_Telefono", item.Empl_Telefono, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Sucu_Id", item.Sucu_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@EsCv_Id", item.EsCv_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Carg_Id", item.Carg_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Colo_Id", item.Colo_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_DireccionExacta", item.Empl_DireccionExacta, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_Imagen", item.Empl_Imagen, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Empleados_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error desconocido" };
                }
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }

        }



        public IEnumerable<tbEmpleados> List()
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbEmpleados>(ScriptDatabase.Empleados_Listar, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public RequestStatus Update(tbEmpleados item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@Empl_Id", item.Empl_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_DNI", item.Empl_DNI, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_Nombres", item.Empl_Nombres, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_Apellidos", item.Empl_Apellidos, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_Sexo", item.Empl_Sexo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_FechaNacimiento", item.Empl_FechaNacimiento, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_Correo", item.Empl_Correo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_Telefono", item.Empl_Telefono, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Sucu_Id", item.Sucu_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@EsCv_Id", item.EsCv_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Carg_Id", item.Carg_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Colo_Id", item.Colo_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_DireccionExacta", item.Empl_DireccionExacta, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_Imagen", item.Empl_Imagen, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_FechaModificacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Empleados_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error desconocido" };
                }
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }
        }


    }
}
