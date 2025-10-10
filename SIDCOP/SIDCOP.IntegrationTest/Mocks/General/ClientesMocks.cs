using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api_SIDCOP.API.Models.Acceso;
using Api_SIDCOP.API.Models.General;


namespace SIDCOP.IntegrationTest.Mocks.General
{
    public class ClientesMocks
    {
        public static ClienteViewModel CrearMockClienteInsertar()
        {
            return new ClienteViewModel
            {
                Clie_Codigo = "CLI-121212",
                Clie_Nacionalidad = "HND",
                Clie_DNI = "221424124",
                Clie_RTN = "2214241241",
                Clie_Nombres = "Alex",
                Clie_Apellidos = "Ramirez",
                Clie_NombreNegocio = "AlexitoUwU",
                Clie_ImagenDelNegocio = "fewgfwegewg.com",
                Clie_Telefono = "24214124",
                Clie_Correo = "egrgrg@gmail.com",
                Clie_Sexo = "M",
                Clie_FechaNacimiento = null,
                TiVi_Id = 0,
                Cana_Id = 0,
                EsCv_Id = null,
                Ruta_Id = null,
                Clie_LimiteCredito = null,
                Clie_DiasCredito = null,
                Clie_Saldo = null,
                Clie_Vencido = null,
                Clie_Observaciones = "",
                Clie_ObservacionRetiro = "",
                Clie_Confirmacion = null,
                Usua_Creacion = 1,
                Clie_FechaCreacion = DateTime.Now
            };
        }
    }
}
