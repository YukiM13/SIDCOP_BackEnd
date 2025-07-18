using SIDCOP_Backend.Entities.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.Logistica
{
    public class BodegaViewModel
    {
        public int Bode_Id { get; set; }

        public string Bode_Descripcion { get; set; }

        public int Sucu_Id { get; set; }

        public int RegC_Id { get; set; }

        public int Vend_Id { get; set; }

        public int Mode_Id { get; set; }

        public string Bode_VIN { get; set; }

        public string Bode_Placa { get; set; }

        public decimal Bode_Capacidad { get; set; }

        public string Bode_TipoCamion { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Bode_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }
        public int? Secuencia { get; set; }

        public DateTime? Bode_FechaModificacion { get; set; }

        public string? Sucu_Descripcion { get; set; }

        public string? RegC_Descripcion { get; set; }

        public string? Vend_Nombres { get; set; }

        public string? Vend_Apellidos { get; set; }

        public string? Mode_Descripcion { get; set; }

        public string? UsuarioCreacion { get; set; }

        public string? UsuarioModificacion { get; set; }
    }
}
