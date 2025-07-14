using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Models.Venta
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

        public int Colo_Id { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime CoFa_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? CoFa_FechaModificacion { get; set; }


    }
}
