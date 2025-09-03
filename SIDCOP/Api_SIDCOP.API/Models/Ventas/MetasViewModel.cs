namespace Api_SIDCOP.API.Models.Ventas
{
    public class MetasViewModel

    {

        public int Meta_Id { get; set; }

        public string Meta_Descripcion { get; set; }

        public DateTime Meta_FechaInicio { get; set; }

        public DateTime Meta_FechaFin { get; set; }

        public string Meta_Tipo { get; set; }

        public decimal? Meta_Ingresos { get; set; }

        public int? Meta_Unidades { get; set; }

        public int? Prod_Id { get; set; }

        public int? Cate_Id { get; set; }

        public bool Meta_Estado { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Meta_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Meta_FechaModificacion { get; set; }

        public string? VendedoresXml { get; set; }
        
        public string? VendedoresJson { get; set; }

        public string? DetallesXml { get; set; }

    }
}
