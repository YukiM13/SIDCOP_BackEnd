using SIDCOP_Backend.DataAccess.Repositories.Acceso;
using SIDCOP_Backend.DataAccess.Repositories.General;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIDCOP_Backend.DataAccess.Repositories.Acceso;
using SIDCOP_Backend.DataAccess.Repositories.General;
using SIDCOP_Backend.Entities.Entities;

namespace SIDCOP_Backend.BusinessLogic.Services
{
    public class GeneralServices
    {
        private readonly MunicipioRepository _municipioRepository;
        private readonly ColoniaRepository _coloniaRepository;
        private readonly EstadoCivilRepository _estadocivilRepository; 

        public GeneralServices(ColoniaRepository coloniaRepository, EstadoCivilRepository estadoCivilRepository, MunicipioRepository municipioRepository)
        {
            _coloniaRepository = coloniaRepository;
            _estadocivilRepository = estadoCivilRepository; 
             _municipioRepository = municipioRepository;

        }


        #region Colonias 

        public IEnumerable<tbColonias> ListarColonia()
        {
            var result = new ServiceResult();
            try
            {
                var list = _coloniaRepository.List();
                return list;
            }
            catch (Exception ex)
            {

                IEnumerable<tbColonias> colonia = null;
                return colonia;
            }
        }
        #endregion


        #region Estados Civiles
        public IEnumerable<tbEstadosCiviles> ListEsCi()
        {
            var result = new ServiceResult();
            try
            {
                var list = _estadocivilRepository.List();
                return list;
            }
            catch (Exception ex)
            {

                IEnumerable<tbEstadosCiviles> esci = null;
                return esci;
            }
        }
        #endregion
    
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

        public ServiceResult ActualizarMunicipios(tbMunicipios item)
        {
            var result = new ServiceResult();
            try
            {
                var muni = _municipioRepository.Update(item);
                return result.Ok(muni);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public IEnumerable<tbMunicipios> ListarMunicipios()
        {
            var result = new ServiceResult();
            try
            {
                var list = _municipioRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbMunicipios> muni = null;
                return muni;
            }
        }

        #endregion
    
    
    }
}
