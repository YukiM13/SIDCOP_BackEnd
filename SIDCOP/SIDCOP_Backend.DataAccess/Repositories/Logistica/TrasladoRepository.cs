using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;

namespace SIDCOP_Backend.DataAccess.Repositories.Logistica
{
    public class TrasladoRepository : IRepository<tbTraslados>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbTraslados> ListTraslados()
        {
            var parameter = new DynamicParameters();


            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbTraslados>(ScriptDatabase.Traslados_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();


            return result;
        }

        public RequestStatus InsertTraslado(tbTraslados item)
        {
            var parameters = new DynamicParameters();
            //Declaracion de parametros
            parameters.Add("@Tras_Origen", item.Tras_Origen, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameters.Add("@Tras_Destino", item.Tras_Destino, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameters.Add("@Tras_Fecha", item.Tras_Fecha, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameters.Add("@Tras_Observaciones", item.Tras_Observaciones, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@Tras_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            //Se llama el ConnectionString para conectarse a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            //Ejecuta el procedimiento con los parametros y trae lista de RequestStatus
            var result = db.Query<RequestStatus>(ScriptDatabase.Traslado_Insertar, parameters, commandType: System.Data.CommandType.StoredProcedure);

            var status = new RequestStatus();
            status = result.First();

            //Retorna el status del procedimiento para saber si se realizo
            return status;
        }

        public tbTraslados Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbTraslados item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbTraslados> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbTraslados item)
        {
            throw new NotImplementedException();
        }
    }
}
