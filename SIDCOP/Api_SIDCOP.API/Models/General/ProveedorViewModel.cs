using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.General
{
    public class ProveedorViewModel
    {

        public int Prov_Id { get; set; }

        public string Prov_Codigo { get; set; }

        public string Prov_NombreEmpresa { get; set; }

        public string Prov_NombreContacto { get; set; }

        public int Colo_Id { get; set; }

        public string Prov_DireccionExacta { get; set; }

        public string Prov_Telefono { get; set; }

        public string Prov_Correo { get; set; }

        public string Prov_Observaciones { get; set; }

        public int Usua_Creacion { get; set; }

        [NotMapped]
        public string Colo_Descripcion { get; set; }
        [NotMapped]
        public string Muni_Descripcion { get; set; }

        [NotMapped]
        public string Depa_Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public bool Prov_Estado { get; set; }

    }
}
