using SIDCOP_Backend.Entities.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.General
{
    public class CuentasPorCobrarViewModel
    {
        public int CPCo_Id { get; set; }

        public int Clie_Id { get; set; }

        public int Fact_Id { get; set; }

        public DateOnly CPCo_FechaEmision { get; set; }

        public DateOnly? CPCo_FechaVencimiento { get; set; }

        public decimal CPCo_Valor { get; set; }

        public decimal CPCo_Saldo { get; set; }

        public string CPCo_Observaciones { get; set; }

        public bool? CPCo_Anulado { get; set; }

        public bool? CPCo_Saldada { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime CPCo_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? CPCo_FechaModificacion { get; set; }

        public bool CPCo_Estado { get; set; }

        [NotMapped]
        public string Clie_Codigo { get; set; }
        [NotMapped]
        public string Clie_Nombres { get; set; }
        [NotMapped]
        public string Clie_Apellidos { get; set; }
        [NotMapped]
        public string Clie_NombreNegocio { get; set; }
        [NotMapped]
        public string Clie_Telefono { get; set; }
        [NotMapped]
        public string Clie_LimiteCredito { get; set; }
        [NotMapped]
        public string Clie_Saldo { get; set; }
        [NotMapped]
        public string UsuarioCreacion { get; set; }
        [NotMapped]
        public string UsuarioModificacion { get; set; }
    }
}
