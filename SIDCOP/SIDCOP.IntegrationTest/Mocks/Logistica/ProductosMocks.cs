using Api_SIDCOP.API.Models.Inventario;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;

namespace SIDCOP.IntegrationTest.Mocks.Logistica
{
    public static class ProductosMocks
    {
        public static ProductosViewModel CrearMockProducto()
        {
            return new ProductosViewModel
            {
                Prod_Id = 1,
                Secuencia = 1,
                Prod_Codigo = "PROD001",
                Prod_CodigoBarra = "1234567890123",
                Prod_Descripcion = "Producto de Prueba",
                Prod_DescripcionCorta = "Prod Test",
                Prod_Imagen = "imagen.jpg",
                Prod_Peso = 1.5m,
                UnPe_Id = 1,
                Cate_Id = 1,
                Cate_Descripcion = "Categoría 1",
                Subc_Id = 1,
                Subc_Descripcion = "Subcategoría 1",
                Marc_Id = 1,
                Marc_Descripcion = "Marca 1",
                Prov_Id = 1,
                Prov_NombreEmpresa = "Proveedor 1",
                Impu_Id = 1,
                Impu_Descripcion = "IVA",
                Prod_PrecioUnitario = 100.50m,
                Prod_PagaImpuesto = "S",
                Prod_EsPromo = "N",
                Prod_Impulsado = false,
                Prod_Estado = true,
                Usua_Creacion = 1,
                UsuarioCreacion = "Usuario Prueba",
                Prod_FechaCreacion = DateTime.Now,
                Usua_Modificacion = null,
                Prod_FechaModificacion = null,
                UsuarioModificacion = null,
                ListasPrecio_JSON = null,
                DescuentosEscala_JSON = null,
                Desc_EspecificacionesJSON = null,
                InfoPromocion_JSON = null,
                Impu_Valor = 15.0
            };
        }

        public static List<ProductosViewModel> CrearMockListaProductos()
        {
            return new List<ProductosViewModel>
            {
                new()
                {
                    Prod_Id = 1,
                    Secuencia = 1,
                    Prod_Codigo = "P001",
                    Prod_Descripcion = "Producto 1",
                    Prod_DescripcionCorta = "Prod 1",
                    UnPe_Id = 1,
                    Cate_Id = 1,
                    Cate_Descripcion = "Categoría 1",
                    Subc_Id = 1,
                    Subc_Descripcion = "Subcategoría 1",
                    Marc_Id = 1,
                    Marc_Descripcion = "Marca 1",
                    Prov_Id = 1,
                    Prov_NombreEmpresa = "Proveedor 1",
                    Impu_Id = 1,
                    Impu_Descripcion = "IVA",
                    Prod_PrecioUnitario = 100.50m,
                    Prod_PagaImpuesto = "S",
                    Prod_EsPromo = "N",
                    Prod_Impulsado = false,
                    Prod_Estado = true,
                    Usua_Creacion = 1,
                    UsuarioCreacion = "Usuario Prueba",
                    Prod_FechaCreacion = DateTime.Now.AddDays(-10),
                    Impu_Valor = 15.0
                },
                new()
                {
                    Prod_Id = 2,
                    Secuencia = 2,
                    Prod_Codigo = "P002",
                    Prod_Descripcion = "Producto 2",
                    Prod_DescripcionCorta = "Prod 2",
                    UnPe_Id = 1,
                    Cate_Id = 1,
                    Cate_Descripcion = "Categoría 1",
                    Subc_Id = 2,
                    Subc_Descripcion = "Subcategoría 2",
                    Marc_Id = 2,
                    Marc_Descripcion = "Marca 2",
                    Prov_Id = 2,
                    Prov_NombreEmpresa = "Proveedor 2",
                    Impu_Id = 1,
                    Impu_Descripcion = "IVA",
                    Prod_PrecioUnitario = 200.75m,
                    Prod_PagaImpuesto = "S",
                    Prod_EsPromo = "N",
                    Prod_Impulsado = true,
                    Prod_Estado = true,
                    Usua_Creacion = 1,
                    UsuarioCreacion = "Usuario Prueba",
                    Prod_FechaCreacion = DateTime.Now.AddDays(-5),
                    Impu_Valor = 15.0
                },
                new()
                {
                    Prod_Id = 3,
                    Secuencia = 3,
                    Prod_Codigo = "P003",
                    Prod_Descripcion = "Producto 3",
                    Prod_DescripcionCorta = "Prod 3",
                    UnPe_Id = 2,
                    Cate_Id = 2,
                    Cate_Descripcion = "Categoría 2",
                    Subc_Id = 3,
                    Subc_Descripcion = "Subcategoría 3",
                    Marc_Id = 3,
                    Marc_Descripcion = "Marca 3",
                    Prov_Id = 3,
                    Prov_NombreEmpresa = "Proveedor 3",
                    Impu_Id = 1,
                    Impu_Descripcion = "IVA",
                    Prod_PrecioUnitario = 150.25m,
                    Prod_PagaImpuesto = "S",
                    Prod_EsPromo = "S",
                    Prod_Impulsado = false,
                    Prod_Estado = true,
                    Usua_Creacion = 1,
                    UsuarioCreacion = "Usuario Prueba",
                    Prod_FechaCreacion = DateTime.Now.AddDays(-2),
                    Impu_Valor = 15.0
                }
            };
        }

        public static ProductosViewModel CrearMockProductoInvalido()
        {
            return new ProductosViewModel
            {
                Prod_Id = -1,
                Secuencia = -1,
                Prod_Codigo = "",
                Prod_CodigoBarra = "",
                Prod_Descripcion = "",
                Prod_DescripcionCorta = "",
                Prod_Imagen = "",
                Prod_Peso = -1,
                UnPe_Id = -1,
                Cate_Id = -1,
                Cate_Descripcion = "",
                Subc_Id = -1,
                Subc_Descripcion = "",
                Marc_Id = -1,
                Marc_Descripcion = "",
                Prov_Id = -1,
                Prov_NombreEmpresa = "",
                Impu_Id = -1,
                Impu_Descripcion = "",
                Prod_PrecioUnitario = -100,
                Prod_PagaImpuesto = "",
                Prod_EsPromo = "",
                Prod_Impulsado = false,
                Prod_Estado = false,
                Usua_Creacion = -1,
                UsuarioCreacion = "",
                Prod_FechaCreacion = DateTime.Now.AddYears(5),
                Usua_Modificacion = -1,
                UsuarioModificacion = "",
                ListasPrecio_JSON = "",
                DescuentosEscala_JSON = "",
                Desc_EspecificacionesJSON = "",
                InfoPromocion_JSON = "",
                Impu_Valor = -1
            };
        }

        public static ProductosViewModel CrearMockProductoValoresExtremos()
        {
            return new ProductosViewModel
            {
                Prod_Id = int.MaxValue,
                Secuencia = int.MaxValue,
                Prod_Codigo = new string('X', 50),
                Prod_CodigoBarra = new string('1', 20),
                Prod_Descripcion = new string('D', 500),
                Prod_DescripcionCorta = new string('d', 100),
                Prod_Imagen = new string('i', 255),
                Prod_Peso = decimal.MaxValue,
                UnPe_Id = int.MaxValue,
                Cate_Id = int.MaxValue,
                Cate_Descripcion = new string('C', 100),
                Subc_Id = int.MaxValue,
                Subc_Descripcion = new string('S', 100),
                Marc_Id = int.MaxValue,
                Marc_Descripcion = new string('M', 100),
                Prov_Id = int.MaxValue,
                Prov_NombreEmpresa = new string('P', 100),
                Impu_Id = int.MaxValue,
                Impu_Descripcion = new string('I', 100),
                Prod_PrecioUnitario = decimal.MaxValue,
                Prod_PagaImpuesto = "S",
                Prod_EsPromo = "S",
                Prod_Impulsado = true,
                Prod_Estado = true,
                Usua_Creacion = int.MaxValue,
                UsuarioCreacion = new string('U', 100),
                Prod_FechaCreacion = DateTime.MinValue,
                Usua_Modificacion = int.MaxValue,
                UsuarioModificacion = new string('U', 100),
                ListasPrecio_JSON = new string('J', 4000),
                DescuentosEscala_JSON = new string('D', 4000),
                Desc_EspecificacionesJSON = new string('E', 4000),
                InfoPromocion_JSON = new string('I', 4000),
                Impu_Valor = double.MaxValue
            };
        }


        }
    }

