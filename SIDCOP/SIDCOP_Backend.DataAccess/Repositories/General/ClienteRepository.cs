using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess.Repositories.General
{
    public class ClienteRepository : IRepository<tbClientes>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus ChangeState(int? id, DateTime? fecha)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Clie_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@FechaActual", fecha, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Cliente_CambiarEstado, parameter, commandType: System.Data.CommandType.StoredProcedure);
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

        public tbClientes Find(int? id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@Clie_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            var result = db.QueryFirstOrDefault<tbClientes>(ScriptDatabase.Cliente_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            if (result == null)
            {
                throw new Exception("Cliente no encontrado");
            }
            return result;
        }

        public RequestStatus Insert(tbClientes item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@Clie_Codigo", item.Clie_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Nacionalidad", item.Clie_Nacionalidad, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_DNI", item.Clie_DNI, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_RTN", item.Clie_RTN, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Nombres", item.Clie_Nombres, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Apellidos", item.Clie_Apellidos, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_NombreNegocio", item.Clie_NombreNegocio, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_ImagenDelNegocio", item.Clie_ImagenDelNegocio, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Telefono", item.Clie_Telefono, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Correo", item.Clie_Correo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Sexo", item.Clie_Sexo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_FechaNacimiento", item.Clie_FechaNacimiento, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@TiVi_Id", item.TiVi_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Cana_Id", item.Cana_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@EsCv_Id", item.EsCv_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Ruta_Id", item.Ruta_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_LimiteCredito", item.Clie_LimiteCredito, System.Data.DbType.Decimal, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_DiasCredito", item.Clie_DiasCredito, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Saldo", item.Clie_Saldo, System.Data.DbType.Decimal, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Vencido", item.Clie_Vencido, System.Data.DbType.Boolean, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Observaciones", item.Clie_Observaciones, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_ObservacionRetiro", item.Clie_ObservacionRetiro, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Confirmacion", item.Clie_Confirmacion, System.Data.DbType.Boolean, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_FechaCreacion", item.Clie_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Cliente_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                

                
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

        public IEnumerable<tbClientes> ListConfirmados()
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbClientes>(ScriptDatabase.Clientes_ListarConfirmados, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public IEnumerable<tbClientes> ListSinConfirmacion()
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbClientes>(ScriptDatabase.Clientes_ListarSinConfirmacion, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public RequestStatus Update(tbClientes item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacíos o datos erroneos" };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@Clie_Id", item.Clie_Id, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Codigo", item.Clie_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Nacionalidad", item.Clie_Nacionalidad, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_DNI", item.Clie_DNI, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_RTN", item.Clie_RTN, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Nombres", item.Clie_Nombres, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Apellidos", item.Clie_Apellidos, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_NombreNegocio", item.Clie_NombreNegocio, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_ImagenDelNegocio", item.Clie_ImagenDelNegocio, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Telefono", item.Clie_Telefono, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Correo", item.Clie_Correo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Sexo", item.Clie_Sexo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_FechaNacimiento", item.Clie_FechaNacimiento, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@TiVi_Id", item.TiVi_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Cana_Id", item.Cana_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@EsCv_Id", item.EsCv_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Ruta_Id", item.Ruta_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_LimiteCredito", item.Clie_LimiteCredito, System.Data.DbType.Decimal, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_DiasCredito", item.Clie_DiasCredito, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Saldo", item.Clie_Saldo, System.Data.DbType.Decimal, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Vencido", item.Clie_Vencido, System.Data.DbType.Boolean, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Observaciones", item.Clie_Observaciones, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_ObservacionRetiro", item.Clie_ObservacionRetiro, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Confirmacion", item.Clie_Confirmacion, System.Data.DbType.Boolean, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_FechaModificacion", item.Clie_FechaModificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Cliente_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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


