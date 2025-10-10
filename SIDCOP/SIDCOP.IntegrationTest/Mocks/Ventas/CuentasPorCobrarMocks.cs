using Api_SIDCOP.API.Models.General;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Mocks
{
    public class CuentasPorCobrarMocks
    {
        public static CuentasPorCobrarViewModel CrearMockCuentaPorCobrarListarConFiltro()
        {
            return new CuentasPorCobrarViewModel
            {
                Clie_Id = 3285
            };
        }

        public static CuentasPorCobrarViewModel CrearMockCuentaPorCobrarDetalle()
        {
            return new CuentasPorCobrarViewModel
            {
                CPCo_Id = 84
            };
        }

        public static CuentasPorCobrarViewModel CrearMockCuentaPorCobrartimeLine()
        {
            return new CuentasPorCobrarViewModel
            {
                Clie_Id = 3285
            };
        }
    }
}
