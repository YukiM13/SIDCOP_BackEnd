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
    public class PagosCuentasPorCobrarRepository
    {
        public virtual int InsertarPago(tbPagosCuentasPorCobrar item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Los datos llegaron vacíos o datos erróneos");
            }

            var parameter = new DynamicParameters();
            parameter.Add("@CPCo_Id", item.CPCo_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Pago_Monto", item.Pago_Monto, System.Data.DbType.Decimal, System.Data.ParameterDirection.Input);
            parameter.Add("@FoPa_Id", item.FoPa_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Pago_NumeroReferencia", item.Pago_NumeroReferencia, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Pago_Observaciones", item.Pago_Observaciones, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<int>("Vnta.SP_PagosCuentasPorCobrar_Insertar", parameter, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al insertar el pago: {ex.Message}", ex);
            }
        }

        public virtual IEnumerable<tbPagosCuentasPorCobrar> ListarPorCuentaPorCobrar(int cpcId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@CPCo_Id", cpcId, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.Query<tbPagosCuentasPorCobrar>("Vnta.SP_PagosCuentasPorCobrar_ListarPorCxC", parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al listar pagos por cuenta por cobrar: {ex.Message}", ex);
            }
        }

        public virtual IEnumerable<dynamic> ListarCuentasPorCobrar(int? clienteId = null, bool soloActivas = true, bool soloVencidas = false)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Clie_Id", clienteId, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@SoloActivas", soloActivas, System.Data.DbType.Boolean, System.Data.ParameterDirection.Input);
            parameter.Add("@SoloVencidas", soloVencidas, System.Data.DbType.Boolean, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.Query<dynamic>("Vnta.SP_PagosCuentasPorCobrar_Listar", parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al listar cuentas por cobrar: {ex.Message}", ex);
            }
        }

        public virtual RequestStatus AnularPago(int pagoId, int usuarioModificacion, string motivoAnulacion)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Pago_Id", pagoId, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", usuarioModificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Motivo_Anulacion", motivoAnulacion, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                db.Execute("Vnta.SP_PagoCuentaPorCobrar_Anular", parameter, commandType: System.Data.CommandType.StoredProcedure);
                return new RequestStatus { code_Status = 1, message_Status = "Pago anulado exitosamente" };
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error al anular el pago: {ex.Message}" };
            }
        }
    }
}
