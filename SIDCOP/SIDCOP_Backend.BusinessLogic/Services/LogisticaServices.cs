using Microsoft.Identity.Client;
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

        #region Rutas
        public LogisticaServices(RutasRepository rutasRepository)
        {
            _rutasRepository = rutasRepository;
        }


        public IEnumerable<tbRutas> BuscarRuta(tbRutas item)
        {
            var result = new ServiceResult();

            try
            {
                var list = _rutasRepository.Find2(item.Ruta_Codigo);
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbRutas> ruta = null;
                return ruta;
            }
        }
        public IEnumerable<tbRutas> ListRutas()
        {

            try
            {
                var list = _rutasRepository.Listar();
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
            //var result = new ServiceResult();
            try
            {
                var list = _rutasRepository.Insert(item);
                return list;
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

        public ServiceResult EliminarRuta(tbRutas item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _rutasRepository.Delete(item);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion
    }
}
