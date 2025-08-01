using Api_SIDCOP.API.Models.Reportes;
using SIDCOP_Backend.DataAccess.Repositories.General;
using SIDCOP_Backend.DataAccess.Repositories.Inventario;
using SIDCOP_Backend.DataAccess.Repositories.Reportes;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.BusinessLogic.Services
{
    public class ReportesServices
    {

        private readonly ReporteRepository _reporteRepository;


        public  ReportesServices(ReporteRepository reporteRepository)
        {
            _reporteRepository = reporteRepository ;
        }




        public IEnumerable<ReportesViewModel> ReporteProductos()
        {
            try
            {
                var list = _reporteRepository.ReporteDeProductos();
                return list;
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<ReportesViewModel>();
            }
        }
    }
}
