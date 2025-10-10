using Api_SIDCOP.API.Models.Ventas;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.SqlServer.Management.Smo;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Mocks.Ventas
{
    public class PedidosMocks
    {
        


        public static PedidosViewModel CrearPedidoMock() 
        {
           var infoDetalles = new List<PedidoDetalleDTO>
            { 
                new PedidoDetalleDTO
                {
                    Prod_Id = 1,
                    PeDe_Cantidad = 2,
                    PeDe_ProdPrecio = 100.00m,
                    PeDe_Impuesto = 0.15m,
                    PeDe_Descuento = 5.00m,
                    PeDe_Subtotal = 210.00m,
                    PeDe_ProdPrecioFinal = 110.00m
                },
            };


            return new PedidosViewModel
            {
                DiCl_Id = 1,
                Vend_Id = 1,
                Pedi_Codigo = "PED-001",
                Pedi_FechaPedido = DateTime.Now,
                Pedi_FechaEntrega = DateTime.Now.AddDays(7),
                Usua_Creacion = 1,
                Pedi_FechaCreacion = DateTime.Now,
                Detalles = infoDetalles
            };

        }

        public static PedidosViewModel ActualizarPedidoMock()
        {
            var infoDetalles = new List<PedidoDetalleDTO>
            {
                new PedidoDetalleDTO
                {
                    Prod_Id = 1,
                    PeDe_Cantidad = 2,
                    PeDe_ProdPrecio = 100.00m,
                    PeDe_Impuesto = 0.15m,
                    PeDe_Descuento = 5.00m,
                    PeDe_Subtotal = 210.00m,
                    PeDe_ProdPrecioFinal = 110.00m
                },
            };


            return new PedidosViewModel
            {
                Pedi_Id = 1,
                DiCl_Id = 1,
                Vend_Id = 1,
                Pedi_Codigo = "PED-001",
                Pedi_FechaPedido = DateTime.Now,
                Pedi_FechaEntrega = DateTime.Now.AddDays(7),
                Usua_Modificacion = 1,
                Pedi_FechaModificacion = DateTime.Now,
                Detalles = infoDetalles
            };

        }

        public static int EliminarPedido()
        {
            return 1; 
        }


        public static PedidosViewModel CrearPedidosMockValoresInvalidos()
        {
            return new PedidosViewModel
            {
                DiCl_Id = -1,
                Vend_Id = -1,

                Pedi_Codigo = "PED-001",
                Pedi_FechaPedido = DateTime.Now.AddYears(10),
                Pedi_FechaEntrega = DateTime.Now.AddDays(7),
                Usua_Creacion = -1,
                Pedi_FechaCreacion = DateTime.Now,
                Detalles = new List<PedidoDetalleDTO>()  
            };
        }

        public static PedidosViewModel ActualizarPedidoMockValoresInvalidos()
        {
            var infoDetalles = new List<PedidoDetalleDTO>
            {
               new PedidoDetalleDTO
                {
                    Prod_Id = 0,
                    PeDe_Cantidad = -1,
                    PeDe_ProdPrecio = -10.0m,
                    PeDe_Impuesto = -0.5m,
                    PeDe_Descuento = -5.0m,
                    PeDe_Subtotal = -100.0m,
                    PeDe_ProdPrecioFinal = -50.0m,
                    Prod_Imagen = ""
                }

            };


            return new PedidosViewModel
            {
                Pedi_Id = -1,
                DiCl_Id = -1,
                Vend_Id = -1,
                Pedi_Codigo = "",
                Pedi_FechaPedido = DateTime.MinValue,
                Pedi_FechaEntrega = DateTime.MaxValue,
                Usua_Modificacion = -1,
                Pedi_FechaModificacion = DateTime.MinValue,
                Pedi_Estado = false,
          
                Detalles = infoDetalles,

            };

        }

        public static int EliminarPedidoValoresInvalidos()
        {
            return -1;
        }

    }
}
