using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.Inventario
{
    public class DescuentoDetalleViewModel
    {
        public int DesD_Id { get; set; }

        public int Desc_Id { get; set; }

        public int DesD_IdReferencia { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime DesD_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? DesD_FechaModificacion { get; set; }

        public bool DesD_Estado { get; set; }

        public List<int> IdReferencias { get; set; }
    }
}
