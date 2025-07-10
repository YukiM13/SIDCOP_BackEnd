namespace Api_SIDCOP.API.Models.General
{
    public class MarcaViewModel
    {
        public int Marc_Id { get; set; }

        public string Marc_Descripcion { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Marc_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Marc_FechaModificacion { get; set; }

        public bool Marc_Estado { get; set; }


    }
}
