using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.General
{
    public class ClientesVisitaHistorialViewModel
    {
        public int HCVi_Id { get; set; }

        public int? VeRu_Id { get; set; }

        public int? Clie_Id { get; set; }

        public string HCVi_Foto { get; set; }

        public string HCVi_Observaciones { get; set; }

        public DateTime? HCVi_Fecha { get; set; }

        public decimal? HCVi_Latitud { get; set; }

        public decimal? HCVi_Longitud { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime HCVi_FechaCreacion { get; set; }


        [NotMapped]
        public string Veru_Dias { get; set; }


        [NotMapped]
        public string Cliente { get; set; }

        [NotMapped]
        public string Clie_NombreNegocio { get; set; }

        [NotMapped]
        public int? Secuencia { get; set; }
    }
}
