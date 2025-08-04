using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.Logistica
{
    public class TrasladoDetalleViewModel
    {

        public int TrDe_Id { get; set; }

        public int Tras_Id { get; set; }

        public int Prod_Id { get; set; }

        public string Prod_Descripcion { get; set; }

        public string Prod_Imagen { get; set; }

        public int TrDe_Cantidad { get; set; }

        public string TrDe_Observaciones { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime TrDe_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? TrDe_FechaModificacion { get; set; }

    }
}
