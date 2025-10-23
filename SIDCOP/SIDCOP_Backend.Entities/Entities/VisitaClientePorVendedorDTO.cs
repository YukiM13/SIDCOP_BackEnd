using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.Entities.Entities
{
    public class VisitaClientePorVendedorDTO
    {
        public int? ClVi_Id { get; set; }

        public int? DiCl_Id { get; set; }

        public decimal? DiCl_Latitud { get; set; }

        public decimal? DiCl_Longitud { get; set; }

        public int? Vend_Id { get; set; }

        public string? Vend_Codigo { get; set; }

        public string? Vend_DNI { get; set; }

        public string? Vend_Nombres { get; set; }

        public string? Vend_Apellidos { get; set; }

        public string? Vend_Telefono { get; set; }

        public int? Vend_Tipo { get; set; }

        public string? Vend_Imagen { get; set; }

        public int? Ruta_Id { get; set; }

        public string? Ruta_Descripcion { get; set; }

        public int? VeRu_Id { get; set; }

        public string? VeRu_Dias { get; set; }

        public int? Clie_Id { get; set; }

        public string? Clie_Codigo { get; set; }

        public string? Clie_Nombres { get; set; }       

        public string? Clie_Apellidos { get; set; }

        public string? Clie_NombreNegocio { get; set; }

        public string? ImVi_Imagen { get; set; }

        public string? Clie_Telefono { get; set; }
        public int? EsVi_Id { get; set; }
        public string? EsVi_Descripcion { get; set; }

        public string? ClVi_Observaciones { get; set; }

        public DateTime? ClVi_Fecha { get; set; }

        public int? Usua_Creacion { get; set; }

        public DateTime? ClVi_FechaCreacion { get; set; }
    }
}
