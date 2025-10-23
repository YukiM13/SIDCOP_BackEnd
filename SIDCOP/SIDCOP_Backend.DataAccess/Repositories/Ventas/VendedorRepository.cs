using Microsoft.Data.SqlClient;
using Dapper;
using SIDCOP_Backend.Entities.Entities;
using SIDCOP_Backend.DataAccess.Context;

namespace SIDCOP_Backend.DataAccess.Repositories.Ventas
{
    public class VendedorRepository : IRepository<tbVendedores>
    {
        private readonly BDD_SIDCOPContext _bddContext;
        public VendedorRepository(BDD_SIDCOPContext bddContext)
        {
            _bddContext = bddContext;
        }

        public RequestStatus Delete(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Vend_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Vendedor_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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

        public tbVendedores Find(int? id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@Vend_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            var result = db.QueryFirstOrDefault<tbVendedores>(ScriptDatabase.Vendedor_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            if (result == null)
            {
                throw new Exception("Vendedor no encontrado");
            }
            return result;
        }

        public RequestStatus Insert(tbVendedores item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }

            var parameter = new DynamicParameters();

            parameter.Add("@Vend_Codigo", item.Vend_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_DNI", item.Vend_DNI, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_Nombres", item.Vend_Nombres, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_Apellidos", item.Vend_Apellidos, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_Telefono", item.Vend_Telefono, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_Correo", item.Vend_Correo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_Sexo", item.Vend_Sexo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_DireccionExacta", item.Vend_DireccionExacta, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Sucu_Id", item.Sucu_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Colo_Id", item.Colo_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_Supervisor", item.Vend_Supervisor, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_Ayudante", item.Vend_Ayudante, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_Tipo", item.TiVe_Id, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_EsExterno", item.Vend_EsExterno, System.Data.DbType.Boolean, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_Imagen", item.Vend_Imagen, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@rutas", item.rutas, System.Data.DbType.String, System.Data.ParameterDirection.Input);


            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Vendedor_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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

        public IEnumerable<tbVendedores> List()
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbVendedores>(ScriptDatabase.Vendedores_Listar, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public IEnumerable<tbVendedoresPorRuta> ListVeRu()
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbVendedoresPorRuta>(ScriptDatabase.Vendedores_ListarPorRuta, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public RequestStatus Update(tbVendedores item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }

            var parameter = new DynamicParameters();

            parameter.Add("@Vend_Id", item.Vend_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_Codigo", item.Vend_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_DNI", item.Vend_DNI, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_Nombres", item.Vend_Nombres, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_Apellidos", item.Vend_Apellidos, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_Telefono", item.Vend_Telefono, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_Correo", item.Vend_Correo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_Sexo", item.Vend_Sexo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_DireccionExacta", item.Vend_DireccionExacta, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Sucu_Id", item.Sucu_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Colo_Id", item.Colo_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_Supervisor", item.Vend_Supervisor, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_Ayudante", item.Vend_Ayudante, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_Tipo", item.TiVe_Id, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_EsExterno", item.Vend_EsExterno, System.Data.DbType.Boolean, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_Imagen", item.Vend_Imagen, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Vend_FechaModificacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@rutas", item.rutas, System.Data.DbType.String, System.Data.ParameterDirection.Input);


            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Vendedor_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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

        public IEnumerable<VendedorConVisitasDTO> ListarVendedoresConVisitas()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<VendedorConVisitasDTO>(ScriptDatabase.VendedoresConVisitas_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            return result;
        }
    }
}