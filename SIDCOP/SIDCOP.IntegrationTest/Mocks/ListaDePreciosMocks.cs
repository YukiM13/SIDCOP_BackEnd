using Api_SIDCOP.API.Models.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Mocks
{
    public class ListaDePreciosMocks
    {
        public static PreciosPorProductoViewModel CrearMockPreciosPorProducto()
        {
            return new PreciosPorProductoViewModel
            {
                Prod_Id = 1,
                Clie_Id = 1,
                PreP_PrecioContado = 150.50m,
                PreP_PrecioCredito = 175.75m,
                PreP_InicioEscala = 1,
                PreP_FinEscala = 10,
                PreP_ListaPrecios = 1,
                Usua_Creacion = 1,
                PreP_FechaCreacion = DateTime.Now,
                PreP_Estado = true,
                ClientesXml = "<Clientes><Cliente><Id>1</Id></Cliente></Clientes>"
            };
        }

        public static PreciosPorProductoViewModel CrearMockPreciosPorProductoParaActualizar()
        {
            return new PreciosPorProductoViewModel
            {
                PreP_Id = 1,
                Prod_Id = 1,
                Clie_Id = 1,
                PreP_PrecioContado = 200.00m,
                PreP_PrecioCredito = 225.00m,
                PreP_InicioEscala = 1,
                PreP_FinEscala = 15,
                PreP_ListaPrecios = 1,
                Usua_Creacion = 1,
                PreP_FechaCreacion = DateTime.Now,
                Usua_Modificacion = 1,
                PreP_FechaModificacion = DateTime.Now,
                PreP_Estado = true,
                ClientesXml = "<Clientes><Cliente><Id>1</Id></Cliente></Clientes>"
            };
        }
    }
}
