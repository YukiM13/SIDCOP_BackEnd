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

        private readonly ColoniaRepository _coloniaRepository;
        private readonly EstadoCivilRepository _estadocivilRepository; 
        private readonly MarcaRepository _marcaRepository;

        public GeneralServices(ColoniaRepository coloniaRepository, EstadoCivilRepository estadoCivilRepository, MarcaRepository marcaRepository)
        {
            _coloniaRepository = coloniaRepository;
            _estadocivilRepository = estadoCivilRepository; 
            _marcaRepository = marcaRepository;

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

        public ServiceResult InsertEsCi(tbEstadosCiviles item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _estadocivilRepository.InsertEsCi(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


        #endregion

        #region Marcas

        public IEnumerable<tbMarcas> ListMarcas()
        {
            var result = new ServiceResult();
            try
            {
                var list = _marcaRepository.List();
                return list;
            }
            catch (Exception ex)
            {

                IEnumerable<tbMarcas> marc = null;
                return marc;
            }
        }

        public ServiceResult InsertMarca(tbMarcas item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _marcaRepository.InsertMarca(item);
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
