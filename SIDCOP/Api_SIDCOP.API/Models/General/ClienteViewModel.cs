namespace Api_SIDCOP.API.Models.General
{
    public class ClienteViewModel
    {
        public int Clie_Id { get; set; }

        public string Clie_Codigo { get; set; }

        public string Clie_Nacionalidad { get; set; }

        public string Clie_DNI { get; set; }

        public string Clie_RTN { get; set; }

        public string Clie_Nombres { get; set; }

        public string Clie_Apellidos { get; set; }

        public string Clie_NombreNegocio { get; set; }

        public string Clie_ImagenDelNegocio { get; set; }

        //public string Clie_DireccionExacta { get; set; }

        public string Clie_Telefono { get; set; }

        public string Clie_Correo { get; set; }

        public string Clie_Sexo { get; set; }

        public DateTime? Clie_FechaNacimiento { get; set; }

        public int? TiVi_Id { get; set; }

        public int Cana_Id { get; set; }

        //public int Colo_Id { get; set; }

        public int? EsCv_Id { get; set; }

        //public decimal Clie_Latitud { get; set; }

        //public decimal Clie_Longitud { get; set; }

        public int? Ruta_Id { get; set; }

        public decimal? Clie_LimiteCredito { get; set; }

        public int? Clie_DiasCredito { get; set; }

        public decimal? Clie_Saldo { get; set; }

        public bool? Clie_Vencido { get; set; }

        public string Clie_Observaciones { get; set; }

        public string Clie_ObservacionRetiro { get; set; }

        public bool? Clie_Confirmacion { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Clie_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Clie_FechaModificacion { get; set; }

        public bool Clie_Estado { get; set; }

        public string? UsuaC_Nombre { get; set; }
        public string? UsuaM_Nombre { get; set; }

        public string? TiVi_Descripcion { get; set; }
        public string? Cana_Descripcion { get; set; }
        public string? EsCv_Descripcion { get; set; }
        public string? Ruta_Descripcion { get; set; }

        public string? Pais_Descripcion { get; set; }
    }
}
