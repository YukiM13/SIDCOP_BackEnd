using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.General
{
    public class ClientesVisitaHistorialViewModel
    {
        public int ClVi_Id { get; set; }

        public int? VeRu_Id { get; set; }

        public int? DiCl_Id { get; set; }

        public int? EsVi_Id { get; set; }

        public string ClVi_Observaciones { get; set; }

        public DateTime? ClVi_Fecha { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime ClVi_FechaCreacion { get; set; }


        [NotMapped]
        public string? Veru_Dias { get; set; }


        [NotMapped]
        public string? Cliente { get; set; }

        [NotMapped]
        public string? Clie_NombreNegocio { get; set; }

        [NotMapped]
        public string? DiCl_Latitud { get; set; }

        [NotMapped]
        public string DiCl_Longitud { get; set; }

        [NotMapped]
        public string? EsV_Descripcion { get; set; }

        [NotMapped]
        public string? vend_Nombres { get; set; }

        [NotMapped]
        public string? vend_Apellidos { get; set; }

        [NotMapped]
        public int? ruta_Id { get; set; }

        [NotMapped]
        public string? ruta_Codigo { get; set; }

        [NotMapped]
        public string? ruta_Descripcion { get; set; }

        [NotMapped]
        public string? veru_Descripcion { get; set; }

        [NotMapped]
        public int? Secuencia { get; set; }
    }
}
