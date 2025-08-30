using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess.Repositories.Inventario
{
    public class ProductosRepository : IRepository<tbProductos>
    {
        public RequestStatus Delete(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Prod_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Producto_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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

        public tbProductos Find(int? id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@Prod_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            var result = db.QueryFirstOrDefault<tbProductos>(ScriptDatabase.Producto_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            if (result == null)
            {
                throw new Exception("Producto no encontrado");
            }
            return result;
        }

        public IEnumerable<tbProductos> ListaPrecio(int? id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@Clie_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            var result = db.Query<tbProductos>(ScriptDatabase.Producto_ClienteDescuentoLista, parameter, commandType: System.Data.CommandType.StoredProcedure);
            if (result == null)
            {
                throw new Exception("Producto no encontrado");
            }
            return result;
        }

        public async Task<IEnumerable<ListasPreciosVendedor>> ObtenerProductosDescuentoPrecioPorClienteVendedorAsync(int clieId, int vendId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Clie_Id", clieId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Vend_Id", vendId, DbType.Int32, ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = await db.QueryAsync<ListasPreciosVendedor>(
                    "[Inve].[SP_ProductosDescuentoPrecioPorCliente_Vendedor]",
                    parameters,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 60 // 60 segundos timeout
                );

                if (result == null)
                {
                    throw new Exception("No se pudieron obtener los productos");
                }

                return result;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error de base de datos al obtener productos: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al obtener productos: {ex.Message}", ex);
            }
        }

        public IEnumerable<tbProductos> FindFactura(int? id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@Fact_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            var result = db.Query<tbProductos>(ScriptDatabase.Producto_BuscarPorFactura, parameter, commandType: System.Data.CommandType.StoredProcedure);
            if (result == null)
            {
                throw new Exception("Producto no encontrado");
            }
            return result;
        }

        public RequestStatus Insert(tbProductos item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            if (item.Impu_Id == 0)
            {
                item.Impu_Id = null;
            }
            var parameter = new DynamicParameters();
            parameter.Add("@Prod_Codigo", item.Prod_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_CodigoBarra", item.Prod_CodigoBarra, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_Descripcion", item.Prod_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_DescripcionCorta", item.Prod_DescripcionCorta, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_Imagen", item.Prod_Imagen, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_Peso", item.Prod_Peso, System.Data.DbType.Double, System.Data.ParameterDirection.Input);
            parameter.Add("@UnPe_Id", item.UnPe_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Subc_Id", item.Subc_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Marc_Id", item.Marc_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prov_Id", item.Prov_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Impu_Id", item.Impu_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_PrecioUnitario", item.Prod_PrecioUnitario, System.Data.DbType.Double, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_PagaImpuesto", item.Prod_PagaImpuesto, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_EsPromo", item.Prod_EsPromo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_Impulsado", item.Prod_Impulsado, System.Data.DbType.Boolean, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Producto_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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

        public IEnumerable<tbProductos> List()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbProductos>(ScriptDatabase.Productos_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public RequestStatus Update(tbProductos item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@Prod_Id", item.Prod_Id, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_Codigo", item.Prod_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_CodigoBarra", item.Prod_CodigoBarra, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_Descripcion", item.Prod_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_DescripcionCorta", item.Prod_DescripcionCorta, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_Imagen", item.Prod_Imagen, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_Peso", item.Prod_Peso, System.Data.DbType.Double, System.Data.ParameterDirection.Input);
            parameter.Add("@UnPe_Id", item.UnPe_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Subc_Id", item.Subc_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Marc_Id", item.Marc_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prov_Id", item.Prov_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Impu_Id", item.Impu_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_PrecioUnitario", item.Prod_PrecioUnitario, System.Data.DbType.Double, System.Data.ParameterDirection.Input);        
            parameter.Add("@Prod_PagaImpuesto", item.Prod_PagaImpuesto, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_EsPromo", item.Prod_EsPromo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_Impulsado", item.Prod_Impulsado, System.Data.DbType.Boolean, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_FechaModificacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Producto_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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
