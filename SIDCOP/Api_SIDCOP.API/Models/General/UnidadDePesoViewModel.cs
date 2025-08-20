using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.General
{
    public class UnidadDePesoViewModel
    {

        public int UnPe_Id { get; set; }
        public string Secuencia { get; set; }
        public string UnPe_Descripcion { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime UnPe_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        [NotMapped]
        public string UsuarioCreacion { get; set; }
        [NotMapped]
        public string UsuarioModificacion { get; set; }


        public DateTime? UnPe_FechaModificacion { get; set; }


    }
}
