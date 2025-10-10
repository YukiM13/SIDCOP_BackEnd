
using Azure.Core;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.DataAccess.Repositories.General;
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
    public class LogisticaServices
    {

        private readonly RutasRepository _rutasRepository;
        private readonly BodegaRepository _bodegaRepository;
        private readonly TrasladoRepository _trasladoRepository;
        private readonly RecargasRepository _recargasRepository;

        public LogisticaServices(
RutasRepository rutasRepository,
BodegaRepository bodegaRepository,
TrasladoRepository trasladoRepository,
RecargasRepository recargasRepository)
        {
            _rutasRepository = rutasRepository;
            _bodegaRepository = bodegaRepository;
            _trasladoRepository = trasladoRepository;
            _recargasRepository = recargasRepository;
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


        public IEnumerable<tbRutas> ListarRutasDisponibles()
        {

            try
            {
                var list = _rutasRepository.ListDisponibles();
                return list;
            }
            catch (Exception ex)
            {
                List<tbRutas> lista = null;
                return lista;
            }
        }

        public ServiceResult InsertarRuta(tbRutas item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _rutasRepository.Insert(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
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
                var list = _rutasRepository.Delete(id);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


 
        #endregion



        #region Bodegas 

        
        public IEnumerable<tbBodegas> ListBodegas()
        {
   
            try
            {
                var list = _bodegaRepository.List();
                return list; //Retorna el listado 
            }
            catch (Exception ex)
            {
                // En caso de error, retorna null
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
                return result.Ok(response); // Retorna el resultado exitoso
            }
            catch (Exception ex)
            { 
                return result.Error(ex.Message); // Retorna el mensaje de error si falla
            }
        }

      
        public ServiceResult UpdateBodega(tbBodegas item)
        {
            var result = new ServiceResult();
            try
            {
                var response = _bodegaRepository.Update(item);
                return result.Ok(response);  // Retorna el resultado exitoso
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);  // Retorna el mensaje de error si falla
            }
        }

  
        public ServiceResult DeleteBodega(int id)
        {
            var result = new ServiceResult();
            try
            {
                var response = _bodegaRepository.Delete(id);
                return result.Ok(response); // Retorna el resultado exitoso
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);  // Retorna el mensaje de error si falla
            }
        }

     
        public ServiceResult FindBodega(int id)
        {
            var result = new ServiceResult();
            try
            {
                var response = _bodegaRepository.Find(id);
                return result.Ok(response); // Retorna el resultado exitoso
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);  // Retorna el mensaje de error si falla
            }
        }

        #endregion


        #region Traslados

        public IEnumerable<tbTraslados> ListTraslados()
        {

            try
            {
                var list = _trasladoRepository.ListTraslados();
                return list; //Retorna el listado 
            }
            catch (Exception ex)
            {
                // En caso de error, retorna null
                IEnumerable<tbTraslados> result = null;
                return result;
            }
        }


        public ServiceResult InsertTraslado(tbTraslados item)
        {
            var result = new ServiceResult();
            try
            {
                var response = _trasladoRepository.InsertTraslado(item);
                return result.Ok(response); // Retorna el resultado exitoso
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna el mensaje de error si falla
            }
        }

        public ServiceResult InsertTrasladoDetalle(tbTrasladosDetalle item)
        {
            var result = new ServiceResult();
            try
            {
                var response = _trasladoRepository.InsertTrasladoDetalle(item);
                return result.Ok(response); // Retorna el resultado exitoso
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message); // Retorna el mensaje de error si falla
            }
        }


        public ServiceResult UpdateTraslado(tbTraslados item)
        {
            var result = new ServiceResult();
            try
            {
                var response = _trasladoRepository.Update(item);
                return result.Ok(response);  // Retorna el resultado exitoso
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);  // Retorna el mensaje de error si falla
            }
        }


        public ServiceResult EliminarTraslado(int id)
        {
            var result = new ServiceResult();
            try
            {
                var response = _trasladoRepository.EliminarTraslado(id);
                return result.Ok(response); // Retorna el resultado exitoso
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);  // Retorna el mensaje de error si falla
            }
        }


        public ServiceResult BuscarTraslado(int id)
        {
            var result = new ServiceResult();
            try
            {
                var response = _trasladoRepository.BuscarTraslado(id);
                return result.Ok(response); // Retorna el resultado exitoso
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);  // Retorna el mensaje de error si falla
            }
        }

        public ServiceResult BuscarTrasladoDetalle(int id)
        {
            var result = new ServiceResult();
            try
            {
                var response = _trasladoRepository.BuscarTrasladoDetalle(id);
                return result.Ok(response); // Retorna el resultado exitoso
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);  // Retorna el mensaje de error si falla
            }
        }

        #endregion

        #region Recargas 


        public IEnumerable<tbRecargas> ListRecargas()
        {

            try
            {
                var list = _recargasRepository.List();
                return list; //Retorna el listado 
            }
            catch (Exception ex)
            {
                // En caso de error, retorna null
                IEnumerable<tbRecargas> result = null;
                return result;
            }
        }


        public virtual ServiceResult InsertRecargas(tbRecargas item)
        {
            var result = new ServiceResult();
            try
            {
                var response = _recargasRepository.Insert(item);

                if (response.code_Status == 1)
                {
                    return result.Ok(response);
                }
                else
                {
                    return result.Error(response);
                }

            }
            catch (Exception ex)
            {
                return result.Error($"Error al insertar sucursal: {ex.Message}");
            }
        }


        public virtual ServiceResult UpdateRecargas(tbRecargas item)
        {
            var result = new ServiceResult();
            try
            {
                var response = _recargasRepository.Update(item);
                return result.Ok(response);  // Retorna el resultado exitoso
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);  // Retorna el mensaje de error si falla
            }
        }

        public ServiceResult ConfirmRecargas(tbRecargas item)
        {
            var result = new ServiceResult();
            try
            {
                var response = _recargasRepository.RecargasConfirm(item);
                return result.Ok(response);  // Retorna el resultado exitoso
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);  // Retorna el mensaje de error si falla
            }
        }


        public ServiceResult DeleteRecargas(int id)
        {
            var result = new ServiceResult();
            try
            {
                var response = _recargasRepository.Delete(id);
                return result.Ok(response); // Retorna el resultado exitoso
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);  // Retorna el mensaje de error si falla
            }
        }


        public ServiceResult FindRecargas(int id)
        {
            var result = new ServiceResult();
            try
            {
                var response = _recargasRepository.Find2(id);
                return result.Ok(response); // Retorna el resultado exitoso
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);  // Retorna el mensaje de error si falla
            }
        }



        // Servicio
        //public IEnumerable<tbRecargas> FindRecargasSucu(int id, bool esAdmin)
        //{
        //    try
        //    {
        //        var recargas = _recargasRepository.FindSucu(id, esAdmin);

        //        // Debug: Verifica si hay datos
        //        if (recargas == null)
        //        {
        //            throw new Exception("Repository devolvió null");
        //        }

        //        if (!recargas.Any())
        //        {
        //            throw new Exception("Repository devolvió lista vacía");
        //        }

        //        return recargas;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Debug: Ver el error específico
        //        throw new Exception($"Error en FindRecargasSucu: {ex.Message}");
        //    }
        //}

        public ServiceResult FindRecargasSucu(int id, bool esAdmin)
        {
            var result = new ServiceResult();
            try
            {
                var response = _recargasRepository.FindSucu(id, esAdmin);
                return result.Ok(response); // Retorna el resultado exitoso
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);  // Retorna el mensaje de error si falla
            }
        }



        #endregion

    }
}
