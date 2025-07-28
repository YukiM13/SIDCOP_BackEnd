using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.Venta
{
    public class PuntoEmisionViewModel
    {
        public int Secuencia { get; set; }

        public String Estado { get; set; }

        public int PuEm_Id { get; set; }

        public string PuEm_Codigo { get; set; }

        public string PuEm_Descripcion { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime PuEm_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? PuEm_FechaModificacion { get; set; }

        public bool PuEm_Estado { get; set; }

        public int? Sucu_Id { get; set; }

        public string Sucu_Descripcion { get; set; }

        public String UsuarioCreacion { get; set; }


        public String UsuarioModificacion { get; set; }
    }
}
