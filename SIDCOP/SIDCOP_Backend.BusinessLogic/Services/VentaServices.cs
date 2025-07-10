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
        private readonly CaiSRepository _CaiSrepository;


        #region CaiS

        public IEnumerable<tbCAIs> BuscarCAiS(tbCAIs item)
        {
            var result = new ServiceResult();

            try
            {
                var list = _CaiSrepository.Find2(item.NCai_Codigo);
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbCAIs> CaiS = null;
                return CaiS;
            }
        }
        public IEnumerable<tbCAIs> ListarCaiS()
        {

            try
            {
                var list = _CaiSrepository.Listar();
                return list;
            }
            catch (Exception ex)
            {
                List<tbCAIs> lista = null;
                return lista;
            }
        }
        public int InsertarCaiS(tbCAIs item)
        {
            try
            {
                var list = _CaiSrepository.Insert(item);
                return list;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public ServiceResult EliminarCaiS(tbCAIs item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _CaiSrepository.Delete(item);

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
