namespace Api_SIDCOP.API.Models.Inventario
{
    public class InventarioBodegasViewModel
    {

        public int InBo_Id { get; set; }

        public int Bode_Id { get; set; }

        public int Prod_Id { get; set; }

        public int InBo_Cantidad { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime InBo_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? InBo_FechaModificacion { get; set; }

        public bool InBo_Estado { get; set; }
    }
}
