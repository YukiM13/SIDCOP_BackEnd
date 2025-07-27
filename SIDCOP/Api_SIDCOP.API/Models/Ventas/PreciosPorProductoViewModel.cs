using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.Ventas
{
    public class PreciosPorProductoViewModel
    {
        public int PreP_Id { get; set; }

        public int Prod_Id { get; set; }

        public int Clie_Id { get; set; }

        public decimal PreP_PrecioContado { get; set; }

        public decimal PreP_PrecioCredito { get; set; }

        public int PreP_InicioEscala { get; set; }

        public int PreP_FinEscala { get; set; }

        public int PreP_ListaPrecios { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime PreP_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? PreP_FechaModificacion { get; set; }

        public bool? PreP_Estado { get; set; }

        [NotMapped]
        public int? Cana_Id { get; set; }

        [NotMapped]
        public string? ClientesXml { get; set; }

        [NotMapped]
        public string? Clie_Nombres { get; set; }

        [NotMapped]
        public string? Clie_Apellidos { get; set; }

        [NotMapped]
        public string? Clie_NombreNegocio { get; set; }

        [NotMapped]
        public string? UsuarioCreacion { get; set; }

        [NotMapped]
        public string? UsuarioModificacion { get; set; }

    }
}
