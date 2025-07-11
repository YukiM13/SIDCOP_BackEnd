using SIDCOP_Backend.DataAccess.Repositories.Logistica;
using SIDCOP_Backend.DataAccess.Repositories.Ventas;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.BusinessLogic.Services
{
    public class LogisticaServices
    {
        private readonly BodegaRepository _bodegaRepository;

        public LogisticaServices(BodegaRepository bodegaRepository)
        {
            _bodegaRepository = bodegaRepository;

        }

        #region ConfiguracionFacturas 

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
