using Api_SIDCOP.API.Models.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Mocks.Logistica
{
    public class ProductosMocks
    {
        public static ProductosViewModel CrearMockProducto()
        {
            return new ProductosViewModel
            {
                Prod_Id = 1,
                Prod_Codigo = "PROD001",
                Prod_Descripcion = "Producto de Prueba",
                Prod_DescripcionCorta = "Prod Test",
                UnMe_Id = 1,
                UnMe_Descripcion = "Unidad",
                Prod_Precio = 100.50m,
                Prod_Estado = true,
                Usua_Creacion = 1,
                Prod_FechaCreacion = DateTime.Now
            };
        }

        public static List<ProductosViewModel> CrearMockListaProductos()
        {
            return new List<ProductosViewModel>
            {
                new ProductosViewModel { Prod_Id = 1, Prod_Descripcion = "Producto 1", Prod_Codigo = "P001", UnMe_Id = 1, Prod_Precio = 100.50m },
                new ProductosViewModel { Prod_Id = 2, Prod_Descripcion = "Producto 2", Prod_Codigo = "P002", UnMe_Id = 1, Prod_Precio = 200.75m },
                new ProductosViewModel { Prod_Id = 3, Prod_Descripcion = "Producto 3", Prod_Codigo = "P003", UnMe_Id = 2, Prod_Precio = 150.25m }
            };
        }

        public static ProductosViewModel CrearMockProductoInvalido()
        {
            return new ProductosViewModel
            {
                Prod_Id = -1,
                Prod_Codigo = "",
                Prod_Descripcion = "",
                UnMe_Id = -1,
                Prod_Precio = -100,
                Prod_Estado = false,
                Usua_Creacion = -1,
                Prod_FechaCreacion = DateTime.Now.AddYears(5)
            };
        }

        public static ProductosViewModel CrearMockProductoValoresExtremos()
        {
            return new ProductosViewModel
            {
                Prod_Id = int.MaxValue,
                Prod_Codigo = new string('X', 100),
                Prod_Descripcion = new string('D', 1000),
                UnMe_Id = int.MaxValue,
                Prod_Precio = decimal.MaxValue,
                Prod_Estado = true,
                Usua_Creacion = int.MaxValue,
                Prod_FechaCreacion = DateTime.MinValue
            };
        }
    }
}
