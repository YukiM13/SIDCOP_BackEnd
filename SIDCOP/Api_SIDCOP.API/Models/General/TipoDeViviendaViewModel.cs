namespace Api_SIDCOP.API.Models.General
{
    public class TipoDeViviendaViewModel
    {
        public int TiVi_Id { get; set; }

        public string TiVi_Descripcion { get; set; }

        public string TiVi_Observaciones { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime TiVi_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? TiVi_FechaModificacion { get; set; }

        public bool TiVi_Estado { get; set; }
    }
}
