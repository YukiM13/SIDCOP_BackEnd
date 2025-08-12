using Api_SIDCOP.API.Models.Reportes;
using SIDCOP_Backend.DataAccess.Repositories.Reportes;
using SIDCOP_Backend.Entities.Entities;

namespace SIDCOP_Backend.BusinessLogic.Services
{
    public class ReportesServices
    {

        private readonly ReporteRepository _reporteRepository;


        public ReportesServices(ReporteRepository reporteRepository)
        {
            _reporteRepository = reporteRepository;
        }




        public IEnumerable<ReportesViewModel> ReporteProductos(
          DateTime? fechaInicio = null,
          DateTime? fechaFin = null,
          int? marcaId = null,
          int? categoriaId = null)
        {
            try
            {
                var list = _reporteRepository.ReporteDeProductos(fechaInicio, fechaFin, marcaId, categoriaId);
                return list;
            }
            catch (Exception ex)
            {
                // Log del error si tienes sistema de logging
                return Enumerable.Empty<ReportesViewModel>();
            }
        }

        public IEnumerable<ReporteProductosVendidosRuta> ReporteProductosPorRuta(int? rutaId = null)
        {
            try
            {
                var list = _reporteRepository.ReporteProductosVendidosRutas(rutaId);
                return list;
            }
            catch (Exception ex)
            {
                // Log del error si tienes sistema de logging
                return Enumerable.Empty<ReporteProductosVendidosRuta>();
            }
        }

        public IEnumerable<ReportesViewModel> ReporteClientesMasFacturados(DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            try
            {
                var list = _reporteRepository.ReporteClientesMasFacturados(fechaInicio, fechaFin);
                return list;
            }
            catch (Exception ex)
            {
                // Log del error si tienes sistema de logging
                return Enumerable.Empty<ReportesViewModel>();
            }
        }


        public IEnumerable<dynamic> ReportePedidosPorFecha(DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            try
            {
                var list = _reporteRepository.ReportePedidosPorFecha(fechaInicio, fechaFin);
                return list;
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<dynamic>();
            }
        }

        public IEnumerable<dynamic> ReporteVendedoresPorRuta(int? rutaId = null)
        {
            try
            {
                var list = _reporteRepository.ReporteVendedoresPorRuta(rutaId);
                return list;
            }
            catch (Exception ex)
            {
                
                return Enumerable.Empty<dynamic>();
            }
        }

        public IEnumerable<dynamic> ReporteClientesPorCanalesFecha(DateTime? fechaInicio = null, DateTime? fechaFin = null, int? canaId =null)
        {
            try
            {
                var list = _reporteRepository.ReporteClientesPorCanalesFecha(fechaInicio, fechaFin, canaId);
                return list;
            }
            catch (Exception ex)
            {

                return Enumerable.Empty<dynamic>();
            }
        }


    }
}
