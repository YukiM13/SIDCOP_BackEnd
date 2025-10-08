using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;
using SIDCOP_Backend.Entities.Entities;

namespace SIDCOP_Backend.DataAccess.Repositories.Acceso
{
    public class UsuarioRepository : IRepository<tbUsuarios>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbUsuarios Find(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbUsuarios> List()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbUsuarios>(ScriptDatabase.Usuarios_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public virtual RequestStatus Insert(tbUsuarios item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacíos o datos erróneos." };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@Usua_Usuario", item.Usua_Usuario, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Clave", item.Usua_Clave, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Role_Id", item.Role_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_IdPersona", item.Usua_IdPersona, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_EsVendedor", item.Usua_EsVendedor, System.Data.DbType.Boolean, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_EsAdmin", item.Usua_EsAdmin, System.Data.DbType.Boolean, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Imagen", item.Usua_Imagen, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_TienePermisos", item.Usua_TienePermisos, System.Data.DbType.Boolean, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_FechaCreacion", item.Usua_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Usuario_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);

                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error desconocido." };
                }
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }
        }

        public virtual RequestStatus Update(tbUsuarios item)
        {
            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }

            var parameter = new DynamicParameters();
            parameter.Add("@Usua_Id", item.Usua_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Usuario", item.Usua_Usuario, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Role_Id", item.Role_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_IdPersona", item.Usua_IdPersona, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_EsVendedor", item.Usua_EsVendedor, System.Data.DbType.Boolean, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_EsAdmin", item.Usua_EsAdmin, System.Data.DbType.Boolean, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Imagen", item.Usua_Imagen, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_TienePermisos", item.Usua_TienePermisos, System.Data.DbType.Boolean, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_FechaModificacion", item.Usua_FechaModificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.Usuario_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);

                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error desconocido." };
                }
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }
        }

        public RequestStatus ChangeUserState(tbUsuarios? item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Usua_Id", item.Usua_Id, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@Usua_FechaModificacion", item.Usua_FechaModificacion, DbType.DateTime, ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.QueryFirstOrDefault<dynamic>(ScriptDatabase.Usuario_CambiarEstado, parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "No se pudo cambiar el estado del usuario." };
            }

            return new RequestStatus
            {
                code_Status = result.code_Status,
                message_Status = result.message_Status
            };
        }

        public IEnumerable<tbUsuarios> FindUser(tbUsuarios? item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Usua_Id", item.Usua_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbUsuarios>(ScriptDatabase.Usuario_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public IEnumerable<tbUsuarios> VerificateExistingUser(tbUsuarios? item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Usua_Usuario", item.Usua_Usuario, DbType.String, ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbUsuarios>(ScriptDatabase.Usuario_VerificarUsuarioExistente, parameter, commandType: CommandType.StoredProcedure);

            return result;
        }

        //public IEnumerable<tbUsuarios> Login(tbUsuarios? item)
        //{
        //    var parameter = new DynamicParameters();
        //    parameter.Add("@Usua_Usuario", item.Usua_Usuario, System.Data.DbType.String, System.Data.ParameterDirection.Input);
        //    parameter.Add("@Usua_Contrasena", item.Usua_Clave, System.Data.DbType.String, System.Data.ParameterDirection.Input);

        //    using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
        //    var result = db.Query<tbUsuarios>(ScriptDatabase.Usuario_IniciarSesion, parameter, commandType: System.Data.CommandType.StoredProcedure);

        //    return result;
        //}

        public LoginResponse Login(LoginResponse item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Usua_Usuario", item.Usua_Usuario);
            parameter.Add("@Usua_Contrasena", item.Usua_Clave);
            parameter.Add("@FechaActual", DateTime.Now);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.QueryFirstOrDefault<LoginResponse>(
                ScriptDatabase.Usuario_IniciarSesion,
                parameter,
                commandType: CommandType.StoredProcedure
                                                              );

            return result;
        }

        public RequestStatus ShowPassword(int usuaId, string claveSeguridad)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Usua_Id", usuaId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@Contrasena", claveSeguridad, DbType.String, ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.QueryFirstOrDefault<dynamic>(
                ScriptDatabase.Usuario_MostrarContrasena,
                parameter,
                commandType: CommandType.StoredProcedure
                                                        );

            if (result == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Error al obtener la contraseña." };
            }

            if (result.code_Status == -1 || result.code_Status == 0)
            {
                return new RequestStatus
                {
                    code_Status = result.code_Status,
                    message_Status = result.message_Status
                };
            }

            return new RequestStatus
            {
                code_Status = result.code_Status,
                message_Status = result.message_Status,
                data = result.Contrasena
            };
        }

        public RequestStatus RestorePassword(tbUsuarios item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Usua_Id", item.Usua_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Contrasena", item.Usua_Clave, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_FechaModificacion", item.Usua_FechaModificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Execute(ScriptDatabase.Usuario_RestablecerContrasena, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al restablecer" : "Restablecer correctamente";

            return new RequestStatus { code_Status = result, message_Status = mensaje };
        }
    }
}