using Api_SIDCOP.API.Models.General;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Mocks.General
{
    public class VisitasClienteMocks
    {
        // Constantes para IDs consistentes
        public const int VendId = 9;
        public const int VeRuIdValido = 20;
        public const int ClieId = 4459;
        public const int DiClIdValido = 4242;
        public const int EsViIdValido = 3;

        // Fecha fija para las pruebas
        private static readonly DateTime FechaVisita = new DateTime(2025, 10, 7);

        // Mock para INSERTAR una visita
        public static VisitaClientePorVendedorDTO ObtenerVisitaValida()
        {
            return new VisitaClientePorVendedorDTO
            {
                VeRu_Id = VeRuIdValido,
                DiCl_Id = DiClIdValido,
                EsVi_Id = EsViIdValido,
                ClVi_Observaciones = "Visita de prueba",
                ClVi_Fecha = DateTime.Now,
                Usua_Creacion = 1,
                ClVi_FechaCreacion = DateTime.Now
            };
        }

        // Mock con fecha personalizada
        //public static ClientesVisitaHistorialViewModel CrearMockVisitaConFecha(DateTime fecha)
        //{
        //    var mock = CrearMockVisitaInsertar();
        //    mock.ClVi_Fecha = fecha;
        //    return mock;
        //}

        //// Mock para diferentes estados de visita
        //public static ClientesVisitaHistorialViewModel CrearMockVisitaPorEstado(int estadoId, string observacion)
        //{
        //    var mock = CrearMockVisitaInsertar();
        //    mock.EsVi_Id = estadoId;
        //    mock.ClVi_Observaciones = observacion;
        //    return mock;
        //}
    }
}
