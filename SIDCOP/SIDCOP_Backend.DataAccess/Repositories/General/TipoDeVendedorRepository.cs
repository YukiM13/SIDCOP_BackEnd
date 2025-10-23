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
    public class TipoDeVendedorRepository : IRepository<tbTiposDeVendedor>
    {
        /// Elimina el tipo de peso específica por su ID
        public RequestStatus Delete(int? id)
        {
            // Configuración de parámetros para eliminación de tipos de vendedor
            var parameter = new DynamicParameters();
            parameter.Add("@TiVe_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            try
            {
                // Ejecuta procedimiento almacenado para eliminar tipos de vendedor
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.TiVe_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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


        public tbTiposDeVendedor Find(int? id)
        {
            throw new NotImplementedException();
        }


        /// Inserta una nueva tipos de vendedor en la base de datos

        public RequestStatus Insert(tbTiposDeVendedor item)
        {
            // Validación de datos de entrada
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }

            // Configuración de parámetros para inserción de tipos de vendedor
            var parameter = new DynamicParameters();
            parameter.Add("@TiVe_TipoVendedor", item.TiVe_TipoVendedor, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@TiVe_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                // Ejecuta procedimiento almacenado para insertar tipos de vendedor
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.TiVe_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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


        /// Lista todas los tipos de vendedor disponibles

        public IEnumerable<tbTiposDeVendedor> List()
        {
            // Obtiene lista completa de tipos de vendedor
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbTiposDeVendedor>(ScriptDatabase.TiVe_Listar, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }


        /// Actualiza la información de una tipos de vendedor existente

        public RequestStatus Update(tbTiposDeVendedor item)
        {
            // Validación de datos de entrada
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }

            // Configuración de parámetros para actualización de tipos de vendedor
            var parameter = new DynamicParameters();
            parameter.Add("@TiVe_Id", item.TiVe_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@TiVe_TipoVendedor", item.TiVe_TipoVendedor, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@TiVe_FechaModificacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                // Ejecuta procedimiento almacenado para actualizar tipos de vendedor
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.TiVe_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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

