using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;
using SIDCOP_Backend.Entities.Entities;

namespace SIDCOP_Backend.DataAccess.Repositories.Ventas
{
    public class CuentasPorCobrarRepository : IRepository<tbCuentasPorCobrar>
    {
        public RequestStatus Delete(int? id)
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

        public RequestStatus Insert(tbCuentasPorCobrar item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbCuentasPorCobrar> List()
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbCuentasPorCobrar>(ScriptDatabase.CuentasPorCobrar_Listar, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public RequestStatus Update(tbCuentasPorCobrar item)
        {
            throw new NotImplementedException();
        }

        tbCuentasPorCobrar IRepository<tbCuentasPorCobrar>.Find(int? id)
        {
            throw new NotImplementedException();
        }

        public tbCuentasPorCobrar GetDetalle(int cuentaPorCobrarId)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@CPCo_Id", cuentaPorCobrarId);

            var result = db.QueryFirstOrDefault<tbCuentasPorCobrar>(
                ScriptDatabase.CuentaPorCobrar_Detalle,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure);

            return result;
        }

        public IEnumerable<tbCuentasPorCobrar> ResumenAntiguedad()
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbCuentasPorCobrar>(ScriptDatabase.CuentasPorCobrar_ResumenAntiguedad, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public IEnumerable<tbCuentasPorCobrar> ResumenCliente()
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbCuentasPorCobrar>(ScriptDatabase.CuentasPorCobrar_ResumenPorCliente, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public tbCuentasPorCobrar timeLineCliente(int Clie_Id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@Clie_Id", Clie_Id);

            var result = db.QueryFirstOrDefault<tbCuentasPorCobrar>(
                ScriptDatabase.CuentasPorCobrar_TimelineCliente,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure);

            return result;
        }
    }
}