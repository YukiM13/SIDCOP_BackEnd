namespace Api_SIDCOP.API.Models.General
{
    public class DireccionesPorClienteViewModel
    {
        public int DiCl_Id { get; set; }

        public int Clie_Id { get; set; }

        public int Colo_Id { get; set; }

        public string DiCl_DireccionExacta { get; set; }

        public string DiCl_Observaciones { get; set; }

        public decimal DiCl_Latitud { get; set; }

        public decimal DiCl_Longitud { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime DiCl_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? DiCl_FechaModificacion { get; set; }
    }
}
