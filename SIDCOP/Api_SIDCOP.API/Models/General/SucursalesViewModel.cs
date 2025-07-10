namespace Api_SIDCOP.API.Models.General
{
    public class SucursalesViewModel
    {
        public int Sucu_Id { get; set; }

        public string Sucu_Descripcion { get; set; }

        public int Colo_Id { get; set; }

        public string Sucu_DireccionExacta { get; set; }

        public string Sucu_Telefono1 { get; set; }

        public string Sucu_Telefono2 { get; set; }

        public string Sucu_Correo { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Sucu_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Sucu_FechaModificacion { get; set; }

        public bool Sucu_Estado { get; set; }
    }
}
