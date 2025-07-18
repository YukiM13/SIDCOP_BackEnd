using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Models.Ventas
{
    public class CaiSViewModel
    {
        public int NCai_Id { get; set; }

        public string NCai_Codigo { get; set; }

        public string NCai_Descripcion { get; set; }

        public int Usua_Creacion { get; set; }

        public int? Secuencia { get; set; }

        public string UsuarioCreacion { get; set; }

        public string UsuarioModificacion { get; set; }

        public DateTime NCai_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? NCai_FechaModificacion { get; set; }

        public bool NCai_Estado { get; set; }

        public string Estado { get; set; }

    }
}
