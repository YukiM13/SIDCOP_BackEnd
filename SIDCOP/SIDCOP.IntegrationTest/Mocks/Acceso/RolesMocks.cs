using Api_SIDCOP.API.Models.Acceso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Mocks
{
    public class RolesMocks
    {
        public static RolViewModel CrearMockRolInsertar()
        {
            return new RolViewModel
            {
                Role_Descripcion = "Rol de Prueba",
                Usua_Creacion = 1,
                Role_FechaCreacion = DateTime.Now,
            };
        }

        public static RolViewModel CrearMockRolActualizar()
        {
            return new RolViewModel
            {
                Role_Id = 1,
                Role_Descripcion = "Admin",
                Usua_Creacion = 1,
                Role_FechaCreacion = DateTime.Now,
                Usua_Modificacion = 1,
                Role_FechaModificacion = DateTime.Now,
            };
        }

        public static RolViewModel CrearMockRolBuscar()
        {
            return new RolViewModel
            {
                Role_Id = 1
            };
        }

        public static RolViewModel CrearMockRolEliminar()
        {
            return new RolViewModel
            {
                Role_Id = 124
            };
        }

        public static RolViewModel CrearMockRolInvalidos()
        {
            return new RolViewModel
            {
                Role_Descripcion = "",
                Usua_Creacion = -1,
                Role_FechaCreacion = DateTime.Now.AddYears(10),
                Role_Estado = false
            };
        }

        public static RolViewModel CrearMockRolValoresExtremos()
        {
            return new RolViewModel
            {
                Role_Descripcion = "asdjlkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkewriiojoasidfosdfhnslkdf",
                Usua_Creacion = 9999,
                Role_FechaCreacion = DateTime.MinValue,
                Role_Estado = true
            };
        }
    }
}
