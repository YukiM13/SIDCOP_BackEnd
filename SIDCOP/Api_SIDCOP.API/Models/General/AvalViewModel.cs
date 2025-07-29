namespace Api_SIDCOP.API.Models.General
{
    public class AvalViewModel
    {
        public int Aval_Id { get; set; }

        public int Clie_Id { get; set; }

        public string Aval_Nombres { get; set; }

        public string Aval_Apellidos { get; set; }

        public string Aval_Sexo { get; set; }

        public int? Pare_Id { get; set; }

        public string Aval_DNI { get; set; }

        public string Aval_Telefono { get; set; }

        public int TiVi_Id { get; set; }

        public string Aval_Observaciones { get; set; }

        public string Aval_DireccionExacta { get; set; }

        public int Colo_Id { get; set; }

        public DateTime? Aval_FechaNacimiento { get; set; }

        public int? EsCv_Id { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Aval_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Aval_FechaModificacion { get; set; }

        public bool Aval_Estado { get; set; }

    }
}
