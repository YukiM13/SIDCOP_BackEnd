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

        private readonly ColoniaRepository _coloniaRepository;
        private readonly EstadoCivilRepository _estadocivilRepository;
        private readonly ModeloRepository _modeloRepository;

        public GeneralServices(ColoniaRepository coloniaRepository, EstadoCivilRepository estadoCivilRepository, ModeloRepository modeloRepository)
        {
            _coloniaRepository = coloniaRepository;
            _estadocivilRepository = estadoCivilRepository;
            _modeloRepository = modeloRepository;

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

        #region Modelos

        public IEnumerable<tbModelos> ListModelos()
        {
            try
            {
                var list = _modeloRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                List<tbModelos> lista = null;
                return lista;
            }
        }

        public ServiceResult InsertarModelo(tbModelos item)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _modeloRepository.Insert(item);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarModelo(tbModelos item)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _modeloRepository.Update(item);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarModelo(tbModelos item)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _modeloRepository.Delete(item);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarModelo(tbModelos item)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _modeloRepository.FindCodigo(item);
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
