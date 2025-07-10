using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.DataAccess.Repositories.Logistica;
using SIDCOP_Backend.DataAccess.Repositories.Ventas;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.BusinessLogic.Services
{
    public class VentaServices
    {
        private readonly CaiSRepository _caiSRepository;
        private readonly RegistrosCaiSRepository _registrosCaiSRepository;

        public VentaServices(CaiSRepository caiSrepository, RegistrosCaiSRepository registrosCaiSRepository)
        {
            _caiSRepository = caiSrepository;
            _registrosCaiSRepository = registrosCaiSRepository;
        }

        #region CaiS
        public tbCAIs BuscarCaiS(int? id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@NCai_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            var result = db.QueryFirstOrDefault<tbCAIs>(ScriptDatabase.Cai_Filtrar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            if (result == null)
            {
                throw new Exception("Cais no encontrada");
            }
            return result;
        }

        public IEnumerable<tbCAIs> ListarCaiS()
        {
            try
            {
                var list = _caiSRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                List<tbCAIs> lista = null;
                return lista;
            }
        }

        public int CrearCai(tbCAIs item)
        {
            try
            {
                var list = _caiSRepository.Insert(item);
                return list.code_Status;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        //public int InsertarCaiS(tbCAIs item)
        //{
        //    try
        //    {
        //        var list = _CaiSrepository.Insert(item);
        //        return list.code_Status;
        //    }
        //    catch (Exception ex)
        //    {   
        //        return 0;
        //    }
        //}


        public ServiceResult EliminarCai(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var deleteResult = _caiSRepository.Delete(id);
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
                return result.Error($"Error al eliminar Cai: {ex.Message}");
            }
        }
        #endregion


        #region RegistroCais

        public tbRegistrosCAI BuscarRegistroCaiS(int? id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@RegC_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            var result = db.QueryFirstOrDefault<tbRegistrosCAI>(ScriptDatabase.RegistrosCaiSFiltrar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            if (result == null)
            {
                throw new Exception("Cais no encontrada");
            }
            return result;
        }

        public IEnumerable<tbRegistrosCAI> ListarRegistrosCaiS()
        {
            try
            {
                var list = _registrosCaiSRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                List<tbRegistrosCAI> lista = null;
                return lista;
            }
        }

        public int CrearRegistroCAi(tbRegistrosCAI item)
        {
            try
            {
                var list = _registrosCaiSRepository.Insert(item);
                return list.code_Status;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public ServiceResult ModificarRegistroCai(tbRegistrosCAI item)
        {

            var result = new ServiceResult();
            try
            {
                var list = _registrosCaiSRepository.Update(item);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarRegistroCai(int? id)
        {
            var result = new ServiceResult();
            try
            {
                var deleteResult = _registrosCaiSRepository.Delete(id);
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
                return result.Error($"Error al eliminar Registro Cai: {ex.Message}");
            }
        }
        #endregion
    }
}
