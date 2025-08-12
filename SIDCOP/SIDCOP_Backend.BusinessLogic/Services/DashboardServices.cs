using Api_SIDCOP.API.Models.Reportes;
using SIDCOP_Backend.DataAccess.Repositories.Dashboards;
using SIDCOP_Backend.DataAccess.Repositories.Reportes;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.BusinessLogic.Services
{
    public class DashboardServices
    {

        private readonly DashboardsRepository _dashboardsRepository;


        public DashboardServices(DashboardsRepository dashboardsRepository)
        {
            _dashboardsRepository = dashboardsRepository;
        }




        public IEnumerable<dynamic> VentasPorMes()
        {
            try
            {
                var list = _dashboardsRepository.VentasPorMes();
                return list;
            }
            catch (Exception ex)
            {
                
                return Enumerable.Empty<dynamic>();
            }
        }

        public IEnumerable<dynamic> VentasPorMesCategorias(DashboardsViewModel item)
        {
            try
            {
                var list = _dashboardsRepository.VentasPorMesCategorias(item);
                return list;
            }
            catch (Exception ex)
            {
                
                return Enumerable.Empty<dynamic>();
            }
        }

        public IEnumerable<dynamic> VentasPorMesProductos(DashboardsViewModel item)
        {
            try
            {
                var list = _dashboardsRepository.VentasPorMesProductos(item);
                return list;
            }
            catch (Exception ex)
            {
                
                return Enumerable.Empty<dynamic>();
            }
        }

        public IEnumerable<dynamic> Top5VendedoresPorMes(DashboardsViewModel item)
        {
            try
            {
                var list = _dashboardsRepository.Top5VendedoresPorMes(item);
                return list;
            }
            catch (Exception ex)
            {

                return Enumerable.Empty<dynamic>();
            }
        }
        public IEnumerable<dynamic> Top5ProductosCategoria(DashboardsViewModel item)
        {
            try
            {
                var list = _dashboardsRepository.Top5ProductosCategoria(item);
                return list;
            }
            catch (Exception ex)
            {

                return Enumerable.Empty<dynamic>();
            }
        }
        public IEnumerable<dynamic> Top5MarcasMasVendidas(
          DateTime? fechaInicio = null,
          DateTime? fechaFin = null)
        {
            try
            {
                var list = _dashboardsRepository.Top5MarcasMasVendidas(fechaInicio, fechaFin);
                return list;
            }
            catch (Exception ex)
            {

                return Enumerable.Empty<dynamic>();
            }
        }
        public IEnumerable<dynamic> ProductosPorMarcas(
          int marcaId,
          DateTime? fechaInicio = null,
          DateTime? fechaFin = null)
        {
            try
            {
                var list = _dashboardsRepository.DashboardProductosPorMarcas(marcaId, fechaInicio, fechaFin);
                return list;
            }
            catch (Exception ex)
            {

                return Enumerable.Empty<dynamic>();
            }
        }
    }
}
