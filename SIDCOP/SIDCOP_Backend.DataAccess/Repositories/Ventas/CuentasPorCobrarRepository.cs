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

        public virtual IEnumerable<tbCuentasPorCobrar> List()
        {
            //Se llama el ConnectionString para conectarse a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            //Ejecuta el procedimiento y trae una lista de cuentas por cobrar
            var result = db.Query<tbCuentasPorCobrar>(ScriptDatabase.CuentasPorCobrar_Listar, commandType: System.Data.CommandType.StoredProcedure).ToList();

            //Retorna la lista de cuentas por cobrar
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

        public virtual tbCuentasPorCobrar GetDetalle(int cuentaPorCobrarId)
        {
            //Se llama el ConnectionString para conectarse a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            var parameters = new DynamicParameters();
            //Declaracion de parametros
            parameters.Add("@CPCo_Id", cuentaPorCobrarId);

            //Ejecuta el procedimiento con el parametro y obtiene el detalle de la cuenta por cobrar
            var result = db.QueryFirstOrDefault<tbCuentasPorCobrar>(
                ScriptDatabase.CuentaPorCobrar_Detalle,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure);

            //Retorna el detalle de la cuenta por cobrar
            return result;
        }

        public virtual IEnumerable<tbCuentasPorCobrar> ListarFiltrado(int ventId)
        {
            //Se llama el ConnectionString para conectarse a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameters = new DynamicParameters();
            //Declaracion de parametros
            parameters.Add("@Vend_Id", ventId);
            //Ejecuta el procedimiento con el parametro y obtiene todas las cuentas por cobrar
            var result = db.Query<tbCuentasPorCobrar>(
                ScriptDatabase.CuentasPorCobrarFiltro_Listar,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure);
            //Retorna todas las cuentas por cobrar
            return result;
        }

        public virtual IEnumerable<tbCuentasPorCobrar> ResumenAntiguedad()
        {
            //Se llama el ConnectionString para conectarse a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            //Ejecuta el procedimiento y trae el resumen de antigüedad de cuentas por cobrar
            var result = db.Query<tbCuentasPorCobrar>(ScriptDatabase.CuentasPorCobrar_ResumenAntiguedad, commandType: System.Data.CommandType.StoredProcedure).ToList();

            //Retorna el resumen de antigüedad
            return result;
        }

        public virtual IEnumerable<tbCuentasPorCobrar> ResumenCliente()
        {
            //Se llama el ConnectionString para conectarse a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            //Ejecuta el procedimiento y trae el resumen de cuentas por cobrar por cliente
            var result = db.Query<tbCuentasPorCobrar>(ScriptDatabase.CuentasPorCobrar_ResumenPorCliente, commandType: System.Data.CommandType.StoredProcedure).ToList();

            //Retorna el resumen por cliente
            return result;
        }

        public virtual IEnumerable<tbCuentasPorCobrar> timeLineCliente(int Clie_Id)
        {
            //Se llama el ConnectionString para conectarse a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

            var parameters = new DynamicParameters();
            //Declaracion de parametros
            parameters.Add("@Clie_Id", Clie_Id);

            //Ejecuta el procedimiento con el parametro y obtiene la línea de tiempo del cliente
            var result = db.Query<tbCuentasPorCobrar>(
                ScriptDatabase.CuentasPorCobrar_TimelineCliente,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
            );

            //Retorna la línea de tiempo del cliente
            return result;
        }

    }
}