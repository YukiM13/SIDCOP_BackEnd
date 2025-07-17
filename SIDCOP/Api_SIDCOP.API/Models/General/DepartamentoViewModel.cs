using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.General
{
    public class DepartamentoViewModel
    {
        public string Depa_Codigo { get; set; }

        public string Depa_Descripcion { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Depa_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Depa_FechaModificacion { get; set; }

        public string UsuarioCreacion { get; set; }

        public string UsuarioModificacion { get; set; }

        public int? Secuencia { get; set; }
    }
}
