using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.General
{
    public class MarcaVehiculoViewModel
    {
        public int MaVe_Id { get; set; }

        public string MaVe_Marca { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime MaVe_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? MaVe_FechaModificacion { get; set; }

        public bool MaVe_Estado { get; set; }

    
        public string UsuarioCreacion { get; set; }

    
        public string UsuarioModificacion { get; set; }
    }
}
