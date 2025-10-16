using Api_SIDCOP.API.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Mocks.General
{
    public class ImagenesVisitaMocks
    {
        public static ImagenVisitaViewModel  ListarUsuariosMock()
        {
            return new ImagenVisitaViewModel
            {
                ImVi_Id = 74,
                ImVi_Imagen = "heuceda.jpg",
                ClVi_Id = 3,
                Usua_Creacion = 35,
                ImVi_FechaCreacion = DateTime.Now,
            };
        }
    }
}
