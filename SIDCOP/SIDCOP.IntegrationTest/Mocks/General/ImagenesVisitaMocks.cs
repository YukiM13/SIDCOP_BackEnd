using Api_SIDCOP.API.Models.General;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Mocks.General
{
    public class ImagenesVisitaMocks
    {
        // Constantes para IDs consistentes
        public const int ImagenId = 1210;
        public const string ImViImagenValido = "heuceda.jpg";
        public const int ClViId = 2320;

        public static ImagenVisitaViewModel  ListarImagenesVisitaMock()
        {
            return new ImagenVisitaViewModel
            {
                ImVi_Id = 1205,
                ImVi_Imagen = "heuceda.jpg",
                ClVi_Id = 2320,
                Usua_Creacion = 35,
                ImVi_FechaCreacion = DateTime.Now,
            };
        }

        // Mock para INSERTAR una visita
        public static ImagenVisitaViewModel InsertarImagenVisitaMock  ()
        {
            return new ImagenVisitaViewModel
            {
                ImVi_Imagen = ImViImagenValido,
                ClVi_Id = ClViId,
                Usua_Creacion = 1,
                ImVi_FechaCreacion = DateTime.Now
            };
        }
    }
}
