using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess.Repositories.Ventas
{
    public class RegistrosCaiSRepository : IRepository<tbRegistrosCAI>
    {
        public virtual RequestStatus Insert(tbRegistrosCAI item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            // Configuración extensa de parámetros para registro CAI (incluye rangos de numeración)
            var parameter = new DynamicParameters();
            parameter.Add("@RegC_Descripcion", item.RegC_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Sucu_Id", item.Sucu_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@PuEm_Id", item.PuEm_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@NCai_Id", item.NCai_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@RegC_RangoInicial", item.RegC_RangoInicial, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@RegC_RangoFinal", item.RegC_RangoFinal, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@RegC_FechaInicialEmision", item.RegC_FechaInicialEmision, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@RegC_FechaFinalEmision", item.RegC_FechaFinalEmision, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@RegC_FechaCreacion", item.RegC_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.RegistrosCaiSInsertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error Desconocido" };
                }
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }
        }

        public virtual IEnumerable<tbRegistrosCAI> List()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbRegistrosCAI>(ScriptDatabase.RegistrosCaiSListar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            return result;
        }

        public virtual tbRegistrosCAI Find(int? id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@RegC_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            var result = db.QueryFirstOrDefault<tbRegistrosCAI>(ScriptDatabase.RegistrosCaiSFiltrar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            if (result == null)
            {
                throw new Exception("Registro Cai no encontrado");
            }
            return result;
        }

        public virtual RequestStatus Delete(tbRegistrosCAI item)
        {
            // Eliminación lógica con auditoría de usuario y fecha
            var parameter = new DynamicParameters();
            parameter.Add("@RegC_Id", item.RegC_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Regc_FechaModificacion", item.RegC_FechaModificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.RegistrosCaiSEliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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

        public virtual RequestStatus Update(tbRegistrosCAI item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@RegC_Id", item.RegC_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@RegC_Descripcion", item.RegC_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Sucu_Id", item.Sucu_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@PuEm_Id", item.PuEm_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@NCai_Id", item.NCai_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@RegC_RangoInicial", item.RegC_RangoInicial, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@RegC_RangoFinal", item.RegC_RangoFinal, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@RegC_FechaInicialEmision", item.RegC_FechaInicialEmision, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@RegC_FechaFinalEmision", item.RegC_FechaFinalEmision, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@RegC_FechaModificacion", item.RegC_FechaModificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.RegistrosCaiSEditar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error Desconocido" };
                }
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }
        }

        // Implementaciones de interfaz no utilizadas - patrón de diseño inconsistente
        IEnumerable<tbRegistrosCAI> IRepository<tbRegistrosCAI>.List()
        {
            throw new NotImplementedException();
        }

        tbRegistrosCAI IRepository<tbRegistrosCAI>.Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }
    }
}