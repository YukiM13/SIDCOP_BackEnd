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
        private readonly ClienteRepository _clienteRepository;

        public GeneralServices(ColoniaRepository coloniaRepository, EstadoCivilRepository estadoCivilRepository, ClienteRepository clienteRepository)
        {
            _coloniaRepository = coloniaRepository;
            _estadocivilRepository = estadoCivilRepository; 
            _clienteRepository = clienteRepository;

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

        public ServiceResult ActualizarEsCi(tbEstadosCiviles item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _estadocivilRepository.ActualizarEsCi(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarEsCi(tbEstadosCiviles item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _estadocivilRepository.EliminarEsCi(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarEsCi(tbEstadosCiviles item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _estadocivilRepository.BuscarEsCi(item);
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

        public ServiceResult ActualizarMarca(tbMarcas item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _marcaRepository.ActualizarMarca(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarMarca(tbMarcas item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _marcaRepository.EliminarMarca(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarMarca(tbMarcas item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _marcaRepository.BuscarMarca(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion

        #region Clientes
        public ServiceResult InsertCliente(tbClientes item)
        {
            var result = new ServiceResult();
            try
            {
                var insert = _clienteRepository.Insert(item);
                return result.Ok(insert);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion
    }
}
