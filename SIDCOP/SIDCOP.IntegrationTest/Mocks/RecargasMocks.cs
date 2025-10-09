using Api_SIDCOP.API.Models.Logistica;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Mocks
{
    class RecargasMocks
    {

        public static RecargasViewModel CrearMockRecargas()
        {
            return new RecargasViewModel
            {

                Bode_Id = 1,
                Vend_Id = 1,
                Reca_Fecha = DateTime.Now,
                Reca_Observaciones = "Recarga de prueba",
                Usua_Creacion = 1,
                Reca_FechaCreacion = DateTime.Now,
                Detalles = new List<RecargaDetalleDTO>
        {
            new RecargaDetalleDTO
            {
                Prod_Id = 100, // Usa un ID de producto válido en tu base de datos de pruebas
                ReDe_Cantidad = 5,
                ReDe_Observaciones = "Detalle de prueba"
            }
        }

            };
        }

        public static RecargasViewModel ActualizarMockRecargas()
        {
            return new RecargasViewModel
            {
                Reca_Id = 1,
                Bode_Id = 1,
                Vend_Id = 1,
                Reca_Fecha = DateTime.Now,
                Reca_Observaciones = "Recarga de prueba",
                Usua_Creacion = 1,
                Reca_FechaCreacion = DateTime.Now,
                Detalles = new List<RecargaDetalleDTO>
        {
            new RecargaDetalleDTO
            {
                Prod_Id = 100, // Usa un ID de producto válido en tu base de datos de pruebas
                ReDe_Cantidad = 5,
                ReDe_Observaciones = "Detalle de prueba"
            }
        }

            };
        }



    }
}
