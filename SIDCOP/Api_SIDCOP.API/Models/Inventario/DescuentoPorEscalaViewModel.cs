using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.Inventario
{
    public class DescuentoPorEscalaViewModel
    {
        public int DeEs_Id { get; set; }

        public int Desc_Id { get; set; }

        public int DeEs_InicioEscala { get; set; }

        public int DeEs_FinEscala { get; set; }

        public decimal DeEs_Valor { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime DeEs_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? DeEs_FechaModificacion { get; set; }

        public bool DeEs_Estado { get; set; }

      
        public string? Escala_JSON { get; set; }
       
        public List<EscalaDetalleViewModel> Escalas { get; set; }
    }

    public class EscalaDetalleViewModel
    {
        public int deEs_InicioEscala { get; set; }
        public int deEs_FinEscala { get; set; }
        public decimal deEs_Valor { get; set; }
    }
}
