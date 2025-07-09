using SIDCOP_Backend.DataAccess.Repositories.Acceso;
using SIDCOP_Backend.DataAccess.Repositories.General;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.BusinessLogic.Services
{
    public class GeneralServices
    {
        private readonly DepartamentoRepository _departamentoRepository;

        public GeneralServices(DepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;

        }

        #region Departamentos
        public ServiceResult InsertarDepartamento(tbDepartamentos item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _departamentoRepository.Insert(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EditarDepartamento(tbDepartamentos item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _departamentoRepository.Update(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarDepartamento(tbDepartamentos item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _departamentoRepository.Delete(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


        public IEnumerable<tbDepartamentos> BuscarDepartamento(tbDepartamentos item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _departamentoRepository.Find(item);
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbDepartamentos> usua = null;
                return usua;
            }
        }

        public IEnumerable<tbDepartamentos> ListarDepartamentos()
        {
            var result = new ServiceResult();
            try
            {
                var list = _departamentoRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbDepartamentos> usua = null;
                return usua;
            }
        }
        #endregion

    }
}
