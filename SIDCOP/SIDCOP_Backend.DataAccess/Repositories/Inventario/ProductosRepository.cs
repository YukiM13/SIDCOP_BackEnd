using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess.Repositories.Inventario
{
    public class ProductosRepository : IRepository<tbProductos>
    {
        public RequestStatus Delete(tbProductos item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Prod_Id", item.Prod_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
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

        public RequestStatus Insert(tbProductos item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@Prod_Codigo", item.Prod_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_CodigoBarra", item.Prod_CodigoBarra, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_Descripcion", item.Prod_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_DescripcionCorta", item.Prod_DescripcionCorta, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Subc_Id", item.Subc_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Marc_Id", item.Marc_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prov_Id", item.Prov_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Impu_Id", item.Impu_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_PrecioUnitario", item.Prod_PrecioUnitario, System.Data.DbType.Double, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_CostoTotal", item.Prod_CostoTotal, System.Data.DbType.Double, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_PagaImpuesto", item.Prod_PagaImpuesto, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_PromODesc", item.Prod_PromODesc, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_EsPromo", item.Prod_EsPromo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_FechaCreacion", item.Prod_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

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
            parameter.Add("@Subc_Id", item.Subc_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Marc_Id", item.Marc_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prov_Id", item.Prov_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Impu_Id", item.Impu_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_PrecioUnitario", item.Prod_PrecioUnitario, System.Data.DbType.Double, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_CostoTotal", item.Prod_CostoTotal, System.Data.DbType.Double, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_PagaImpuesto", item.Prod_PagaImpuesto, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_PromODesc", item.Prod_PromODesc, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_EsPromo", item.Prod_EsPromo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_FechaModificacion", item.Prod_FechaModificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

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
