using Api_SIDCOP.API.Models.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Mocks.Logistica
{
    public class InventarioSucursalesMocks
    {
        public static InventarioSucursalesViewModel CrearMockInventarioItem()
        {
            return new InventarioSucursalesViewModel
            {
                InSu_Id = 1,
                Sucu_Id = 1,
                Prod_Id = 10,
                Sucu_Descripcion = "Sucursal Central",
                Prod_Descripcion = "Producto A",
                Prod_DescripcionCorta = "ProdA",
                InSu_Cantidad = 50,
                Cambio = null,
                Usua_Creacion = 1,
                InSu_FechaCreacion = DateTime.Now,
                InSu_Estado = true
            };
        }

        public static List<InventarioSucursalesViewModel> CrearMockListaInventario()
        {
            return new List<InventarioSucursalesViewModel>
            {
                new InventarioSucursalesViewModel { InSu_Id = 1, Sucu_Id = 1, Prod_Id = 10, Prod_Descripcion = "Producto A", InSu_Cantidad = 15 },
                new InventarioSucursalesViewModel { InSu_Id = 2, Sucu_Id = 1, Prod_Id = 11, Prod_Descripcion = "Producto B", InSu_Cantidad = 25 },
                new InventarioSucursalesViewModel { InSu_Id = 3, Sucu_Id = 1, Prod_Id = 12, Prod_Descripcion = "Producto C", InSu_Cantidad = 30 }
            };
        }

        public static List<InventarioSucursalesViewModel> CrearMockListaParaActualizarCantidades()
        {
            return new List<InventarioSucursalesViewModel>
            {
                new InventarioSucursalesViewModel { InSu_Id = 1, Prod_Id = 8, InSu_Cantidad = 100 },
                new InventarioSucursalesViewModel { InSu_Id = 2, Prod_Id = 9, InSu_Cantidad = 200 }
            };
        }

        public static InventarioSucursalesViewModel CrearMockInventarioInvalidos()
        {
            return new InventarioSucursalesViewModel
            {
                InSu_Id = -1,
                Sucu_Id = -5,
                Prod_Id = -10,
                InSu_Cantidad = -100,
                Usua_Creacion = -1,
                InSu_FechaCreacion = DateTime.Now.AddYears(5),
                InSu_Estado = false
            };
        }

        public static InventarioSucursalesViewModel CrearMockInventarioValoresExtremos()
        {
            return new InventarioSucursalesViewModel
            {
                InSu_Id = int.MaxValue,
                Sucu_Id = int.MaxValue,
                Prod_Id = int.MaxValue,
                InSu_Cantidad = int.MaxValue,
                Usua_Creacion = int.MaxValue,
                InSu_FechaCreacion = DateTime.MinValue,
                InSu_Estado = true
            };
        }
    }
}
