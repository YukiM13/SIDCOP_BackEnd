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
    public class PreciosPorProductoRepository : IRepository<tbPreciosPorProducto>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus DeleteLista(tbPreciosPorProducto item)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@Prod_Id", item.Prod_Id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@PreP_ListaPrecios", item.PreP_ListaPrecios, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<RequestStatus>(ScriptDatabase.PreciosPorProducto_EliminarLista, parameters, commandType: System.Data.CommandType.StoredProcedure);

            var status = new RequestStatus();
            status = result.First();


            return status;
        }

        public tbPreciosPorProducto Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbPreciosPorProducto item)
        {
            throw new NotImplementedException();
        }

        public RequestStatus InsertLista(tbPreciosPorProducto item)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@Prod_Id", item.Prod_Id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@ClientesXml", item.ClientesXml, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@PreP_PrecioContado", item.PreP_PrecioContado, System.Data.DbType.Decimal, System.Data.ParameterDirection.Input);
            parameters.Add("@PreP_PrecioCredito", item.PreP_PrecioCredito, System.Data.DbType.Decimal, System.Data.ParameterDirection.Input);
            parameters.Add("@PreP_InicioEscala", item.PreP_InicioEscala, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameters.Add("@PreP_FinEscala", item.PreP_FinEscala, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            parameters.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@PreP_FechaCreacion", item.PreP_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<RequestStatus>(ScriptDatabase.PreciosPorProducto_InsertarLista, parameters, commandType: System.Data.CommandType.StoredProcedure);

            var status = new RequestStatus();
            status = result.First();


            return status;
        }

        public RequestStatus UpdateLista(tbPreciosPorProducto item)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@PreP_ListaPrecios", item.PreP_ListaPrecios, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@Prod_Id", item.Prod_Id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@ClientesXml", item.ClientesXml, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@PreP_PrecioContado", item.PreP_PrecioContado, System.Data.DbType.Decimal, System.Data.ParameterDirection.Input);
            parameters.Add("@PreP_PrecioCredito", item.PreP_PrecioCredito, System.Data.DbType.Decimal, System.Data.ParameterDirection.Input);
            parameters.Add("@PreP_InicioEscala", item.PreP_InicioEscala, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameters.Add("@PreP_FinEscala", item.PreP_FinEscala, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            parameters.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@PreP_FechaCreacion", item.PreP_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<RequestStatus>(ScriptDatabase.PreciosPorProducto_EditarLista, parameters, commandType: System.Data.CommandType.StoredProcedure);

            var status = new RequestStatus();
            status = result.First();

            return status;
        }

        public IEnumerable<tbPreciosPorProducto> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbPreciosPorProducto> ListPorProducto(int? id)
        {

            var parameters = new DynamicParameters();

            parameters.Add("@Prod_Id", id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbPreciosPorProducto>(ScriptDatabase.PreciosPorProductoListar_PorProducto, parameters, commandType: System.Data.CommandType.StoredProcedure);

            return result;
        }

        public RequestStatus Update(tbPreciosPorProducto item)
        {
            throw new NotImplementedException();
        }
    }
}
