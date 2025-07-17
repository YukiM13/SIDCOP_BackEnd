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
    public class MarcaVehiculoRepository : IRepository<tbMarcasVehiculos>
    {
        public RequestStatus Update(tbMarcasVehiculos item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@MaVe_Id", item.MaVe_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@MaVe_Marca", item.MaVe_Marca, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@MaVe_FechaModificacion", item.MaVe_FechaModificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);


            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.MarcasVehiculos_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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

       
     


        public RequestStatus Insert(tbMarcasVehiculos item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@MaVe_Marca", item.MaVe_Marca, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@MaVe_FechaCreacion", item.MaVe_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.MarcasVehiculos_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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

        public IEnumerable<tbMarcasVehiculos> List()
        {
            var parameter = new DynamicParameters();


            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbMarcasVehiculos>(ScriptDatabase.MarcasVehiculos_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();


            return result;
        }

        public tbMarcasVehiculos Find(int? id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@MaVe_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            var result = db.QueryFirstOrDefault<tbMarcasVehiculos>(ScriptDatabase.MarcasVehiculos_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            if (result == null)
            {
                throw new Exception("Marca Vehiculo no encontrada");
            }
            return result;
        }

        public tbMarcasVehiculos Modelos(int? id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@MaVe_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            var result = db.QueryFirstOrDefault<tbMarcasVehiculos>(ScriptDatabase.MarcasVehiculos_ListarModelos, parameter, commandType: System.Data.CommandType.StoredProcedure);
            if (result == null)
            {
                throw new Exception("Modelo no encontrado");
            }
            return result;
        }


        public RequestStatus Delete(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@MaVe_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.MarcasVehiculos_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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
