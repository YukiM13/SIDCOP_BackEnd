using Api_SIDCOP.API.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Mocks.General
{
    public class EmpleadosMocks
    {
        public static EmpleadoViewModel CrearMockEmpleado()
        {
            return new EmpleadoViewModel
            {
                Empl_DNI = "402-1234567-8",
                Empl_Codigo = "EMP001",
                Empl_Nombres = "Juan",
                Empl_Apellidos = "Pérez González",
                Empl_Sexo = "M",
                Empl_FechaNacimiento = DateTime.Now.AddYears(-30),
                Empl_Correo = "juan.perez@empresa.com",
                Empl_Telefono = "809-555-1234",
                Sucu_Id = 1,
                EsCv_Id = 1,
                Carg_Id = 1,
                Colo_Id = 1,
                Empl_DireccionExacta = "Calle Principal #123, Santo Domingo",
                Empl_Imagen = "empleado1.jpg",
                Usua_Creacion = 1,
                Empl_FechaCreacion = DateTime.Now,
                Empl_Estado = true,
                // Campos descriptivos opcionales
                Sucu_Descripcion = "Sede Central",
                EsCv_Descripcion = "Activo",
                Carg_Descripcion = "Analista",
                Colo_Descripcion = "Santo Domingo",
                UsuarioCreacion = "Admin"
            };
        }

        public static EmpleadoViewModel CrearMockEmpleadoParaActualizar()
        {
            return new EmpleadoViewModel
            {
                Empl_Id = 1,
                Empl_DNI = "402-1234567-8",
                Empl_Codigo = "EMP001",
                Empl_Nombres = "Juan Carlos",
                Empl_Apellidos = "Pérez González",
                Empl_Sexo = "M",
                Empl_FechaNacimiento = DateTime.Now.AddYears(-30),
                Empl_Correo = "juancarlos.perez@empresa.com",
                Empl_Telefono = "809-555-5678",
                Sucu_Id = 2,
                EsCv_Id = 1,
                Carg_Id = 2,
                Colo_Id = 1,
                Empl_DireccionExacta = "Avenida Principal #456, Santo Domingo",
                Empl_Imagen = "empleado1_actualizado.jpg",
                Usua_Creacion = 1,
                Empl_FechaCreacion = DateTime.Now.AddYears(-1),
                Usua_Modificacion = 1,
                Empl_FechaModificacion = DateTime.Now,
                Empl_Estado = true,
                // Campos descriptivos opcionales actualizados
                Sucu_Descripcion = "Sucursal Este",
                EsCv_Descripcion = "Activo",
                Carg_Descripcion = "Supervisor",
                Colo_Descripcion = "Santo Domingo Este",
                UsuarioCreacion = "Admin",
                UsuarioModificacion = "Supervisor"
            };
        }

        public static EmpleadoViewModel CrearMockEmpleadoValoresExtremos()
        {
            return new EmpleadoViewModel
            {
                Empl_Id = int.MaxValue,
                Empl_DNI = new string('9', 50),
                Empl_Codigo = new string('E', 20),
                Empl_Nombres = new string('A', 255),
                Empl_Apellidos = new string('B', 255),
                Empl_Sexo = "X", // Valor no estándar para sexo
                Empl_FechaNacimiento = DateTime.MinValue,
                Empl_Correo = new string('d', 255) + "@" + new string('e', 255) + ".com",
                Empl_Telefono = new string('1', 50),
                Sucu_Id = int.MaxValue,
                EsCv_Id = int.MaxValue,
                Carg_Id = int.MaxValue,
                Colo_Id = int.MaxValue,
                Empl_DireccionExacta = new string('D', 1000),
                Empl_Imagen = new string('i', 500) + ".jpg",
                Usua_Creacion = int.MaxValue,
                Empl_FechaCreacion = DateTime.MaxValue,
                Usua_Modificacion = int.MaxValue,
                Empl_FechaModificacion = DateTime.MaxValue,
                Empl_Estado = true,
                // Campos descriptivos con valores extremos
                Sucu_Descripcion = new string('S', 500),
                EsCv_Descripcion = new string('E', 500),
                Carg_Descripcion = new string('C', 500),
                Colo_Descripcion = new string('L', 500),
                UsuarioCreacion = new string('U', 500),
                UsuarioModificacion = new string('M', 500),
                Usua_Imagen = new string('I', 500) + ".jpg"
            };
        }

        public static EmpleadoViewModel CrearMockEmpleadoInvalidos()
        {
            return new EmpleadoViewModel
            {
                Empl_Id = -1,
                Empl_DNI = "",
                Empl_Codigo = "",
                Empl_Nombres = "",
                Empl_Apellidos = null,
                Empl_Sexo = null,
                Empl_FechaNacimiento = DateTime.Now.AddYears(10),
                Empl_Correo = "correo.invalido",
                Empl_Telefono = "abc",
                Sucu_Id = -1,
                EsCv_Id = -1,
                Carg_Id = -1,
                Colo_Id = -1,
                Empl_DireccionExacta = "",
                Empl_Imagen = "archivo_no_existente.jpg",
                Usua_Creacion = -1,
                Empl_FechaCreacion = DateTime.Now.AddYears(5),
                Usua_Modificacion = -1,
                Empl_FechaModificacion = DateTime.Now.AddYears(5),
                Empl_Estado = false,
                // Campos descriptivos inválidos
                Sucu_Descripcion = "",
                EsCv_Descripcion = null,
                Carg_Descripcion = "",
                Colo_Descripcion = null,
                UsuarioCreacion = "",
                UsuarioModificacion = null,
                Usua_Imagen = "imagen_invalida"
            };
        }
    }
}