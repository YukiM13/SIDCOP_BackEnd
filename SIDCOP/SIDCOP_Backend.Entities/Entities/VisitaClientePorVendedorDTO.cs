using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.Entities.Entities
{
    public class VisitaClientePorVendedorDTO
    {
        public int HCVi_Id { get; set; }

        public int? Vend_Id { get; set; }

        public string Vend_Codigo { get; set; }

        public string Vend_DNI { get; set; }

        public string Vend_Nombres { get; set; }

        public string Vend_Apellidos { get; set; }

        public string Vend_Telefono { get; set; }

        public string Vend_Tipo { get; set; }

        public int? VeRu_Id { get; set; }

        public string VeRu_Dias { get; set; }

        public int? Clie_Id { get; set; }

        public string Clie_Codigo { get; set; }

        public string Clie_Nombres { get; set; }       

        public string Clie_Apellidos { get; set; }

        public string Clie_NombreNegocio { get; set; }

        public string Clie_Telefono { get; set; }

        public string HCVi_Foto { get; set; }

        public string HCVi_Observaciones { get; set; }

        public DateTime? HCVi_Fecha { get; set; }

        public decimal? HCVi_Latitud { get; set; }

        public decimal? HCVi_Longitud { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime HCVi_FechaCreacion { get; set; }
    }
}
