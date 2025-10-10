using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;

namespace SIDCOP.IntegrationTest.Mocks.Ventas
{
    public class FacturasMocks
    {
        /// <summary>
        /// Crea un mock válido para insertar una factura
        /// </summary>
        public static VentaInsertarDTO CrearMockFacturaInsertar()
        {
            return new VentaInsertarDTO
            {
                Fact_Numero = "FAC-001-001-000TESTT",
                Fact_TipoDeDocumento = "01",
                RegC_Id = 21,
                DiCl_Id = 1150,
                Vend_Id = 11,
                Fact_TipoVenta = "CONTADO",
                Fact_FechaEmision = DateTime.Now,
                Fact_Latitud = 14.0723m,
                Fact_Longitud = -87.1921m,
                Fact_Referencia = "Venta de prueba integración",
                Fact_AutorizadoPor = "Sistema Test",
                Usua_Creacion = 1,
                Fact_EsPedido = false,
                Pedi_Id = 0,
                DetallesFacturaInput = new List<VentaDetalleDTO>
                {
                    new VentaDetalleDTO
                    {
                        Prod_Id = 149,
                        FaDe_Cantidad = 5
                    },
                    new VentaDetalleDTO
                    {
                        Prod_Id = 126,
                        FaDe_Cantidad = 3
                    }
                }
            };
        }

        /// <summary>
        /// Crea un mock válido para insertar una factura en sucursal
        /// </summary>
        public static VentaInsertarDTO CrearMockFacturaInsertarEnSucursal()
        {
            return new VentaInsertarDTO
            {
                // No se envía Fact_Numero porque lo genera el SP
                Fact_TipoDeDocumento = "1",
                RegC_Id = 1,
                DiCl_Id = 1,
                Vend_Id = 1,
                Fact_TipoVenta = "CREDITO",
                Fact_FechaEmision = DateTime.Now,
                Fact_Latitud = 14.0823m,
                Fact_Longitud = -87.2021m,
                Fact_Referencia = "Venta sucursal prueba",
                Fact_AutorizadoPor = "Gerente Sucursal",
                Usua_Creacion = 1,
                DetallesFacturaInput = new List<VentaDetalleDTO>
                {
                    new VentaDetalleDTO
                    {
                        Prod_Id = 1,
                        FaDe_Cantidad = 10
                    },
                    new VentaDetalleDTO
                    {
                        Prod_Id = 3,
                        FaDe_Cantidad = 2
                    }
                }
            };
        }

        /// <summary>
        /// Crea un mock para validar una factura antes de insertarla
        /// </summary>
        public static VentaInsertarDTO CrearMockFacturaParaValidar()
        {
            return new VentaInsertarDTO
            {
                Fact_Numero = "FAC-001-001-00000002",
                Fact_TipoDeDocumento = "1",
                RegC_Id = 1,
                DiCl_Id = 1,
                Vend_Id = 1,
                Fact_TipoVenta = "CONTADO",
                Fact_FechaEmision = DateTime.Now,
                Fact_Latitud = 14.0723m,
                Fact_Longitud = -87.1921m,
                Fact_Referencia = "Validación de venta",
                Usua_Creacion = 1,
                Fact_EsPedido = false,
                Pedi_Id = 0,
                DetallesFacturaInput = new List<VentaDetalleDTO>
                {
                    new VentaDetalleDTO
                    {
                        Prod_Id = 1,
                        FaDe_Cantidad = 1
                    }
                }
            };
        }

        /// <summary>
        /// Crea un mock con datos inválidos para probar el manejo de errores
        /// </summary>
        public static VentaInsertarDTO CrearMockFacturaInvalida()
        {
            return new VentaInsertarDTO
            {
                Fact_Numero = "FAC-INVALID",
                Fact_TipoDeDocumento = "1",
                RegC_Id = -1, // ID inválido
                DiCl_Id = -999, // ID inválido
                Vend_Id = -1, // ID inválido
                Fact_TipoVenta = "INVALIDO", // Tipo inválido
                Fact_FechaEmision = DateTime.Now.AddYears(10), // Fecha futura
                Fact_Latitud = 200m, // Latitud inválida (fuera de rango -90 a 90)
                Fact_Longitud = 300m, // Longitud inválida (fuera de rango -180 a 180)
                Usua_Creacion = -1,
                DetallesFacturaInput = new List<VentaDetalleDTO>
                {
                    new VentaDetalleDTO
                    {
                        Prod_Id = -1, // ID inválido
                        FaDe_Cantidad = -5 // Cantidad negativa
                    }
                }
            };
        }

        /// <summary>
        /// Crea un mock con valores extremos para probar límites del sistema
        /// </summary>
        public static VentaInsertarDTO CrearMockFacturaValoresExtremos()
        {
            return new VentaInsertarDTO
            {
                Fact_Numero = "FAC-999-999-99999999",
                Fact_TipoDeDocumento = "1",
                RegC_Id = int.MaxValue, // ID extremo
                DiCl_Id = 0, // ID cero que podría no existir
                Vend_Id = 99999, // ID inexistente
                Fact_TipoVenta = "CONTADO",
                Fact_FechaEmision = DateTime.MinValue, // Fecha mínima
                Fact_Latitud = 90m, // Latitud máxima válida
                Fact_Longitud = 180m, // Longitud máxima válida
                Fact_Referencia = new string('X', 500), // Referencia muy larga
                Usua_Creacion = 99999,
                DetallesFacturaInput = new List<VentaDetalleDTO>
                {
                    new VentaDetalleDTO
                    {
                        Prod_Id = int.MaxValue,
                        FaDe_Cantidad = int.MaxValue
                    }
                }
            };
        }

        /// <summary>
        /// Crea un mock sin detalles para probar validación
        /// </summary>
        public static VentaInsertarDTO CrearMockFacturaSinDetalles()
        {
            return new VentaInsertarDTO
            {
                Fact_Numero = "FAC-001-001-00000003",
                Fact_TipoDeDocumento = "1",
                RegC_Id = 1,
                DiCl_Id = 1,
                Vend_Id = 1,
                Fact_TipoVenta = "CONTADO",
                Fact_FechaEmision = DateTime.Now,
                Fact_Latitud = 14.0723m,
                Fact_Longitud = -87.1921m,
                Usua_Creacion = 1,
                DetallesFacturaInput = new List<VentaDetalleDTO>() // Lista vacía
            };
        }
    }
}
