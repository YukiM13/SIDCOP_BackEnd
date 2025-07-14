namespace Api_SIDCOP.API.Models.Acceso
{
    public class PermisoViewModel
    {
        public int Perm_Id { get; set; }

        public int Role_Id { get; set; }

        public int Pant_Id { get; set; }

        public int Acci_Id { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Perm_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Perm_FechaModificacion { get; set; }
    }
}
