using Api_SIDCOP.API.Models.Logistica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Mocks.Logistica
{
    public class TrasladosMocks
    {
        public static TrasladoViewModel CrearMockTraslado()
        {
            return new TrasladoViewModel
            {
                Tras_Id = 0,
                Tras_Origen = 1,
                Origen = "Sucursal Rio De Piedra",
                Tras_Destino = 26,
                Destino = "Bodega #2",
                Tras_Fecha = DateTime.Now,
                Tras_Observaciones = "Traslado de prueba entre sucursales",
                Tras_EsRecarga = null,
                Reca_Id = null,
                Usua_Creacion = 1,
                UsuaCreacion = "Usuario Prueba",
                Tras_FechaCreacion = DateTime.Now,
                Usua_Modificacion = null,
                UsuaModificacion = null,
                Tras_FechaModificacion = null,
                Tras_Estado = true
            };
        }

        public static TrasladoDetalleViewModel CrearMockTrasladoDetalle()
        {
            return new TrasladoDetalleViewModel
            {
                Tras_Id = 1105,
                Prod_Id = 1,
                Prod_Descripcion = "Producto de Prueba",
                Prod_Imagen = "https://example.com/imagen.jpg",
                TrDe_Cantidad = 2,
                TrDe_Observaciones = "Detalle de traslado de prueba",
                Usua_Creacion = 1,
                TrDe_FechaCreacion = DateTime.Now,
                Usua_Modificacion = null,
                TrDe_FechaModificacion = null
            };
        }

        public static TrasladoDetalleViewModel ActualizarMockTrasladoDetalle()
        {
            return new TrasladoDetalleViewModel
            {
                TrDe_Id = 1178,
                Tras_Id = 1105,
                Prod_Id = 1,
                Prod_Descripcion = "Producto de Prueba Actualizado",
                Prod_Imagen = "https://example.com/imagen-actualizada.jpg",
                TrDe_Cantidad = 3,
                TrDe_Observaciones = "Detalle de traslado actualizado",
                Usua_Creacion = 1,
                TrDe_FechaCreacion = DateTime.Now.AddDays(-1),
                Usua_Modificacion = 1,
                TrDe_FechaModificacion = DateTime.Now
            };
        }

        public static int ObtenerIdTrasladoExistente()
        {
            return 1105;
        }

        public static int ObtenerIdTrasladoParaEliminar()
        {
            return 1105;
        }

        public static int ObtenerIdTrasladoConDetalles()
        {
            return 1105;
        }

        public static TrasladoViewModel CrearMockTrasladoMinimo()
        {
            return new TrasladoViewModel
            {
                Tras_Id = 0,
                Tras_Origen = 1,
                Origen = "Sucursal Rio De Piedra",
                Tras_Destino = 26,
                Destino = "Bodega #2",
                Tras_Fecha = DateTime.Now,
                Tras_Observaciones = "Prueba mínima",
                Tras_EsRecarga = null,
                Reca_Id = null,
                Usua_Creacion = 1,
                UsuaCreacion = "Usuario Prueba",
                Tras_FechaCreacion = DateTime.Now,
                Usua_Modificacion = null,
                UsuaModificacion = null,
                Tras_FechaModificacion = null,
                Tras_Estado = true
            };
        }

        public static TrasladoDetalleViewModel CrearMockDetalleMinimo()
        {
            return new TrasladoDetalleViewModel
            {
                Tras_Id = 1105,
                Prod_Id = 1,
                Prod_Descripcion = "Producto Mínimo",
                Prod_Imagen = "https://example.com/minimo.jpg",
                TrDe_Cantidad = 1,
                TrDe_Observaciones = "Prueba",
                Usua_Creacion = 1,
                TrDe_FechaCreacion = DateTime.Now,
                Usua_Modificacion = null,
                TrDe_FechaModificacion = null
            };
        }
    }
}

