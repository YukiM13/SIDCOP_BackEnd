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
    public class InventarioSucursalRepository : IRepository<tbInventarioSucursales>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbInventarioSucursales Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbInventarioSucursales item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbInventarioSucursales> ListInve(int id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@Sucu_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            var result = db.Query<tbInventarioSucursales>(
                ScriptDatabase.InventarioSucursal_Filtrado,
                parameter,
                commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public IEnumerable<tbInventarioSucursales> ListadoPorSucursal(int id)
        {
            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var parameter = new DynamicParameters();
                parameter.Add("@Sucu_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                var result = db.Query<tbInventarioSucursales>(ScriptDatabase.InventarioSucursal_ListarPorSucursal, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();
                if(result == null)
                {
                    throw new Exception("Inventario no encontrado");
                }
                return result;
            }
            catch (Exception)
            {
                throw new Exception("Error");
            }
        }

        public IEnumerable<tbInventarioSucursales> ActulizarInventario(int sucu_id, int usua_id)
        {
            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var parameter = new DynamicParameters();
                parameter.Add("@Sucu_Id", sucu_id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Usua_Id", usua_id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                var result = db.Query<tbInventarioSucursales>(ScriptDatabase.InventarioSucursal_ActualizarPorSucursal, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();
                if (result == null || !result.Any())
                {
                    throw new Exception("No se encontraron registros para actualizar el inventario.");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar el inventario: {ex.Message}");
            }
        }

        public IEnumerable<tbInventarioSucursales> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbInventarioSucursales item)
        {
            throw new NotImplementedException();
        }

 
    }
}
