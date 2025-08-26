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
    public class ImagenVisitaRepository : IRepository<tbImagenesVisita>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbImagenesVisita> ListPorVisita(int? id)
        {
            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var parameter = new DynamicParameters();
                parameter.Add("@ClVi_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                var result = db.Query<tbImagenesVisita>(ScriptDatabase.ImagenesVisita_ListarPorVisita, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

                if (result == null)
                {
                    throw new Exception("Visita no encontrada");
                }
                return result;
            }
            catch (Exception)
            {
                throw new Exception("Error");
            }
        }

        public RequestStatus Insert(tbImagenesVisita item)
        {
            if (item == null)
            {
                return new RequestStatus { codeStatus = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@ImVi_Imagen", item.ImVi_Imagen, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@ClVi_Id", item.ClVi_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@ImVi_FechaCreacion", item.ImVi_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.ImagenesVisita_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    return new RequestStatus { codeStatus = 0, message_Status = "Error desconocido" };
                }
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { codeStatus = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }
        }

        public IEnumerable<tbImagenesVisita> List()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbImagenesVisita>(ScriptDatabase.ImagenesVisita_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public RequestStatus Update(tbImagenesVisita item)
        {
            throw new NotImplementedException();
        }

        public tbImagenesVisita Find(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
