using SIDCOP_Backend.DataAccess.Repositories.Acceso;
using SIDCOP_Backend.DataAccess.Repositories.Ventas;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.BusinessLogic.Services
{
    public class VentaServices
    {
        private readonly ConfiguracionFacturaRepository _configuracionFacturaRepository;

        public VentaServices(ConfiguracionFacturaRepository configuracionFacturaRepository)
        {
            _configuracionFacturaRepository = configuracionFacturaRepository;

        }

        #region Usuarios 

        public IEnumerable<tbConfiguracionFacturas> ListConfiguracionFactura()
        {
            //var result = new ServiceResult();
            try
            {
                var list = _configuracionFacturaRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbConfiguracionFacturas> result = null;
                return result;
            }
        }

        public ServiceResult InsertConfiguracionFactura(tbConfiguracionFacturas item)
        {
            var result = new ServiceResult();
            try
            {
                var response = _configuracionFacturaRepository.Insert(item);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdateConfiguracionFactura(tbConfiguracionFacturas item)
        {
            var result = new ServiceResult();
            try
            {
                var response = _configuracionFacturaRepository.Update(item);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult DeleteConfiguracionFactura(tbConfiguracionFacturas item)
        {
            var result = new ServiceResult();
            try
            {
                var response = _configuracionFacturaRepository.Delete(item);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult FindConfiguracionFactura(int id)
        {
            var result = new ServiceResult();
            try
            {
                var response = _configuracionFacturaRepository.Find(id);
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
