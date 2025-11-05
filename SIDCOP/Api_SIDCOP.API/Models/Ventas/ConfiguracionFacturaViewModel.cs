using SIDCOP_Backend.Entities.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.Ventas
{
    public class ConfiguracionFacturaViewModel
    {
        public int CoFa_Id { get; set; }

        public string CoFa_NombreEmpresa { get; set; }

        public string CoFa_DireccionEmpresa { get; set; }

        public string CoFa_RTN { get; set; }

        public string CoFa_Correo { get; set; }

        public string CoFa_Telefono1 { get; set; }

        public string CoFa_Telefono2 { get; set; }

        public string CoFa_Logo { get; set; }

        public string CoFa_LogoZPL { get; set; }

        public int CoFa_DiasDevolucion { get; set; }

        public string CoFa_RutaMigracion { get; set; }

        public int Colo_Id { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime CoFa_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? CoFa_FechaModificacion { get; set; }

        public string? Colo_Descripcion { get; set; }

        public string? Muni_Codigo { get; set; }

        public string? Muni_Descripcion { get; set; }

        public string? Depa_Codigo { get; set; }

        public string? Depa_Descripcion { get; set; }

        public string? UsuarioCreacion { get; set; }

        public string? UsuarioModificacion { get; set; }

        public int? Secuencia { get; set; }


    }
}
