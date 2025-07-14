
using Azure.Core;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.DataAccess.Repositories.Ventas;
using SIDCOP_Backend.DataAccess.Repositories.Logistica;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.BusinessLogic.Services
{
    public class LogisticaServices
    {
        private readonly RutasRepository _rutasRepository;
        private readonly BodegaRepository _bodegaRepository;

        public LogisticaServices(RutasRepository rutasRepository, BodegaRepository bodegaRepository)
        {
            _rutasRepository = rutasRepository;
            _bodegaRepository = bodegaRepository;
        }

        #region Rutas

        public tbRutas BuscarRuta(int? id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@Ruta_id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            var result = db.QueryFirstOrDefault<tbRutas>(ScriptDatabase.Rutas_Filtrar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            if (result == null)
            {
                return null;
            }
            return result;
        }
 
        public IEnumerable<tbRutas> ListarRutas()
        {

            try
            {
                var list = _rutasRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                List<tbRutas> lista = null;
                return lista;
            }
        }
        public int InsertarRuta(tbRutas item)
        {
            try
            {
                var list = _rutasRepository.Insert(item);
                return list.code_Status;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public ServiceResult ModificarRuta(tbRutas item)
        {

            var result = new ServiceResult();
            try
            {
                var list = _rutasRepository.Update(item);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult EliminarRuta(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var deleteResult = _rutasRepository.Delete(id);
                if (deleteResult.code_Status == 1)
                {
                    return result.Ok(deleteResult.message_Status);
                }
                else
                {
                    return result.Error(deleteResult.message_Status);
                }
            }
            catch (Exception ex)
            {
                return result.Error($"Error al eliminar ruta: {ex.Message}");
            }
        }
        #endregion

        #region Bodegas 

        public IEnumerable<tbBodegas> ListBodegas()
        {
            //var result = new ServiceResult();
            try
            {
                var list = _bodegaRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbBodegas> result = null;
                return result;
            }
        }

        public ServiceResult InsertBodega(tbBodegas item)
        {
            var result = new ServiceResult();
            try
            {
                var response = _bodegaRepository.Insert(item);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdateBodega(tbBodegas item)
        {
            var result = new ServiceResult();
            try
            {
                var response = _bodegaRepository.Update(item);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult DeleteBodega(tbBodegas item)
        {
            var result = new ServiceResult();
            try
            {
                var response = _bodegaRepository.Delete(item);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult FindBodega(int id)
        {
            var result = new ServiceResult();
            try
            {
                var response = _bodegaRepository.Find(id);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion
    }
}
