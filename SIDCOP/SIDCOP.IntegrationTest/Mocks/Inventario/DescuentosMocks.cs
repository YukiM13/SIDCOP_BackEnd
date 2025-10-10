using Api_SIDCOP.API.Models.Inventario;
using System;
using System.Collections.Generic;

namespace SIDCOP.IntegrationTest.Mocks.Inventario
{
    public static class DescuentosMocks
    {
        public static DescuentoViewModel CrearMockValidoParaInsertar()
        {
            return new DescuentoViewModel
            {
                Desc_Descripcion = "Descuento por volumen Q1 2025",
                Desc_Tipo = true, // Tipo porcentaje
                Desc_Aplicar = "PRODUCTO",
                Desc_FechaInicio = new DateTime(2025, 1, 1),
                Desc_FechaFin = new DateTime(2025, 12, 31),
                Desc_Observaciones = "Descuento aplicable a compras mayores a 100 unidades",
                Usua_Creacion = 1,
                Desc_FechaCreacion = DateTime.Now,
                Desc_Estado = true,
                Desc_TipoFactura = "CONTADO",
                clientes = "<Clientes><Cliente><Id>1</Id></Cliente></Clientes>",
                referencias = "<Referencias><Referencia><Id>1</Id></Referencia></Referencias>",
                IdClientes = new List<int> { 1, 2 },
                IdReferencias = new List<int> { 1 },
                Secuencia = 1,
                UsuarioCreacion = "admin",
                escalas_Json = new List<EscalaDetalleViewModel>
                {
                    new EscalaDetalleViewModel
                    {
                        deEs_InicioEscala = 1,
                        deEs_FinEscala = 50,
                        deEs_Valor = 5.0m
                    },
                    new EscalaDetalleViewModel
                    {
                        deEs_InicioEscala = 51,
                        deEs_FinEscala = 100,
                        deEs_Valor = 10.0m
                    }
                }
            };
        }

        public static DescuentoViewModel CrearMockValidoParaActualizar()
        {
            return new DescuentoViewModel
            {
                Desc_Id = 1, // ID para actualización
                Desc_Descripcion = "Descuento por volumen Q1 2025 - Actualizado",
                Desc_Tipo = true,
                Desc_Aplicar = "PRODUCTO",
                Desc_FechaInicio = new DateTime(2025, 1, 1),
                Desc_FechaFin = new DateTime(2025, 12, 31),
                Desc_Observaciones = "Descuento actualizado - aplicable a compras mayores a 80 unidades",
                Usua_Creacion = 1,
                Desc_FechaCreacion = DateTime.Now.AddDays(-30),
                Usua_Modificacion = 1,
                Desc_FechaModificacion = DateTime.Now,
                Desc_Estado = true,
                Desc_TipoFactura = "CREDITO",
                clientes = "<Clientes><Cliente><Id>1</Id><Id>2</Id></Cliente></Clientes>",
                referencias = "<Referencias><Referencia><Id>1</Id><Id>2</Id></Referencia></Referencias>",
                IdClientes = new List<int> { 1, 2, 3 },
                IdReferencias = new List<int> { 1, 2 },
                Secuencia = 1,
                UsuarioCreacion = "admin",
                UsuarioModificacion = "admin",
                escalas_Json = new List<EscalaDetalleViewModel>
                {
                    new EscalaDetalleViewModel
                    {
                        deEs_InicioEscala = 1,
                        deEs_FinEscala = 80,
                        deEs_Valor = 7.5m
                    },
                    new EscalaDetalleViewModel
                    {
                        deEs_InicioEscala = 81,
                        deEs_FinEscala = 150,
                        deEs_Valor = 12.5m
                    }
                }
            };
        }

        public static DescuentoViewModel CrearMockConValoresExtremos()
        {
            return new DescuentoViewModel
            {
                Desc_Id = int.MaxValue,
                Desc_Descripcion = new string('A', 1000), // Descripción muy larga
                Desc_Tipo = true,
                Desc_Aplicar = "EXTREMO",
                Desc_FechaInicio = DateTime.MinValue,
                Desc_FechaFin = DateTime.MaxValue,
                Desc_Observaciones = new string('B', 2000), // Observaciones muy largas
                Usua_Creacion = int.MaxValue,
                Desc_FechaCreacion = DateTime.MinValue,
                Usua_Modificacion = int.MaxValue,
                Desc_FechaModificacion = DateTime.MaxValue,
                Desc_Estado = true,
                Desc_TipoFactura = new string('C', 100),
                clientes = new string('D', 5000), // XML muy largo
                referencias = new string('E', 5000),
                IdClientes = new List<int> { int.MaxValue, int.MinValue },
                IdReferencias = new List<int> { int.MaxValue },
                Secuencia = int.MaxValue,
                UsuarioCreacion = new string('F', 500),
                UsuarioModificacion = new string('G', 500),
                escalas_Json = new List<EscalaDetalleViewModel>
                {
                    new EscalaDetalleViewModel
                    {
                        deEs_InicioEscala = int.MaxValue,
                        deEs_FinEscala = int.MaxValue,
                        deEs_Valor = decimal.MaxValue
                    }
                }
            };
        }

        public static DescuentoViewModel CrearMockConDatosInvalidos()
        {
            return new DescuentoViewModel
            {
                Desc_Id = -1, // ID negativo
                Desc_Descripcion = "", // Descripción vacía
                Desc_Tipo = false,
                Desc_Aplicar = "", // Campo vacío
                Desc_FechaInicio = new DateTime(2025, 12, 31), // Fecha inicio posterior a fin
                Desc_FechaFin = new DateTime(2025, 1, 1),
                Desc_Observaciones = null, // Campo nulo
                Usua_Creacion = -1, // Usuario inválido
                Desc_FechaCreacion = DateTime.Now.AddYears(10), // Fecha futura
                Usua_Modificacion = -999,
                Desc_FechaModificacion = DateTime.MinValue,
                Desc_Estado = false, // Estado inactivo
                Desc_TipoFactura = null,
                clientes = "<XML_MALFORMADO>", // XML inválido
                referencias = "<Referencias><Referencia><Id>INVALID</Id></Referencia>",
                IdClientes = new List<int> { -1, -999 }, // IDs negativos
                IdReferencias = new List<int> { 0 }, // ID cero
                Secuencia = -1,
                UsuarioCreacion = null,
                UsuarioModificacion = "",
                escalas_Json = new List<EscalaDetalleViewModel>
                {
                    new EscalaDetalleViewModel
                    {
                        deEs_InicioEscala = -1, // Valores negativos
                        deEs_FinEscala = -10,
                        deEs_Valor = -5.0m // Descuento negativo
                    }
                }
            };
        }
    }
}
