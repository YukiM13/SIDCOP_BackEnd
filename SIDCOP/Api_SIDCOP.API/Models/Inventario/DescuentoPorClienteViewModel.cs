using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.Inventario
{
    public class DescuentoPorClienteViewModel
    {
        public int DeCl_Id { get; set; }

        public int Desc_Id { get; set; }

        public int Clie_Id { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime DeEs_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? DeEs_FechaModificacion { get; set; }

        public bool DeCl_Estado { get; set; }

        public List<int> IdClientes { get; set; }
    }
}
