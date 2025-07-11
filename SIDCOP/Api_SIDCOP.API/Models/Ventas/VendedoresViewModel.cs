namespace Api_SIDCOP.API.Models.Ventas
{
    public class VendedoresViewModel
    {
        public int Vend_Id { get; set; }

        public string Vend_Codigo { get; set; }

        public string Vend_DNI { get; set; }

        public string Vend_Nombres { get; set; }

        public string Vend_Apellidos { get; set; }

        public string Vend_Telefono { get; set; }

        public string Vend_Correo { get; set; }

        public string Vend_Sexo { get; set; }

        public string Vend_DireccionExacta { get; set; }

        public int Sucu_Id { get; set; }

        public int Colo_Id { get; set; }

        public int? Vend_Supervisor { get; set; }

        public int? Vend_Ayudante { get; set; }

        public string Vend_Tipo { get; set; }

        public bool? Vend_EsExterno { get; set; }

        public bool Vend_Estado { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Vend_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Vend_FechaModificacion { get; set; }
    }
}
