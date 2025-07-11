namespace Api_SIDCOP.API.Models.General
{
    public class CanalViewModel
    {
        public int Cana_Id { get; set; }

        public string Cana_Descripcion { get; set; }

        public string Cana_Observaciones { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Cana_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Cana_FechaModificacion { get; set; }

        public bool Cana_Estado { get; set; }

        public string UsuaC_Nombre { get; set; }

        public string UsuaM_Nombre { get; set; }
    }
}
