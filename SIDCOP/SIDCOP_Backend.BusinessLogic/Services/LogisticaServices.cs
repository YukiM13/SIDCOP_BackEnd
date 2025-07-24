
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

        // Repositorios para manejar las operaciones de acceso a datos
        private readonly RutasRepository _rutasRepository;
        private readonly BodegaRepository _bodegaRepository;
        private readonly TrasladoRepository _trasladoRepository;

        // Constructor que recibe los repositorios necesarios
        public LogisticaServices(RutasRepository rutasRepository, BodegaRepository bodegaRepository, TrasladoRepository trasladoRepository)
        {
            // Asignación de los repositorios a las variables de instancia
            _rutasRepository = rutasRepository;
            _bodegaRepository = bodegaRepository;
            _trasladoRepository = trasladoRepository;
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


        public ServiceResult DeleteTraslado(int id)
        {
            var result = new ServiceResult();
            try
            {
                var response = _trasladoRepository.Delete(id);
                return result.Ok(response); // Retorna el resultado exitoso
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);  // Retorna el mensaje de error si falla
            }
        }


        public ServiceResult FindTraslado(int id)
        {
            var result = new ServiceResult();
            try
            {
                var response = _trasladoRepository.Find(id);
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
