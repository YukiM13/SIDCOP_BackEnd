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
    public class ModeloRepository : IRepository<tbModelos>
    {
        public RequestStatus Delete(tbModelos item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Mode_Id", item.Mode_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            var result = db.Execute(ScriptDatabase.Modelos_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

        public tbModelos Find(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbModelos> FindCodigo(tbModelos? item)
        {

            var parameter = new DynamicParameters();
            parameter.Add("@Mode_Id", item.Mode_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbModelos>(ScriptDatabase.Modelos_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;

        }

        public RequestStatus Insert(tbModelos item)
        {
            {
                var parameter = new DynamicParameters();
                parameter.Add("@MaVe_Id", item.MaVe_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Mode_Descripcion", item.Mode_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameter.Add("@Mode_FechaCeacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.Execute(ScriptDatabase.Modelos_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                string mensaje = (result == 0) ? "Error en base de datos" : "Exito";

                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }

        public IEnumerable<tbModelos> List()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbModelos>(ScriptDatabase.Modelos_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            return result;
        }

        public RequestStatus Update(tbModelos item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Mode_Id", item.Mode_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@MaVe_Id", item.MaVe_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Mode_Descripcion", item.Mode_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Mode_FechaCeacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);


            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            var result = db.Execute(ScriptDatabase.Modelos_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }




    }
}
