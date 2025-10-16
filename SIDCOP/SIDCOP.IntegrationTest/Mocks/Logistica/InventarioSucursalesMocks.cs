using Api_SIDCOP.API.Models.Inventario;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIDCOP.IntegrationTest.Mocks.Logistica
{
    public static class InventarioSucursalesMocks
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
                new() { 
                    InSu_Id = 1, 
                    Sucu_Id = 1, 
                    Prod_Id = 10, 
                    Sucu_Descripcion = "Sucursal Central",
                    Prod_Descripcion = "Producto A",
                    Prod_DescripcionCorta = "ProdA",
                    InSu_Cantidad = 15,
                    Usua_Creacion = 1,
                    InSu_FechaCreacion = DateTime.Now.AddDays(-10),
                    InSu_Estado = true
                },
                new() { 
                    InSu_Id = 2, 
                    Sucu_Id = 1, 
                    Prod_Id = 11, 
                    Sucu_Descripcion = "Sucursal Central",
                    Prod_Descripcion = "Producto B",
                    Prod_DescripcionCorta = "ProdB",
                    InSu_Cantidad = 25,
                    Usua_Creacion = 1,
                    InSu_FechaCreacion = DateTime.Now.AddDays(-5),
                    InSu_Estado = true
                },
                new() { 
                    InSu_Id = 3, 
                    Sucu_Id = 1, 
                    Prod_Id = 12, 
                    Sucu_Descripcion = "Sucursal Central",
                    Prod_Descripcion = "Producto C",
                    Prod_DescripcionCorta = "ProdC",
                    InSu_Cantidad = 30,
                    Usua_Creacion = 1,
                    InSu_FechaCreacion = DateTime.Now.AddDays(-2),
                    InSu_Estado = true
                }
            };
        }

        public static List<InventarioSucursalesViewModel> CrearMockListaParaActualizarCantidades()
        {
            return new List<InventarioSucursalesViewModel>
            {
                new() { 
                    InSu_Id = 1, 
                    Prod_Id = 8, 
                    InSu_Cantidad = 100,
                    Sucu_Id = 1,
                    Usua_Creacion = 1,
                    InSu_FechaCreacion = DateTime.Now
                },
                new() { 
                    InSu_Id = 2, 
                    Prod_Id = 9, 
                    InSu_Cantidad = 200,
                    Sucu_Id = 1,
                    Usua_Creacion = 1,
                    InSu_FechaCreacion = DateTime.Now
                }
            };
        }

        public static InventarioSucursalesViewModel CrearMockInventarioInvalido()
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

        public static tbInventarioSucursales CrearEntidadInventarioSucursal()
        {
            return new tbInventarioSucursales
            {
                InSu_Id = 1,
                Sucu_Id = 1,
                Prod_Id = 10,
                InSu_Cantidad = 50,
                Usua_Creacion = 1,
                InSu_FechaCreacion = DateTime.Now,
                InSu_Estado = true,
                Prod = new tbProductos
                {
                    Prod_Id = 10,
                    Prod_Descripcion = "Producto A",
                    Prod_DescripcionCorta = "ProdA"
                },
                Sucu = new tbSucursales
                {
                    Sucu_Id = 1,
                    Sucu_Descripcion = "Sucursal Central"
                },
                Usua_CreacionNavigation = new tbUsuarios
                {
                    Usua_Id = 1,
                  
                }
            };
        }

        public static List<tbInventarioSucursales> CrearListaEntidadInventarioSucursal()
        {
            return new List<tbInventarioSucursales>
            {
                new()
                {
                    InSu_Id = 1,
                    Sucu_Id = 1,
                    Prod_Id = 10,
                    InSu_Cantidad = 15,
                    Usua_Creacion = 1,
                    InSu_FechaCreacion = DateTime.Now.AddDays(-10),
                    InSu_Estado = true,
                    Prod = new tbProductos { Prod_Descripcion = "Producto A", Prod_DescripcionCorta = "ProdA" },
                    Sucu = new tbSucursales { Sucu_Descripcion = "Sucursal Central" }
                },
                new()
                {
                    InSu_Id = 2,
                    Sucu_Id = 1,
                    Prod_Id = 11,
                    InSu_Cantidad = 25,
                    Usua_Creacion = 1,
                    InSu_FechaCreacion = DateTime.Now.AddDays(-5),
                    InSu_Estado = true,
                    Prod = new tbProductos { Prod_Descripcion = "Producto B", Prod_DescripcionCorta = "ProdB" },
                    Sucu = new tbSucursales { Sucu_Descripcion = "Sucursal Central" }
                },
                new()
                {
                    InSu_Id = 3,
                    Sucu_Id = 1,
                    Prod_Id = 12,
                    InSu_Cantidad = 30,
                    Usua_Creacion = 1,
                    InSu_FechaCreacion = DateTime.Now.AddDays(-2),
                    InSu_Estado = true,
                    Prod = new tbProductos { Prod_Descripcion = "Producto C", Prod_DescripcionCorta = "ProdC" },
                    Sucu = new tbSucursales { Sucu_Descripcion = "Sucursal Central" }
                }
            };
        }
    }
}
