using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.Acceso
{
    public class MunicipioViewModel
    {
        public string Muni_Codigo { get; set; }

        public string Muni_Descripcion { get; set; }

        public string Depa_Codigo { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Muni_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Muni_FechaModificacion { get; set; }

        public int? Secuencia { get; set; }

        public string? Depa_Descripcion { get; set; }
    }
}
