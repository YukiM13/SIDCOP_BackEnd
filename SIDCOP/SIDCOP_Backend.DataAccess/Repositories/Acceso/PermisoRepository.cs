using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess.Repositories.Acceso
{
    class PermisoRepository
    {
        public RequestStatus Insert(tbUsuarios item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Role_Id", item.Role_Id, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Pant_Id", item.Pant_Id, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Acci_Id", item.Acci_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Perm_FechaCreacion", item.Perm_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Execute(ScriptDatabase.Permiso_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al insertar" : "Insertado correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

        public RequestStatus Update(tbUsuarios item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Usua_Id", item.Usua_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Usuario", item.Usua_Usuario, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Role_Id", item.Role_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_IdPersona", item.Usua_IdPersona, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_EsVendedor", item.Usua_EsVendedor, System.Data.DbType.Boolean, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_EsAdmin", item.Usua_EsAdmin, System.Data.DbType.Boolean, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Imagen", item.Usua_Imagen, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_FechaModificacion", item.Usua_FechaModificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Execute(ScriptDatabase.Usuario_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al actualizar" : "Actualizado correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }
    }
}
