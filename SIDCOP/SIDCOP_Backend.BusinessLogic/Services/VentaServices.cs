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


        private readonly ImpuestosRepository _impuestosRepository;

        public VentaServices(ImpuestosRepository impuestosRepository)
        {

            _impuestosRepository = impuestosRepository;

        }

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


    }
}
