using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess.Repositories.General
{
    public class MunicipioRepository : IRepository<tbMunicipios>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbMunicipios Find(int? id)
        {
            throw new NotImplementedException();
        }


        //Metodo que inserta un nuevo municipio
        public RequestStatus Insert(tbMunicipios item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }

            //Envio de los parámetros al procedimiento almacenado
            var parameter = new DynamicParameters();
            parameter.Add("@Muni_Codigo", item.Muni_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Muni_Descripcion", item.Muni_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Depa_Codigo", item.Depa_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Muni_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            try
            {
                //Conexion a la base de datos
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                //Ejecutar el procedimiento almacenado
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Municipios_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error desconocido" };
                }
                //Retorno del resultado de la operacion en formato RequestStatus
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }
        }

        //Metodo que lista todos los municipios
        public IEnumerable<tbMunicipios> List()
        {
            var parameter = new DynamicParameters();

            //Conexion a la base de datos
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbMunicipios>(ScriptDatabase.Municipios_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            // Retorno del resultado de la operacion en formato lista
            return result;
        }

        //Metodo que actualiza un municipio
        public RequestStatus Update(tbMunicipios item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }

            //Envio de los parámetros al procedimiento almacenado
            var parameter = new DynamicParameters();
            parameter.Add("@Muni_Codigo", item.Muni_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Muni_Descripcion", item.Muni_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Depa_Codigo", item.Depa_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Muni_FechaModificacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            try
            {
                //Conexion a la base de datos
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                //Ejecutar el procedimiento almacenado
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Municipios_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error desconocido" };
                }
                //Retorno del resultado de la operacion en formato RequestStatus
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }
        }

        //Metodo que elimina un municipio por su codigo
        public RequestStatus DeleteConCodigo(string? id)
        {
            //Envio del parametro al procedimiento almacenado
            var parameter = new DynamicParameters();
            parameter.Add("@Muni_Codigo", id, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            try
            {
                //Conexion a la base de datos
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Municipios_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error desconocido" };
                }
                // Retorno del resultado de la operacion en formato RequestStatus
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }
        }

        //Metodo que busca un municipio por su codigo
        public tbMunicipios FindConCodigo(string? id)
        {
            try
            {
                //Conexion a la base de datos
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var parameter = new DynamicParameters();
                //Envio del parametro al procedimiento almacenado
                parameter.Add("@Muni_Codigo", id, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                var result = db.QueryFirstOrDefault<tbMunicipios>(ScriptDatabase.Municipios_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure);

                if (result == null)
                {
                    throw new Exception("Municipio no encontrada");
                }
                //Retorno del resultado de la operacion en lista de formato tbMunicipios
                return result;
            }
            catch (Exception)
            {
                throw new Exception("Error");
            }
        }

        //Metodo que lista las sucursales por municipio
        public IEnumerable<tbSucursales> SucursalesPorMunicipio(string? id)
        {
            try
            {
                //Conexion a la base de datos
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var parameter = new DynamicParameters();
                //Envio del parametro al procedimiento almacenado
                parameter.Add("@Muni_Codigo", id, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                var result = db.Query<tbSucursales>(ScriptDatabase.Municipio_ListarSucursales, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

                if (result == null)
                {
                    throw new Exception("Municipio no encontrada");
                }
                //Retorno del resultado de la operacion en lista de formato tbSucursales
                return result;
            }
            catch (Exception)
            {
                throw new Exception("Error");
            }
        }
    }
}