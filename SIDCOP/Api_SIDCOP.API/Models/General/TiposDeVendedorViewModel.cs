using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.General
{
    public class TiposDeVendedorViewModel
    {
        public int TiVe_Id { get; set; }

        public string TiVe_TipoVendedor { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime TiVe_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? TiVe_FechaModificacion { get; set; }

        [NotMapped]
        public string? Secuencia { get; set; }


        [NotMapped]
        public string? UsuarioCreacion { get; set; }

        [NotMapped]
        public string? UsuarioModificacion { get; set; }


    }
}
