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
            //Validación de datos de entrada
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Los datos llegaron vacíos o datos erróneos");
            }

            var parameter = new DynamicParameters();
            //Declaracion de parametros
            parameter.Add("@CPCo_Id", item.CPCo_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Pago_Monto", item.Pago_Monto, System.Data.DbType.Decimal, System.Data.ParameterDirection.Input);
            parameter.Add("@FoPa_Id", item.FoPa_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Pago_NumeroReferencia", item.Pago_NumeroReferencia, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Pago_Observaciones", item.Pago_Observaciones, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            try
            {
                //Se llama el ConnectionString para conectarse a la base de datos
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

                //Ejecuta el procedimiento con los parametros y obtiene el ID del pago insertado
                var result = db.QueryFirstOrDefault<int>("Vnta.SP_PagosCuentasPorCobrar_Insertar", parameter, commandType: System.Data.CommandType.StoredProcedure);

                //Retorna el ID del pago insertado
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
            //Declaracion de parametros
            parameter.Add("@CPCo_Id", cpcId, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            try
            {
                //Se llama el ConnectionString para conectarse a la base de datos
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

                //Ejecuta el procedimiento con el parametro y obtiene la lista de pagos de la cuenta por cobrar
                var result = db.Query<tbPagosCuentasPorCobrar>("Vnta.SP_PagosCuentasPorCobrar_ListarPorCxC", parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

                //Retorna la lista de pagos
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
            //Declaracion de parametros
            parameter.Add("@Clie_Id", clienteId, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@SoloActivas", soloActivas, System.Data.DbType.Boolean, System.Data.ParameterDirection.Input);
            parameter.Add("@SoloVencidas", soloVencidas, System.Data.DbType.Boolean, System.Data.ParameterDirection.Input);

            try
            {
                //Se llama el ConnectionString para conectarse a la base de datos
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

                //Ejecuta el procedimiento con los parametros y obtiene la lista de cuentas por cobrar
                var result = db.Query<dynamic>("Vnta.SP_PagosCuentasPorCobrar_Listar", parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

                //Retorna la lista de cuentas por cobrar
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
            //Declaracion de parametros
            parameter.Add("@Pago_Id", pagoId, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", usuarioModificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Motivo_Anulacion", motivoAnulacion, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            try
            {
                //Se llama el ConnectionString para conectarse a la base de datos
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);

                //Ejecuta el procedimiento con los parametros para anular el pago
                db.Execute("Vnta.SP_PagoCuentaPorCobrar_Anular", parameter, commandType: System.Data.CommandType.StoredProcedure);

                //Retorna el estado exitoso de la anulación
                return new RequestStatus { code_Status = 1, message_Status = "Pago anulado exitosamente" };
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error al anular el pago: {ex.Message}" };
            }
        }
    }
}
