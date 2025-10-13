using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.Logistica
{
    public class TrasladoViewModel
    {
        public int Tras_Id { get; set; }

        public int Tras_Origen { get; set; }

        public string Origen { get; set; }

        public int Tras_Destino { get; set; }

        public string Destino { get; set; }

        public DateTime Tras_Fecha { get; set; }

        public string Tras_Observaciones { get; set; }

        public bool? Tras_EsRecarga { get; set; }

        public int? Reca_Id { get; set; }

        public int Usua_Creacion { get; set; }

        public string UsuaCreacion { get; set; }

        public DateTime Tras_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public string? UsuaModificacion { get; set; }

        public DateTime? Tras_FechaModificacion { get; set; }

        public bool Tras_Estado { get; set; }

    }
}
