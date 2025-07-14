using SIDCOP_Backend.DataAccess.Repositories.Ventas;
﻿using Dapper;
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


        private readonly ImpuestosRepository _impuestosRepository;
        private readonly CaiSRepository _caiSRepository;
        private readonly RegistrosCaiSRepository _registrosCaiSRepository;
        private readonly VendedorRepository _vendedorRepository;

        public VentaServices(
            CaiSRepository caiSrepository, RegistrosCaiSRepository registrosCaiSRepository
            ,VendedorRepository vendedorRepository, ImpuestosRepository impuestosRepository
    
        )
        {


            _impuestosRepository = impuestosRepository;
            _caiSRepository = caiSrepository;
            _registrosCaiSRepository = registrosCaiSRepository;
            _vendedorRepository = vendedorRepository;
        }






        #region CaiS

        public ServiceResult BuscarCaiS(int? id)
        {
            var result = new ServiceResult();
            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var parameter = new DynamicParameters();
                parameter.Add("@NCai_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

                var cai = db.QueryFirstOrDefault<tbCAIs>(ScriptDatabase.Cai_Filtrar, parameter, commandType: System.Data.CommandType.StoredProcedure);

                if (cai == null)
                    return result.Error("Cai no encontrado");

                return result.Ok(cai);
            }
            catch (Exception ex)
            {
                return result.Error($"Error al buscar Cai: {ex.Message}");
            }
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

        public ServiceResult CrearCai(tbCAIs item)
        {

            var result = new ServiceResult();

            try
            {
                var list = _caiSRepository.Insert(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarCai(tbCAIs item)
        {

            var result = new ServiceResult();
            try
            {
                var list = _caiSRepository.Delete(item);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
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
                return null;
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


        public ServiceResult EliminarRegistroCai(tbRegistrosCAI item)
        {

            var result = new ServiceResult();
            try
            {
                var list = _registrosCaiSRepository.Delete(item);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        //public ServiceResult EliminarRegistroCai(int? id)
        //{
        //    var result = new ServiceResult();
        //    try
        //    {
        //        var deleteResult = _registrosCaiSRepository.Delete(id);
        //        if (deleteResult.code_Status == 1)
        //        {
        //            return result.Ok(deleteResult.message_Status);
        //        }
        //        else
        //        {
        //            return result.Error(deleteResult.message_Status);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return result.Error($"Error al eliminar Registro Cai: {ex.Message}");
        //    }
        //}
        #endregion
                #region Impuestos

        public IEnumerable<tbImpuestos> ListImpuestos()
        {
            try
            {
                var list = _impuestosRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                List<tbImpuestos> lista = null;
                return lista;
            }
        }

        public ServiceResult ActualizarImpuestos(tbImpuestos item)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _impuestosRepository.Update(item);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion



        #region Vendedores

         public IEnumerable<tbVendedores> ListarVendedores()
         {
             try
             {
                 var list = _vendedorRepository.List();
                 return list;
             }
             catch (Exception ex)
             {
                 // Log the exception or handle it as needed
                 //throw new Exception("Error al listar vendedores: " + ex.Message);
                 return null;
             }
         }

         public ServiceResult InsertarVendedor(tbVendedores vendedores)
         {
             var result = new ServiceResult();
             try
             {
                 var insertResult = _vendedorRepository.Insert(vendedores);

                 if (insertResult.code_Status == 1)
                 {
                     return result.Ok(insertResult.message_Status);;
                 }
                 else
                 {
                     return result.Error(insertResult.message_Status);
                 }

             }
             catch (Exception ex)
             {
                 return result.Error($"Error al insertar sucursal: {ex.Message}");
             }
         }

         public ServiceResult ActualizarVendedor(tbVendedores vendedor)
         {
             var result = new ServiceResult();
             try
             {
                 var updateResult = _vendedorRepository.Update(vendedor);
                 if (updateResult.code_Status == 1)
                 {
                     return result.Ok(updateResult.message_Status);
                 }
                 else
                 {
                     return result.Error(updateResult.message_Status);
                 }
             }
             catch (Exception ex)
             {
                 return result.Error($"Error al actualizar vendedor: {ex.Message}");
             }
         }

         public ServiceResult EliminarVendedor(int? id)
         {
             var result = new ServiceResult();
             try
             {
                 var deleteResult = _vendedorRepository.Delete(id);
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
                 return result.Error($"Error al eliminar sucursal: {ex.Message}");
             }
         }

         public tbVendedores BuscarVendedor(int? id)
         {
             try
             {
                 var vendedor = _vendedorRepository.Find(id);
                 return vendedor;
             }
             catch (Exception ex)
             {
                return null;
            }
         }


 #endregion


    }
}
