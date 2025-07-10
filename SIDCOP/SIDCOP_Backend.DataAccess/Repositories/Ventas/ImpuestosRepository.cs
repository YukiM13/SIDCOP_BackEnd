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
    public class ImpuestosRepository : IRepository<tbImpuestos>
    {
        public RequestStatus Delete(tbImpuestos item)
        {
            throw new NotImplementedException();
        }

        public tbImpuestos Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbImpuestos item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbImpuestos> List()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbImpuestos>(ScriptDatabase.Impuestos_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            return result;
        }

        public RequestStatus Update(tbImpuestos item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Impu_Id", item.Impu_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Impu_Descripcion", item.Impu_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Impu_Valor", item.Impu_Valor, System.Data.DbType.Double, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Impu_FechaModificacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);


            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            var result = db.Execute(ScriptDatabase.Impuestos_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }
    }
}
