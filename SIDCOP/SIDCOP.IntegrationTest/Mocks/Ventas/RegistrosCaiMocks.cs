using Api_SIDCOP.API.Models.Ventas;
using System;

namespace SIDCOP.IntegrationTest.Mocks.Ventas
{
    internal class RegistrosCaiMocks
    {
        public static RegistrosCaiSViewModel MockRegistroCai()
        {
            return new RegistrosCaiSViewModel
            {
                RegC_Id = 1,
                RegC_Descripcion = "string",
                Sucu_Id = 0,
                PuEm_Id = 0,
                NCai_Id = 0,
                RegC_RangoInicial = "string",
                RegC_RangoFinal = "string",
                RegC_FechaInicialEmision = DateTime.Parse("2025-10-10T13:58:35.922Z"),
                RegC_FechaFinalEmision = DateTime.Parse("2025-10-10T13:58:35.922Z"),
                Usua_Creacion = 0,
                RegC_FechaCreacion = DateTime.Parse("2025-10-10T13:58:35.922Z"),
                Usua_Modificacion = 0,
                RegC_FechaModificacion = DateTime.Parse("2025-10-10T13:58:35.922Z"),
                RegC_Estado = true,
                Secuencia = 0,
                Estado = "string",
                UsuarioCreacion = "string",
                UsuarioModificacion = "string",
                Sucu_Descripcion = "string",
                PuEm_Descripcion = "string",
                NCai_Descripcion = "string",
                PuEm_Codigo = "string",
                NCai_Codigo = "string"
            };
        }
    }
}