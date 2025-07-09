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
        private readonly MunicipioRepository _municipioRepository;

        public GeneralServices(MunicipioRepository municipioRepository)
        {
            _municipioRepository = municipioRepository;
            
        }

        #region Municipios 

        public ServiceResult InsertarMunicipios(tbMunicipios item)
        {
            var result = new ServiceResult();
            try
            {
                var muni = _municipioRepository.Insert(item);
                return result.Ok(muni);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

    }
}
