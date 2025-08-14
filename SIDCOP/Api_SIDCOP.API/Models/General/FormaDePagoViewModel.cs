using System.ComponentModel.DataAnnotations.Schema;


namespace Api_SIDCOP.API.Models.General
{
    public class FormaDePagoViewModel
    {
        public int FoPa_Id { get; set; }

        public string FoPa_Descripcion { get; set; }

        public int? Usua_Creacion { get; set; }

        public string UsuaCreacion { get; set; }

        public int Secuencia { get; set; }

        public DateTime? FoPa_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public string UsuaModificacion { get; set; }

        public DateTime? FoPa_FechaModificacion { get; set; }

    }
}
