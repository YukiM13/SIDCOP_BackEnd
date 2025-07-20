using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.Inventario
{
    public class CategoriaViewModel
    {

        public int Cate_Id { get; set; }

        public string Cate_Descripcion { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Cate_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Cate_FechaModificacion { get; set; }

        public bool Cate_Estado { get; set; }

        
        public string UsuarioCreacion { get; set; }

        
        public string UsuarioModificacion { get; set; }

    }
}
