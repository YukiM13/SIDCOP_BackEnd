using Api_SIDCOP.API.Models.Reportes;
using SIDCOP_Backend.DataAccess.Repositories.Reportes;
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
                // Log del error si tienes sistema de logging
                return Enumerable.Empty<dynamic>();
            }
        }

    }
}
