using Api_SIDCOP.API.Models.Acceso;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Mocks
{
    public class PermisosMocks
    {
        public static PermisoViewModel CrearMockPermisoInsertar()
        {
            return new PermisoViewModel
            {
                Role_Id = 124,
                AcPa_Id = 1,
                Usua_Creacion = 1,
                Perm_FechaCreacion = DateTime.Now,
            };
        }

        public static PermisoViewModel CrearMockPermisoActualizar()
        {
            return new PermisoViewModel
            {
                Perm_Id = 2285,
                Role_Id = 124,
                AcPa_Id = 2,
                Usua_Creacion = 1,
                Perm_FechaCreacion = DateTime.Now,
                Usua_Modificacion = 1,
                Perm_FechaModificacion = DateTime.Now,
            };
        }

        public static PermisoViewModel CrearMockPermisoEliminar()
        {
            return new PermisoViewModel
            {
                Perm_Id = 2286
            };
        }

        public static PermisoViewModel CrearMockPermisoBuscar()
        {
            return new PermisoViewModel
            {
                Perm_Id = 2283,
            };
        }
    }
}
