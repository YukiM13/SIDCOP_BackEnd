using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;

namespace SIDCOP_Backend.DataAccess.Repositories.General
{
     public class MarcaRepository: IRepository<tbMarcas>
    {

        public RequestStatus Delete(tbMarcas item)
        {
            throw new NotImplementedException();
        }

        public tbMarcas Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbMarcas item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbMarcas> List()
        {
            var parameter = new DynamicParameters();


            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.Query<tbMarcas>(ScriptDatabase.Marcas_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();


            return result;
        }


        public int InsertMarca(tbMarcas item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Marc_Descripcion", item.Marc_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Marc_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var result = db.QueryFirstOrDefault<int>(
                ScriptDatabase.Marca_Insertar,
                parameter,
                commandType: System.Data.CommandType.StoredProcedure
            );

            return result; // Puede ser 1 (éxito), -1 (DNI duplicado), o 0 (error interno)
        }

        public RequestStatus Update(tbMarcas item)
        {
            throw new NotImplementedException();
        }

    }
}
