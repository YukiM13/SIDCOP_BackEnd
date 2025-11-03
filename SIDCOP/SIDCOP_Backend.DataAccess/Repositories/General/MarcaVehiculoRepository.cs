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
    // Repositorio para manejar las operaciones CRUD sobre las marcas de vehículos
    public class MarcaVehiculoRepository : IRepository<tbMarcasVehiculos>
    {
        // Actualiza una marca de vehículo existente en la base de datos
        public RequestStatus Update(tbMarcasVehiculos item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            var parameter = new DynamicParameters();
            //Declaracion de parametros
            parameter.Add("@MaVe_Id", item.MaVe_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@MaVe_Marca", item.MaVe_Marca, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@MaVe_FechaModificacion", item.MaVe_FechaModificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);


            try
            {
                //Se llama el ConnectionString para conectarse a la base de datos
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                //Ejecuta el procedimiento con los parametros y trae un resultado
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.MarcasVehiculos_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error desconocido" };
                }

                //Retorna el status del procedimiento para saber si se realizo
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }
        }

       
     


        // Inserta una nueva marca de vehículo en la base de datos
        public RequestStatus Insert(tbMarcasVehiculos item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            var parameter = new DynamicParameters();
            //Declaracion de parametros
            parameter.Add("@MaVe_Marca", item.MaVe_Marca, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@MaVe_FechaCreacion", item.MaVe_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                //Se llama el ConnectionString para conectarse a la base de datos
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                //Ejecuta el procedimiento con los parametros y trae lista de RequestStatus
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.MarcasVehiculos_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error desconocido" };
                }
                //Retorna el status del procedimiento para saber si se realizo
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }
        }

        // Lista todas las marcas de vehículos registradas en el sistema
        public IEnumerable<tbMarcasVehiculos> List()
        {
            var parameter = new DynamicParameters();

            //Se llama el ConnectionString para conectarse a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            //Ejecuta el procedimiento y trae una lista de marcas de vehículos
            var result = db.Query<tbMarcasVehiculos>(ScriptDatabase.MarcasVehiculos_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            //Retorna la lista de marcas de vehículos
            return result;
        }

        // Busca una marca de vehículo por ID
        public tbMarcasVehiculos Find(int? id)
        {
            //Se llama el ConnectionString para conectarse a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            //Declaracion de parametros
            parameter.Add("@MaVe_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            //Ejecuta el procedimiento con el parametro y trae una lista
            var result = db.QueryFirstOrDefault<tbMarcasVehiculos>(ScriptDatabase.MarcasVehiculos_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            if (result == null)
            {
                throw new Exception("Marca Vehiculo no encontrada");
            }
            //Retorna la marca de vehículo encontrada
            return result;
        }

        // Busca los modelos de una marca de vehículo por ID
        public tbMarcasVehiculos Modelos(int? id)
        {
            //Se llama el ConnectionString para conectarse a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            //Declaracion de parametros
            parameter.Add("@MaVe_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            //Ejecuta el procedimiento con el parametro y trae una lista
            var result = db.QueryFirstOrDefault<tbMarcasVehiculos>(ScriptDatabase.MarcasVehiculos_ListarModelos, parameter, commandType: System.Data.CommandType.StoredProcedure);
            if (result == null)
            {
                throw new Exception("Modelo no encontrado");
            }
            //Retorna los modelos de la marca encontrados
            return result;
        }


        // Elimina una marca de vehículo por ID
        public RequestStatus Delete(int? id)
        {
            var parameter = new DynamicParameters();
            //Declaracion de parametros
            parameter.Add("@MaVe_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            try
            {
                //Se llama el ConnectionString para conectarse a la base de datos
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                //Ejecuta el procedimiento con el parametro
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.MarcasVehiculos_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error desconocido" };
                }
                //Retorna el status del procedimiento para saber si se realizo
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }
        }
    }
}
