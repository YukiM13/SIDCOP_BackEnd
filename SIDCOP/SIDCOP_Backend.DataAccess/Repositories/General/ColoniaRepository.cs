using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess.Repositories.General
{
    /// <summary>
    /// Repositorio para el manejo de operaciones CRUD de colonias
    /// Implementa la interfaz IRepository para la entidad tbColonias
    /// </summary>
    public class ColoniaRepository : IRepository<tbColonias>
    {


        /// <summary>
        /// Elimina una colonia específica por su ID
        /// </summary>
        /// <param name="id">ID de la colonia a eliminar</param>
        /// <returns>Estado de la operación de eliminación</returns>
        public RequestStatus Delete(int? id)
        {
            // Configuración de parámetros para eliminación de colonia
            var parameter = new DynamicParameters();
            parameter.Add("@Colo_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            try
            {
                // Ejecuta procedimiento almacenado para eliminar colonia
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Colonias_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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

        /// <summary>
        /// Busca una colonia específica por su ID
        /// </summary>
        /// <param name="id">ID de la colonia a buscar</param>
        /// <returns>Entidad de la colonia encontrada</returns>
        /// <exception cref="Exception">Se lanza cuando la colonia no es encontrada</exception>
        public tbColonias Find(int? id)
        {
            // Ejecuta búsqueda de colonia por ID usando procedimiento almacenado
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@Colo_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            var result = db.QueryFirstOrDefault<tbColonias>(ScriptDatabase.Colonias_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            if (result == null)
            {
                throw new Exception("Colonia no encontrada");
            }
            return result;
        }




        /// <summary>
        /// Inserta una nueva colonia en la base de datos
        /// </summary>
        /// <param name="item">Entidad de la colonia a insertar</param>
        /// <returns>Estado de la operación de inserción</returns>
        public RequestStatus Insert(tbColonias item)
        {
            // Validación de datos de entrada
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            
            // Configuración de parámetros para inserción de colonia
            var parameter = new DynamicParameters();
            parameter.Add("@Colo_Descripcion", item.Colo_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Muni_Codigo", item.Muni_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Colo_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                // Ejecuta procedimiento almacenado para insertar colonia
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Colonias_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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



        /// <summary>
        /// Lista todas las colonias disponibles
        /// </summary>
        /// <returns>Colección de todas las colonias</returns>
        public IEnumerable<tbColonias> List()
        {
            // Obtiene lista completa de colonias
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbColonias>(ScriptDatabase.Colonias_Listar, commandType: System.Data.CommandType.StoredProcedure);
             return result;
        }

        /// <summary>
        /// Lista colonias con información de municipios y departamentos
        /// </summary>
        /// <returns>Colección de colonias con datos de municipios y departamentos</returns>
        public IEnumerable<tbColonias> ListMunicipiosyDepartamentos()
        {
            // Obtiene lista de colonias incluyendo información de municipios y departamentos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbColonias>(ScriptDatabase.Colonias_ListarMunicipiosyDepartamentos, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }





        /// <summary>
        /// Actualiza la información de una colonia existente
        /// </summary>
        /// <param name="item">Entidad de la colonia con datos actualizados</param>
        /// <returns>Estado de la operación de actualización</returns>
        public RequestStatus Update(tbColonias item)
        {
            // Validación de datos de entrada
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            
            // Configuración de parámetros para actualización de colonia
            var parameter = new DynamicParameters();
            parameter.Add("@Colo_Id", item.Colo_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Colo_Descripcion", item.Colo_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Muni_Codigo", item.Muni_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Colo_FechaModificacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                // Ejecuta procedimiento almacenado para actualizar colonia
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Colonias_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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
