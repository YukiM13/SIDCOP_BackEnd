using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.DataAccess.Repositories.Acceso;
using SIDCOP_Backend.DataAccess.Repositories.General;
using SIDCOP_Backend.Entities.Entities;

namespace SIDCOP_Backend.BusinessLogic.Services
{
    public class GeneralServices
    {
        private readonly EstadoCivilRepository _estadocivilRepository;
        private readonly SucursalesRepository _sucursalesRepository;

        public GeneralServices(EstadoCivilRepository estadocivilRepository, SucursalesRepository sucursalesRepository)
        {
            _estadocivilRepository = estadocivilRepository;
            _sucursalesRepository = sucursalesRepository;

        }

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

        #region Sucursales

        public IEnumerable<tbSucursales> ListSucursales()
        {
            var result = new ServiceResult();
            try
            {
                var list = _sucursalesRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbSucursales> sucursales = null;
                return sucursales;
            }
        }

        public ServiceResult InsertarSucursal(tbSucursales sucursal)
        {
            var result = new ServiceResult();
            try
            {
                var insertResult = _sucursalesRepository.Insert(sucursal);

                if (insertResult.CodeStatus == 1)
                {
                    //result.Ok = true;
                    //result.Message = ;
                    return result.Ok(insertResult.MessageStatus);
                    //return result.Ok(insertResult.MessageStatus);
                }
                else
                {
                    //result.IsSuccess = false;
                    //result.Message = insertResult.MessageStatus;
                    //return result.Error(insertResult.MessageStatus);
                    return result.Error(insertResult.MessageStatus);
                }

            }
            catch (Exception ex)
            {
                //return new RequestStatus { CodeStatus = 0, MessageStatus = $"Error inesperado: {ex.Message}" };
                //return result.Error($"Error al insertar carro: {ex.Message}");
                return result.Error($"Error al insertar sucursal: {ex.Message}");
            }
        }
        #endregion
    }
}
