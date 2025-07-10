using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;

namespace SIDCOP_Backend.DataAccess.Repositories.General
{
     public class MarcaRepository: IRepository<tbMarcas>
    {
        public tbMarcas Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbMarcas item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbMarcas> List()
        {
            var parameter = new DynamicParameters();


            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbMarcas>(ScriptDatabase.Marcas_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();


            return result;
        }


        public int InsertMarca(tbMarcas item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Marc_Descripcion", item.Marc_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Marc_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.QueryFirstOrDefault<int>(
                ScriptDatabase.Marca_Insertar,
                parameter,
                commandType: System.Data.CommandType.StoredProcedure
            );

            return result; // Puede ser 1 (éxito), -1 (DNI duplicado), o 0 (error interno)
        }


        public RequestStatus ActualizarMarca(tbMarcas item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Marc_Id", item.Marc_Id, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@Marc_Descripcion", item.Marc_Descripcion, DbType.String, ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@Marc_FechaModificacion", DateTime.Now, DbType.DateTime, ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Execute(ScriptDatabase.Marca_Actualizar, parameter, commandType: CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al actualizar la Marca" : "Marca actualizada correctamente";
            return new RequestStatus { code_Status = result, message_Status = mensaje };
        }

        public RequestStatus EliminarMarca(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Marc_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Marca_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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
        public tbMarcas BuscarMarca(int? id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@Marc_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            var result = db.QueryFirstOrDefault<tbMarcas>(ScriptDatabase.Marca_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            if (result == null)
            {
                throw new Exception("Marca no encontrada");
            }
            return result;
        }
        public RequestStatus Update(tbMarcas item)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
