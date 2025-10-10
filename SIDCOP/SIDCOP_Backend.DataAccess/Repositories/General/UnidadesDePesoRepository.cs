using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;

namespace SIDCOP_Backend.DataAccess.Repositories.General
{
    /// <summary>
    /// Repositorio para el manejo de operaciones CRUD de unidades de peso
    /// Implementa la interfaz IRepository para la entidad tbUnidadesDePeso
    /// </summary>
    public class UnidadesDePesoRepository : IRepository<tbUnidadesDePeso>
    {
        /// Elimina una unidad de peso específica por su ID
        public RequestStatus Delete(int? id)
        {
            // Configuración de parámetros para eliminación de unidad de peso
            var parameter = new DynamicParameters();
            parameter.Add("@UnPe_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            try
            {
                // Ejecuta procedimiento almacenado para eliminar unidad de peso
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.UnPeso_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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


        public tbUnidadesDePeso Find(int? id)
        {
            throw new NotImplementedException();
        }


        /// Inserta una nueva unidad de peso en la base de datos

        public RequestStatus Insert(tbUnidadesDePeso item)
        {
            // Validación de datos de entrada
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            
            // Configuración de parámetros para inserción de unidad de peso
            var parameter = new DynamicParameters();
            parameter.Add("@UnPe_Descripcion", item.UnPe_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@UnPe_Abreviatura", item.UnPe_Abreviatura, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@UnPe_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                // Ejecuta procedimiento almacenado para insertar unidad de peso
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.UnPeso_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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


        /// Lista todas las unidades de peso disponibles
 
        public IEnumerable<tbUnidadesDePeso> List()
        {
            // Obtiene lista completa de unidades de peso
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbUnidadesDePeso>(ScriptDatabase.UnPeso_Listar, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }


        /// Actualiza la información de una unidad de peso existente

        public RequestStatus Update(tbUnidadesDePeso item)
        {
            // Validación de datos de entrada
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            
            // Configuración de parámetros para actualización de unidad de peso
            var parameter = new DynamicParameters();
            parameter.Add("@UnPe_Id", item.UnPe_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@UnPe_Descripcion", item.UnPe_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@UnPe_Abreviatura", item.UnPe_Abreviatura, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@UnPe_FechaModificacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                // Ejecuta procedimiento almacenado para actualizar unidad de peso
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.UnPeso_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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
