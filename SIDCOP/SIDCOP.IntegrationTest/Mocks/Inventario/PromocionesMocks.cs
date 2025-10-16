using Api_SIDCOP.API.Models.General;
using Api_SIDCOP.API.Models.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Mocks.Inventario
{
    public class PromocionesMocks
    {
        public static PromocionViewModel CrearMockPromocion()
        {
            return new PromocionViewModel
            {

                Prod_Codigo = "PROM-00022",
                Prod_Descripcion = "Pet Master de Adulto + Pet Master de Cachorro",
                Prod_DescripcionCorta  = "Pet Master Adulto + Cachorro",
                Prod_Imagen            = "https://res.cloudinary.com/dbt7mxrwk/image/upload/v1755788301/bjkqcoa9g6jmmv5rnaz9.png",
                Impu_Id                = 4,
                Prod_PrecioUnitario    = 650,
                Prod_PagaImpuesto      = "S",
                Usua_Creacion          = 1,
                Prod_FechaCreacion     = DateTime.Now,
                productos = "[{\"id\":129,\"nombre\":\"PET MASTER CACHORRO \",\"cantidad\":1},{\"id\":128,\"nombre\":\"Pet Master Adulto\",\"cantidad\":1}]",
                clientes = "[{\"id\":1212,\"nombre\":\"La Bendición\"},{\"id\":1210,\"nombre\":\"Dos Hermanos\"},{\"id\":1208,\"nombre\":\"La Roca\"},{\"id\":1198,\"nombre\":\"Tortillería El Plantel\"},{\"id\":1195,\"nombre\":\"Pulpería El Buen Precio\"},{\"id\":1194,\"nombre\":\"Pulpería La Nueva\"},{\"id\":1192,\"nombre\":\"Pulpería Diego\"},{\"id\":1189,\"nombre\":\"Pulpería Las Niñas\"},{\"id\":1187,\"nombre\":\"Pulpería Franklin\"},{\"id\":1186,\"nombre\":\"Pulpería Lemus\"},{\"id\":1185,\"nombre\":\"Pulpería La Bendición\"},{\"id\":1183,\"nombre\":\"Carmencita\"},{\"id\":1172,\"nombre\":\"Carnicería El Buen Punto\"},{\"id\":1171,\"nombre\":\"Pulpería Aitza\"},{\"id\":1170,\"nombre\":\"Tortillería Daniel\"},{\"id\":1167,\"nombre\":\"Pulpería Gabriel\"},{\"id\":1165,\"nombre\":\"Pulpería Chito\"},{\"id\":1164,\"nombre\":\"Pulpería Monserrat\"},{\"id\":1163,\"nombre\":\"Pulpería Yanitza\"},{\"id\":1162,\"nombre\":\"Pulpería Renacer\"}]",
                productos_Json = new List<ProductoDetalleViewModel>
                    {
                        new ProductoDetalleViewModel { prod_Id = 129, prDe_Cantidad = 1 },
                        new ProductoDetalleViewModel { prod_Id = 128, prDe_Cantidad = 1 }
                    },


            };
        }

        public static PromocionViewModel CrearMockPromocionParaActualizar()
        {
            return new PromocionViewModel
            {
                Prod_Id = int.MaxValue,
                Prod_Codigo = "PROM-00022",
                Prod_Descripcion = "Pet Master de Adulto + Pet Master de Cachorro",
                Prod_DescripcionCorta = "Pet Master Adulto y Cachorro",
                Prod_Imagen = "https://res.cloudinary.com/dbt7mxrwk/image/upload/v1755788301/bjkqcoa9g6jmmv5rnaz9.png",
                Impu_Id = 4,
                Prod_PrecioUnitario = 650,
                Prod_PagaImpuesto = "S",
                Usua_Creacion = 1,
                Prod_FechaCreacion = DateTime.Now,
                productos = "[{\"id\":129,\"nombre\":\"PET MASTER CACHORRO \",\"cantidad\":1},{\"id\":128,\"nombre\":\"Pet Master Adulto\",\"cantidad\":1}]",
                clientes = "[{\"id\":1212,\"nombre\":\"La Bendición\"},{\"id\":1210,\"nombre\":\"Dos Hermanos\"},{\"id\":1208,\"nombre\":\"La Roca\"},{\"id\":1198,\"nombre\":\"Tortillería El Plantel\"},{\"id\":1195,\"nombre\":\"Pulpería El Buen Precio\"},{\"id\":1194,\"nombre\":\"Pulpería La Nueva\"},{\"id\":1192,\"nombre\":\"Pulpería Diego\"},{\"id\":1189,\"nombre\":\"Pulpería Las Niñas\"},{\"id\":1187,\"nombre\":\"Pulpería Franklin\"},{\"id\":1186,\"nombre\":\"Pulpería Lemus\"},{\"id\":1185,\"nombre\":\"Pulpería La Bendición\"},{\"id\":1183,\"nombre\":\"Carmencita\"},{\"id\":1172,\"nombre\":\"Carnicería El Buen Punto\"},{\"id\":1171,\"nombre\":\"Pulpería Aitza\"},{\"id\":1170,\"nombre\":\"Tortillería Daniel\"},{\"id\":1167,\"nombre\":\"Pulpería Gabriel\"},{\"id\":1165,\"nombre\":\"Pulpería Chito\"},{\"id\":1164,\"nombre\":\"Pulpería Monserrat\"},{\"id\":1163,\"nombre\":\"Pulpería Yanitza\"},{\"id\":1162,\"nombre\":\"Pulpería Renacer\"}]",
                productos_Json = new List<ProductoDetalleViewModel>
                    {
                        new ProductoDetalleViewModel { prod_Id = 129, prDe_Cantidad = 1 },
                        new ProductoDetalleViewModel { prod_Id = 128, prDe_Cantidad = 1 }
                    },
            };
        }

        public static PromocionViewModel CrearMockPromocionValoresExtremos()
        {
            return new PromocionViewModel
            {

                Prod_Codigo = new string('G', 255),
                Prod_Descripcion = new string('D', 255),
                Prod_DescripcionCorta = new string('C', 255),
                Prod_Imagen = new string('I', 255),
                Impu_Id = int.MaxValue,
                Prod_PrecioUnitario = decimal.MaxValue,
                Prod_PagaImpuesto = new string('B', 255),
                Usua_Creacion = int.MaxValue,
                Prod_FechaCreacion = DateTime.MaxValue,
                productos = "[{\"id\":129,\"nombre\":\"PET MASTER CACHORRO \",\"cantidad\":1},{\"id\":128,\"nombre\":\"Pet Master Adulto\",\"cantidad\":1}]",
                clientes = "[{\"id\":1212,\"nombre\":\"La Bendición\"},{\"id\":1210,\"nombre\":\"Dos Hermanos\"},{\"id\":1208,\"nombre\":\"La Roca\"},{\"id\":1198,\"nombre\":\"Tortillería El Plantel\"},{\"id\":1195,\"nombre\":\"Pulpería El Buen Precio\"},{\"id\":1194,\"nombre\":\"Pulpería La Nueva\"},{\"id\":1192,\"nombre\":\"Pulpería Diego\"},{\"id\":1189,\"nombre\":\"Pulpería Las Niñas\"},{\"id\":1187,\"nombre\":\"Pulpería Franklin\"},{\"id\":1186,\"nombre\":\"Pulpería Lemus\"},{\"id\":1185,\"nombre\":\"Pulpería La Bendición\"},{\"id\":1183,\"nombre\":\"Carmencita\"},{\"id\":1172,\"nombre\":\"Carnicería El Buen Punto\"},{\"id\":1171,\"nombre\":\"Pulpería Aitza\"},{\"id\":1170,\"nombre\":\"Tortillería Daniel\"},{\"id\":1167,\"nombre\":\"Pulpería Gabriel\"},{\"id\":1165,\"nombre\":\"Pulpería Chito\"},{\"id\":1164,\"nombre\":\"Pulpería Monserrat\"},{\"id\":1163,\"nombre\":\"Pulpería Yanitza\"},{\"id\":1162,\"nombre\":\"Pulpería Renacer\"}]",
                productos_Json = new List<ProductoDetalleViewModel>
                    {
                        new ProductoDetalleViewModel { prod_Id = 129, prDe_Cantidad = 1 },
                        new ProductoDetalleViewModel { prod_Id = 128, prDe_Cantidad = 1 }
                    },
            };
        }

        public static PromocionViewModel CrearMockPromocionInvalidos()
        {
            return new PromocionViewModel
            {

                Prod_Codigo = "",
                Prod_Descripcion = "",
                Prod_DescripcionCorta = "",
                Prod_Imagen = null,
                Impu_Id = -1,
                Prod_PrecioUnitario = -1,
                Prod_PagaImpuesto = "",
                Usua_Creacion = -1,
                Prod_FechaCreacion = DateTime.Now,
                productos = "[{\"id\":129,\"nombre\":\"PET MASTER CACHORRO \",\"cantidad\":1},{\"id\":128,\"nombre\":\"Pet Master Adulto\",\"cantidad\":1}]",
                clientes = "[{\"id\":1212,\"nombre\":\"La Bendición\"},{\"id\":1210,\"nombre\":\"Dos Hermanos\"},{\"id\":1208,\"nombre\":\"La Roca\"},{\"id\":1198,\"nombre\":\"Tortillería El Plantel\"},{\"id\":1195,\"nombre\":\"Pulpería El Buen Precio\"},{\"id\":1194,\"nombre\":\"Pulpería La Nueva\"},{\"id\":1192,\"nombre\":\"Pulpería Diego\"},{\"id\":1189,\"nombre\":\"Pulpería Las Niñas\"},{\"id\":1187,\"nombre\":\"Pulpería Franklin\"},{\"id\":1186,\"nombre\":\"Pulpería Lemus\"},{\"id\":1185,\"nombre\":\"Pulpería La Bendición\"},{\"id\":1183,\"nombre\":\"Carmencita\"},{\"id\":1172,\"nombre\":\"Carnicería El Buen Punto\"},{\"id\":1171,\"nombre\":\"Pulpería Aitza\"},{\"id\":1170,\"nombre\":\"Tortillería Daniel\"},{\"id\":1167,\"nombre\":\"Pulpería Gabriel\"},{\"id\":1165,\"nombre\":\"Pulpería Chito\"},{\"id\":1164,\"nombre\":\"Pulpería Monserrat\"},{\"id\":1163,\"nombre\":\"Pulpería Yanitza\"},{\"id\":1162,\"nombre\":\"Pulpería Renacer\"}]",
                productos_Json = new List<ProductoDetalleViewModel>
                    {
                        new ProductoDetalleViewModel { prod_Id = 129, prDe_Cantidad = 1 },
                        new ProductoDetalleViewModel { prod_Id = 128, prDe_Cantidad = 1 }
                    },


            };
        }




    }
}
