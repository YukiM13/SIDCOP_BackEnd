using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.Inventario
{
    public class InventarioSucursalesViewModel
    {

        public int InSu_Id { get; set; }

        public int Sucu_Id { get; set; }

        public int Prod_Id { get; set; }

        public string? Sucu_Descripcion { get; set; }

        public string? Prod_Descripcion { get; set; }

        public int InSu_Cantidad { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime InSu_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? InSu_FechaModificacion { get; set; }

        public bool InSu_Estado { get; set; }

    }
}
