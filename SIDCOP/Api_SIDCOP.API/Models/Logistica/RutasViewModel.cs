namespace Api_SIDCOP.API.Models.Logistica
{
    public class RutasViewModel
    {
        public int? Secuencia { get; set; }

        public int Ruta_Id { get; set; }

        public string Ruta_Codigo { get; set; }

        public string Ruta_Descripcion { get; set; }

        public string Ruta_Observaciones { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Ruta_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Ruta_FechaModificacion { get; set; }

        public bool Ruta_Estado { get; set; }

    }
}
