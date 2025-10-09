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
                Sucu_Id = 3,
                RegC_Id = 1,
                Vend_Id = 1,
                Mode_Id = 1,
                Bode_VIN = "1HGCM82633A123456",
                Bode_Placa = "HRK-5522",
                Bode_Capacidad = 200.50M,
                Bode_TipoCamion = "M",
                Usua_Creacion = 15,
                Bode_FechaCreacion = DateTime.Now
            };
        }

        public static BodegaViewModel MockBodegaActualizar()
        {
            return new BodegaViewModel
            {
                Bode_Id = 20,
                Bode_Descripcion = "Camión de La Lopez",
                Sucu_Id = 5,
                RegC_Id = 10,
                Vend_Id = 22,
                Mode_Id = 5,
                Bode_VIN = "1HGCM82633A123456",
                Bode_Placa = "HDP-2033",
                Bode_Capacidad = 100.55M,
                Bode_TipoCamion = "P",
                Usua_Creacion = 15,
                Bode_FechaCreacion = DateTime.Now,
                Usua_Modificacion = 30,
                Bode_FechaModificacion = DateTime.Now
            };
        }

        public static BodegaViewModel MockBodegaListar()
        {
            return new BodegaViewModel
            {
                Bode_Id = 20,
                Bode_Descripcion = "Camión de La Lopez",
                Sucu_Id = 5,
                RegC_Id = 10,
                Vend_Id = 22,
                Mode_Id = 5,
                Bode_VIN = "1HGCM82633A123456",
                Bode_Placa = "HDP-2033",
                Bode_Capacidad = 100.55M,
                Bode_TipoCamion = "P",
                Usua_Creacion = 15,
                Bode_FechaCreacion = DateTime.Now,
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
