using Api_SIDCOP.API.Models.Ventas;
using System;

namespace SIDCOP.IntegrationTest.Mocks.Ventas
{
    public static class DevolucionesMocks
    {
        public static DevolucionesViewModel CrearMockValidoParaInsertar()
        {
            return new DevolucionesViewModel
            {
                Fact_Id = 4727, // ID de factura válida
                Devo_Fecha = DateTime.Now,
                Devo_Motivo = "Producto defectuoso - devolución por garantía",
                Usua_Creacion = 1,
                Devo_FechaCreacion = DateTime.Now,
                Devo_Estado = true,
                Devo_EnSucursal = true, // Devolución procesada en sucursal
                Nombre_Completo = "Juan Carlos Pérez",
                Clie_NombreNegocio = "Distribuidora El Sol S.A.",
                UsuarioCreacion = "admin",
                devoDetalle_XML = @"<DevolucionDetalle>
                    <Producto>
                        <Prod_Id>1</Prod_Id>
                        <DevD_Cantidad>2</DevD_Cantidad>
                    </Producto>
                    <Producto>
                        <Prod_Id>2</Prod_Id>
                        <DevD_Cantidad>1</DevD_Cantidad>
                    </Producto>
                </DevolucionDetalle>"
            };
        }

        public static DevolucionesViewModel CrearMockValidoParaActualizar()
        {
            return new DevolucionesViewModel
            {
                Devo_Id = 1, // ID para actualización/traslado
                Fact_Id = 2,
                Devo_Fecha = DateTime.Now.AddDays(-1),
                Devo_Motivo = "Traslado de devolución a bodega central",
                Usua_Creacion = 1,
                Devo_FechaCreacion = DateTime.Now.AddDays(-1),
                Usua_Modificacion = 1,
                Devo_FechaModificacion = DateTime.Now,
                Devo_Estado = true,
                Devo_EnSucursal = false, // Trasladada a bodega
                Nombre_Completo = "María Elena González",
                Clie_NombreNegocio = "Comercial La Luna Ltda.",
                UsuarioCreacion = "admin",
                UsuarioModificacion = "supervisor",
                devoDetalle_XML = @"<DevolucionDetalle>
                    <Producto>
                        <Prod_Id>3</Prod_Id>
                        <DevD_Cantidad>5</DevD_Cantidad>
                    </Producto>
                    <Producto>
                        <Prod_Id>4</Prod_Id>
                        <DevD_Cantidad>3</DevD_Cantidad>
                    </Producto>
                </DevolucionDetalle>"
            };
        }

        public static DevolucionesViewModel CrearMockConValoresExtremos()
        {
            return new DevolucionesViewModel
            {
                Devo_Id = int.MaxValue,
                Fact_Id = int.MaxValue,
                Devo_Fecha = DateTime.MaxValue,
                Devo_Motivo = new string('A', 2000), // Motivo extremadamente largo
                Usua_Creacion = int.MaxValue,
                Devo_FechaCreacion = DateTime.MinValue,
                Usua_Modificacion = int.MaxValue,
                Devo_FechaModificacion = DateTime.MaxValue,
                Devo_Estado = true,
                Devo_EnSucursal = true,
                Nombre_Completo = new string('B', 1000), // Nombre muy largo
                Clie_NombreNegocio = new string('C', 1000), // Nombre de negocio muy largo
                UsuarioCreacion = new string('D', 500),
                UsuarioModificacion = new string('E', 500),
                devoDetalle_XML = new string('F', 10000) // XML extremadamente largo
            };
        }

        public static DevolucionesViewModel CrearMockConDatosInvalidos()
        {
            return new DevolucionesViewModel
            {
                Devo_Id = -1, // ID negativo
                Fact_Id = -999, // Factura inexistente
                Devo_Fecha = DateTime.Now.AddYears(10), // Fecha futura inválida
                Devo_Motivo = "", // Motivo vacío
                Usua_Creacion = -1, // Usuario inválido
                Devo_FechaCreacion = DateTime.MinValue, // Fecha mínima
                Usua_Modificacion = 0, // Usuario cero
                Devo_FechaModificacion = DateTime.Now.AddYears(-100), // Fecha muy antigua
                Devo_Estado = false, // Estado inactivo
                Devo_EnSucursal = true,
                Nombre_Completo = null, // Campo nulo
                Clie_NombreNegocio = "", // Campo vacío
                UsuarioCreacion = null,
                UsuarioModificacion = "",
                devoDetalle_XML = "<XML_MALFORMADO><Producto><Prod_Id>INVALID</Prod_Id></XML_MALFORMADO>" // XML inválido
            };
        }

        public static DevolucionesViewModel CrearMockParaTrasladoEspecifico()
        {
            return new DevolucionesViewModel
            {
                Devo_Id = 5,
                Fact_Id = 10,
                Devo_Fecha = DateTime.Now.AddDays(-3),
                Devo_Motivo = "Traslado urgente por reorganización de inventario",
                Usua_Creacion = 2,
                Devo_FechaCreacion = DateTime.Now.AddDays(-3),
                Usua_Modificacion = 3,
                Devo_FechaModificacion = DateTime.Now,
                Devo_Estado = true,
                Devo_EnSucursal = false, // Ya no está en sucursal
                Nombre_Completo = "Roberto Martínez Silva",
                Clie_NombreNegocio = "Importadora Norte S.A.C.",
                UsuarioCreacion = "operador1",
                UsuarioModificacion = "supervisor2",
                devoDetalle_XML = @"<DevolucionDetalle>
                    <Producto>
                        <Prod_Id>10</Prod_Id>
                        <DevD_Cantidad>15</DevD_Cantidad>
                    </Producto>
                    <Producto>
                        <Prod_Id>11</Prod_Id>
                        <DevD_Cantidad>8</DevD_Cantidad>
                    </Producto>
                </DevolucionDetalle>"
            };
        }
    }
}
