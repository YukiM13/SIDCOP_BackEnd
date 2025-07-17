using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.General
{
    public class ModeloViewModel
    {

        public int Mode_Id { get; set; }

        public int MaVe_Id { get; set; }
        public string MaVe_Marca { get; set; }

        public string Mode_Descripcion { get; set; }

        public int Usua_Creacion { get; set; }
        public string UsuarioCreacion { get; set; }

        public string UsuarioModificacion { get; set; }
        public DateTime Mode_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public int? Secuencia { get; set; }

        public DateTime? Mode_FechaModificacion { get; set; }

        public bool Mode_Estado { get; set; }

    }
}
