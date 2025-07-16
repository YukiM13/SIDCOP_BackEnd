using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.General
{
    public class ColoniaViewModel
    {
        public int Colo_Id { get; set; }

        public string Colo_Descripcion { get; set; }

        public string Muni_Codigo { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Colo_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Colo_FechaModificacion { get; set; }

        public int? Secuencia { get; set; }

        public int? Muni_Descripción { get; set; }

        public int? Depa_Codigo { get; set; }

        public int? Depa_Descripción { get; set; }
    }
}
