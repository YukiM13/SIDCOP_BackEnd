using Api_SIDCOP.API.Models.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Mocks
{
    public class PagoCuentaPorCobrarMocks
    {
        public static PagosCuentasPorCobrarViewModel CrearMockPagoCuentaPorCobrarInsertar()
        {
            return new PagosCuentasPorCobrarViewModel
            {
                CPCo_Id = 81,
                Pago_Monto = 69,
                FoPa_Id = 1,
                Pago_NumeroReferencia = "123456",
                Pago_Observaciones = "Pago de prueba 2.0",
                Usua_Creacion = 1
            };
        }

        public static PagosCuentasPorCobrarViewModel CrearMockPagoCuentaPorCobrarListarCuentaPorCobrar()
        {
            return new PagosCuentasPorCobrarViewModel
            {
                CPCo_Id = 76
            };
        }

        public static AnularPagoViewModel CrearMockPagoCuentaPorCobrarAnular()
        {
            return new AnularPagoViewModel
            {
                Pago_Id = 2207,
                Usua_Modificacion = 1,
                Motivo_Anulacion = "Porque si"
            };
        }
    }
}
