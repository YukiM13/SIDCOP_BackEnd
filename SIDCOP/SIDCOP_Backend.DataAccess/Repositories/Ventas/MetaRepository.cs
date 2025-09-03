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
    public class MetaRepository : IRepository<tbMetas>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbMetas Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbMetas item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbMetas> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbMetas item)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<tbMetas> ListCompleto()
        {
            //var parameters = new DynamicParameters();
            //parameters.Add("@Prod_Id", id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbMetas>(ScriptDatabase.Metas_ListarCompleto, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;

        }

        public RequestStatus InsertCompleto(tbMetas item)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@Meta_Descripcion", item.Meta_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@Meta_FechaInicio", item.Meta_FechaInicio, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameters.Add("@Meta_FechaFin", item.Meta_FechaFin, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameters.Add("@Meta_Tipo", item.Meta_Tipo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@Meta_Ingresos", item.Meta_Ingresos, System.Data.DbType.Decimal, System.Data.ParameterDirection.Input);
            parameters.Add("@Meta_Unidades", item.Meta_Unidades, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@Prod_Id", item.Prod_Id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@Cate_Id", item.Cate_Id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@VendedoresXml", item.VendedoresXml, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            parameters.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@Meta_FechaCreacion", item.Meta_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<RequestStatus>(ScriptDatabase.Metas_InsertarCompleto, parameters, commandType: System.Data.CommandType.StoredProcedure);

            var status = new RequestStatus();
            status = result.First();

            return status;
        }

        public RequestStatus UpdateCompleto(tbMetas item)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@Meta_Id", item.Meta_Id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@Meta_Descripcion", item.Meta_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@Meta_FechaInicio", item.Meta_FechaInicio, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameters.Add("@Meta_FechaFin", item.Meta_FechaFin, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameters.Add("@Meta_Tipo", item.Meta_Tipo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@Meta_Ingresos", item.Meta_Ingresos, System.Data.DbType.Decimal, System.Data.ParameterDirection.Input);
            parameters.Add("@Meta_Unidades", item.Meta_Unidades, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@Prod_Id", item.Prod_Id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@Cate_Id", item.Cate_Id, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@VendedoresXml", item.VendedoresXml, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            parameters.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@Meta_FechaCreacion", item.Meta_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<RequestStatus>(ScriptDatabase.Metas_EditarCompleto, parameters, commandType: System.Data.CommandType.StoredProcedure);

            var status = new RequestStatus();
            status = result.First();

            return status;
        }

        public RequestStatus ActualizarProgreso(tbMetas item)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@DetallesXml", item.DetallesXml, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            parameters.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
            parameters.Add("@MeEm_FechaModificacion", item.Meta_FechaModificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<RequestStatus>(ScriptDatabase.Metas_ActualizarProgreso, parameters, commandType: System.Data.CommandType.StoredProcedure);

            var status = new RequestStatus();
            status = result.First();

            return status;
        }
    }
}
