namespace Api_SIDCOP.API.Models.General
{
    public class CargoViewModel
    {
        public int Carg_Id { get; set; }

        public string Carg_Descripcion { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Carg_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Carg_FechaModificacion { get; set; }

        public bool Carg_Estado { get; set; }
    }
}
