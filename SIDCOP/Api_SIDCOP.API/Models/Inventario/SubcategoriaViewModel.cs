using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.Inventario
{
    public class SubcategoriaViewModel
    {

        public int Subc_Id { get; set; }

        public string Subc_Descripcion { get; set; }

        public int Cate_Id { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Subc_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Subc_FechaModificacion { get; set; }

        public bool Subc_Estado { get; set; }

        public string UsuarioCreacion { get; set; }

        public string UsuarioModificacion { get; set; }

    }
}
