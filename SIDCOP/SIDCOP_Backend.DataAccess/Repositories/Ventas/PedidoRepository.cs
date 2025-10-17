using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess.Repositories.Ventas
{
    public class PedidoRepository : IRepository<tbPedidos>
    {
        public virtual RequestStatus Delete(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Pedi_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Pedidos_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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

        public tbPedidos Find(int? id)
        {
            throw new NotImplementedException();
        }

        public virtual RequestStatus Insert(tbPedidos item)
        {

            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }

            var parameter = new DynamicParameters();

            //Los parametros necesarios para la cabecera de pedidos
            parameter.Add("@DiCl_Id", item.DiCl_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_Id", item.Vend_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Pedi_Codigo", item.Pedi_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Pedi_FechaPedido", item.Pedi_FechaPedido, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@Pedi_FechaEntrega", item.Pedi_FechaEntrega, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Pedi_FechaCreacion", item.Pedi_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            //enviamos los parametros de los detalles como un xml debido a la versión del sql usado
            string detallesXml = item.Detalles != null && item.Detalles.Any()
             ? "<Detalles>" + string.Join("", item.Detalles.Select(d =>
                 $"<Deta>" +
                     $"<Prod_Id>{d.Prod_Id}</Prod_Id>" +
                     $"<PeDe_Cantidad>{d.PeDe_Cantidad}</PeDe_Cantidad>" +
                     $"<PeDe_ProdPrecio>{d.PeDe_ProdPrecio.ToString(System.Globalization.CultureInfo.InvariantCulture)}</PeDe_ProdPrecio>" +
                     $"<PeDe_Impuesto>{d.PeDe_Impuesto.ToString(System.Globalization.CultureInfo.InvariantCulture)}</PeDe_Impuesto>" +
                     $"<PeDe_Descuento>{d.PeDe_Descuento.ToString(System.Globalization.CultureInfo.InvariantCulture)}</PeDe_Descuento>" +
                     $"<PeDe_Subtotal>{d.PeDe_Subtotal.ToString(System.Globalization.CultureInfo.InvariantCulture)}</PeDe_Subtotal>" +
                     $"<PeDe_ProdPrecioFinal>{d.PeDe_ProdPrecioFinal.ToString(System.Globalization.CultureInfo.InvariantCulture)}</PeDe_ProdPrecioFinal>" +
                 $"</Deta>"
             )) + "</Detalles>"
             : "<Detalles></Detalles>";

            parameter.Add("@Detalles", detallesXml, DbType.Xml);


            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Pedidos_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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

        public virtual IEnumerable<tbPedidos> List()
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbPedidos>(ScriptDatabase.Pedidos_Listar, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public virtual RequestStatus Update(tbPedidos item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }

            //Parametros necesarios para la actualización de pedidos en la parte de la cabecera
            var parameter = new DynamicParameters();
            parameter.Add("@Pedi_Id", item.Pedi_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@DiCl_Id", item.DiCl_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Pedi_Codigo", item.Pedi_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_Id", item.Vend_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Pedi_FechaPedido", item.Pedi_FechaPedido, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@Pedi_FechaEntrega", item.Pedi_FechaEntrega, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Pedi_FechaModificacion", item.Pedi_FechaModificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            //enviamos los parametros de los detalles como un xml debido a la versión del sql usado
            string detallesXml = item.Detalles != null && item.Detalles.Any()
             ? "<Detalles>" + string.Join("", item.Detalles.Select(d =>
                 $"<Deta>" +
                     $"<Prod_Id>{d.Prod_Id}</Prod_Id>" +
                     $"<PeDe_Cantidad>{d.PeDe_Cantidad}</PeDe_Cantidad>" +
                     $"<PeDe_ProdPrecio>{d.PeDe_ProdPrecio.ToString(System.Globalization.CultureInfo.InvariantCulture)}</PeDe_ProdPrecio>" +
                     $"<PeDe_Impuesto>{d.PeDe_Impuesto.ToString(System.Globalization.CultureInfo.InvariantCulture)}</PeDe_Impuesto>" +
                     $"<PeDe_Descuento>{d.PeDe_Descuento.ToString(System.Globalization.CultureInfo.InvariantCulture)}</PeDe_Descuento>" +
                     $"<PeDe_Subtotal>{d.PeDe_Subtotal.ToString(System.Globalization.CultureInfo.InvariantCulture)}</PeDe_Subtotal>" +
                     $"<PeDe_ProdPrecioFinal>{d.PeDe_ProdPrecioFinal.ToString(System.Globalization.CultureInfo.InvariantCulture)}</PeDe_ProdPrecioFinal>" +
                 $"</Deta>"
             )) + "</Detalles>"
             : "<Detalles></Detalles>";


            parameter.Add("@Detalles", detallesXml, DbType.Xml);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Pedidos_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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
    }
}


