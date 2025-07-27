namespace Api_SIDCOP.API.Models.General
{
    public class ParentescoViewModel
    {
        public int Pare_Id { get; set; }

        public string Pare_Descripcion { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Pare_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Pare_FechaModificacion { get; set; }
    }
}
