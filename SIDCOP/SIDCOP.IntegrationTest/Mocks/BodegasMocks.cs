using Api_SIDCOP.API.Models.Logistica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Mocks
{
    public class BodegasMocks
    {
        public static BodegaViewModel MockBodegaInsertar()
        {
            return new BodegaViewModel
            {
                Bode_Descripcion = "Camión de La Lima",
                Sucu_Id = 1,
                RegC_Id = 19,
                Vend_Id = 2,
                Mode_Id = 29,
                Bode_VIN = "1HGCM82633A123456",
                Bode_Placa = "HRK-5522",
                Bode_Capacidad = 200.50M,
                Bode_TipoCamion = "M",
                Usua_Creacion = 24,
                Bode_FechaCreacion = DateTime.Now
            };
        }

        public static BodegaViewModel MockBodegaActualizar()
        {
            return new BodegaViewModel
            {
                Bode_Id = 47,
                Bode_Descripcion = "Camión de La Lopez",
                Sucu_Id = 2,
                RegC_Id = 19,
                Vend_Id = 2,
                Mode_Id = 25,
                Bode_VIN = "1HGCM82633A123456",
                Bode_Placa = "HDP-2033",
                Bode_Capacidad = 100.55M,
                Bode_TipoCamion = "P",
                Usua_Modificacion = 30,
                Bode_FechaModificacion = DateTime.Now
            };
        }

        public static BodegaViewModel MockBodegaEliminar()
        {
            return new BodegaViewModel
            {
                Bode_Id = 5
            };
        }

        public static BodegaViewModel MockBodegaDetalle()
        {
            return new BodegaViewModel
            {
                Bode_Id = 3
            };
        }
    }
}
